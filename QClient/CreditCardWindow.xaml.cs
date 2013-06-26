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
using System.Windows.Threading;
using System.ComponentModel;
using QClient.QueueClinetServiceReference;
using QClient.Core.ViewModel;
using System.Threading;

namespace QClient
{
    /// <summary>
    /// CreditCardWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CreditCardWindow : Window
    {
        DispatcherTimer disTime = new DispatcherTimer();
        public CreditCardWindow( TickModth mTickType= TickModth.QHSK)
        {
            InitializeComponent();
            IsOK = false;

            ShowMsg = "请刷卡…";

            int popTimeLent = Convert.ToInt32(MainWindow._SysParaConfigObj.Popswiptime);
            TimeLen = popTimeLent;

            if (mTickType == TickModth.SK)//刷卡
            {
                btnButtom.Visibility = Visibility.Collapsed;
            }
            
            TimeSpan ts = new TimeSpan(0, 0, 1);
            disTime.Interval = ts;
            disTime.IsEnabled = true;
            disTime.Tick+=new EventHandler(disTime_Tick);

            this.DataContext = this;
            lblTime.Text = TimeLen.ToString();

            Thread th = new Thread(HeadCard);
            th.Start();
        }

        public bool IsOK { get; set; }

        public string ShowMsg { set { lblMsg.Text = value; } }

        int _TimeLen = 15;
        public int TimeLen { get { return _TimeLen; } set { _TimeLen = value; NotifyPropertyChanged("TimeLen"); } }

        protected void disTime_Tick(object sender, EventArgs e)
        {
            TimeLen = TimeLen - 1;
            lblTime.Text = TimeLen.ToString();
            if (TimeLen <= 0)
                this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            disTime.IsEnabled = false;
        }

        private void btnButtom_Click(object sender, RoutedEventArgs e)
        {
            IsOK = true;
            this.Close();
        }

        #region 获取卡号
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        #endregion

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
        //读取号卡号处理
        private void HeadCard()
        {
            string mCard = ImgSetViewModel.Instance.ReadCard();
            if (mCard == "")
            {
                return;
            }

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate()
            {
                if (CheckCard(mCard))
                {
                    IsOK = true;
                    CardNo = mCard;
                    this.Close();
                }
                else
                {
                    ShowMsg = MainWindow._SysParaConfigObj.Invalidcardinfo;
                }
            });
        }
        private bool CheckCard(string mCard)
        {
            using (var client = new QueueClientSoapClient())
            {
               return client.ValidationCard(mCard);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeadCard();
        }
    }

   
    public enum TickModth
    {
        /// <summary>
        /// 刷卡
        /// </summary>
        SK,
        /// <summary>
        /// 取号或刷卡
        /// </summary>
        QHSK
    }
}
