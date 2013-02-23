using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using QM.Client.WebService.Control;


namespace QM.Client.WebService
{
    /// <summary>
    /// QueueClient 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.ritacc.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class QueueClient : System.Web.Services.WebService
    {
        public static QueueMian _QueueMain { set; get; }
        public object lockObj = new object();
        private QueueMian Instanse()
        {
            if (_QueueMain == null)
            {
                lock (lockObj)
                {
                    if (_QueueMain == null)
                    {
                        _QueueMain = new QueueMian();
                    }
                }
            }
            return _QueueMain;
        }
        

        /// <summary>
        /// 业务队列取号
        /// </summary>
        /// <param name="BussinessID">业务队列ID</param>
        /// <param name="mCard">取号卡号</param>
        /// <returns></returns>
        [WebMethod]
        public string BussinessQH(string BussinessID,string mCard)
        {
            string _Bill = string.Empty;
            try
            {
              _Bill =  Instanse().QH(BussinessID, mCard);
            }
            catch (Exception ex)
            {
                _Bill=string.Format("Error: {0}",ex.Message);
            }
            return _Bill;
        }
    }
}
