using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using QM.Client.DA.MySql;
using QM.Client.Entity;
using System.Collections;
using System.Configuration;
using System.Linq;

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

        #region 配置文件参数
        /// <summary>
        /// 网点机构号
        /// </summary>
        public string BankNo { get; set; }
        
        /// <summary>
        /// int playType：播放类型。1（只播放主音箱），2（只播放无线音箱），3（主音箱和无线音箱都播放）
        /// </summary>
        public int playType { get; set; }
        /// <summary>
        ///playSequence：播放顺序，以分号隔开多个语种。1（提示音），2（普通话），3（英语），4（粤语）。例如“1;2;3;4;”表示先播提示音，然后播普通话
        /// </summary>
        public string playSequence { get; set; }
        #endregion

        List<WindowLoginInfoOR> ListWindowLogins = new List<WindowLoginInfoOR>();

        /// <summary>
        /// 获取窗口
        /// </summary>
        List<WindowOR> ListWindows = new List<WindowOR>();

        //Vip卡处理
        VipCardHeadle VipCardHeadObj;

        //业务角色处理
        BussinessRoleHeadle BussRoleObj;

        SysParamConfigOR _SysparaConfigObj;
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
            //Vip优先时间处理类
            VipCardHeadObj = new VipCardHeadle();
            VipCardHeadObj.Init();

            List<BussinessOR> ListBuss=new List<BussinessOR>();//所有业务
            //查询 所有的业务队列
            ListBuss = _busDA.selectAllBussiness();

            QhQueues = new List<BussinessQueueOR>();
            //根据队列，取出已取号的排队信息。
            foreach (BussinessOR obj in ListBuss)
            {
                BussinessQueueOR bussQue = new BussinessQueueOR();
                bussQue.Init(obj);
                bussQue.BussQueues = _QueueDA.selectBussinessQueues(obj.Id);//获取此队列未办结的取号记录
                foreach (QueueInfoOR qhObj in bussQue.BussQueues)
                {
                    if (!string.IsNullOrEmpty(qhObj.Cardno))
                    {
                        qhObj.VipFirstTime = VipCardHeadObj.GetFirstTime(qhObj.Cardno);
                    }
                }
                QhQueues.Add(bussQue);
            }

            //初使化登录日志
           ListWindowLogins= _WindowLoginDA.SelectToDayLogins();

            //获取窗口
           ListWindows = new WindowMySqlDA().SelectWindows();

            //业务角色处理
           BussRoleObj = new BussinessRoleHeadle();
           BussRoleObj.Init();

            //参数设置
            _SysparaConfigObj= new SysParaMySqlDA().SelectConfigORByWdbh();

            //读取config.xml文件
            _Config = new ReadXmlConfig().Read();
        }

        private ConfigOR _Config = null;

        /// <summary>
        /// 从配置文件获取，网点编号OrgNo
        /// </summary>
        private void InitBankNo()
        {
            BankNo = ConfigurationManager.AppSettings["BankNo"];            
            playType = Convert.ToInt32(ConfigurationManager.AppSettings["playType"]);
            playSequence = ConfigurationManager.AppSettings["playSequence"];
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
                return "用户名或密码错误";//用户名或密码错误
            }
            WindowOR _winOR = new WindowMySqlDA().SelectWindowByNo(windowid);
            if (_winOR == null)
            {
                return string.Format("窗口号：{0}不存在", windowid);
            }

            WindowLoginInfoOR _Log = GetLoginLog(userid, windowid);
            if (_Log == null)
            {
                //在内存中查询用户是否已经登录
                WindowLoginInfoOR _LoginRecordEmp = GetLoginLogByEmployeeNo(userid);
                if (_LoginRecordEmp != null && isHaveLoginInfo(_LoginRecordEmp))
                {
                    return string.Format("用户:{0}已经登录",userid);//用户已经登录
                }

                WindowLoginInfoOR _LoginRecordWin = GetLoginLogByWindowNo(windowid);
                if (_LoginRecordWin != null && isHaveLoginInfo(_LoginRecordWin))
                {
                    return string.Format("此窗口号：{0}已登录",windowid);//此窗口已登录
                }
            }
            else
            {
                if(isHaveLoginInfo(_Log))
                {
                    return string.Format("用户:{0},窗口号：{1}已经登录", userid, windowid);
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
                _Login.BussinessRoleOn = BussRoleObj.GetBussinessRoleOn(_empOR, _winOR);
                _WindowLoginDA.InsertLoginWindowInfo(_Login);//写入数据库
                ListWindowLogins.Add(_Login);
                

            }
            catch (Exception ex)
            {
                return ex.Message; //写入数据库出错。
            }
            return "0";
        }
        private bool isHaveLoginInfo(WindowLoginInfoOR _Log)
        {
            int timeLen = GetTimeLen(_Log.GetDataTime, DateTime.Now);
            if (timeLen > 60)
            {
                _Log.Status = 1;
                _WindowLoginDA.UpdateLoginStatus(_Log);
                ListWindowLogins.Remove(_Log);
                return false;
            }
            return true;
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
                WindowOR _win=GetAWindow(windowid);

                _winLog.Status = 1;
                _WindowLoginDA.EndServer(_winLog);
                ListWindowLogins.Remove(_winLog);

                HDDA.Instance.TpShowSuspendedRestore(4, _win.tpAddress, _win);
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

                WindowOR _win = GetAWindow(windowNo);
                HDDA.Instance.TpShowSuspendedRestore(3, _win.tpAddress, _win);
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

                WindowOR _win = GetAWindow(windowNo);
                HDDA.Instance.TpShowSuspendedRestore(4, _win.tpAddress, _win);
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
        /// 获取所有业务队业,根据用户登录窗口处理它们可以办理的队列
        /// </summary>
        /// <returns></returns>
        public List<BussinessQueueOR> getQueuesByWindow(string windowID)
        {
           WindowLoginInfoOR _loginWin= GetLoginLogByWindowNo(windowID);
           if (_loginWin == null)
               return null;
           _loginWin.GetDataTime = DateTime.Now;
           List<BussinessQueueOR> list = new List<BussinessQueueOR>();
            if (QhQueues != null)
            {
                foreach (var v in QhQueues)
                {
                    if (BussRoleObj.BussinessIsEnableHeadle(_loginWin.BussinessRoleOn, v.Id,ListWindowLogins))
                    {
                        BussinessQueueOR obj = new BussinessQueueOR();
                        obj.Init(v);
                        obj.InitNumber();
                        obj.BussQueues = v.GetCurrentQueues(windowID);
                        //v.InitNumber();
                        list.Add(obj);
                    }
                }
            }
            return list;
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

        public int GetBussinessWiatUser(string BussinessID)
        {
            int mWaitpeopleBussiness=0;
            int mWaitBank=0;

            GetWaitPeople(BussinessID, out mWaitpeopleBussiness, out mWaitBank);
            return mWaitpeopleBussiness;
        }

        public EmployeeOR GetEmployeeInfo(string userID)
        {
            EmployeeMySqlDA _empDA = new EmployeeMySqlDA();
            EmployeeOR obj = _empDA.SelectAEmployee(userID);
            return obj;
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
            RemovePre(mWindowNo);
           
            QueueInfoOR mSelectQhObj=null;
            //先处理其它窗口过来的属况,即不用排队
            List<QueueInfoOR> mQueueTranseferList = new List<QueueInfoOR>();//转移排队列表
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                {
                    if (objQue.Transferdestwin == mWindowNo && objQue.Status <= 1)
                    {
                        //objQue.Status = 1;
                        mQueueTranseferList.Add(objQue);
                    }
                }
            }
            var vf = from ft in mQueueTranseferList orderby ft.Prillbilltime ascending select ft;
            if (vf.Count() > 0)
            {
                mQueueTranseferList = vf.ToList();
                mSelectQhObj = mQueueTranseferList[0];
            }
           
            //第二次遍历过程中，转移窗口号不为空且不等于呼叫窗口号的元素略过，更新所有元素的“换算后排队时间”（
            //更新时间，并将其移到一个数组中
            if (mSelectQhObj == null)
            {
                List<QueueInfoOR> mQueueList = new List<QueueInfoOR>();//排队列表
                foreach (BussinessQueueOR objQhQue in QhQueues)
                {
                    if (BussRoleObj.BussinessIsEnableHeadle(_winLogin.BussinessRoleOn, objQhQue.Id
                        ,ListWindowLogins))//判断此队列是否可以，办理
                    {
                        foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                        {
                            if (objQue.Status == 0 && objQue.Transferdestwin == "")//转移窗口不能为本窗口
                            //|| (objQue.Status == 1 && objQue.Windowno== mWindowNo)
                            //)//本窗口上次叫号
                            {
                                int TimeLen = GetTimeLen(objQue.Prillbilltime, DateTime.Now);
                                if (objQue.Delaytime > 0)
                                {
                                    int DelayToNowTimeLen = GetTimeLen(objQue.DelayDateTime, DateTime.Now);

                                    if (DelayToNowTimeLen < objQue.Delaytime)//如果延后时间未到，不参与排队取号
                                    {
                                        continue;
                                    }
                                }
                                Console.WriteLine("", objQue.VipFirstTime);
                                //根据角色增加优先时间
                                objQue.ConvertTimeLen = TimeLen
                                    + GetPriorTime(TimeLen, objQhQue)   //业务队列优先时间
                                    + objQue.VipFirstTime               //Vip优先时间
                                    + BussRoleObj.GetRoleFirstTimeLent(_winLogin.BussinessRoleOn, 
                                    objQue.Bussinessid)//处理,角色优先时间
                                    ;
                                mQueueList.Add(objQue);
                            }
                        }
                    }
                }
                var v= from f in mQueueList orderby f.ConvertTimeLen descending select f;
                mQueueList=v.ToList();// mQueueList.OrderBy(a => a.ConvertTimeLen  descending).ToList();
                string msg = string.Empty;
                foreach (QueueInfoOR obj in mQueueList)
                {
                    msg = obj.Billno;                  
                }

                if (mQueueList.Count > 0)
                    mSelectQhObj = mQueueList[0];

                mQueueList.Clear();
            }           

            if (mSelectQhObj != null)
            {
                //调查用硬件接口，呼叫
				string content = _Config.tp_8_show.Replace("*", mSelectQhObj.Billno)
					.Replace("#", mWindowNo);

				int mWidth = (_Config.tp_8_show.Length - 2) * 16
					+ (mSelectQhObj.Billno.Length + mWindowNo.Length) * 8;

				string result = HDDA.Instance.ShowTpMsg(_windOR.tpAddress, content,mSelectQhObj.Billno,mWindowNo,_windOR);//显示条屏信息
				if (result == "0")
				{
                    //更新数据库状态
                    mSelectQhObj.Status = 1;
                    mSelectQhObj.Waitinterval = GetTimeLen(mSelectQhObj.Prillbilltime
                        , DateTime.Now);
                    mSelectQhObj.Windowno = _windOR.Name;
                    mSelectQhObj.Employno = _winLogin.Employno;
                    mSelectQhObj.Employname = _winLogin.Employname;

					HDDA.Instance.PlayBill(mSelectQhObj.Billno, mWindowNo, _Config.volume);

					_QueueDA.UpdateCall(mSelectQhObj);
					return mSelectQhObj.Billno;
				}
				else
				{
					return string.Format("error:{0}", result);					
				}
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
            else if (objQH.Status == 2)
            {
                return "办理中。";
            }
            else if (objQH.Status == 3)
            {
                return "已办结！";
            }
            else if (objQH.Status == 1)//正确的重呼
            {
                objQH.ReCallNumber++;

                //重呼硬件接口
                string mWindowNo = objQH.Windowno;
                WindowOR mwinOR = GetAWindow(mWindowNo);
                if (mwinOR == null)
                {
                    return "窗口不存在！";
                }

                string content = _Config.tp_8_show.Replace("*", mBillNo)
                    .Replace("#", mWindowNo);

                int mWidth = (_Config.tp_8_show.Length - 2) * 16
                    + (mBillNo.Length + mWindowNo.Length) * 8;

                string result = HDDA.Instance.ShowTpMsg(mwinOR.tpAddress, content, mBillNo, mWindowNo, mwinOR);
                if (result == "0")
                {
                    HDDA.Instance.PlayBill(mBillNo, mWindowNo, _Config.volume);
                }
                return result;

                //return "0";
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
            objQH.DelayDateTime = DateTime.Now;
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
                return "参数错误！";
            string mBillNo = mparam.Substring(0, mindex);
            string targetWin = mparam.Substring(mindex + 2);

            QueueInfoOR objQH = GetQueueInfo(mBillNo);
            if (objQH == null)
                return string.Format("票号:{0} 不存在!",mBillNo);

			WindowOR _winOR = GetAWindow(targetWin);
            if (_winOR == null)
            {
                return string.Format("目标窗口：{0} 不存在", targetWin);//此窗口已登录
            }
            if (targetWin == objQH.Windowno)
            {
                return string.Format("您当前窗口为：{0},请输入其它窗口！",objQH.Windowno);
            }
            

            objQH.Transferdestwin = targetWin;
            objQH.Employno = "";
            objQH.Employname = "";
            objQH.Status = 1;
            objQH.Windowno = "";
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
            string mWindowGet = strArr[0];//窗口号，用于获取窗口,对象
            string mWindowNo = strArr[0].PadLeft(2,'0');//窗口号
            string mCallType = strArr[1];//呼叫类型
            string mBillNo = strArr[2];//票号

			if (mCallType == "客户")
			{
				QueueInfoOR objQH = GetQueueInfo(mBillNo);
				if (objQH == null)
					return string.Format("票号:{0} 不存在!", mBillNo);
				if (objQH.Status == 3)
				{
					return "此单号已办结";
				}

                WindowOR mwinOR = GetAWindow(mWindowGet);
				if (mwinOR == null)
					return "窗口不存在！";

				string content = _Config.tp_8_show.Replace("*", mBillNo)
					.Replace("#", mWindowNo);

                //int mWidth = (_Config.tp_8_show.Length - 2) * 16
                //    + (mBillNo.Length + mWindowNo.Length) * 8;

                string result = HDDA.Instance.ShowTpMsgSelf(mwinOR.tpAddress, content, mwinOR);
				if (result == "0")
				{
					HDDA.Instance.PlayBill(mBillNo, mWindowNo, _Config.volume);
				}
				return result;
				//呼号代码
			}
            else if (mCallType == "大堂经理")
            {
				return HDDA.Instance.PlaySpecial(mCallType, mWindowNo, _Config.volume);
            }
            else if (mCallType == "客户经理")
            {
				return HDDA.Instance.PlaySpecial(mCallType, mWindowNo, _Config.volume);
            }
            else if (mCallType == "保安")
            {
				return HDDA.Instance.PlaySpecial(mCallType, mWindowNo, _Config.volume);
            }
            else if (mCallType == "业务顾问")
            {
				return HDDA.Instance.PlaySpecial(mCallType, mWindowNo, _Config.volume);
            }
            else if (mCallType == "一米线")//参数三为，窗口号
            {
                WindowOR mWin = GetAWindow(mWindowGet);
                if (mWin == null)
                {
                    return "窗口号不存在！";
                }
                HDDA.Instance.SPECIAL_PJQ(3, mWin.pjqAddress);
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
				WindowOR _winOR = GetAWindow(objQH.Windowno);
				if (_winOR == null)
				{
					return string.Format("窗口：{0} 不存在", objQH.Windowno);
				}
				HDDA.Instance.SPECIAL_PJQ(1, _winOR.pjqAddress);

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
                //调用硬件:
                //请评价
				WindowOR _winOR = GetAWindow(objQH.Windowno);
				if (_winOR == null)
				{
					return string.Format("窗口：{0} 不存在", objQH.Windowno);
				}
				HDDA.Instance.PJ(_winOR.pjqAddress, mBillNo,objQH.Id);

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
            else if (TimeLen > obj.Waittime2)
            {
                return obj.Priortime2;
            }
            else if (TimeLen > obj.Waittime1)
            {
                return obj.Priortime1;
            }
            return 0;
        }
        /// <summary>
        /// 移出上一下
        /// </summary>
        /// <param name="windowNo"></param>
        private void RemovePre(string windowNo)
        {
            List<QueueInfoOR> ListRemoveQH = new List<QueueInfoOR>();
            foreach (BussinessQueueOR objQhQue in QhQueues)
            {
                foreach (QueueInfoOR objQue in objQhQue.BussQueues)
                {
                    if (objQue.Status == 1  && objQue.Windowno == windowNo)
                    {
                        ListRemoveQH.Add(objQue);
                    }
                }
                //移出重呼两次的记录
                if (ListRemoveQH.Count > 0)
                {
                    foreach (QueueInfoOR obj in ListRemoveQH)
                    {
                        obj.Status = 3;
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
        /// 取号，返回票号
        /// </summary>
        /// <param name="bussinessID"></param>
        /// <param name="mCardno"></param>
        /// <returns></returns>
        public string QH(string mbussinessID, string mCardno)
        {
            BussinessQueueOR _CurentBuss = GetBussiness(mbussinessID);
            if (_CurentBuss == null)
            {
                throw new Exception("获取业务队列失败！，无法取号。");
            }
            //这里需要处理：取号类型（直接，刷卡、直接刷卡） 办理时间
            string mErrorMsg = string.Empty;
            if (!CheckBussinessTime(_CurentBuss,out mErrorMsg))
            {
                return mErrorMsg;
            }
            try
            {
                string _BillNo = _CurentBuss.Prefix + GetBillNo(mbussinessID);

                int mWaitpeoplebusssiness = 0;
                int mWaitpeoplebank = 0;
                //int mCustemclass = 0;
                GetWaitPeople(mbussinessID, out  mWaitpeoplebusssiness, out mWaitpeoplebank);

                QueueInfoOR _qhOR = new QueueInfoOR(BankNo, _BillNo, mbussinessID, mCardno
                    , mWaitpeoplebusssiness, mWaitpeoplebank);//初使化取号
                _qhOR.VipFirstTime = 0;
                //处理vip优先时间
                if (!string.IsNullOrEmpty(mCardno))
                {
                    _qhOR.VipFirstTime = VipCardHeadObj.GetFirstTime(mCardno);
                }
                _QueueDA.QH(_qhOR);//将取号插入到数据库
                
                //插入到当前队列
                _CurentBuss.BussQueues.Add(_qhOR);

                //票号#业务名称#当前业务人数#当前网点人数
                string result= string.Format("{0}#{1}#{2}#{3}", _BillNo, _CurentBuss.Name,mWaitpeoplebusssiness,mWaitpeoplebank);
                if (HDDA.Instance.PrintSlip(result))
                {

                }
                return result;
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
        private string GetBillNo(string bussinessID)
        {
            int QueNumber = _QueueDA.GetQueueNumber(bussinessID);
            int nowNumber = QueNumber + 1;
            return nowNumber.ToString().PadLeft(4, '0');
        }

        /// <summary>
        /// 验证卡，有效性
        /// </summary>
        /// <param name="mCard"></param>
        /// <returns></returns>
        public bool ValidationCard(string mCard)
        {
            string mValidCardCode = _SysparaConfigObj.ValidCardCode;
            if (string.IsNullOrEmpty(mValidCardCode)
                || string.IsNullOrEmpty(mCard))
            {
                return true;
            }
            if (mValidCardCode.IndexOf(';') >= 0)
            {
                string[] arr = mValidCardCode.Split(';');
                foreach (string str in arr)
                {
                    if (str.Trim() == "")
                        continue;
                    if (Common.CardViald(mCard, str))
                        return true;
                }
            }
            else
            {
                if (Common.CardViald(mCard, mValidCardCode))
                    return true;
            }
            return false;
        }

        #region 时间验证
        /// <summary>
        /// 判断当前时间是否可以办理
        /// </summary>
        /// <returns></returns>
        private bool CheckBussinessTime(BussinessQueueOR _buss, out string mErrorMsg)
        {
            bool isEnable = false;
            string headTime = string.Empty;
            string WeekShow = "";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday://星期一
                    isEnable = _buss.Mondayflag;
                    headTime = _buss.Mondaytime;
                    WeekShow = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    isEnable = _buss.Tuesdayflag;
                    headTime = _buss.Tuesdaytime;
                    WeekShow = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    isEnable = _buss.Wednesdayflag;
                    headTime = _buss.Wednesdaytime;
                    WeekShow = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    isEnable = _buss.Thurdayflag;
                    headTime = _buss.Thurdaytime;
                    WeekShow = "星期四";
                    break;
                case DayOfWeek.Friday:
                    isEnable = _buss.Fridayflag;
                    headTime = _buss.Fridaytime;
                    WeekShow = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    isEnable = _buss.Saturdayflag;
                    headTime = _buss.Saturdaytime;
                    WeekShow = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    isEnable = _buss.Sundayflag;
                    headTime = _buss.Sundaytime;
                    WeekShow = "星期日";
                    break;
            }
            mErrorMsg = "";
            if (!isEnable)
            {
                mErrorMsg = string.Format("Error:业务：{1},{0}不能办理。", _buss.Name, WeekShow);
                return false;
            }
            //判断时间判断
            if (string.IsNullOrEmpty(headTime))
                return true;
            string[] timeArr=headTime.Split(';');

            if (timeArr.Length >= 3)
            {
                if (string.IsNullOrEmpty(timeArr[0]) && string.IsNullOrEmpty(timeArr[1]))
                    return true;

                if (!VaildTime(timeArr[0], timeArr[1], out  mErrorMsg))
                {
                    return false;
                }
                
            }
            return true;
        }

        private bool VaildTime(string strTime1, string strTime2, out string mErrorMsg)
        {
            DateTime dtStart, dtEnd, dtZW;
            string useTime = string.Empty;
            string strSXW = "上午";
            dtZW = CombinTime("12", "30");
            if (DateTime.Now < dtZW)
            {
                useTime = strTime1;
            }
            else
            {
                useTime = strTime2;
                strSXW = "下午";
            }

            mErrorMsg = "";
            if (string.IsNullOrEmpty(useTime))
                return true;

            if (strTime1.Length == 4)
            {
                dtStart = CombinTime(useTime.Substring(0, 2),
                    useTime.Substring(2, 2));
                if (dtStart > DateTime.Now)
                {
                    return true;
                }
                mErrorMsg = string.Format("Error:{0}开始办理时间{1}:{2}", strSXW, useTime.Substring(0, 2),
                    useTime.Substring(2, 2));
            }
            else if (useTime.Length == 8)
            {
                dtStart = CombinTime(useTime.Substring(0, 2),
                     useTime.Substring(2, 2));
                dtEnd = CombinTime(useTime.Substring(4, 2),
                     useTime.Substring(6, 2));

                if (DateTime.Now>dtStart && DateTime.Now < dtEnd)
                    return true;
                mErrorMsg = string.Format("Error: {0}开始办理时间{1}:{2}到{3}:{4}", strSXW, useTime.Substring(0, 2), useTime.Substring(2, 2)
                    , useTime.Substring(4, 2),useTime.Substring(6, 2));
            }
            return false;
        }

        private DateTime CombinTime(string hh,string mm)
        {
            return Convert.ToDateTime(
                string.Format("{0} {1}:{2}:00",DateTime.Now.ToString("yyyy-MM-dd")
                , hh, mm));
        }



        #endregion
        #endregion

        #region 取号图片
        /// <summary>
        /// 查询图片配置
        /// </summary>
        /// <returns></returns>
        public string GetClientValue(string strKey)
        {
            QhImgSetDA _da = new QhImgSetDA();
            return _da.GetValue(strKey);
        }

        /// <summary>
        /// 添加或修改图片配置
        /// </summary>
        /// <param name="mImgName"></param>
        /// <returns></returns>
        public string UpdateImgPassword(string mImgName, string newpwd)
        {
            QhImgSetDA _da = new QhImgSetDA();
            try
            {
                _da.UpdateImgPassword(mImgName, newpwd);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "0";
        }
        #endregion

        #region 设备处理
        /// <summary>
        /// 查询所有设备
        /// </summary>
        /// <returns></returns>
        public List<DeviceOR> GetAllDevices()
        {
            return new DeviceDAMySql().SelectAllDevices();
        }


        /// <summary>
        /// 更新设备状态
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public bool UpdateDeviceSatus(string ID, int Status)
        {
            return new DeviceDAMySql().UpdateDeviceStatus(ID, Status);
        }

        #endregion

		/// <summary>
		/// 返回配置文件，实体
		/// </summary>
		/// <returns></returns>
		public ConfigOR GetXMLConfig()
		{
			return _Config;
		}

    }
}