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
using System.Collections.ObjectModel;
using ButtomDefin.WCFSV;
using System.Windows.Browser;

namespace ButtomDefin
{
    public partial class PageWinButtomAdmin : UserControl
    {
        ButtomAdmin _ButtomControl;
        private string _WDBH = string.Empty;

        public ObservableCollection<PageWinOR> PageWinORList { get; set; }
        public PageWinButtomAdmin()
        {
            InitializeComponent();

            _WDBH = "";
            if (HtmlPage.Document.QueryString.Count > 0)
                _WDBH = HtmlPage.Document.QueryString["wdbh"];
            if (string.IsNullOrEmpty(_WDBH))
            {
                ShowMsg("无法获取参数！");
                return;
            }

            _ButtomControl = new ButtomAdmin() { CBottom = CBottom };
            
        }

        public void Init()
        {
            PageWinORList = Common.ListPageWin;
            this.DataContext = this;

            if (Common.ListPageWin != null && Common.ListPageWin.Count > 0)
            {
                cbWinPage.SelectedItem = Common.ListPageWin.First();
                LoadButtomList();
                this.MouseLeftButtonUp += new MouseButtonEventHandler(Main_MouseLeftButtonUp);
            }
        }

        #region 加载按钮
        /// <summary>
        /// 加载选择窗口页的按钮
        /// </summary>
        private void LoadButtomList()
        {
            try
            {
                PageWinOR obj = cbWinPage.SelectedItem as PageWinOR;

                var v = DAL.WCF.GetQueueButtom();
                v.GetBottomListAsync(_WDBH, obj.Id);
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
                listButtom.Clear();
                CBottom.Children.Clear();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        protected void Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MainPage._Instanse.IsDown)
            {
                PageWinOR objPageWin = cbWinPage.SelectedItem as PageWinOR;

                Point position = e.GetPosition(CBottom);
                ButtomControl bc = _ButtomControl.InitAddPosition(position, this._WDBH);
                bc.ButtomOR.Windowid = objPageWin.Id;
                listButtom.Add(bc);
                MainPage._Instanse.IsDown = false;
            }
        }

        ObservableCollection<ButtomControl> listButtom = new ObservableCollection<ButtomControl>();
        private void btnSave_Click(object sender, EventArgs e)
        {
            var v = DAL.WCF.GetQueueButtom();
            v.UpdateBottomAsync(listButtom);
            v.UpdateBottomCompleted += (obj, result) =>
            {
                if (result.Result)
                {
                    CBottom.Children.Clear();
                    LoadButtomList();

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
            MessageBox.Show(msg, "提示", MessageBoxButton.OK);
        }
        
        private void cbWinPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadButtomList();
             PageWinOR objPageWin = cbWinPage.SelectedItem as PageWinOR;
             CBottom.Width = objPageWin.Width;
             CBottom.Height = objPageWin.Height;
        }
    }
}
