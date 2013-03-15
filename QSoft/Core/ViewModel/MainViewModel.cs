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

namespace QSoft.Core.ViewModel
{
    public class MainViewModel : EntityObject
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
        #endregion

        public void Clear()
        {
            QueuesInfo[1].BussQueues=null;
        }

        #region 构造函数

        private MainViewModel()
        {
            _command = new DelegateCommand<string>(Excute);//, CanExcute);

            InitData();
        }

        #endregion

        #region 业务队列-排队处理
        /// <summary>
        /// 加载业务队列数据
        /// </summary>
        private void InitData()
        {
            QueuesInfo = new ObservableCollection<BussinessQueueOR>();
            using (var client = new QueueClientSoapClient())
            {
                var v = client.getQueue();
                foreach (var obj in v)
                {
                    AddBussiness(obj);
                }
            }
        }

        private void AddBussiness(BussinessQueueOR obj)
        {
            if (isHaveAddObj(obj))
            {
                
            }
            else
            {
                QueuesInfo.Add(obj);
            }
            
        }

        private bool isHaveAddObj(BussinessQueueOR obj)
        {
            foreach (var v in QueuesInfo)
            {
                if (v.ID == obj.ID)
                {
                    return true;
                }
            }
            return false;
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
                sysSet.ShowDialog();
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
                        return;
                    }
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
                    case "TRANSFER":
                        CallTransfer();
                        break;
                    case "SPECALL":
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
        private void CallReCall()
        {
            if (string.IsNullOrEmpty(_NowBillNo))
            {
                ShowErrorMsg("请先呼叫用户！");
                return;
            }
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall("RECALL", _NowBillNo);
                if (value != "0")
                {
                    ShowErrorMsg(value);
                }
            }
        }
        private void CallDelay() { ShowErrorMsg(""); }
        private void CallTransfer() { ShowErrorMsg(""); }
        private void CallSpecall() { ShowErrorMsg(""); }

        /// <summary>
        /// 欢迎
        /// </summary>
        private void CallWelcome()
        {
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall("WELCOME", _NowBillNo);
                if (value != "0")
                {
                    ShowErrorMsg(value);
                }
            }
        }
        /// <summary>
        /// 请评价
        /// </summary>
        private void CallJudge()
        {
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall("JUDGE", _NowBillNo);
                if (value != "0")
                {
                    ShowErrorMsg(value);
                }
            }
        }
        /// <summary>
        /// 暂停
        /// </summary>
        private void CallPause()
        {
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall("PAUSE", GlobalData.WindowNo);
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
        }
        /// <summary>
        /// 恢复
        /// </summary>
        private void CallRestart()
        {
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall("RESTART", GlobalData.WindowNo);
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
        }

        /// <summary>
        /// 呼叫下一位	CALL	空串
        /// </summary>
        private void CallGetNext()
        {
            using (var client = new QueueClientSoapClient())
            {
                string value = client.getCall("CALL", GlobalData.WindowNo);
                if (value.IndexOf("error:") >= 0)
                {
                    ShowErrorMsg(value);
                    return;
                }
                _NowBillNo = value;
            }
        }
        #endregion

        #endregion
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
