using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSoft.Core.Model;
using System.Windows;

namespace QSoft.Core.ViewModel
{
    internal class MainViewModel : EntityObject
    {
        #region 变量

        private static readonly MainViewModel _instance = new MainViewModel();

        private readonly DelegateCommand<string> _command;

        #endregion

        #region 属性

        public static MainViewModel Instance {get{return _instance;}}

        public DelegateCommand<string> Command { get { return _command; } }

        #endregion

        #region 构造函数

        private MainViewModel()
        {
            _command = new DelegateCommand<string>(Excute, CanExcute);
        }

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        private bool CanExcute(string parameter)
        {
            return true;
        }

        private void Excute(string parameter)
        {
            MessageBox.Show(string.Format("执行按钮命令[{0}]., 查找关键字[cba]添加功能", parameter));
        }



        #endregion
    }
}
