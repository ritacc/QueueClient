using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QClient.HD;
using QClient.QueueClinetServiceReference;
using QClient.Core.Uitl.Logger;
using System.Threading;

namespace QClient.Core.ViewModel
{
	public class DeviceCheckHead
	{
		private static readonly DeviceCheckHead _instance = new DeviceCheckHead();
		public static DeviceCheckHead Instance { get { return _instance; } }

		public List<WindowOR> listWin { get; set; }
		public ControllerSoapClient GetHDClient()
		{
			return new ControllerSoapClient();
		}

		public QueueClientSoapClient GetQueueClient()
		{
			return new QueueClientSoapClient();
		}

		public List<DeviceOR> DeviceList { get; set; }
		public void HDMain()
		{
            DeviceList = new List<DeviceOR>();
            var client = DeviceCheckHead.Instance.GetQueueClient();

            DeviceOR[] devices = client.GetAllDevices();
            foreach (var obj in devices)
            {
                DeviceList.Add(obj);
            }

			WindowOR[] ArrWin = client.SelectAllWindow();
			listWin = new List<WindowOR>();
			if (ArrWin != null && ArrWin.Length > 0)
			{
				foreach (WindowOR _win in ArrWin)
				{
					listWin.Add(_win);
				}
			}

			//开线程处理，评价器的消息
			foreach (WindowOR obj in listWin)
			{
				PJQHead pjq = new PJQHead();
				pjq.Window = obj;
				Thread th = new Thread(pjq.CheckMsg);
				th.Start();
			}

			if(listWin.Count==0)
			{
                ErrorLog.WriteLog("DeviceCheckHead#listWin.Count", "没有定义窗口。");
			}

            //处理设备状态
            Thread thStatus = new Thread(DeviceStatusHead);
            thStatus.Start();

			Thread thInit = new Thread(InitDevice);
            thInit.Start();

		}

		private void InitDevice()
		{
			foreach (WindowOR win in listWin)
			{
				//win.tpAddress
                Thread.Sleep(2000);
			}
		}

        #region 设备状态更新
        private const int StatusCheckTimeLen = 1 * 10 * 60 * 1000;
        public void DeviceStatusHead()
        {
            do
            {
                foreach (DeviceOR obj in DeviceList)
                {
                    try
                    {
                        int iStatus = 1;
                        string Result = GetHDClient().GetDeviceStatus(SysConverHDType(obj.Devicetypeid), obj.Address, 0, 0, 10);
                        if (Result != "0")
                            iStatus = 0;
                        this.GetQueueClient().UpdateDeviceSatus(obj.Id, iStatus);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.WriteLog("DeviceCheckHead#DeviceStatusHead", ex.Message);
                    }
                }
                Thread.Sleep(StatusCheckTimeLen);
                ErrorLog.WriteTestLog("DeviceStatusHead", "");
            } while (true);
        }
        #endregion

        public static int SysConverHDType(int type)
        {
            switch (type)
            {
                case DeviceType.DeviceType_PJQ:
                    return 4;
                case DeviceType.DeviceType_FJQ:
                    return 1;
                case DeviceType.DeviceType_TP:
                    return 2;
            }
            return -1;
        }
	}

	public class PJQHead
	{
		//public string Address { get; set; }
		private int _SleapLen = 900;
		private int _TimeOut = 10;//读取消息超时，时间

		private string _NowBillNo = string.Empty;
        		
        /// <summary>
        /// 窗口、加相关的地址信息
        /// </summary>
        public WindowOR Window { get; set; }

		/// <summary>
		/// 当前用户ID
		/// </summary>
		private string UserID = string.Empty;

		/// <summary>
		/// 读取msg间隔时间
		/// </summary>
		public int SleapLen
		{
			get {return _SleapLen;}
			set
			{
				if (_SleapLen < 500)
					_SleapLen = 500;
			}
		}

		/// <summary>
		/// 登录状态  1未登录,2登录中(输入了用户名),3登录成功。
		/// </summary>
		public int loginStatus { get; set; }

        /// <summary>
        /// 是否工作
        /// </summary>
        protected bool isWork = false;

		public void CheckMsg()
		{
			try
			{
                ErrorLog.WriteTestLog("***************CheckMsg:开始执行：****************************", Window.Name);
				do
				{
					Thread.Sleep(_SleapLen);
					try
					{
						string Msg = DeviceCheckHead.Instance.GetHDClient().GetDeviceMSG(
                            DeviceType.DeviceType_FJQ, Window.fjqAddress, _TimeOut);

                        ErrorLog.WriteTestLog("#CheckMsg#", Msg);
						if (!string.IsNullOrEmpty(Msg))
						{
							MsgDo(Msg);
						}
					}
					catch (Exception ex)
					{
						ErrorLog.WriteLog("PJQHead#Msg", ex.Message);
					}
                    
				} while (true);
			}
			catch (Exception ex)
			{
				ErrorLog.WriteLog("PJQHead#CheckMsg", ex.Message);
			}
		}

