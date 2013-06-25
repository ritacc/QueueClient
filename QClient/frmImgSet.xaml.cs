using MahApps.Metro.Controls;
using System.Windows;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;
using System.ServiceModel.Configuration;
using QClient.QueueClinetServiceReference;
using System.ServiceModel.Channels;
using System.ServiceModel;
using QClient.Core.Util;
using QClient.Core.ViewModel;
using System;

namespace QClient
{
    /// <summary>
    /// frmImgSet.xaml 的交互逻辑
    /// </summary>
    public partial class frmImgSet : MetroWindow
    {
        private string InitPathName = string.Empty;

        public string Userpsw { get; set; }

        public frmImgSet()
        {
            InitializeComponent();
            try
            {
                InitPathName = ImgSetViewModel.Instance.GetImgSetPath();
                Userpsw = ImgSetViewModel.Instance.GetPwd();

                txtFileName.Text = InitPathName;
            }
            catch (EndpointNotFoundException exEnd)
            {
                ShowErrorMsg("配置Web服务不存在！");
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                ShowErrorMsg("获取配置信息出错！\r\n详细信息："+ ex.Message);
                Application.Current.Shutdown();
            }
            this.DataContext = this;
        }

        private void ShowErrorMsg(string errmsg)
        {
            MessageBox.Show(errmsg, "出错啦！");
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                ShowErrorMsg("请选择背景图片！");
                return;
            }

            string mPath = Common.GetStartpath() + "Resources\\Images\\" + txtFileName.Text;
            if (!System.IO.File.Exists(mPath))
            {
                ShowErrorMsg(string.Format("文件:{0}不存在！", mPath));
                return;
            }
            //if (InitPathName == txtFileName.Text.Trim())//未修改直接返回
            //{
            //    Application.Current.Shutdown();
            //    return;
            //}
            try
            {
                string Result = ImgSetViewModel.Instance.SetImgPathPassword(txtFileName.Text, this.Userpsw);
               if (Result == "0")
               {
                   Application.Current.Shutdown();
               }
               else
               {
                   ShowErrorMsg(Result);
               }
            }
            catch (Exception ex)
            {
                ShowErrorMsg(ex.Message);
            }
        }

        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           // Application.Current.Shutdown();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            string mPath = Common.GetStartpath() + "Resources\\Images\\";
            OpenFileDialog mopenFile = new OpenFileDialog();
            mopenFile.Filter = "图像文件(*.jpg,*.png)|*.jpg;*.png";
            mopenFile.Multiselect = false;
            mopenFile.InitialDirectory = mPath;

            if (mopenFile.ShowDialog().Value)
            {
                txtFileName.Text = mopenFile.SafeFileName;
            }

        }
    }
}
