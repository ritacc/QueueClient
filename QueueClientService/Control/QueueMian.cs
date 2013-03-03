using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using QM.Client.DA.MySql;
using QM.Client.Entity;
using System.Collections;
using System.Configuration;

namespace QM.Client.WebService.Control
{
    /// <summary>
    /// 排队主类，包含取号数据。列表数据
    /// 放在一个类，因为，webService 等待时间长一点(应用程序池设置20分钟)，数据就会被清掉。
    /// </summary>
    public class QueueMian
    {
        /*
每种业务类型一个队列，取号时往对应的队列里面插入一个元素，
元素结构包含：是否VIP、取号时间、换算后排队时间、转移窗口号、延后人数、延后时间。
其中，转移窗口号只有按下转移后才使用，延后人数在按下延后以及后面的呼叫后更新；数据结构采用hash实现，关键字是业务类型ID，值是队列，队列里面是元素。延后人数和延后时间作为延后策略的可选项，目前先实现延后时间，预留延后人数的逻辑与接口，实现时可以快速实现；
         */
         
        BussinessMySqlDA _busDA = new BussinessMySqlDA();//业务DA
        QueueInfoDA _QueueDA=new QueueInfoDA();//取号DA
        WindowLoginInfoDA _WindowLoginDA = new WindowLoginInfoDA();

        #region 属性
        /// <summary>
        /// 网点业务队列
        /// </summary>
        public List<BussinessQueueOR> QhQueues { get; set; }
               
        /// <summary>
        /// 网点机构号
        /// </summary>
        public string BankNo { get; set; }

        List<WindowLoginInfoOR> ListWindowLogins = new List<WindowLoginInfoOR>();
        #endregion

        #region 登录函数
        /// <summary>
        /// 查询员工是否已经登录
        /// </summary>
        /// <param name="mEmployeeNo"></param>
        /// <returns></returns>
        private WindowLoginInfoOR GetLoginLogByEmployeeNo(string mEmployeeNo)
        {
            foreach (WindowLoginInfoOR obj in ListWindowLogins)
            {
                if (obj.Status != 0 && obj.Employno == mEmployeeNo)
                    return obj;
            }
            return null;
        }

        private WindowLoginInfoOR GetLoginLogByWindowNo(string mWindowno)
        {
            foreach (WindowLoginInfoOR obj in ListWindowLogins)
            {
                if (obj.Status != 0 && obj.Windowno == mWindowno)
                    return obj;
            }
            return null;
        }

        private WindowLoginInfoOR GetLoginLog(string userid, string windowid)
        {
            foreach (WindowLoginInfoOR obj in ListWindowLogins)
            {
                if (obj.Employno == userid && obj.Windowno == windowid)
                    return obj;
            }
            return null;
        }

        private WindowLoginInfoOR GetLoginLogByUserID(string userid, int mStatus)
        {
            foreach (WindowLoginInfoOR obj in ListWindowLogins)
            {
                if (obj.Employno == userid && obj.Status == mStatus)
                    return obj;
            }
            return null;
        }
        #endregion

        #region 初使化
        /// <summary>
        /// 初使化、
        /// </summary>
        public QueueMian()
        {
            InitBankNo();

            List<BussinessOR> ListBuss=new List<BussinessOR>();//所有业务
           
            //查询 所有的业务队列
            ListBuss = _busDA.selectAllBussiness();

            QhQueues = new List<BussinessQueueOR>();
            //根据队列，取出已取号的排队信息。
            foreach (BussinessOR obj in ListBuss)
            {
                BussinessQueueOR bussQue = new BussinessQueueOR();
                bussQue.ID = obj.Id;
                bussQue.Name = obj.Name;
                bussQue.EnglishName = obj.Englishname;
                bussQue.BussQueues = _QueueDA.selectBussinessQueues(obj.Id);//获取此队列未办结的取号记录
                QhQueues.Add(bussQue);
            }

            //初使化登录日志
           ListWindowLogins= _WindowLoginDA.SelectToDayLogins();
        }

        /// <summary>
        /// 从配置文件获取，网点编号OrgNo
        /// </summary>
        private void InitBankNo()
        {
            BankNo = ConfigurationManager.AppSettings["BankNo"];
        }
        #endregion

