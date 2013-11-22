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
using QClinet.Core.Util;
using QClient.Core.Util;
using System.Windows.Threading;
using System.Threading;


namespace QClient
{
    public class ENLableControl : UserControl
    {

        
        TextBlock tb = new TextBlock();
        public ENLableControl()
        {
            SetTextInfo();
            this.Content = tb;
        }
        public void SetText(string Content)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate()
            {
                tb.Text = Content;
            });
        }
        public void SetTextInfo()
        {
            if (this.Tag != null)
            {
                if (this.Tag is ButtomControl)
                {
                    var obj = this.Tag as ButtomControl;
                    if (obj.ButtomOR.EnlabelVisible)
                    {
                        this.Visibility = Visibility.Visible;
                    
                    }
                    else
                    {
                        this.Visibility = Visibility.Collapsed;
                        return;
                    }
                    tb = new TextBlock();
                    this.Content = tb;
                   
                    //tb.FontSize = 12.0;
                    tb.HorizontalAlignment = HorizontalAlignment.Left;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = obj.ButtomOR.EnlabelFontsize;

                    this.tb.Text = obj.ButtomOR.EnlabelCaption;
                    
                    if (obj.ButtomOR.EnlabelFontbold )
                    {
                        tb.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        tb.FontWeight = FontWeights.Normal;
                    }

                    if (obj.ButtomOR.EnlabelFontitalic )
                    {
                        tb.FontStyle = FontStyles.Italic; ;
                    }
                    else
                    {
                        tb.FontStyle = FontStyles.Normal;
                    }

                    if (obj.ButtomOR.EnlabelFontunderline )
                    {
                        tb.TextDecorations = TextDecorations.Underline;
                    }

                    this.FontFamily = new FontFamily(Common.GetFontEn(obj.ButtomOR.EnlabelFontname));
                    this.Foreground = Converter.ToBrush(obj.ButtomOR.EnlabelFontcolor);
                }
            }
        }
    }
}

