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
    /// CustomDetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomDetailWindow : Window
    {
        public IEnumerable<Asset> Assets { get; set; }
        public CustomDetailWindow()
        {
            InitializeComponent();
            Assets = CreateData();
            this.DataContext = Assets;
        }

        private IEnumerable<Asset> CreateData()
        {
            yield return new Asset("个人贷款", 123400d);
            yield return new Asset("信用卡违章", 56400d);
            yield return new Asset("保证金", 9200d);
            yield return new Asset("理财", 100000d);
            yield return new Asset("借记卡", 4999d);
        }
    }

    public class Asset
    {
        public string Class { get; set; }
        public double Fund { get; set; }

        public Asset(string @class, double fund)
        {
            Class = @class;
            Fund = fund;
        }
    }
}
