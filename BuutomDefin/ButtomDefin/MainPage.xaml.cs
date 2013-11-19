using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ButtomDefin.Control;
using ButtomDefin.WCFSV;
using System.Collections.ObjectModel;
using System.Windows.Browser;

namespace ButtomDefin
{
    public partial class MainPage : UserControl
    {

        private string _WDBH = string.Empty;

        public static ObservableCollection<WCFSV.YWOR> ListYw = new ObservableCollection<YWOR>();
        ButtomAdmin _ButtomControl;// = new ButtomAdmin() {  CBottom= cbu };
        /// <summary>
        /// 网点编号
        /// </summary>
        //public string WDBH
        //{
        //    get { return _WDBH; }
        //    set { _WDBH = value; }
        //}
        public static MainPage _Instanse{get;set;}
        public MainPage()
        {
            InitializeComponent();
            //按钮控制
            _ButtomControl = new ButtomAdmin() {  CBottom= CBottom };

            _Instanse = this;
            //因为拖动，处理样式
            drapDropListBox.BorderBrush = new SolidColorBrush();
            fromListBox.BorderBrush = new SolidColorBrush();
            fromListBox.Background = new SolidColorBrush();
            lbitem.Background = new SolidColorBrush();
            fromListBox.MouseLeave += (sender, e) => { fromListBox.SelectedIndex = -1; };

            _WDBH = "";
            if (HtmlPage.Document.QueryString.Count > 0)
                _WDBH = HtmlPage.Document.QueryString["wdbh"];
            if (string.IsNullOrEmpty(_WDBH))
            {
                ShowMsg("无法获取参数！");
                return;
            }
            
            //加载业务数据
            LoadYWList();
            LoadWdDataList();
            LoadPageWin();
           
        }
        object LockObj = new object();
        int CompleteNumber = 0;
        public void LoadCompleteInit()
        {
            lock (LockObj)
            {
                CompleteNumber++;
            }
            if (CompleteNumber == 3)
            {
                //拖动按钮处理 移动上来处理
                CBottom.MouseLeftButtonUp += new MouseButtonEventHandler(CBottom_MouseLeftButtonUp);
                btn.MouseLeftButtonDown += new MouseButtonEventHandler(btn_MouseLeftButtonDown);
                this.MouseLeftButtonUp += new MouseButtonEventHandler(Main_MouseLeftButtonUp);
                this.SizeChanged += new SizeChangedEventHandler(TankView_SizeChanged);
                tbWait.IsBusy = false;
            }
        } 
        #region 实例化加载数据
        #region 加载数据页窗口
        /// <summary>
        /// 加载当前网点页面窗口
        /// </summary>
        private void LoadPageWin()
        {
            Common.ListPageWin = new ObservableCollection<PageWinOR>();

            var v = DAL.WCF.GetQueueButtom();
            v.GetPageWinSAsync(_WDBH);
            v.GetPageWinSCompleted += new EventHandler<GetPageWinSCompletedEventArgs>(v_GetPageWinSCompleted);
        }

        private void v_GetPageWinSCompleted(object sender, GetPageWinSCompletedEventArgs e)
        {
            ObservableCollection<PageWinOR> list = e.Result;
            foreach (PageWinOR obj in list)
            {
                Common.ListPageWin.Add(obj);
            }
            LoadCompleteInit();
        }
        #endregion

		#region 加载按钮

