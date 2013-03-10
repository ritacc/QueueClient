using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QClient.Core.Model;
using QClient.QueueClinetServiceReference;

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

        public PageWinOR GetPageWinById(string id)
        {
            if (_pageCahches.ContainsKey(id))
            {
                return _pageCahches[id];
            }

            using (var client = new QueueClientSoapClient())
            {
                var result = client.GetPageWinById(id);
                _pageCahches.Add(id, result);
                return result;
            }
        }

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
                if (result.IndexOf("error:") >= 0)//有错
                {
                    errorMsg = result;
                    return false;
                }
                //取号成功： result票号
                errorMsg = result;
                //打印票号
                return true;
            }

        }
        #endregion
    }
}