		protected void MsgDo(string Msg)
		{
			//011|CALLER_SPECIAL|7
			if (string.IsNullOrEmpty(Msg))
				return;
			if (Msg.IndexOf('|') <= 0)
				return;
			string[] msgArr = Msg.Split('|');
			if (msgArr.Length < 3)
			{
				ErrorLog.WriteLog("PJQHead#ErrorMsg", Msg);
				return;
			}
			switch (msgArr[1])
			{
				case "CALLER_LOGIN":
					Login(msgArr[2]);
					break;
				case "CALLER_NEXT":
                    if (isWork)
                    {
                        CallGetNext();
                    }
					break;
				case "CALLER_RECALL"://重新呼叫
                    if (isWork)
                    {
                        CallReCall();
                    }
					break;
				case "CALLER_PAUSE"://暂停服务
                    if (isWork)
                    {
                        CallPause();
                    }
					break;
                case "CALLER_RESUME_SERVICE"://恢复服务
                    CallRestart();
                    break;
                case "CALLER_TRANSFER"://目标柜台号
                    if (isWork)
                    {
                        CallTransfer(msgArr[2]);
                    }
                    break;
                case "CALLER_TRANSFER2"://目标业务队列   /******zcs: 当前没有实现*****/
                    break;
                case "CALLER_SEARCH"://查询未受理客户数
                    break;
                case "CALLER_OUT"://柜员退出
                    StopServer();
                    break;
                case "CALLER_APPOINT"://叫指定号码，号码由柜员按键输入
                    break;
                case "CALLER_START"://服务开始
                    break;
                case "CALLER_CLOSE"://服务结束
                    StopServer();
                    break;
                case "CALLER_SPECIAL"://特呼编号（数字）
                    if (isWork)
                    {
                        Specall("客户", msgArr[2]);
                    }
                    break;
                case "CALLER_DELAY"://当前办理号码延迟办理，号码再次进入排队队列
                    if (isWork)
                    {
                        CallDelay(msgArr[2]);
                    }
                    break;
                case "EVA_MSG"://1：好2：中3：差4： 未评价
                    if (isWork)
                    {
                        PJ(msgArr[2]);
                    }
                    break;
			}
		}


        /// <summary>
        /// 转移
        /// </summary>
        private void CallTransfer(string windowNumber)
        {
                string msg = GetCall("TRANSFER", string.Format("{0}##{1}", _NowBillNo, windowNumber));
                if (msg == "0")
                {
                    
                    _NowBillNo = "";
                }
                else
                {
                    ShowErrorMsg(msg);
                }
            
        }

        /// <summary>
        /// 延后
        /// </summary>
        /// <param name="DelayNumber">延后分钟</param>
        private void CallDelay(string DelayNumber)
        {
            string msg = GetCall("DELAY", string.Format("{0}##{1}", _NowBillNo, DelayNumber));
            if (msg == "0")
            {
                _NowBillNo = "";
            }
            else
            {
                ShowErrorMsg(msg);
            }
        }

		public void Login(string data)
		{
			if (loginStatus == 1)
			{
				UserID = data;
				//记录柜员号
				loginStatus = 2;
				DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(6, Window.fjqAddress
					, "m1", "", 0, ""
					, 0, 0, 0, 0
					, "请输入密码：");
			}
			else if (loginStatus == 2)
			{
				string password = data;

				string loginmsg = DeviceCheckHead.Instance.GetQueueClient().getLogin(UserID, password, Window.Name);
				if (loginmsg != "0")//失败
				{
					DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(2, Window.fjqAddress
					, "m1", "", 0, ""
					, 1	//login：登录是否成功，showtype为2时有效。0（成功），1（失败）
					, 0, 0, 0, "");
					loginStatus = 1;
					UserID = "";

                    isWork = false;
				}
				else//成功
				{
					DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(2, Window.fjqAddress
						, "m1", "", 0, ""
						, 0	//login：登录是否成功，showtype为2时有效。0（成功），1（失败）
						, 0, 0, 0, "");
					loginStatus = 3;
                    isWork = true;
				}
			}
		}

		/// <summary>
		/// 结束服务
		/// </summary>
		private void StopServer()
		{
			if (loginStatus == 1)
			{
				DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(3, Window.fjqAddress
					, "m1", "", 0, ""
					, 0
					, 1		//logout：登出是否成功，showtype为3时有效。0（成功），1（失败）
					, 0, 0, "");
			}
			string msg = DeviceCheckHead.Instance.GetQueueClient().endService(UserID, Window.Name);
			if (msg == "0")
			{
				DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(3, Window.fjqAddress
					, "m1", "", 0, ""
					, 0
					, 0		//logout：登出是否成功，showtype为3时有效。0（成功），1（失败）
					, 0, 0, "");
			}
			else
			{
				DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(6, Window.fjqAddress
					, "m1", "", 0, ""
					, 0, 0, 0, 0
					, msg);
				//ShowErrorMsg(msg);
			}
		}

       
		public void CALLER_SPECIAL(string Number)
		{
			switch (Number)
			{
				case "1"://大堂经理
                    Specall("大堂经理", _NowBillNo);
					break;
				case "2"://业务顾问
                    Specall("业务顾问", _NowBillNo);
					break;
				case "3"://保安
                    Specall("保安", _NowBillNo);
					break;
				case "4"://	您好，欢迎光临
					SPECIAL_PJQ(1);
					break;
				case "5"://请评价
                    PreBillNo = _NowBillNo;
                    _NowBillNo = "";
					SPECIAL_PJQ(2);
					break;
				case "6"://谢谢，再见        =>评介器直接评价?
					break;
				case "7"://一米线
					SPECIAL_PJQ(3);
					break;
			}
		}

