﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ButtomDefin.WCFSV;
using System.Windows.Media.Imaging;


namespace ButtomDefin.Control
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
			//LinearGradientBrush FColor = new LinearGradientBrush();
			//FColor.StartPoint = new Point(0.5, 1);
			//FColor.EndPoint = new Point(0.5, 0);
           
			//GradientStop g = new GradientStop();
			//g.Color = Colors.White;
			//FColor.GradientStops.Add(g);

			//g = new GradientStop();
			//g.Color = Common.StringToColor("#FFCED4D9");
			//g.Offset = 1;
			//FColor.GradientStops.Add(g);
            //rect.Fill = FColor;
            rect.RadiusX = rect.RadiusY = 8.0;

			//string gbUrl = string.Format("{0}/Buttonbg/{1}", Common.TopUrl(), "bg1.png");
			//BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
			//ImageBrush img = new ImageBrush();
			//img.ImageSource = bitmap;
			//img.Stretch = Stretch.Fill;
			//rect.Fill = img;

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
					string gbUrl = string.Format("{0}/Buttonbg/{1}", Common.TopUrl(), obj.ButtomOR.Bg);
					BitmapImage bitmap = new BitmapImage(new Uri(gbUrl, UriKind.Absolute));
					ImageBrush img = new ImageBrush();
					img.ImageSource = bitmap;
					img.Stretch = Stretch.Fill;
					rect.Fill = img;
				}
			}
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
                    this.Foreground= new SolidColorBrush(ColorHead.GetColor(obj.ButtomOR.LabelFontcolor));
                }
            }
        }
       
        public BottomKJ()
        {
            Paint();
            this.Content = _Content;

            var menu = new ContextMenu();
            var menuItem = new MenuItem() { Header = "属性" };
            menuItem.Click += PropertyMenuItem_Click;
            menu.Items.Add(menuItem);

            var menuDelete = new MenuItem() { Header = "删除" };
            menuDelete.Click += PropertyDelete_Click;
            menu.Items.Add(menuDelete);

            this.SetValue(ContextMenuService.ContextMenuProperty, menu);
        }
       

        private void PropertyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CWButtomProperty cwbp = new CWButtomProperty(this.Tag as ButtomControl);
            cwbp.SendBottomKJ = this;
            cwbp.Show();            
        }
        private void PropertyDelete_Click(object sender, RoutedEventArgs e)
        {
            //(this.Parent as MainPage).OnDelte(this.Tag as ButtomControl);
            ButtomControl butt = this.Tag as ButtomControl;
            Canvas mParent = this.Parent as Canvas;
            var v1 = mParent.FindName("x1" + butt.ID);
            var v2 = mParent.FindName("x2" + butt.ID);
            var v3 = mParent.FindName("x3" + butt.ID);
            mParent.Children.Remove(v1 as FrameworkElement);
            mParent.Children.Remove(v2 as FrameworkElement);
            mParent.Children.Remove(v3 as FrameworkElement);

            butt.OpType = 2;
        }

        public void SetPropert()
        {
            ButtomControl butt = this.Tag as ButtomControl;
            Canvas mParent = this.Parent as Canvas;
            var v1 = mParent.FindName("x1" + butt.ID) as BottomKJ;
            v1.SetTextInfo();
			v1.SetSizeBg();

            var v2 = mParent.FindName("x2" + butt.ID) as ENLableControl;
            v2.SetTextInfo();
            var v3 = mParent.FindName("x3" + butt.ID) as TagControl;
            v3.SetTextInfo();
        }

    }
}