        #region 1登录 、call(暂停 、恢复) 、2结束服务
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <param name="windowid"></param>
        /// <returns></returns>
        public string getLogin(string userid, string password, string windowid)
        {
            EmployeeOR _empOR = new EmployeeMySqlDA().SelectAEmployeeLogin(userid, password);
            if (_empOR == null)
            {
                return "1";//用户名或密码错误
            }
            WindowOR _winOR = new WindowMySqlDA().SelectWindowByNo(windowid);
            if (_winOR == null)
                return "2";//窗口不存在

            WindowLoginInfoOR _Log = GetLoginLog(userid, windowid);
            if (_Log == null)
            {
                //在内存中查询用户是否已经登录
                WindowLoginInfoOR _LoginRecordEmp = GetLoginLogByEmployeeNo(userid);
                if (_LoginRecordEmp != null)
                {
                    return "3";//用户已经登录
                }

                WindowLoginInfoOR _LoginRecordWin = GetLoginLogByWindowNo(windowid);
                if (_LoginRecordWin != null)
                {
                    return "4";//此窗口已登录
                }
            }
            else
            {
                int TimeLen = GetTimeLen(_Log.Logintime, DateTime.Now);
                if (TimeLen < 300)
                {
                    return "5";
                }
                else//更新上次记录为结束
                {
                    _Log.Status = 1;
                    _WindowLoginDA.UpdateLoginStatus(_Log);
                }
            }

            try
            {
                WindowLoginInfoOR _Login = new WindowLoginInfoOR();
                _Login.Windowno = windowid;
                _Login.Employname = _empOR.Name;
                _Login.Employno = _empOR.Employno;
                _Login.Alerttime = _Login.Logintime = DateTime.Now;
                _Login.Status = 0;
                _WindowLoginDA.InsertLoginWindowInfo(_Login);//写入数据库

                ListWindowLogins.Add(_Login);
            }
            catch (Exception ex)
            {
                return ex.Message; //写入数据库出错。
            }
            return "0";
        }

