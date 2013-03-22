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
using System.Collections.ObjectModel;
using QSoft.Core.Uitl;
using System.Windows.Interop;
using System.Configuration;

namespace QSoft.View
{
    /// <summary>
    /// SysSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SysSetWindow : MetroWindow
    {
        //初使化Key
        string InitHotKey = string.Empty;

        public SysSetWindow()
        {
            InitializeComponent();
            InitSet();
        }
        /// <summary>
        /// 值是否已改变
        /// </summary>
        public bool IsChange{get;set;}
        /// <summary>
        /// 热键设置
        /// </summary>
        public string HotKeySet { get; set; }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> keys = new List<string>();
            
            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) ||
              e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            {
                keys.Add("Ctrl");
            }

            if (e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt))
            {
                keys.Add("Alt");
            }

            if (e.KeyboardDevice.IsKeyDown(Key.LeftShift) ||
                e.KeyboardDevice.IsKeyDown(Key.RightShift))
            {
                keys.Add("Shift");
            }

            if (keys.Count == 0)
                return;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < keys.Count; i++)
            {
                if (i > 0)
                    sb.Append("+");
                sb.Append(keys[i]);
            }

            string mkey = string.Empty;
            int mKeyInit = (int)e.Key;
            if ((mKeyInit >= 44 && mKeyInit <= 69) ||
                (mKeyInit >= 90 && mKeyInit <= 102))
                mkey = e.Key.ToString();
            else if (mKeyInit >= 34 && mKeyInit <= 43)
                mkey = e.Key.ToString().Replace("D", "");
            else
                return;

            sb.Append("+");
            sb.Append(mkey);

            txtKey.Text = sb.ToString();
            //MessageBox.Show(msg);// msg+=e.
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string strKey = txtKey.Text;
            if (string.IsNullOrEmpty(strKey))
            {
                ShowErrorMsg("请输入热键。");
                return;
            }
            
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings["HotKey"].Value = strKey;
            cfg.Save();
           
            //得新设置HotKey
            if (InitHotKey != strKey)
            {
                this.HotKeySet = strKey;
                IsChange = true;
            }
            this.Close();
        }

        private void InitSet()
        {
            string strHotkey = ConfigurationManager.AppSettings["HotKey"];
            if (string.IsNullOrEmpty(strHotkey))
            {
                ShowErrorMsg("配置文件错误！");
                this.Close();
                return;
            }
            txtKey.Text = strHotkey;
            InitHotKey = strHotkey;
        }

        private void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
   
}
