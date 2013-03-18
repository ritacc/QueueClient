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

namespace QSoft
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainViewModel ViewModel { get; set; }
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

       
    }
}
