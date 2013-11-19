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
using System.Windows.Data;
using System.Collections.ObjectModel;
using ButtomDefin.WCFSV;

namespace ButtomDefin
{
    public partial class WindowAdmin : ChildWindow
    {
        public ObservableCollection<WCFSV.PageWinOR> ListDA { get; set; }
       //PagedCollectionView PageView { get; set; }
        public WindowAdmin()
        {
            InitializeComponent();
            //ListDA = new ObservableCollection<WCFSV.PageWinOR>();
            ListDA = Common.ListPageWin;
            this.DataContext = this;
           
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CWPageWinEdit medit = new CWPageWinEdit()
            {
                Owener = this,
                OpType = 0
            };
            medit.Show();
        }

        public void AddData(PageWinOR obj)
        {
            ListDA.Add(obj);
        }

        private void btnAlert_Click(object sender, RoutedEventArgs e)
        {
            var v = gdDataList.SelectedItem;
            if (v == null)
            {
                ShowMsg("请选择窗口页！");
                return;
            }
            if (v is WCFSV.PageWinOR)
            {
                CWPageWinEdit medit = new CWPageWinEdit()
                {
                    Owener = this,
                    OpType = 1,
                    UpdatePage = (v as WCFSV.PageWinOR)
                };
                medit.Init();
                medit.Show();
            }
        }

        PageWinOR DeleteObj = new PageWinOR();
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var v = gdDataList.SelectedItem as PageWinOR;
            if (v == null)
            {
                ShowMsg("请选择窗口页！");
                return;
            }
            if (MessageBox.Show(string.Format("您确定要删除:‘{0}’ 吗？",v.Name), "提示", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            {
                return;
            }
            
                DeleteObj = v ;
                var vwcf = DAL.WCF.GetQueueButtom();
                vwcf.DeletepageWinAsync(DeleteObj.Id);
                vwcf.DeletepageWinCompleted += new EventHandler<DeletepageWinCompletedEventArgs>(vwcf_DeletepageWinCompleted);
            
        }

        private void vwcf_DeletepageWinCompleted(object sender, DeletepageWinCompletedEventArgs e)
        {
            ListDA.Remove(DeleteObj);
        }

        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButton.OK);
        }

    }
}

