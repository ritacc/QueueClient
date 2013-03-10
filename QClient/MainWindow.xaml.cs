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

namespace QClient
{
    /// <summary>
    /// <!--WindowState="Maximized"-->
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ButtomAdmin _buttonAdmin = new ButtomAdmin();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            _buttonAdmin.CBottom = MainCanvas;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            //MainCanvas.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            //MainCanvas.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            LoadButton(string.Empty);
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

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement)
            {
                var element = e.OriginalSource as FrameworkElement;
                if (element.DataContext is QhandyOR)
                {
                    var qhandy = element.DataContext as QhandyOR;
                    if (!qhandy.Buttomtype)
                    {
                        string mCard=string.Empty;
                        string mErrorMsg=string.Empty;
                        if(WebViewModel.Instance.QH(qhandy.LabelJobno,mCard,out mErrorMsg))
                        {
                            //成功不处理
                            MessageBox.Show(mErrorMsg);
                        }
                        else{

                            MessageBox.Show(mErrorMsg);
                        }
                    }
                    else
                    {
                        var pageWinOR = WebViewModel.Instance.GetPageWinById(qhandy.Windowonid);
                        PopupWindow pw = new PopupWindow(pageWinOR);
                        pw.Owner = Application.Current.MainWindow;
                        
                        double mWidht = pageWinOR.Width < 300 ? 300 : pageWinOR.Width;
                        double mHeight = pageWinOR.Height < 300 ? 300 : pageWinOR.Height;
                        pw.Width = mWidht;
                        pw.Height = mHeight;
                        pw.Name = pageWinOR.Name;
                        pw.ShowDialog();
                        //PopupWindow.Show();
                    }
                }
            }
        }
    }
}