        public string endService(string userid, string windowid)
        {
            WindowLoginInfoOR _winLog = GetLoginLog(userid, windowid);
            //WindowLoginInfoOR _winLog = _WindowLoginDA.SelectLoginLogByUserIDAndWindowID(userid, windowid);
            if (_winLog == null)
                return "1";//登录用户、窗口号不存在

            try
            {
                _winLog.Status = 1;
                _WindowLoginDA.EndServer(_winLog);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";//正常结束
        }
        
        /// <summary>
        /// 暂停	PAUSE	空串
        /// </summary>
        private string CallPause(string userID)
        {
            try
            {
                WindowLoginInfoOR obj = GetLoginLogByUserID(userID, 0);
                //WindowLoginInfoOR obj = _WindowLoginDA.SelectLoginLogByUserID(userID, "0");
                if (obj == null)
                {
                    return "2";
                }
                obj.Status = 2;
                _WindowLoginDA.PauseServer(obj);
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
            return "0";
        }

        /// <summary>
        /// 恢复	RESTART	空串
        /// </summary>
        private string CallRestart(string userID)
        {
            try
            {
                WindowLoginInfoOR obj = GetLoginLogByUserID(userID, 2);
                //WindowLoginInfoOR obj = _WindowLoginDA.SelectLoginLogByUserID(userID, "0");
                if (obj == null)
                {
                    return "1";
                }
                obj.Status = 0;
                _WindowLoginDA.RestarServer(obj);
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
            return "0";
        }
        #endregion

        #region 公用函数
        /// <summary>
        /// 根据业务队列ID，获取内存中的 获取业务队列
        /// </summary>
        /// <param name="bussinessID"></param>
        /// <returns></returns>
        private BussinessQueueOR GetBussiness(string bussinessID)
        {
            foreach (BussinessQueueOR obj in QhQueues)
            {

                if (obj.ID == bussinessID)
                    return obj;
            }
            return null;
        }

        /// <summary>
        /// 根据票号，获取取票记录
        /// </summary>
        /// <param name="bileNo"></param>
        /// <returns></returns>
        private QueueInfoOR GetQueueInfo(string billeNo)
        {
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                {
                    if (objQue.Billno == billeNo)
                    {
                        return objQue;
                    }
                }
            }
            return null;
        }

        private int GetTimeLen(DateTime Start, DateTime EndTime)
        {
            int TimeLen = 0;
            TimeSpan t = EndTime - Start;
            TimeLen = (t.Hours * 60 * 60) + t.Minutes * 60 + t.Seconds;
            return TimeLen;
        }
        #endregion

        /// <summary>
        /// 获取所有业务队业
        /// </summary>
        /// <returns></returns>
        public List<BussinessBasicInfoOR> getQueue()
        {
            List<BussinessBasicInfoOR> listQueue = new List<BussinessBasicInfoOR>();
            foreach (BussinessQueueOR obj in QhQueues)
            {
                BussinessBasicInfoOR _mBasciObj = new BussinessBasicInfoOR(obj);
                listQueue.Add(_mBasciObj);
            }
            return listQueue;
        }

        /// <summary>
        /// 4、	获取队列详细信息
        /// 返回本业务所有的排队票号信息，各票号之间以分号隔开
        /// </summary>
        /// <param name="bussinessID">根据业务ID</param>
        /// <returns></returns>
        public string getBussinessInfo(string bussinessID)
        {
            BussinessQueueOR _CurentBuss = GetBussiness(bussinessID);
            if (_CurentBuss == null)
            {
                throw new Exception("获取业务队列失败！，无法取号。");
            }
            string strBillList = string.Empty;
            foreach (QueueInfoOR obj in _CurentBuss.BussQueues)
            {
                strBillList += string.Format("{0};", obj.Billno);
            }
            return strBillList;
        }

        #region 5呼叫接口
        /*
呼叫下一位	CALL	空串
重呼	RECALL	票号
延后	DELAY	时长（单位为分钟）
转移	TRANSFER	目标窗口号
特呼	SPECALL	票号
欢迎光临	WELCOME	空串
请评价	JUDGE	空串

暂停	PAUSE	空串
恢复	RESTART	空串
         */

        /// <summary>
        /// 呼叫接口
        /// </summary>
        /// <param name="param">参数类型</param>
        /// <param name="BillNo">票号</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public string getCall(string param, string value)
        {
            string strReturnValue = "";
            switch (param)
            {
                case "CALL":
                    strReturnValue = CallGetNext(value);
                    break;
                case "RECALL":
                    CallReCall(value);
                    break;
                case "DELAY": //延后 增加了一个票号 (票号##时长)
                    int mindex = value.IndexOf("##");
                    string mBill = value.Substring(0, mindex);
                    string mvalue = value.Substring(mindex + 2);
                    strReturnValue = CallDelay(mvalue, mBill);
                    break;
                case "TRANSFER":
                    CallTransfer(value);
                    break;
                case "SPECALL":
                    CallSpecall(value);
                    break;
                case "WELCOME":
                    strReturnValue = CallWelcome(value);
                    break;
                case "JUDGE":
                    strReturnValue = CallJudge(value);
                    break;
                case "PAUSE":
                    strReturnValue = CallPause(value);
                    break;
                case "RESTART":
                    strReturnValue = CallRestart(value);
                    break;
            }

            return strReturnValue;
        }
        
        /// <summary>
        /// 呼叫下一位	CALL	空串
        /// </summary>
        private string CallGetNext(string mWindowNo)
        {
            int iWindowNo = Convert.ToInt16(mWindowNo);

            //据呼叫的窗口号遍历每一个队列，找出延后人数为0的取出作为结果，若不存在，则进行第二次遍历
            QueueInfoOR mSelectQhObj=null;
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues )
                {
                    if (objQue.Windowno == mWindowNo  && objQue.Delaynum==0 && objQue.Status==0)
                    {
                        //更新呼叫
                        //objQue.Status = 1;
                        mSelectQhObj = objQue;
                    }
                }
            }
            //第二次遍历过程中，转移窗口号不为空且不等于呼叫窗口号的元素略过，更新所有元素的“换算后排队时间”（
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                {
                    if (objQue.Transferdestwin != 0 && objQue.Transferdestwin != iWindowNo)
                    {
                        continue;
                    }
                    if (objQue.Status == 0)
                    {
                        mSelectQhObj = objQue;
                    }
                }
            }
            if (mSelectQhObj != null)
            {
                //更新数据库状态
                mSelectQhObj.Status = 1;
                mSelectQhObj.Waitinterval = GetTimeLen(mSelectQhObj.Prillbilltime
                    , DateTime.Now);
                _QueueDA.UpdateCall(mSelectQhObj);
                //调查用硬件接口，呼叫
                return mSelectQhObj.Billno;
            }

