using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QClient.Core.ViewModel;
using QClient.QueueClinetServiceReference;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows.Threading;
using System.Threading;
using System.Runtime.InteropServices;
using QClient.Core.Util;

namespace QClient
{
    /// <summary>
    /// <!--WindowState="Maximized"-->
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ButtomAdmin _buttonAdmin = new ButtomAdmin();
        public ObservableCollection<BussinessQueueOR> BussinessList { get; set; }
        /// <summary>
        /// 参数设置
        /// </summary>
        public static SysParamConfigOR _SysParaConfigObj { get; set; }
        public static MainWindow _Instance { get; set; }

        public ShutdownTimeOR _ShutdownTimeObj;
        public MainWindow()
        {
            InitializeComponent();
            _buttonAdmin.CBottom = MainCanvas;
            _Instance = this;
            if (Init())
            {
                this.Loaded += MainWindow_Loaded;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public BussinessQueueOR GetBussinessByID(string id)
        {
            if (BussinessList == null)
                return null;
            foreach (BussinessQueueOR obj in BussinessList)
            {
                if (obj.Id == id)
                    return obj;
            }
            return null;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitBackImg();
        }

        private void InitBackImg()
        {
            string imgName = WebViewModel.Instance.GetQhImgName();
            if (string.IsNullOrEmpty(imgName))
            {
                imgName = "background.jpg";
            }

            string mPath = Common.GetStartpath() + "Resources\\Images\\"+ imgName;
            if (System.IO.File.Exists(mPath))
            {
                ImageBrush img = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(mPath,UriKind.Absolute))
                };
                this.Background = img;
            }
        }

