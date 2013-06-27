using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QM.Client.WebService.HD;

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


        public void PJ(string devAdd)
        {
            var client = GetHDClient();
            string result= client.PlayEvaluateSound(2, devAdd);
            if (result == "0") 
            {
                result = client.GetDeviceMSG(2, devAdd, 10);//获取评价信息
                //com1,9600,011|EAV_MSG|7
                if (result.IndexOf("EAV_MSG") > 0)
                {

                }
            }

            
        }

       
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
}