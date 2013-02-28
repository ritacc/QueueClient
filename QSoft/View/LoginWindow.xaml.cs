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
using MahApps.Metro.Controls;

namespace QSoft.View
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.Loaded += LoginWindow_Loaded;
        }

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameTextBox.Focus();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var userName = UserNameTextBox.Text.Trim();
            var password = PasswordBox.Password;
            MessageTextBlock.Text = string.Empty;
            MessageTextBlock.Foreground = Brushes.Red;
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageTextBlock.Text = "* 请输入用户名";
                UserNameTextBox.Focus();
            }
            else if (password.Length == 0)
            {
                PasswordBox.Focus();
            }
            else if (Login(userName, password))
            {
                MessageTextBlock.Text = "登录成功，正在加载数据...";
                MessageTextBlock.Foreground = Brushes.Blue;
                this.DialogResult = true;
                Close();
            }
            else
            {
                MessageTextBlock.Text = "* 用户名或密码不正确.";
            }

        }

        private bool Login(string userName, string password)
        {
            return new Random().Next(10) > 3;
        }
    }
}
