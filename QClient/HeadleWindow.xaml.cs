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

namespace QClient
{
    /// <summary>
    /// HeadleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HeadleWindow : Window
    {
        public HeadleWindow()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            frmImgSet fset = new frmImgSet();
            fset.Owner = this;
            fset.ShowDialog();
        }
        
    }
}
