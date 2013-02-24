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

        #endregion
    }
}