        private void Specall(string CallType,string mBillNo)
        {
            string msg = GetCall("SPECALL", string.Format("{0}##{1}##{2}",
                    Window.Name, CallType, mBillNo));
            if (msg == "0")
            {
                if (CallType == "客户")
                {
                    _NowBillNo = mBillNo;
                }
            }
            else
            {
                ShowErrorMsg(msg);
            }
        }

        /// <summary>
        /// 上一个排队号码
        /// </summary>
        private string PreBillNo { get; set; }
        private void PJ(string pjVal)
        {
            if (string.IsNullOrEmpty(PreBillNo))
                return;
            int pjS=0;

            if (int.TryParse(pjVal, out pjS))
            {
                DeviceCheckHead.Instance.GetQueueClient().UpdatePJ(PreBillNo, pjS);
            }
            else
            {
                ErrorLog.WriteLog("PJQHead#PJ", pjVal);
            }
            PreBillNo = "";
        }


		/// <summary>
		/// 评价器，特呼
		/// </summary>
		public void SPECIAL_PJQ(int playType)
		{
		  string val=	DeviceCheckHead.Instance.GetHDClient().PlayEvaluateSound(playType, Window.pjqAddress);
		  if (val != "0")
			  ShowErrorMsg(val);
		}

		#region 公共函数
		private void ShowErrorMsg(string msg)
		{
			//MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);
			DeviceCheckHead.Instance.GetHDClient().ShowCallerMSG(6, Window.fjqAddress
					, "m1", "", 0, ""
					, 0, 0, 0, 0
					, msg);
		}
		private int GetTimeLen(DateTime Start, DateTime EndTime)
		{
			int TimeLen = 0;
			TimeSpan t = EndTime - Start;
			TimeLen = (t.Hours * 60 * 60) + t.Minutes * 60 + t.Seconds;
			return TimeLen;
		}
		#endregion

		#region Werservice接口

		#region 呼叫
		protected int Calllimittime = 5;

		DateTime lastCallTime = DateTime.Now;
		/// <summary>
		/// 呼叫下一位	CALL	空串
		/// </summary>
		private void CallGetNext()
		{
			int TimeLen = GetTimeLen(lastCallTime, DateTime.Now);
			if (TimeLen < Calllimittime && Calllimittime > 0)
			{
				ShowErrorMsg(string.Format("叫号时间间隔不能小于：{0}秒。", Calllimittime));
				return;
			}
			string value = GetCall("CALL", Window.Name);
			if (value.IndexOf("error:") >= 0)
			{
				ShowErrorMsg(value);
				return;
			}
			else
			{
				lastCallTime = DateTime.Now;
				_NowBillNo = value;
			}
		}

		/// <summary>
		/// 重呼
		/// </summary>
		private void CallReCall()
		{
			if (string.IsNullOrEmpty(_NowBillNo))
			{
				ShowErrorMsg("请叫号：");
				return;
			}
			string value = GetCall("RECALL", _NowBillNo);
			if (value != "0")
			{
				ShowErrorMsg(value);
			}
		}
		#endregion

		
		 /// <summary>
        /// 暂停
        /// </summary>
		private void CallPause()
		{
            string value = GetCall("PAUSE", Window.Name);
			if (value != "0")
			{
                isWork = false;
				ShowErrorMsg(value);
				return;
			}
		}

		
		 /// <summary>
        /// 恢复
        /// </summary>
		private void CallRestart()
		{
            if (loginStatus != 3)
            {
                ShowErrorMsg("未登录：");
                return;
            }
			string value = GetCall("RESTART", Window.Name);
			if (value != "0")
			{
				ShowErrorMsg(value);
                return;
			}
            isWork = true;
		}

		/// <summary>
		/// 调用呼号接口
		/// </summary>
		/// <param name="mType"></param>
		/// <param name="mParameter"></param>
		/// <returns></returns>
		private string GetCall(string mType, string mParameter)
		{
			using (var client = DeviceCheckHead.Instance.GetQueueClient())
			{
				string value = client.getCall(mType, mParameter);
				return value;
			}
		}
		
		#endregion
	}


	public class DeviceType
	{
		public const int DeviceType_FJQ = 1;
		public const int DeviceType_TP = 2;
		public const int DeviceType_PJQ = 3;
		public const int DeviceType_ZP = 4;
	}
	 
}
