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
    /// Delay.xaml 的交互逻辑
    /// </summary>
    public partial class Delay : MetroWindow
    {
        public Delay()
        {
            InitializeComponent();
            this.Loaded += Delay_Loaded;
            this.DataContext = this;
        }
        private void Delay_Loaded(object sender, RoutedEventArgs e)
        {
            txtDelay.Focus();
        }
        bool _isOK=false;
        /// <summary>
        /// 是否正确返回
        /// </summary>
        public bool IsOK { get { return _isOK; } }

        int _DelayNumber = 10;
        /// <summary>
        /// 
        /// </summary>
        public int DelayNumber
        {
            get { return _DelayNumber; }
            set { _DelayNumber = value; }
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //if (Validation.GetHasError(txtDelay))
            //{
            //    return;
            //}
            string txtValue = txtDelay.Text;
            if (!int.TryParse(txtValue, out _DelayNumber))
            {
                this.MessageTextBlock.Text = "输入时间错误！";
                return;
            }
            if (_DelayNumber <= 0)
            {
                this.MessageTextBlock.Text = "请输入大于0的时间延后(分钟)！";
                return;
            }
            if (_DelayNumber > 120)
            {
                this.MessageTextBlock.Text = "输入延后时间太大啦！";
                return;
            }
            _isOK = true;
            this.Close();
        }
    }
}
