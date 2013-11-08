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
using System.Windows.Media.Imaging;



namespace QClient
{
    public class BottomKJ : UserControl
    {

        Grid _Content = new Grid();
        TextBlock tb = new TextBlock();
        Rectangle rect = new Rectangle();
        private void Paint()
        {
            /*
             HorizontalAlignment="Center" VerticalAlignment="Center"
                   FontSize="26" 
             */
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.FontSize = 9;
            tb.Text = "Text";

            
            //背景
           
            rect.RadiusX = rect.RadiusY = 8.0;


            //_Content.Background = new SolidColorBrush(Colors.Yellow);

            _Content.Children.Add(rect);
            _Content.Children.Add(tb);

        }
		public void SetSizeBg()
		{
			if (this.Tag != null)
			{
				if (this.Tag is ButtomControl)
				{
					var obj = this.Tag as ButtomControl;
					this.Width = obj.ButtomOR.ButtonWidth;
					this.Height = obj.ButtomOR.ButtonHeight;

					if (string.IsNullOrEmpty(obj.ButtomOR.Bg))
						obj.ButtomOR.Bg = "bg1.png";

					string mPath = Common.GetStartpath() + "Resources\\Buttonbg\\" + obj.ButtomOR.Bg;
					if (!System.IO.File.Exists(mPath))
					{
						LinearGradientBrush FColor = new LinearGradientBrush();
						FColor.StartPoint = new Point(0.5, 1);
						FColor.EndPoint = new Point(0.5, 0);

						GradientStop g = new GradientStop();
						g.Color = Colors.White;
						FColor.GradientStops.Add(g);

						g = new GradientStop();
						g.Color = Converter.ToColor("#FFCED4D9");
						g.Offset = 1;
						FColor.GradientStops.Add(g);
						rect.Fill = FColor; 
					}
					else
					{

						//BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
						ImageBrush img = new ImageBrush()
						{
							ImageSource = new BitmapImage(new Uri(mPath, UriKind.Absolute))
						};

						//ImageBrush img = new ImageBrush();
						//img.ImageSource = img;
						img.Stretch = Stretch.Fill;
						rect.Fill = img;
					}
				}
			}
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

                    if (obj.ButtomOR.LabelVisible)
                    {
                        //this.Visibility = Visibility.Collapsed;
                        //return;
                    }
                    else
                    {
                        this.Visibility = Visibility.Visible;
                    }

                    tb = new TextBlock();
                    _Content.Children.Clear();
                    _Content.Children.Add(rect);
                    _Content.Children.Add(tb);
                    tb.FontSize = 12.0;
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.FontSize = obj.ButtomOR.LabelFontsize;

                    this.tb.Text = obj.ButtomOR.LabelCaption;
                    //FontStyle="Italic" FontWeight="Bold" TextDecorations="Underline"
                    if (obj.ButtomOR.LabelFontbold)
                    {
                        tb.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        tb.FontWeight = FontWeights.Normal;
                    }

                    if (obj.ButtomOR.LabelFontitalic)
                    {
                        tb.FontStyle = FontStyles.Italic; ;
                    }
                    else
                    {
                        tb.FontStyle = FontStyles.Normal;
                    }

                    if (obj.ButtomOR.LabelFontunderline)
                    {
                        tb.TextDecorations = TextDecorations.Underline ;
                    }

                    this.FontFamily = new FontFamily(Common.GetFontEn(obj.ButtomOR.LabelFontname));
                    this.Foreground= Converter.ToBrush(obj.ButtomOR.LabelFontcolor);
                }
            }
        }
       
        public BottomKJ()
        {
            Paint();
            this.Content = _Content;
        }

    }
}