        /// <summary>
        /// 退出密码
        /// </summary>
        public string Userpsw { get; set; }
        Thread thHDandPJQ;
        DeviceCheckHead _HDHead;
        private bool Init()
        {
            try
            {
                BussinessList = new ObservableCollection<BussinessQueueOR>();
                var v = WebViewModel.Instance.GetQueues();
                foreach (BussinessQueueOR obj in v)
                {
                    BussinessList.Add(obj);
                }

                //获取退出密码
                Userpsw = ImgSetViewModel.Instance.GetPwd();
                if (string.IsNullOrEmpty(Userpsw))
                    Userpsw = "ABCabc123";

                //参数设置
                using (var client = new QueueClientSoapClient())
                {
                    _SysParaConfigObj = client.GetSysParamConfigOR();
                    _ShutdownTimeObj = client.SelectShutdownTime();
                }

                if (_ShutdownTimeObj != null)
                {
                    //MessageBox.Show(_ShutdownTimeObj.Mondaytime);
                    ShutDownInit();
                }
                //处理、硬件信息
                _HDHead=new DeviceCheckHead();

                thHDandPJQ = new Thread(_HDHead.HDMain);
                thHDandPJQ.IsBackground = true;
                thHDandPJQ.Start();
            }
            catch (EndpointNotFoundException exEnd)
            {
                ShowErrorMsg("配置Web服务不存在！");
                return false;
            }
            catch (Exception ex)
            {
                ShowErrorMsg("获取业务类型出错：Webservice未启动，或配置错误！\r\n详细信息：" + ex.Message);
                return false;
            }

            LoadButton(string.Empty);
            return true;
        }
        #region 自动关机处理
        private void ShutDownInit()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            if (_ShutdownTimeObj == null) return;
            string strShutdownTime = string.Empty;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday://星期一
                    strShutdownTime = _ShutdownTimeObj.Mondaytime;
                    break;
                case DayOfWeek.Tuesday:
                    strShutdownTime = _ShutdownTimeObj.Tuesdaytime;
                    break;
                case DayOfWeek.Wednesday:
                    strShutdownTime = _ShutdownTimeObj.Wednesdaytime;
                    break;
                case DayOfWeek.Thursday:
                    strShutdownTime = _ShutdownTimeObj.Thurdaytime;
                    break;
                case DayOfWeek.Friday: 
                    strShutdownTime = _ShutdownTimeObj.Fridaytime;
                    break;
                case DayOfWeek.Saturday:
                    strShutdownTime = _ShutdownTimeObj.Saturdaytime;
                    break;
                case DayOfWeek.Sunday:
                    strShutdownTime = _ShutdownTimeObj.Sundaytime;
                    break;
            }
            if (string.IsNullOrEmpty(strShutdownTime))
                return;
            if (strShutdownTime.Length == 4)
            {
                string hh = strShutdownTime.Substring(0, 2);
                string mm = strShutdownTime.Substring(2);
                if (DateTime.Now.Hour == Convert.ToInt32(hh)
                    && DateTime.Now.Minute == Convert.ToInt32(mm))
                {
                    //关机
                    //Thread th = new Thread(ShutDown);
                    //th.Start();
                }
            }
        }

        [DllImport("user32")]
        public static extern long ExitWindowsEx(long uFlags, long dwReserved);

        long dwReserved=0;
        const int SHUTDOWN = 1;
        const int REBOOT = 2;
        const int LOGOFF = 0;
 
        //private void ShutDown()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        MainWindow.ExitWindowsEx(SHUTDOWN, dwReserved);
        //        Thread.Sleep(5000);
        //    }
        //}
        #endregion
        private void LoadButton(string windowId)
        {
            MainCanvas.Children.Clear();
            QhandyOR[] qhandies=null;
            try
            {
                qhandies = WebViewModel.Instance.GetButtonsByPageWinId(windowId);
            }
            catch (Exception ex)
            {
                ShowErrorMsg("获取按钮配置数据出错啦，可能出现原因：Webservice未启动，或配置错误！\r\n详细信息：" + ex.Message);
                Application.Current.Shutdown();
                return;
            }
            foreach (var qhandy in qhandies)
            {
                ButtomControl mbc = new ButtomControl();
                mbc.OpType = 1;
                mbc.ID = Guid.NewGuid().ToString();
                mbc.ButtomOR = qhandy;
                var bc = _buttonAdmin.AddAButtom(mbc);
            }

            Thread thRefB = new Thread(_buttonAdmin.RefButtomWaitNumber);
            thRefB.IsBackground = true;
            thRefB.Start();

            //处理退出
            this.MouseLeftButtonUp += new MouseButtonEventHandler(rc_MouseLeftButtonUp);
        }
        int ClickNumber = 0;
        DateTime dtClick = DateTime.Now;
        protected void rc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            Console.WriteLine(string.Format("x={0},y={1}", p.X, p.Y));
            if (p.X < 50 && p.Y < 50)
            {
                TimeSpan ts = dtClick - DateTime.Now;
                if (ts.Hours == 0 && ts.Minutes == 0 && ts.Seconds == 0 && ts.Milliseconds <= 1000)
                    ClickNumber++;
                else
                    ClickNumber = 1;
                dtClick = DateTime.Now;
                if (ClickNumber >= 2)
                {
                    //测试代码，关机
                    //ShutDown();

                    ClickNumber = 0;
                    ExitWindow ew = new ExitWindow();
                    ew.Owner = this;
                    ew.ShowDialog();
                    if (ew.IsOK)//密码成功
                    {
                        HeadleWindow hw = new HeadleWindow();
                        hw.Owner = this;
                        hw.ShowDialog();
                    }
                }
            }
        }

        #region 公共方法
        

        public void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        #endregion

        
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement)
            {
                var element = e.OriginalSource as FrameworkElement;
                int Contickettime = Convert.ToInt32(_SysParaConfigObj.Contickettime);

                if (element.DataContext is QhandyOR)
                {
                    var qhandy = element.DataContext as QhandyOR;
                    BussinessQueueOR _CureentObj = null;
                    if (!qhandy.Buttomtype)
                    {
                         _CureentObj = GetBussinessByID(qhandy.LabelJobno);
                    }
                    WebViewModel.Instance.ButtomQH(element, this, Contickettime, _CureentObj);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (thHDandPJQ != null)
                thHDandPJQ.Abort();
        }
    }
}
