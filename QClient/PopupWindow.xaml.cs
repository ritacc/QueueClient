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
using System.Windows.Shapes;
using QClient.Core.ViewModel;
using QClient.QueueClinetServiceReference;
using MahApps.Metro.Controls;

namespace QClient
{
    /// <summary>
    /// PopupWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PopupWindow : Window
    {
        private readonly ButtomAdmin _buttonAdmin = new ButtomAdmin();
        private readonly PageWinOR _pageWinOR;
        public PageWinOR PageWinOR { get { return _pageWinOR; } }
        
        public PopupWindow(PageWinOR pageWinOR)
        {
            if (null == pageWinOR)
            {
                throw new ArgumentNullException("pageWinOR 参数不能为null");
            }

            InitializeComponent();
            this.Width = pageWinOR.Width;
            this.Height = pageWinOR.Height;
            this.Loaded += MainWindow_Loaded;
            _buttonAdmin.CBottom = MainCanvas;
            _pageWinOR = pageWinOR;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            LoadButton(_pageWinOR.Id);
        }

        private void LoadButton(string windowId)
        {
            MainCanvas.Children.Clear();
            var qhandies = WebViewModel.Instance.GetButtonsByPageWinId(windowId);
            foreach (var qhandy in qhandies)
            {
                ButtomControl mbc = new ButtomControl();
                mbc.OpType = 1;
                mbc.ID = Guid.NewGuid().ToString();
                mbc.ButtomOR = qhandy;
                var bc = _buttonAdmin.AddAButtom(mbc);
            }
        }
        private void ShowErrorMsg(string errmsg)
        {
            MessageBox.Show(errmsg, "出错啦！");
        }

        DateTime LastGetTime = DateTime.Now;
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement)
            {
                var element = e.OriginalSource as FrameworkElement;
                if (element.DataContext is QhandyOR)
                {
                    var qhandy = element.DataContext as QhandyOR;
                    int Contickettime = Convert.ToInt32(MainWindow._SysParaConfigObj.Contickettime);
                    BussinessQueueOR _CureentObj = null;
                    if (!qhandy.Buttomtype)
                    {
                        _CureentObj = MainWindow._Instance.GetBussinessByID(qhandy.LabelJobno);
                    }
                    WebViewModel.Instance.ButtomQH(element, this, Contickettime, _CureentObj);  
                }
            }
        }

    }//end class
}
