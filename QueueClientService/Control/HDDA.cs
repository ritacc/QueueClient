using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QM.Client.WebService.Control
{
    public class HDDA
    {
        private static readonly HDDA _instance = new HDDA();
        public static HDDA Instance { get { return _instance; } }


        public void PJ(string devAdd)
        {
            var client = HDClient.Instance.GetHDClient();
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
    }
}