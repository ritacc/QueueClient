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
        private readonly QhandyMySqlDA _qClientDA = new QhandyMySqlDA();
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
        /// 登录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <param name="windowid"></param>
        /// <returns></returns>
        [WebMethod]
        public string getLogin(string userid, string password, string windowid)
        {
            return Instanse().getLogin(userid,password,windowid);
        }

        
        /// <summary>
        /// 结束服务
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="windowid"></param>
        /// <returns>1;登录用户、窗口号不存在
        /// "0";正常结束
        /// 其它字符串：异常信息
        /// </returns>
        [WebMethod]
        public string endService(string userid, string windowid)
        {
            return Instanse().endService(userid, windowid);
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
        ///3 获取所有业务队列
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<BussinessQueueOR> getQueue()
        {
            return Instanse().getQueue();
        }
        [WebMethod]
        public List<BussinessQueueOR> getQueuesByWindow(string windowID)
        {
            return Instanse().getQueuesByWindow(windowID);
        }
        

        /// <summary>
        /// 4、	获取队列详细信息
        /// 返回本业务所有的排队票号信息，各票号之间以分号隔开
        /// </summary>
        /// <param name="bussinessID">根据业务ID</param>
        /// <returns></returns>
         [WebMethod]
        public string getBussinessInfo(string BussinessID)
        {
            string strBillList = string.Empty;
            try
            {
                strBillList = Instanse().getBussinessInfo(BussinessID);
            }
            catch (Exception ex)
            {
                strBillList = string.Format("error: {0}", ex.Message);
            }
            return strBillList;
        }
        
        /// <summary>
        ///5 呼叫接口
        /// </summary>
        /// <param name="param"></param>
        /// <param name="mBillNo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [WebMethod]
        public string getCall(string param, string value)
        {
            return Instanse().getCall(param, value);
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
        #region 其它设置
        [WebMethod]
        public EmployeeOR GetEmployeeInfo(string userID)
        {
            return Instanse().GetEmployeeInfo(userID);
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public SysParamConfigOR GetSysParamConfigOR()
        {
           return new SysParaMySqlDA().SelectConfigORByWdbh();
        }
        /// <summary>
        /// 验证，卡号是否有效
        /// </summary>
        /// <param name="mCard"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ValidationCard(string mCard)
        {
            return Instanse().ValidationCard(mCard);
        }
        #endregion

        [WebMethod]
        public List<DeviceOR> GetAllDevices()
        {
            return Instanse().GetAllDevices();
        }

        /// <summary>
        /// 更新设备状态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [WebMethod]
        public bool UpdateDeviceSatus(string ID, int Status)
        {
            return Instanse().UpdateDeviceSatus(ID, Status);
        }

        [WebMethod]
        public string UpdatePJ(string BillNo, int PJ)
        {
            return "0";
        }

        #region QClient调用
        #region 取号图片处理
        [WebMethod]
        public string GetClientValue(string strKey)
        {
            return Instanse().GetClientValue(strKey);
        }

        [WebMethod]
        public string UpdateImgPassword(string newimgname, string newpwd)
        {
            return Instanse().UpdateImgPassword( newimgname,  newpwd);
        }
        #endregion

        [WebMethod]
        public ShutdownTimeOR SelectShutdownTime()
        {
            return new ShutdownTimeMySqlDA().SelectShutdownTime();
        }

        [WebMethod]
        public List<WindowOR> SelectAllWindow()
        {
            return new WindowMySqlDA().SelectWindows();
        }

        #endregion

    }
}
