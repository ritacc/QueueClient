using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QClient.Core.Model;
using QClient.QueueClinetServiceReference;
using System.Windows;
using QClient.HD;

namespace QClient.Core.ViewModel
{
    internal class WebViewModel : EntityObject
    {
        #region 变量

        private static readonly WebViewModel _instance = new WebViewModel();

        private readonly Dictionary<string, PageWinOR> _pageCahches = new Dictionary<string, PageWinOR>();

        private readonly Dictionary<string, QhandyOR[]> _qhandyCaches = new Dictionary<string, QhandyOR[]>();

        #endregion

        #region 属性

        public static WebViewModel Instance { get { return _instance; } }

        #endregion

        #region 构造函数

        public WebViewModel()
        {
        }

        #endregion

        #region 公共方法
        public string GetQhImgName()
        {
            using (var client = new QueueClientSoapClient())
            {
                string imgName = client.GetClientValue("");
                return imgName;
            }
        }

        /// <summary>
        /// 获取页窗口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PageWinOR GetPageWinById(string id)
        {
            if (_pageCahches.ContainsKey(id))
            {
                return _pageCahches[id];
            }

            try
            {
                using (var client = new QueueClientSoapClient())
                {
                    var result = client.GetPageWinById(id);
                    _pageCahches.Add(id, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取数据出错啦，可能出现原因：Webservice未启动，或配置错误！\r\n详细信息：" + ex.Message); 
            }
        }

        /// <summary>
        /// 获取按钮，为空或页窗口ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QhandyOR[] GetButtonsByPageWinId(string id)
        {
             if (_qhandyCaches.ContainsKey(id))
            {
                return _qhandyCaches[id];
            }

            using (var client = new QueueClientSoapClient())
            {
                var result = client.GetButtonsByPageWinId(id);
                _qhandyCaches.Add(id, result);
                return result;
            }
        }

        /// <summary>
        /// 取号
        /// </summary>
        /// <param name="_qhjobNo">取号业务号</param>
        /// <param name="mCard">取号卡号</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns></returns>
        public bool QH(string  _qhjobNo,string mCard,out string errorMsg)
        {
            errorMsg = string.Empty;
            using (var client = new QueueClientSoapClient())
            {
                if (string.IsNullOrEmpty(_qhjobNo))
                {
                    errorMsg = "没有配置业务队列不能取号！";
                    return false;
                }

                var result = client.BussinessQH(_qhjobNo, mCard);

                if (result.ToLower().IndexOf("error:") >= 0)//有错
                {
                    errorMsg = result;
                    return false;
                }

                //ImgSetViewModel.Instance.PrintSlip(result);
                //取号成功： result票号
                errorMsg = result;
                //打印票号
                return true;
            }
        }

        public BussinessQueueOR[] GetQueues()
        {
            using (var client = new QueueClientSoapClient())
            {
               BussinessQueueOR[] list= client.getQueue();
               return list;
            }
        }
        #endregion
        public int GetTimeLen(DateTime Start, DateTime EndTime)
        {
            int TimeLen = 0;
            TimeSpan t = EndTime - Start;
            TimeLen = (t.Hours * 60 * 60) + t.Minutes * 60 + t.Seconds;
            return TimeLen;
        }
        public void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        DateTime LastGetTime = DateTime.Now.AddMinutes(-10);
        public void ButtomQH(FrameworkElement element, Window Owener, int Contickettime, BussinessQueueOR _CureentObj)
        {
            if (element.DataContext is QhandyOR)
            {
                var qhandy = element.DataContext as QhandyOR;
                if (!qhandy.Buttomtype)
                {
                    //连续取号限制
                    int TimeLen = GetTimeLen(LastGetTime, DateTime.Now);

                    if (TimeLen < Contickettime && Contickettime > 0)
                    {
                        ShowErrorMsg(string.Format("连续取号最短时间间隔不能小于：{0}秒。", Contickettime));
                        return;
                    }
                    LastGetTime = DateTime.Now;

                    //BussinessQueueOR _CureentObj = GetBussinessByID(qhandy.LabelJobno);
                    if (_CureentObj == null)
                    {
                        ShowErrorMsg("无法获取按钮业务类型。");
                        return;
                    }
                    string mCard = string.Empty;
                    if (_CureentObj.Ticketmethod != 2)
                    {
                        CreditCardWindow ccw = null;
                        if (_CureentObj.Ticketmethod == 1)
                        {
                            ccw = new CreditCardWindow(TickModth.SK);
                        }
                        else
                        {
                            ccw = new CreditCardWindow();
                        }
                        ccw.Owner = Owener;
                        ccw.ShowDialog();
                        if (!ccw.IsOK)
                        {
                            return;
                        }
                        mCard = ccw.CardNo;
                    }

                    string mErrorMsg = string.Empty;
                    if (WebViewModel.Instance.QH(qhandy.LabelJobno, mCard, out mErrorMsg))
                    {
                        //成功不处理
                       MessageBox.Show(mErrorMsg);
                    }
                    else
                    {
                        MessageBox.Show(mErrorMsg);
                    }
                }
                else
                {
                    var pageWinOR = WebViewModel.Instance.GetPageWinById(qhandy.Windowonid);
                    PopupWindow pw = new PopupWindow(pageWinOR);
                    pw.Owner = Application.Current.MainWindow;

                    double mWidht = pageWinOR.Width < 300 ? 300 : pageWinOR.Width;
                    double mHeight = pageWinOR.Height < 300 ? 300 : pageWinOR.Height;
                    pw.Width = mWidht;
                    pw.Height = mHeight;
                    pw.Name = pageWinOR.Name;
                    pw.ShowDialog();
                }
            }

        }
    }
}
