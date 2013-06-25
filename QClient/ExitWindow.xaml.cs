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
using System.ComponentModel;

namespace QClient
{
    /// <summary>
    /// ExitWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExitWindow : Window
    {
        public ExitWindow()
        {
            InitializeComponent();
        }

        private string _InputValue;
        public string InputValue
        {
            get { return _InputValue; }
            set
            {
                _InputValue = value;
                NotifyPropertyChanged("InputValue");
            }
        }
        public bool IsOK { get; set; }
        private void btnButtom_Click(object sender, RoutedEventArgs e)
        {
            InputValue += (sender as Button).Content;
            txtValue.Password = InputValue;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputValue))
                return;
           InputValue= InputValue.Substring(0, InputValue.Length - 1);
           txtValue.Password = InputValue;

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if ((this.Owner as MainWindow).Userpsw == txtValue.Password)
            {
                IsOK = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误。", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnCanncel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // INotifyPropertyChanged 成员
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 实现属性更改通知
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
