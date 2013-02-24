using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using QM.Client.WebService.Control;
using QM.Client.Entity;
using QM.Client.DA.MySql;


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
        private readonly QClientDA _qClientDA = new QClientDA();
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

        /// <summary>
        /// 4、	获取队列详细信息
        /// 返回本业务所有的排队票号信息，各票号之间以分号隔开
        /// </summary>
        /// <param name="bussinessID">根据业务ID</param>
        /// <returns></returns>
        public string getBussinessInfo(string BussinessID)
        {
            string strBillList = string.Empty;
            try
            {
                strBillList = Instanse().getBussinessInfo(BussinessID);
            }
            catch (Exception ex)
            {
                strBillList = string.Format("Error: {0}", ex.Message);
            }
            return strBillList;
        }

        /// <summary>
        ///5 获取所有业务队列
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<BussinessBasicInfoOR> getQueue()
        {
            return Instanse().getQueue();
        }



        /// <summary>
        /// 呼叫接口
        /// </summary>
        /// <param name="param"></param>
        /// <param name="mBillNo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [WebMethod]
        public string getCall(string param, string mBillNo, string value)
        {
            return Instanse().getCall(param, mBillNo, value);
        }

        /// <summary>
        /// 6、	获取客户基本信息getCustomerInfo(string billNo): 获取客户姓名、业务名称
        /// </summary>
        /// <param name="billNo"></param>
        [WebMethod]
        public void getCustomerInfo(string billNo)
        {

        }

        /// <summary>
        /// 7、	获取客户营销信息getCustomerSellInfo(string billNo):获取营销详细信息
        /// </summary>
        /// <param name="billNo"></param>
        [WebMethod]
        public void getCustomerSellInfo(string billNo)
        {

        }

        [WebMethod]
        public PageWinOR GetPageWinById(string id)
        {
            return _qClientDA.GetPageWinId(id);
        }

        [WebMethod]
        public List<QhandyOR> GetButtonsByPageWinId(string windowId)
        {
            return _qClientDA.GetButtonsByPageWinId(windowId);
        }
    }
}
