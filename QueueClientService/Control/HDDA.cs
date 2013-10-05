﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QM.Client.WebService.HD;
using System.Threading;
using QM.Client.Entity;

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


        public void PJ(string devAdd, string mBillNo, string queuID)
        {
            try
            {
                var client = GetHDClient();
                string result = client.PlayEvaluateSound(2, devAdd);
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
            catch (Exception ex)
            {
                ErrorLog.WriteLog("PJ#ex", ex.Message);
            }
        }

        public void TpShowSuspendedRestore(int mType, string Address, WindowOR _windOR)
        {
            try
            {
                string result = GetHDClient().ShowScreenMSG(1,
                       mType//显示类型。1（显示客户号|未受理客户数|客户名字），2（显示登录是否成功），3（显示登出是否成功），4（显示暂停服务），5（显示恢复服务），6（显示自定义信息
                      , Address
                     , _windOR.ColNumber.Value * 16
                      , 16 * 1
                      , ""
                      , ""
                      , "");
                if (result == "")
                {

                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("TpShowSuspendedRestore#ex", ex.Message);
            }
        }

        public bool PrintSlip(string mBillNo)
        {
            ////票号#业务名称#当前业务人数#当前网点人数
            if (string.IsNullOrEmpty(mBillNo))
            {
                return false;
            }
            try
            {
                string[] arr = mBillNo.Split('#');
                if (arr.Length >= 4)
                {
                    //Branch=#Number=MA098#BusinessType=个人现金#Count=108#TipMsg2=#Time=2010-3-26 22:31:22#Birthday=##
                    string Content = "Branch=#Number=<#PH>#BusinessType=<#bussNmae>#Count=<#WaitUserLen>#TipMsg2=#Time=<#Time>#Birthday=##";
                    Content = Content.Replace("<#PH>", arr[0])
                          .Replace("<#bussNmae>", arr[1])
                          .Replace("<#WaitUserLen>", arr[3])
                          .Replace("<#Time>", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    ControllerSoapClient HDClient = new ControllerSoapClient();
                    string msg = HDClient.PrintSlip("Branch=#Number=GR0005#BusinessType=个人外汇G#Count=4#TipMsg2=#Time=2013-08-18 22:31:29#Birthday=##", 12);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("PrintSlip#ex", ex.Message);
                return false;
            }
            return true;
        }



        #region 大堂声音呼号
        /// <summary>
        /// 呼号票号
        /// </summary>
        public void PlayBill(string BillNo, string WindowNo, int vol)
        {
            try
            {
                //请;A;0;0;1;号顾客到;1;号;窗口;
                string content = string.Format("请;{0}号顾客到;{1}号;窗口;", MsgToPlayFormat(BillNo), MsgToPlayFormat(WindowNo));
                string contentEN = string.Format("customer;{0}please come to;window;{1};", MsgToPlayFormat(BillNo), MsgToPlayFormat(WindowNo));
                GetHDClient().PlaySpeakerSound(
                    QueueClient._QueueMain.playType
                    , content
                    , contentEN
                    , QueueClient._QueueMain.playSequence   //播放顺序
                    , vol
                    , ""
                    , "");
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("PlayBill#ex", ex.Message);
            }
        }


        public string PlaySpecial(string PlayTpye, string WindowNo, int vol)
        {
            try
            {
                //请;大堂经理;到;1;号;窗口;
                string content = string.Format("请;{0};到;{1}号;窗口;", PlayTpye, MsgToPlayFormat(WindowNo));
                string contentEN = string.Format("{0}please come to;window;{1};", PlayTypeCNToEn(PlayTpye), MsgToPlayFormat(WindowNo));
                return GetHDClient().PlaySpeakerSound(QueueClient._QueueMain.playType
                    , content
                    , contentEN
                    , QueueClient._QueueMain.playSequence   //播放顺序
                    , vol
                    , ""
                    , "");
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("PlaySpecial#ex", ex.Message);
                return "";
            }
        }

        public string PlayTypeCNToEn(string PalyTpye)
        {
            string EnType = "";
            switch (PalyTpye)
            {
                case "客户经理":
                    EnType = "";
                    break;
                case "保安":
                    EnType = "";
                    break;
                case "业务顾问":
                    EnType = "";
                    break;
            }
            return EnType;
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
        public string ShowTpMsg(string devAddr, string content, string Bill, string Windowno, WindowOR _windOR)
        {
            try
            {
                return GetHDClient().ShowScreenMSG(1//屏幕类型。1（窗口屏），2（综合屏）
                    , 1//显示类型。1（显示客户号|窗口号），2（显示自定义信息），3（窗口屏专属，显示暂停服务），4（窗口屏专属，显示服务恢复）
                    , devAddr
                    , _windOR.ColNumber.Value * 16
                    , 16 * 1
                    , Bill
                    , Windowno
                    , content);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("ShowTpMsg#ex", ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 调用条屏，自定义显示信息
        /// </summary>
        /// <param name="devAddr"></param>
        /// <param name="content"></param>
        /// <param name="Bill"></param>
        /// <param name="Windowno"></param>
        /// <returns></returns>
        public string ShowTpMsgSelf(string devAddr, string content, WindowOR _windOR)
        {
            try
            {
                return GetHDClient().ShowScreenMSG(1//屏幕类型。1（窗口屏），2（综合屏）
                    , 2//显示类型。1（显示客户号|窗口号），2（显示自定义信息），3（窗口屏专属，显示暂停服务），4（窗口屏专属，显示服务恢复）
                    , devAddr
                    , _windOR.ColNumber.Value * 16
                    , 16 * 1
                    , ""
                    , ""
                    , content);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("ShowTpMsgSelf#ex", ex.Message);
                return "";
            }
        }
        #endregion


        /// <summary>
        /// 评价器，特呼
        /// </summary>
        public void SPECIAL_PJQ(int playType, string pjqAddress)
        {
            try
            {
                string val = GetHDClient().PlayEvaluateSound(playType, pjqAddress);
                if (val != "0")
                    ShowErrorMsg(val);
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog("SPECIAL_PJQ#ex", ex.Message);
            }
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