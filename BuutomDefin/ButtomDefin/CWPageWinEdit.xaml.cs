using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace ButtomDefin
{
    public partial class CWPageWinEdit : ChildWindow
    {
        string WDBH = "";
        public CWPageWinEdit()
        {
            InitializeComponent();

            WDBH = "";
            if (HtmlPage.Document.QueryString.Count > 0)
                WDBH = HtmlPage.Document.QueryString["wdbh"];
            if (string.IsNullOrEmpty(WDBH))
            {
                ShowMsg("无法获取参数！");
                this.DialogResult = true;
                return;
            }
        }
        public WindowAdmin Owener { get; set; }
        /// <summary>
        /// 操作类型,0：添加;1 修改
        /// </summary>
        public int OpType { get; set; }
        public WCFSV.PageWinOR UpdatePage { get; set; }

        private WCFSV.PageWinOR _PageWinInfo;

        public void Init()
        {
            txtName.Text = UpdatePage.Name;
            txtWidth.Text = UpdatePage.Width.ToString();
            txtHeight.Text = UpdatePage.Height.ToString();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _PageWinInfo = new WCFSV.PageWinOR();
                if (OpType == 0)
                {                    
                    _PageWinInfo.Id = Guid.NewGuid().ToString();
                    _PageWinInfo.Orgbh = WDBH;
                }
                else
                {
                    _PageWinInfo.Id = UpdatePage.Id;
                }
                int mwidth = 0;
                int mheight = 0;
                string ErrorMsg = "";
                if (!int.TryParse(txtWidth.Text, out mwidth))
                {
                    ErrorMsg = "请输入正确的宽度！\r\n";
                }

                if (mwidth <= 0)
                {
                    ErrorMsg = "窗口长必须大于0\r\n";
                }
                if (!int.TryParse(txtHeight.Text, out mheight))
                {
                    ErrorMsg = "请输入正确的高度！\r\n";
                }
                if (mheight <= 0)
                {
                    ErrorMsg = "窗口宽必须大于0\r\n";
                }
                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    ShowMsg(ErrorMsg);
                    return;
                }

                _PageWinInfo.Name = txtName.Text;
                _PageWinInfo.Width = mwidth;
                _PageWinInfo.Height = mheight;

                var v = DAL.WCF.GetQueueButtom();
                if (OpType == 0)
                {
                    v.InsertPageWinAsync(_PageWinInfo);
                    v.InsertPageWinCompleted += new EventHandler<WCFSV.InsertPageWinCompletedEventArgs>(v_InsertCompleted);
                }
                else
                {
                    v.UpdatePageWinAsync(_PageWinInfo);
                    v.UpdatePageWinCompleted+=new EventHandler<WCFSV.UpdatePageWinCompletedEventArgs>(v_UpdatePageWinCompleted);
                }
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }

        }

        public void v_UpdatePageWinCompleted(object sender, WCFSV.UpdatePageWinCompletedEventArgs e)
        {
            if (e.Result)
            {
                UpdatePage.Name = _PageWinInfo.Name;
                UpdatePage.Width = _PageWinInfo.Width;
                UpdatePage.Height = _PageWinInfo.Height;
                this.DialogResult = true;
            }
            else
            {
                ShowMsg("修改失败！");
            }
        }
        protected void v_InsertCompleted(object sender, WCFSV.InsertPageWinCompletedEventArgs ee)
        {
            if (ee.Result)
            {
                Owener.AddData(_PageWinInfo);
                this.DialogResult = true;
            }
            else
            {
                ShowMsg("添加失败！");
            }            
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}

