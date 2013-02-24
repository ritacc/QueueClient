using QClient.Core.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace QClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        #region 重载方法

        protected override void OnStartup(StartupEventArgs e)
        {
            // 设置日志类
            LoggerFactory.SetLoggerInstance(typeof(WriteFileLogger));

            base.OnStartup(e);
        }

        #endregion 重载方法
    }
}
