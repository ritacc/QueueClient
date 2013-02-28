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

namespace QSoft
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            var loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                InitializeComponent();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.CommandParameter.ToString() == "Pause")
            {
                PauseButtonTextBlock.Text = "恢复";
                button.CommandParameter = "Resume";
                PauseButtonImage.Source = new BitmapImage(new Uri(@"Resources/Images/resume.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                PauseButtonTextBlock.Text = "暂停";
                button.CommandParameter = "Pause";
                PauseButtonImage.Source = new BitmapImage(new Uri(@"Resources/Images/pause.png", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
