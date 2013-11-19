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
    /// <summary>
    /// 屏处理
    /// </summary>
    public class ScreenHeadle
    {
        public static string GetScreenSize(int index)
        {
            string[] StrScreen ={"800*600","1024*768","1152*864","1280*600","1280*720","1280*768",
                                    "1280*800","1280*960","1280*1024"};
            string strSize = "1024*768";
            for (int i = 0; i < StrScreen.Length; i++)
            {
                if (i == index)
                    strSize = StrScreen[i];
            }
            return strSize;
        }
    }
}
