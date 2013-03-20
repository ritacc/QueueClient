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

namespace QSoft.View
{
    /// <summary>
    /// CustomInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomInfoWindow : Window
    {
        private static CustomInfoWindow _instnace;

        public static CustomInfoWindow Instance
        {
            get
            {
                if (null == _instnace)
                {
                    _instnace = new CustomInfoWindow();
                    _instnace.Show();
                }
                return _instnace;
            }
        }

        private CustomInfoWindow()
        {
            InitializeComponent();
            this.Owner = Application.Current.MainWindow;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _instnace = null;
        }
    }
}