        private void LoadWdDataList()
        {
            try
            {
                var v = DAL.WCF.GetQueueButtom();
                v.GetBottomListAsync(_WDBH,"");
                v.GetBottomListCompleted += new EventHandler<WCFSV.GetBottomListCompletedEventArgs>(v_GetBottomListCompleted);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        protected void v_GetBottomListCompleted(object sender, WCFSV.GetBottomListCompletedEventArgs ee)
        {
            try
            {
                var list = ee.Result;
                foreach (WCFSV.QhandyOR obj in list)
                {
                    ButtomControl mbc = new ButtomControl();
                    mbc.OpType = 1;
                    mbc.ID = Guid.NewGuid().ToString();
                    WCFSV.QhandyOR mButtom = new WCFSV.QhandyOR();
                    mButtom = _ButtomControl.Init(mButtom, this._WDBH);
                    mbc.ButtomOR = obj;
                    listButtom.Add(mbc);

                    _ButtomControl.AddAButtom(mbc);
                }
                if (list.Count > 0)
                {
                    SetScreen(list.First());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadCompleteInit();
        }
		#endregion


        /// <summary>
        /// 加载业务数据
        /// </summary>
        private void LoadYWList()
        {
            try
            {
                var v = DAL.WCF.GetQueueButtom();
                v.GetYWListAsync(_WDBH);
                v.GetYWListCompleted += new EventHandler<WCFSV.GetYWListCompletedEventArgs>(v_GetYWListCompleted);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        protected void v_GetYWListCompleted(object sender, WCFSV.GetYWListCompletedEventArgs ee)
        {
            try
            {
                ListYw = ee.Result;
                LoadCompleteInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion

        private void TankView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            svRoom.Height = e.NewSize.Height - 35;
            svRoom.Width = e.NewSize.Width;
        }

       public bool IsDown = false;

        protected void Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsDown = false;
        }
        protected void btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsDown = true;
        }


        ObservableCollection<ButtomControl> listButtom = new ObservableCollection<ButtomControl>();
        protected void CBottom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsDown)
            {
                Point position = e.GetPosition(CBottom);
                listButtom.Add(_ButtomControl.InitAddPosition(position, this._WDBH));
            }
        }
        #region 数据处理
        private void SetScreen(QhandyOR obj)
        {
            string strSize = ScreenHeadle.GetScreenSize(obj.Screentype);
            cbScreen.SelectedIndex = obj.Screentype;
            SetScreenSize(strSize);
        }

        private void SetScreenSize(string strSize)
        {
            string[] strInt = strSize.Split('*');
            
            if (strInt.Length == 2)
            {
                CBottom.Width = Convert.ToDouble(strInt[0]);
                CBottom.Height = Convert.ToDouble(strInt[1]);
            }
        }
        #endregion

        private void btnFullS_Click(object sender, EventArgs e)
        {
            btnFull.ImageSource = "../Images/btn/exitqp.png";
            Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
        }

        /// <summary>
        /// 窗口管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWindowAdmin_Click(object sender, EventArgs e)
        {
            WindowAdmin winAdmin = new WindowAdmin();
            winAdmin.Show();
        }

        private void btnPageWinButtoms_Click(object sender, EventArgs e)
        {
            if (!FPPageWinAdmin.IsOpened)
            {
                FPPageWinAdmin.IsOpened = true;
                (FPPageWinAdmin.Child as PageWinButtomAdmin).Init();
                //CWPageWin.Owener = this;
                //CWPageWin.Init();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (ButtomControl bc in listButtom)
            {
                bc.ButtomOR.Screentype = cbScreen.SelectedIndex;
            }
            var v = DAL.WCF.GetQueueButtom();
            v.UpdateBottomAsync(listButtom);
            v.UpdateBottomCompleted += (obj, result) =>
            {
                if (result.Result)
                {
                    CBottom.Children.Clear();
                    LoadWdDataList();

                    ShowMsg("提交成功！");
                }
                else
                {
                    ShowMsg("修改失败！");
                }
            };
        }

        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg,"提示", MessageBoxButton.OK);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            HtmlWindow html = HtmlPage.Window;
            html.Navigate(new Uri("ButtomAdminList.aspx", UriKind.Relative));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strSize = ScreenHeadle.GetScreenSize(cbScreen.SelectedIndex);
           
            SetScreenSize(strSize);
        }

        #region 页窗口管理
        public void SetPageWinPanleSize(Size mSize)
        {
            FPPageWinAdmin.Width = mSize.Width;
            FPPageWinAdmin.Height = mSize.Height;
        }

        #endregion

    }
}
