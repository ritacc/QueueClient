using MahApps.Metro.Controls;
using System.Windows;

namespace QClient
{
    /// <summary>
    /// frmImgSet.xaml 的交互逻辑
    /// </summary>
    public partial class frmImgSet : MetroWindow
    {
        public frmImgSet()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
