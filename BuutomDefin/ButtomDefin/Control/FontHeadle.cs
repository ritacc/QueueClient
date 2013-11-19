using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ButtomDefin.Control
{
    public class FontHeadle
    {
        static string[] StrArr = {"隶书",
"幼圆",
"舒体",
"姚体",
"楷体",
"宋体",
"中宋",
"仿宋",
"彩云",
"琥珀",
"行楷",
"新魏",
"细黑" };

        public static void InitCombox(ComboBox cb)
        {
            cb.Items.Clear();
            cb.ItemsSource = StrArr;
            
        }
    }
}