            return "Error: 没有获取到排队人员。";
        }

        /// <summary>
        /// 重呼	RECALL	票号
        /// </summary>
        /// <param name="mBill">票号</param>
        private void CallReCall(string mBill)
        {
            //不做逻辑更处理，直接呼叫

        }

        /// <summary>
        /// 延后	DELAY	时长（单位为分钟）
        /// </summary>
        /// <param name="TimeLen">时长</param>
        private string CallDelay(string TimeLen,string mBillNo)
        {
            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return "此票号的记录不存在!";

            objQH.Delaytime = Convert.ToInt32(TimeLen) * 60;
            objQH.Status = 0;
            return "";
        }

        /// <summary>
        /// 转移	TRANSFER	目标窗口号
        /// </summary>
        /// <param name="targetWindNo"></param>
        private void CallTransfer(string targetWindNo)
        {


        }

        /// <summary>
        /// 特呼	SPECALL	票号
        /// </summary>
        /// <param name="mBill"></param>
        private void CallSpecall(string mBill)
        {


        }

        /// <summary>
        /// 欢迎光临	WELCOME	空串
        /// </summary>
        private string CallWelcome(string mBillNo)
        {
            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return "此票号的记录不存在!";
            try
            {
                objQH.Status = 2;
                objQH.Processtime = DateTime.Now;
                objQH.Waitinterval = GetTimeLen(objQH.Prillbilltime, DateTime.Now);
                _QueueDA.UpdateWelcome(objQH);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";
        }

        /// <summary>
        /// 请评价	JUDGE	空串
        /// </summary>
        private string CallJudge(string mBillNo)
        {
            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return "此票号的记录不存在!";
            try
            {
                objQH.Status = 3;
                objQH.Finishtime = DateTime.Now;
                objQH.Processinterval = GetTimeLen(objQH.Processtime, objQH.Finishtime);
                _QueueDA.UpdateCallJudge(objQH);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";
        }

       
        #endregion
                

        #region 取号
        /// <summary>
        /// 取号，差返回票号
        /// </summary>
        /// <param name="bussinessID"></param>
        /// <param name="mCardno"></param>
        /// <returns></returns>
        public string QH(string bussinessID, string mCardno)
        {
            BussinessQueueOR _CurentBuss=GetBussiness(bussinessID);
            if (_CurentBuss == null)
            {
                throw new Exception("获取业务队列失败！，无法取号。");
            }
            try
            {
                string _BillNo = GetBillNo();

                int mWaitpeoplebusssiness = 0;
                int mWaitpeoplebank = 0;
                //int mCustemclass = 0;
                GetWaitPeople(bussinessID, out  mWaitpeoplebusssiness, out mWaitpeoplebank);

                QueueInfoOR _qhOR = new QueueInfoOR(BankNo, _BillNo, bussinessID, mCardno
                    , mWaitpeoplebusssiness, mWaitpeoplebank);//初使化取号
                _QueueDA.QH(_qhOR);//将取号插入到数据库

                //插入到当前队列
                _CurentBuss.BussQueues.Add(_qhOR);
                return _BillNo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        
        /// <summary>
        /// 获取排队人数
        /// </summary>
        /// <param name="mBusssinessID"></param>
        /// <param name="mWaitpeopleBussiness"></param>
        /// <param name="mWaitBank"></param>
        private void GetWaitPeople(string mBusssinessID,out int mWaitpeopleBussiness,out int mWaitBank)
        {
            mWaitpeopleBussiness = 0;
            mWaitBank = 0;
            bool isAddBussiness = false;//是否 业务队列计数
            foreach (BussinessQueueOR obj in QhQueues)
            {
                if (obj.ID == mBusssinessID)
                {
                    isAddBussiness = true;
                }
                foreach (QueueInfoOR _qhOr in obj.BussQueues)//计算排除人数
                {
                    if (_qhOr.Status == 0)
                    {
                        mWaitBank++;
                        if (isAddBussiness)//当于队列
                            mWaitpeopleBussiness++;
                    }
                }
                isAddBussiness = false;
            }
        }

        /// <summary>
        /// 获取票号
        /// </summary>
        /// <returns></returns>
        private string GetBillNo()
        {
           int QueNumber= _QueueDA.GetQueueNumber();
           int nowNumber = QueNumber + 1;
           return nowNumber.ToString().PadLeft(4, '0');
        }

        #endregion

    }
}