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
			                
            WindowOR[] listWin =client.SelectAllWindow();
            			
            if (listWin != null && listWin.Length > 0)
			{
                //开线程处理，评价器的消息
                foreach (WindowOR obj in listWin)
				{
                    PJQHead pjq = new PJQHead();
                    pjq.Window = obj;
                    Thread th = new Thread(pjq.CheckMsg);
                    th.Start();
				}
			}
			else
			{
                ErrorLog.WriteLog("DeviceCheckHead#listWin.Count", "没有定义窗口。");
			}

            //处理设备状态
            Thread thStatus = new Thread(DeviceStatusHead);
            thStatus.Start();

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
            } while (true);
        }
        #endregion

        private int SysConverHDType(int type)
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


		public void CheckMsg()
		{
			try
			{
				do
				{
					Thread.Sleep(_SleapLen);
					try
					{
						string Msg = DeviceCheckHead.Instance.GetHDClient().GetDeviceMSG(
                            DeviceType.DeviceType_FJQ, Window.fjqAddress, _TimeOut);

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

					break;
				case "CALLER_NEXT":

					break;
				case "CALLER_RECALL"://重新呼叫
					CallReCall();
					break;
				case "CALLER_PAUSE"://暂停服务
					CallPause();
					break;
				case "CALLER_RESUME_SERVICE"://恢复服务
					CallRestart();
					break;
				case "CALLER_TRANSFER"://目标柜台号
					break;
				case "CALLER_TRANSFER2"://目标业务队列   /******当前没有实现*****/
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
					CALLER_SPECIAL(msgArr[2]);
					break;
				case "CALLER_DELAY"://当前办理号码延迟办理，号码再次进入排队队列
					break;
				case "EVA_MSG"://1：好2：中3：差4： 未评价
					break;
			}
		}

		public void CALLER_SPECIAL(string Number)
		{
			switch (Number)
			{
				case "1"://大堂经理
					break;
				case "2"://业务顾问
					break;
				case "3"://保安
					break;
				case "4"://	您好，欢迎光临
					break;
				case "5"://请评价
					break;
				case "6"://谢谢，再见
					break;
				case "7"://一米线
					break;
			}
/*
1.	大堂经理
2.	
3.	
4.	您好，欢迎光临
5.	
6.	谢谢，再见
7.	一米线
* */
		}

		private void ShowErrorMsg(string msg)
		{
			//MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		#region Werservice接口
		/// <summary>
		/// 重呼
		/// </summary>
		private void CallReCall()
		{
			string value = GetCall("RECALL", _NowBillNo);
			if (value != "0")
			{
				ShowErrorMsg(value);
			}
		}
		 /// <summary>
        /// 暂停
        /// </summary>
		private void CallPause()
		{

            string value = GetCall("PAUSE", Window.Name);
			if (value != "0")
			{
				ShowErrorMsg(value);
				return;
			}
		}

		
		 /// <summary>
        /// 恢复
        /// </summary>
		private void CallRestart()
		{
			string value = GetCall("RESTART", Window.Name);
			if (value != "0")
			{
				ShowErrorMsg(value);
			}
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
		/// <summary>
		/// 结束服务
		/// </summary>
		private void StopServer()
		{
            string msg = DeviceCheckHead.Instance.GetQueueClient().endService(UserID, Window.Name);
			if (msg == "0")
			{
			}
			else
			{
				ShowErrorMsg(msg);
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
