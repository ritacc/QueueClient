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
    public class TagControl : ControlBase
    {

       
        TextBlock tb = new TextBlock();
        public TagControl()
        {
            SetTextInfo();
            this.Content = tb;
        }

        //private void Paint()
        //{
        //    tb.HorizontalAlignment = HorizontalAlignment.Center;
        //    tb.VerticalAlignment = VerticalAlignment.Center;
        //    tb.FontSize = 9;
        //    tb.Text = "Text";
        //}

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
                    if (obj.ButtomOR.TagVisible)
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

                    tb.FontSize = 12.0;
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = obj.ButtomOR.TagFontsize;

                    this.tb.Text = obj.ButtomOR.TagCaption;
                    
                    if (obj.ButtomOR.TagFontbold)
                    {
                        tb.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        tb.FontWeight = FontWeights.Normal;
                    }

                    if (obj.ButtomOR.TagFontitalic)
                    {
                        tb.FontStyle = FontStyles.Italic; ;
                    }
                    else
                    {
                        tb.FontStyle = FontStyles.Normal;
                    }

                    if (obj.ButtomOR.TagFontunderline)
                    {
                        tb.TextDecorations = TextDecorations.Underline ;
                    }
                    this.FontFamily = new FontFamily(Common.GetFontEn(obj.ButtomOR.TagFontname));
                    this.Foreground = Converter.ToBrush(obj.ButtomOR.TagFontcolor);
                }
            }
        }

      

    }
}
