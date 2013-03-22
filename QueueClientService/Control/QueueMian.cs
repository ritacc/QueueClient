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
        QueueInfoMySqlDA _QueueDA = new QueueInfoMySqlDA();//取号DA
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

        /// <summary>
        /// 获取窗口
        /// </summary>
        List<WindowOR> ListWindows = new List<WindowOR>();
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
                if (obj.Windowno == mWindowno)
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
                bussQue.Init(obj);
                //bussQue.ID = obj.Id;
                //bussQue.Name = obj.Name;
                //bussQue.EnglishName = obj.Englishname;
                bussQue.BussQueues = _QueueDA.selectBussinessQueues(obj.Id);//获取此队列未办结的取号记录
                QhQueues.Add(bussQue);
            }

            //初使化登录日志
           ListWindowLogins= _WindowLoginDA.SelectToDayLogins();

            //获取窗口
           ListWindows = new WindowMySqlDA().SelectWindows();
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
                return "error:用户名或密码错误";//用户名或密码错误
            }
            WindowOR _winOR = new WindowMySqlDA().SelectWindowByNo(windowid);
            if (_winOR == null)
            {
                return string.Format("error:窗口号：{0}不存在", windowid);//此窗口已登录
            }

            WindowLoginInfoOR _Log = GetLoginLog(userid, windowid);
            if (_Log == null)
            {
                //在内存中查询用户是否已经登录
                WindowLoginInfoOR _LoginRecordEmp = GetLoginLogByEmployeeNo(userid);
                if (_LoginRecordEmp != null)
                {
                    return "error:用户已经登录";//用户已经登录
                }

                WindowLoginInfoOR _LoginRecordWin = GetLoginLogByWindowNo(windowid);
                if (_LoginRecordWin != null)
                {
                    return string.Format("error:此窗口号：{0}已登录",windowid);//此窗口已登录
                }
            }
            else
            {
                //int TimeLen = GetTimeLen(_Log.Logintime, DateTime.Now);
                //if (TimeLen < 300)
                //{
                //    return "error:已登录。";
                //}
                //else//更新上次记录为结束
                //{
                    _Log.Status = 1;
                    _WindowLoginDA.UpdateLoginStatus(_Log);
                //}
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
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(windowid))
                return "error:用户编号、窗口号不能为空为。";

            WindowLoginInfoOR _winLog = GetLoginLog(userid, windowid);
            if (_winLog == null)
                return "error:无法找到登录用户编号和窗口的登录记录。";

            try
            {
                _winLog.Status = 1;
                _WindowLoginDA.EndServer(_winLog);
                ListWindowLogins.Remove(_winLog);
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
        /// <param name="windowNo">窗口编号</param>
        /// <returns></returns>
        private string CallPause(string windowNo)
        {
            try
            {
                WindowLoginInfoOR obj = GetLoginLogByWindowNo(windowNo);
                if (obj == null)
                {
                    return string.Format("error:找不到窗口编号：{0} 的登录记录。",windowNo);
                }
                obj.Status = 2;
                _WindowLoginDA.PauseServer(obj);
            }
            catch (Exception Ex)
            {
                return "error:"+ Ex.Message;
            }
            return "0";
        }

        /// <summary>
        /// 恢复	RESTART	空串
        /// </summary>
        private string CallRestart(string windowNo)
        {
            try
            {
                WindowLoginInfoOR obj = GetLoginLogByWindowNo(windowNo);
                if (obj == null)
                {
                    return string.Format("error:找不到窗口编号：{0} 登录记录。",windowNo);
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
                if (obj.Id == bussinessID)
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

        private WindowOR GetAWindow(string windowNo)
        {
            foreach (WindowOR obj in ListWindows)
            {
                if (obj.Name == windowNo)
                    return obj;
            }
            return null;
        }
        #endregion

        /// <summary>
        /// 获取所有业务队业
        /// </summary>
        /// <returns></returns>
        public List<BussinessQueueOR> getQueue()
        {
            if (QhQueues != null)
            {
                foreach (var v in QhQueues)
                {
                    v.InitNumber();
                }
            }
            return QhQueues;
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
            if (param == "")
                return "参数错误！";
            string strReturnValue = "";
            switch (param)
            {
                case "CALL":
                    if (string.IsNullOrEmpty(value))
                    {
                        return "error:请输入窗口号。";
                    }
                    strReturnValue = CallGetNext(value);
                    break;
                case "RECALL":
                    strReturnValue = CallReCall(value);
                    break;
                case "DELAY": //延后 增加了一个票号 (票号##时长)                   
                    strReturnValue = CallDelay(value);
                    break;
                case "TRANSFER":
                    strReturnValue = CallTransfer(value);
                    break;
                case "SPECALL":
                    strReturnValue = CallSpecall(value);
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
            WindowOR _windOR = GetAWindow(mWindowNo);
            if (_windOR == null)
                return "error:窗口不存在！";
            WindowLoginInfoOR _winLogin = GetLoginLogByWindowNo(mWindowNo);
            if (_winLogin == null)
                return "error:未登录！";
            //WindowLoginInfoOR _WinLog=get
            //据呼叫的窗口号遍历每一个队列，找出延后人数为0的取出作为结果，若不存在，则进行第二次遍历
            
            //移出重呼两次的取号
            RemoveReCall(mWindowNo);
           
            QueueInfoOR mSelectQhObj=null;
            //先处理其它窗口过来的属况,即不用排队
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                {
                    if (objQue.Transferdestwin == mWindowNo)
                    {
                        //objQue.Status = 1;
                        mSelectQhObj = objQue;
                    }
                }
            }

            //第二次遍历过程中，转移窗口号不为空且不等于呼叫窗口号的元素略过，更新所有元素的“换算后排队时间”（
            //更新时间，并将其移到一个数组中
            if (mSelectQhObj == null)
            {
                List<QueueInfoOR> mQueueList = new List<QueueInfoOR>();//排队列表
                foreach (BussinessQueueOR objQhQue in QhQueues)
                {
                    foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                    {
                        if ((objQue.Status == 0 && objQue.Transferdestwin != mWindowNo)//转移窗口不能为本窗口
                            || (objQue.Status == 1 && objQue.Windowno== mWindowNo)
                            )//本窗口上次叫号
                        {
                            int TimeLen = GetTimeLen(objQue.Prillbilltime, DateTime.Now);
                            if (objQue.Delaytime > 0)//延后，需要减去，延后的时间
                            {
                                TimeLen -= objQue.Delaytime;
                            }

                            objQue.ConvertTimeLen = TimeLen + GetPriorTime(TimeLen, objQhQue);                            
                            mQueueList.Add(objQue);
                        }
                    }
                }
                mQueueList.Sort();
                if (mQueueList.Count > 0)
                    mSelectQhObj = mQueueList[0];

                mQueueList.Clear();
            }
           

            if (mSelectQhObj != null)
            {
                //更新数据库状态
                mSelectQhObj.Status = 1;
                mSelectQhObj.Waitinterval = GetTimeLen(mSelectQhObj.Prillbilltime
                    , DateTime.Now);
                mSelectQhObj.Windowno = _windOR.Name;
                mSelectQhObj.Employno = _winLogin.Employno;
                mSelectQhObj.Employname = _winLogin.Employname;

                _QueueDA.UpdateCall(mSelectQhObj);
                //调查用硬件接口，呼叫
                return mSelectQhObj.Billno;
            }

            return "error: 没有获取到排队人员。";
        }
        
       
        
        /// <summary>
        /// 重呼	RECALL	票号
        /// </summary>
        /// <param name="mBill">票号</param>
        private string CallReCall(string mBillNo)
        {
            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            
            if (objQH == null)
            {
                return string.Format("票号:{0} 不存在!", mBillNo);
            }
            else if (objQH.Status == 0)
            {
                return "未叫号！";
            }
            else if (objQH.Status == 3)
            {
                return "已办结！";
            }
            else if (objQH.Status == 1)//正确的重呼
            {
                objQH.ReCallNumber++;
                if (objQH.ReCallNumber >= 3)
                {
                    RemoveReCall(objQH.Windowno);
                    return "1";
                }
                //重呼接口

                return "0";
            }
            return "未知错误！";
        }

        /// <summary>
        /// 延后	DELAY	票号##时长
        /// </summary>
        /// <param name="TimeLen">时长</param>
        private string CallDelay(string mparam)
        {
            int mindex = mparam.IndexOf("##");
            if (mindex <= 0)
                return "error:参数错误！";
            string mBillNo = mparam.Substring(0, mindex);
            string TimeLen = mparam.Substring(mindex + 2);

            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return string.Format("票号:{0} 的记录不存在!", mBillNo);

            objQH.Delaytime = Convert.ToInt32(TimeLen) * 60;
            objQH.Status = 0;
            _QueueDA.UpdateDelayTimer(objQH);
            return "0";
        }

        /// <summary>
        /// 转移	TRANSFER	目标窗口号
        /// </summary>
        /// <param name="targetWindNo"></param>
        private string CallTransfer(string mparam)
        {
            //targetWindNo
            //票号##目标窗口号
            int mindex = mparam.IndexOf("##");
            if (mindex <= 0)
                return "error:参数错误！";
            string mBillNo = mparam.Substring(0, mindex);
            string targetWin = mparam.Substring(mindex + 2);

            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return string.Format("票号:{0} 不存在!",mBillNo);
            objQH.Transferdestwin = targetWin;
            try
            {
                _QueueDA.UpdateTransfer(objQH);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";
        }

        /// <summary>
        /// 特呼	SPECALL	窗口号##呼号类型#票号
        /// </summary>
        /// <param name="mBill"></param>
        private string CallSpecall(string mparam)
        {
            if (string.IsNullOrEmpty(mparam))
                return "参数错误";
            string[] strArr = mparam.Replace("##","#").Split('#');
            if(strArr.Length != 3)
                return "参数错误";

            string mWindowNo = strArr[0];//窗口号
            string mCallType = strArr[1];//呼叫类型
            string mBillNo = strArr[2];//票号

            if (mCallType == "客户")
            {
                QueueInfoOR objQH = GetQueueInfo(mBillNo);
                if (objQH == null)
                    return string.Format("票号:{0} 不存在!", mBillNo);
                if (objQH.Status == 3)
                    return "此单号已办结";
                

                //呼号代码
            }
            else if (mCallType == "大堂经理")
            {

            }
            else if (mCallType == "客户经理")
            {

            }
            return "0";
        }

        /// <summary>
        /// 欢迎光临	WELCOME	空串
        /// </summary>
        private string CallWelcome(string mBillNo)
        {
            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return string.Format("票号:{0} 不存在!", mBillNo);
            if (objQH.Status == 0)
                return "请先叫号。";

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
                return string.Format("票号:{0} 不存在!", mBillNo);
            try
            {
                objQH.Status = 3;
                objQH.Finishtime = DateTime.Now;
                objQH.Processinterval = GetTimeLen(objQH.Processtime, objQH.Finishtime);
                _QueueDA.UpdateCallJudge(objQH);
                //移出此号码
                foreach (BussinessQueueOR objQhQue in QhQueues)
                {
                    objQhQue.BussQueues.Remove(objQH);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";
        }

        #region 呼叫辅助函数
        /// <summary>
        /// 获取业务优先时间
        /// </summary>
        /// <param name="TimeLen"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int GetPriorTime(int TimeLen, BussinessOR obj)
        {
            if (TimeLen > obj.Waittime3)
            {
                return obj.Priortime3;
            }
            else if (TimeLen > obj.Waittime3)
            {
                return obj.Priortime3;
            }
            else if (TimeLen > obj.Waittime3)
            {
                return obj.Priortime3;
            }
            return 0;
        }
        /// <summary>
        /// 移出 重呼两次的记录
        /// </summary>
        /// <param name="windowNo"></param>
        private void RemoveReCall(string windowNo)
        {
            List<QueueInfoOR> ListRemoveQH = new List<QueueInfoOR>();
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                {
                    if (objQue.Status == 1 && objQue.ReCallNumber >= 2
                        && objQue.Windowno == windowNo)
                    {
                        ListRemoveQH.Add(objQue);
                    }
                }
                //移出重呼两次的记录
                if (ListRemoveQH.Count > 0)
                {
                    foreach (QueueInfoOR obj in ListRemoveQH)
                    {
                        _QueueDA.UpdateRecallEnd(obj);
                        objQhQue.BussQueues.Remove(obj);
                    }
                    ListRemoveQH.Clear();
                }
            }
        }  
        #endregion

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
                if (obj.Id == mBusssinessID)
                {
                    isAddBussiness = true;
                }
                foreach (QueueInfoOR _qhOr in obj.BussQueues)//计算排除人数
                {
                    if (_qhOr.Status <= 1)
                    {
                        mWaitBank++;
                        if (isAddBussiness)//当前队列
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

        #region 取号图片
        /// <summary>
        /// 查询图片配置
        /// </summary>
        /// <returns></returns>
        public string GetQhImgName()
        {
            QhImgSetDA _da = new QhImgSetDA();
            return _da.selectQhImg();
        }

        /// <summary>
        /// 添加或修改图片配置
        /// </summary>
        /// <param name="mImgName"></param>
        /// <returns></returns>
        public string UpdateImgSet(string mImgName)
        {
            QhImgSetDA _da = new QhImgSetDA();
            try
            {
                _da.UpdateImg(mImgName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";
        }
        #endregion

    }
}