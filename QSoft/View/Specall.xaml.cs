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
    /// Specall.xaml 的交互逻辑
    /// </summary>
    public partial class Specall : Window
    {
        public Specall()
        {
            InitializeComponent();

            ShowOrHide(false);
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var v = cbType.SelectedItem as ComboBoxItem;
            if (v != null)
            {
               string  mtype= v.Content.ToString();
               if (mtype == "客户")
               {
                   ShowOrHide(true);
               }
               else
               {
                   ShowOrHide(false);
               }
            }
        }

        private void ShowOrHide(bool isShow)
        {
            if (isShow)
            {
                txtBillNo.Visibility = Visibility.Visible;
                tbCallType.Visibility = Visibility.Visible;
            }
            else
            {
                txtBillNo.Visibility = Visibility.Collapsed;
                tbCallType.Visibility = Visibility.Collapsed;
            }
        }
        bool _isOK = false;
        /// <summary>
        /// 是否正确返回
        /// </summary>
        public bool IsOK { get { return _isOK; } }

        string _CallType = string.Empty;
        /// <summary>
        /// 呼号类型
        /// </summary>
        public string CallType { get { return _CallType; } }

        string _BillNo = string.Empty;
        /// <summary>
        /// 客户，排队号
        /// </summary>
        public string BillNo
        {
            get { return _BillNo; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var v = cbType.SelectedItem as ComboBoxItem;
            _CallType = v.Content.ToString();
            if (_CallType == "客户")
            {
                _BillNo = txtBillNo.Text;
                if (string.IsNullOrEmpty(_BillNo))
                {
                    this.MessageTextBlock.Text = "请输入客户排除票号！";
                    return;
                }
            }
            _isOK = true;
            this.Close();
        }
    }
}
