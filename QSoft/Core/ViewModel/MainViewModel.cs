using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSoft.Core.Model;
using System.Windows;
using QSoft.QueueClientServiceReference;
using System.Windows.Media.Imaging;
using QSoft.View;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace QSoft.Core.ViewModel
{
    internal class MainViewModel : EntityObject
    {
        #region 属性

        private static readonly MainViewModel _instance = new MainViewModel();
        public static MainViewModel Instance { get { return _instance; } }

        private readonly DelegateCommand<string> _command;
        public DelegateCommand<string> Command { get { return _command; } }

        private string _NowBillNo = string.Empty;
        /// <summary>
        /// 当前票号
        /// </summary>
        public string NowBillNo { get { return _NowBillNo; } }

        /// <summary>
        /// 当前用户状态
        /// </summary>
        EmployeeStatus _NowEmployeeStaus = EmployeeStatus.Normal;

        /// <summary>
        /// 业务队列，排队信息
        /// </summary>
        public ObservableCollection<BussinessQueueOR> QueuesInfo { get; set; }

        MainWindow _Page;
        
        /// <summary>
        /// 主页，用于切换
        /// </summary>
        public MainWindow MianPage { set { _Page = value; } }

        SysParamConfigOR _SysParaConfigObj;
        #endregion

       

        #region 构造函数

        private MainViewModel()
        {
            _command = new DelegateCommand<string>(Excute);//, CanExcute);
            //
            using (var client = new QueueClientSoapClient())
            {
                _SysParaConfigObj = client.GetSysParamConfigOR();
            }

            InitData();

            //刷新队列
            //定时更新值
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        #endregion

        #region 业务队列-排队处理

        protected void timer_Tick(object sender, EventArgs e)
        {
            RefQueues();
        }

        /// <summary>
        /// 加载业务队列数据
        /// </summary>
        private void InitData()
        {
            QueuesInfo = new ObservableCollection<BussinessQueueOR>();

            var v = GetBussinessList();
            if (v != null)
            {
                foreach (var obj in v)
                {
                    QueuesInfo.Add(obj);
                }
            }
        }

        private BussinessQueueOR[] GetBussinessList()
        {
            using (var client = new QueueClientSoapClient())
            {
                var v = client.getQueuesByWindow(GlobalData.WindowNo);
                return v;
            }
        }
     

        /// <summary>
        /// 刷新队队信息
        /// </summary>
        /// <param name="obj"></param>
        private void RefQueues()
        {
            bool mIsChange = false;
            BussinessQueueOR[] vBusiness=null;
            try
            {
                vBusiness = GetBussinessList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            //Console.WriteLine("查询到队列：{0},缓存队列：{1}", vBusiness.Count(), QueuesInfo.Count);
            //移出
            if (vBusiness != null && vBusiness.Count() > 0)
            {
                List<BussinessQueueOR> listDelete = new List<BussinessQueueOR>();
                foreach (BussinessQueueOR obj in QueuesInfo)
                {
                    if (!BussinessIsExists(obj.Id, vBusiness))
                    {
                        listDelete.Add(obj);
                    }
                }
                if (listDelete.Count > 0)
                {
                    foreach (BussinessQueueOR obj in listDelete)
                    {
                        if (!IsCurrentBussiness(obj.Id))//应办理队列已不能办理，并切不是当前队列，就移出
                        {
                            QueuesInfo.Remove(obj);
                        }
                    }
                }


                //处理修改信息
                foreach (var mBuss in vBusiness)
                {
                    BussinessQueueOR mCatchBussQue = GetBussinessQueueOR(mBuss.Id);
                    if (mCatchBussQue != null)
                    {
                        if (isChange(mBuss.BussQueues, mCatchBussQue.BussQueues))
                        {
                            mCatchBussQue.QueueNumber = mBuss.QueueNumber;
                            mCatchBussQue.BussQueues = mBuss.BussQueues;
                            mIsChange = true;
                        }
                    }
                    else
                    {
                        this.QueuesInfo.Add(mBuss);
                    }
                }
                if (mIsChange)
                {
                    SetCurrentQueue(_NowBillNo);
                    Console.WriteLine("参数修改");
                }
            }
        }

        private bool BussinessIsExists(string id, BussinessQueueOR[] list)
        {
            foreach (var v in list)
            {
                if (v.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断队列是否改变
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private bool isChange(QueueInfoOR[] list1, QueueInfoOR[] list2)
        {
            if (list1 == null && list2 == null)
                return false;
            else if (list1 == null || list1 == null)//两者不同
                return true;
            else if (list1.Count() == 0 && list2.Count() == 0)
                return false;
            else if (list1.Count() != list2.Count())//两者不同
                return true;
            else
            {
                foreach (var v in list1)
                {
                    if (!IsExists(v.Billno, list2))//list1 的无素在list2中不存在
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsExists(string billno, QueueInfoOR[] list)
        {
            foreach (QueueInfoOR obj in list)
            {
                if (obj.Billno == billno)
                {
                    return true;
                }
            }
            return false;
        }


        private BussinessQueueOR GetBussinessQueueOR(string mBussinessID)
        {
            foreach (var v in QueuesInfo)
            {
                if (v.Id == mBussinessID)
                {
                    return v;
                }
            }
            return null;
        }

        #endregion

        #region 显示客户信息

        private readonly Custom _empty = new Custom() { DisplayName = "暂无客户", Business = string.Empty, };

        /// <summary>
        /// 保存当前选中的客户信息
        /// </summary>
        private Custom _custom;

        /// <summary>
        /// 获取或设置当前客户信息
        /// </summary>
        public Custom Custom { get { if (null == _custom) { _custom = _empty; } return _custom; } set { _custom = value; RaisePropertyChanged("Custom"); } }

        // 保存显示客户信息按钮
        private DelegateCommand _customDetailCommand;

        public DelegateCommand CustomDetailCommand
        {
            get
            {
                if (null == _customDetailCommand)
                {
                    _customDetailCommand = new DelegateCommand(ShowCustomInfo);
                }
                return _customDetailCommand;
            }
        }

        private void ShowCustomInfo()
        {
            //MessageBox.Show("详细信息，来自方法：" + System.Reflection.MethodInfo.GetCurrentMethod().Name);
            CustomDetailWindow window = new CustomDetailWindow();
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }

        #endregion

        #region 公共方法
        private void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion

        #region 私有方法

        #region 按钮事件
        private void Excute(string parameter)
        {
            if (parameter == "Setting")
            {
                SysSetWindow sysSet = new SysSetWindow();
                sysSet.Owner = this._Page;
                sysSet.ShowDialog();
                if (sysSet.IsChange)
                {
                    this._Page.HeadHotkey(sysSet.HotKeySet);
                }
            }
            else if (parameter == "Stop")
            {
                StopServer();
            }
            else
            {
                if (_NowEmployeeStaus != EmployeeStatus.Normal)
                {
                    if (parameter != "RESTART")
                    {
                        ShowErrorMsg("请先恢复！");
                        return;
                    }
                }
                if (string.IsNullOrEmpty(_NowBillNo) &&
                    (parameter == "RECALL" || parameter == "DELAY" || parameter == "TRANSFER"
                   || parameter == "WELCOME" || parameter == "JUDGE" ))
                {
                    ShowErrorMsg("请先呼号客户!");
                    return;
                }
                switch (parameter)
                {
                    case "CALL":
                        CallGetNext();
                        break;
                    case "RECALL":
                        CallReCall();
                        break;
                    case "DELAY": //延后 增加了一个票号 (票号##时长)
                        CallDelay();
                        break;
                    case "TRANSFER"://转移 票号##目标窗口号
                        CallTransfer();
                        break;
                    case "SPECALL"://窗口号##呼号类型#票号
                        CallSpecall();
                        break;
                    case "WELCOME":
                        CallWelcome();
                        break;
                    case "JUDGE":
                        CallJudge();
                        break;
                    case "PAUSE":
                        CallPause();
                        break;
                    case "RESTART":
                        CallRestart();
                        break;
                }
                //MessageBox.Show(string.Format("执行按钮命令[{0}]., 查找关键字[cba]添加功能", parameter));
            }
        }

        /// <summary>
        /// 结束服务
        /// </summary>
        private void StopServer()
        {
            if (MessageBox.Show("确定要退出系统吗？","提示",MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            using (var client = new QueueClientSoapClient())
            {
                string msg = client.endService(GlobalData.UserID, GlobalData.WindowNo);
                if (msg == "0")
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    ShowErrorMsg(msg);
                }
            }
        }
        
        /// <summary>
        /// 调用呼号接口
        /// </summary>
        /// <param name="mType"></param>
        /// <param name="mParameter"></param>
        /// <returns></returns>
        private string GetCall(string mType, string mParameter)
        {
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall(mType, mParameter);
                return value;
            }
        }

        /// <summary>
        /// 延后
        /// </summary>
        private void CallDelay()
        {
            Delay mObj = new Delay();
            mObj.Owner = this._Page;
            mObj.ShowDialog();
            if (mObj.IsOK)
            {
                string msg = GetCall("DELAY", string.Format("{0}##{1}", _NowBillNo, mObj.DelayNumber));
                if (msg == "0") {
                    CanncelCurrentQueue(_NowBillNo);
                    _NowBillNo = "";
                }
                else
                {
                    ShowErrorMsg(msg);
                }
            }
        }
        /// <summary>
        /// 转移
        /// </summary>
        private void CallTransfer()
        {
            Transfer frmTran = new Transfer();
            frmTran.Owner = this._Page;
            frmTran.ShowDialog();
            if (frmTran.IsOK)
            {
                string msg = GetCall("TRANSFER", string.Format("{0}##{1}", _NowBillNo, frmTran.TargetWinNmber));
                if (msg == "0") {
                    CanncelCurrentQueue(_NowBillNo);
                    _NowBillNo = "";
                }
                else
                {
                    ShowErrorMsg(msg);
                }
            }
        }
        /// <summary>
        /// 特呼
        /// </summary>
        private void CallSpecall()
        {
            Specall frmSpe = new Specall();
            frmSpe.Owner = this._Page;
            frmSpe.ShowDialog();
            if (frmSpe.IsOK)
            {
                string msg = GetCall("SPECALL", string.Format("{0}##{1}##{2}",
                    GlobalData.WindowNo, frmSpe.CallType, frmSpe.BillNo));
                if (msg == "0") {
                    if (frmSpe.CallType == "客户")
                    {
                        SetCurrentQueue(frmSpe.BillNo);
                    }
                }
                else
                {
                    ShowErrorMsg(msg);
                }
            }
        }

        DateTime lastCallTime = DateTime.Now;
        /// <summary>
        /// 呼叫下一位	CALL	空串
        /// </summary>
        private void CallGetNext()
        {
            int TimeLen = GetTimeLen(lastCallTime, DateTime.Now);
            int Calllimittime = Convert.ToInt32(_SysParaConfigObj.Calllimittime);
            if (TimeLen < Calllimittime && Calllimittime > 0)
            {
                ShowErrorMsg(string.Format("叫号时间间隔不能小于：{0}秒。", _SysParaConfigObj.Calllimittime));
                return;
            }
            string value = GetCall("CALL", GlobalData.WindowNo);
            RefQueues();
            if (value.IndexOf("error:") >= 0)
            {
                ShowErrorMsg(value);
                return;
            }
            lastCallTime = DateTime.Now;
            this.SetCurrentQueue(value);
        }
        //Calllimittime
        /// <summary>
        /// 重呼
        /// </summary>
        private void CallReCall()
        {
            string value = GetCall("RECALL", _NowBillNo);
            //if (value == "1")
            //{
            //    RefQueues();
            //}else
            if (value != "0")
            {
                ShowErrorMsg(value);
            }
        }
        /// <summary>
        /// 欢迎
        /// </summary>
        private void CallWelcome()
        {
            string value = GetCall("WELCOME", _NowBillNo);
            if (value != "0")
            {
                ShowErrorMsg(value);
            }
        }

        /// <summary>
        /// 请评价
        /// </summary>
        private void CallJudge()
        {
            string value = GetCall("JUDGE", _NowBillNo);
            if (value != "0")
            {
                ShowErrorMsg(value);
            }
            else
            {
                RefQueues();
            }
        }
        /// <summary>
        /// 暂停
        /// </summary>
        private void CallPause()
        {
           
                string value = GetCall("PAUSE", GlobalData.WindowNo);
                if (value != "0")
                {
                    ShowErrorMsg(value);
                    return;
                }
                else
                {
                    _Page.PauseButtonTextBlock.Text = "恢复";
                    _Page.btnPauseReStart.CommandParameter = "RESTART";
                    _Page.PauseButtonImage.Source = new BitmapImage(new Uri(@"Resources/Images/resume.png", UriKind.RelativeOrAbsolute));

                    _NowEmployeeStaus = EmployeeStatus.Pause;
                }
           
        }
        /// <summary>
        /// 恢复
        /// </summary>
        private void CallRestart()
        {

            string value = GetCall("RESTART", GlobalData.WindowNo);
            if (value != "0")
            {
                ShowErrorMsg(value);
            }
            else
            {
                _Page.PauseButtonTextBlock.Text = "暂停";
                _Page.btnPauseReStart.CommandParameter = "PAUSE";
                _Page.PauseButtonImage.Source = new BitmapImage(new Uri(@"Resources/Images/pause.png", UriKind.RelativeOrAbsolute));
                _NowEmployeeStaus = EmployeeStatus.Normal;
            }
        }
        #endregion

        #region 当前处理
        /// <summary>
        /// 是否是：当前队列
        /// </summary>
        /// <param name="BussinessID"></param>
        /// <returns></returns>
        private bool IsCurrentBussiness(string BussinessID)
        {
            if (QueuesInfo != null)
            {
                foreach (BussinessQueueOR obj in QueuesInfo)
                {
                    if (obj.Id == BussinessID)
                    {
                        foreach (QueueInfoOR queObj in obj.BussQueues)
                        {
                            if (queObj.Billno == _NowBillNo)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void SetCurrentQueue(string QhBH)
        {
            if (QueuesInfo != null)
            {
                foreach (BussinessQueueOR obj in QueuesInfo)
                {
                    foreach (QueueInfoOR queObj in obj.BussQueues)
                    {
                        if (queObj.Billno == QhBH)
                        {
                            if (_NowBillNo != QhBH)
                            {
                                _empty.DisplayName = QhBH;
                                _empty.Business = obj.Name;

                                CanncelCurrentQueue(_NowBillNo);
                                _NowBillNo = QhBH;
                            }

                            queObj.IsNowQueue = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 取消当前排队
        /// </summary>
        /// <param name="QhBH"></param>
        private void CanncelCurrentQueue(string QhBH)
        {
            if (QueuesInfo != null)
            {
                foreach (BussinessQueueOR obj in QueuesInfo)
                {
                    foreach (QueueInfoOR queObj in obj.BussQueues)
                    {
                        if (queObj.Billno == QhBH)
                        {
                            queObj.IsNowQueue = false;
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
        private int GetTimeLen(DateTime Start, DateTime EndTime)
        {
            int TimeLen = 0;
            TimeSpan t = EndTime - Start;
            TimeLen = (t.Hours * 60 * 60) + t.Minutes * 60 + t.Seconds;
            return TimeLen;
        }
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum EmployeeStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause
    }
}
