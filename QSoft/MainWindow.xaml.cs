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
using MahApps.Metro.Controls;
using QSoft.View;
using QSoft.Core.ViewModel;
using QSoft.QueueClientServiceReference;
using QSoft.Core.Model;

namespace QSoft
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        internal MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            var loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                InitializeComponent();
                ViewModel = MainViewModel.Instance;
                ViewModel.MianPage = this;
                this.DataContext = ViewModel;

            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Clear();
        }

        private void lbItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement)
            {
                var element = e.OriginalSource as FrameworkElement;
                if (element.DataContext is QueueInfoOR)
                {
                    var queueInfo = element.DataContext as QueueInfoOR;
                    CustomInfoWindow.Instance.DataContext = new Custom() { DisplayName = "未识别", Business = MainViewModel.Instance.Businesses.First(c => queueInfo.Bussinessid == c.Id).Name, CustomType = "未识别", ServiceLevel = "未识别" };
                }
            }
        }
    }
}
