using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QM.Client.WebService.HD;
using System.Threading;

namespace QM.Client.WebService.Control
{
    public class HDDA
    {
        private static readonly HDDA _instance = new HDDA();
        public static HDDA Instance { get { return _instance; } }

        protected ControllerSoapClient _HDSoapClient;
        public ControllerSoapClient GetHDClient()
        {
            if (_HDSoapClient == null)
            {
                //BasicHttpBinding binding = new BasicHttpBinding();
                //binding.MaxReceivedMessageSize = 2147483647;
                //binding.MaxBufferSize = 2147483647;
                //EndpointAddress address = new EndpointAddress(this.GetHDURL());
                //_HDSoapClient= new ControllerSoapClient(binding, address);
                _HDSoapClient = new ControllerSoapClient();
            }
            return _HDSoapClient;
        }


        public void PJ(string devAdd,string mBillNo,string queuID)
        {
            var client = GetHDClient();
            string result= client.PlayEvaluateSound(2, devAdd);
            if (result == "0") 
            {
				PjResult pjr = new PjResult();
				pjr.Address = devAdd;
				pjr.BillNo = mBillNo;
				pjr.queuID = queuID;
				Thread th = new Thread(pjr.GetPJResult);
				th.Start();
            }
        }

		

		#region 大堂声音呼号
		/// <summary>
		/// 呼号票号
		/// </summary>
		public void PlayBill(string BillNo,string WindowNo, int vol)
		{
			//请;A;0;0;1;号顾客到;1;号;窗口;
			string content = string.Format("请;{0}号顾客到;{1}号;窗口;", MsgToPlayFormat(BillNo), MsgToPlayFormat(WindowNo));
			GetHDClient().PlaySpeakerSound(3, content, "", "2", vol);
		}


		public string PlaySpecial(string PlayTpye, string WindowNo, int vol)
		{
			//请;大堂经理;到;1;号;窗口;
			string content = string.Format("请;{0};到;{1}号;窗口;", PlayTpye, MsgToPlayFormat(WindowNo));
			return GetHDClient().PlaySpeakerSound(3, content, "", "2", vol);
		}
		
		public string MsgToPlayFormat(string msg)
		{
			if (string.IsNullOrEmpty(msg))
				return string.Empty;

			string formtStr = string.Empty;
			for (int i = 0; i < msg.Length; i++)
			{
				formtStr += msg[i] + ";";
			}
			return formtStr;
		}
		#endregion

		#region 条屏显示
		/// <summary>
		/// 条屏显示信息
		/// </summary>
		public string ShowTpMsg(string devAddr,string content,int mwidth)
		{
		return	GetHDClient().ShowScreenMSG(1//屏幕类型。1（窗口屏），2（综合屏）
			, 2//显示类型。1（显示客户号|窗口号），2（显示自定义信息），3（窗口屏专属，显示暂停服务），4（窗口屏专属，显示服务恢复）
			, devAddr
			, mwidth
			, 16
			, ""
			, "",
			content);
		}
		#endregion


		/// <summary>
        /// 评价器，特呼
        /// </summary>
        public void SPECIAL_PJQ(int playType, string pjqAddress)
        {
            string val = GetHDClient().PlayEvaluateSound(playType, pjqAddress);
            if (val != "0")
                ShowErrorMsg(val);
        }
        private void ShowErrorMsg(string msg)
        {
            ErrorLog.WriteLog("#ShowErrorMsg", msg);
        }

    }

	public class PjResult
	{
		public string BillNo { get; set; }
		public string Address { get; set; }
		public string queuID { get; set; }

		public void GetPJResult()
		{
			string result = HDDA.Instance.GetHDClient().GetDeviceMSG(2, Address, 10);//获取评价信息
			//com1,9600,011|EAV_MSG|7
			if (result.IndexOf("EAV_MSG") > 0)
			{
				string[] arr = result.Split('|');
				if (arr.Length == 3)
				{
					int pjR = 0;
					if (!string.IsNullOrEmpty(arr[2]))
					{
						if (int.TryParse(arr[2], out pjR))
						{

						}
					}
				}
			}//end if
		}//end getpj
	}
	 
}