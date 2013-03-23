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

namespace QSoft.View
{
    /// <summary>
    /// Transfer.xaml 的交互逻辑
    /// </summary>
    public partial class Transfer : Window
    {
        public Transfer()
        {
            InitializeComponent();
            this.Loaded += Delay_Loaded;
            this.DataContext = this;
        }
        private void Delay_Loaded(object sender, RoutedEventArgs e)
        {
            txtTargetWindow.Focus();
        }
        bool _isOK = false;
        /// <summary>
        /// 是否正确返回
        /// </summary>
        public bool IsOK { get { return _isOK; } }

        string _TargetNmber = "";
        /// <summary>
        /// 
        /// </summary>
        public string TargetWinNmber
        {
            get { return _TargetNmber; }            
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string txtValue = txtTargetWindow.Text;
            if (string.IsNullOrEmpty(txtValue))
            {
                this.MessageTextBlock.Text = "请输入目标窗口号！";
                return;
            }

            _TargetNmber = txtValue;
            _isOK = true;
            this.Close();
        }
    }
}
