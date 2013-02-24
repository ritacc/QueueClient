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

        //public List<object> GetPageWinById()
        //{
        //    using (QueueClinetServiceReference.QueueClientSoapClient client = new QueueClientSoapClient())
        //    {
        //    }
        //}

        #endregion
    }
}
