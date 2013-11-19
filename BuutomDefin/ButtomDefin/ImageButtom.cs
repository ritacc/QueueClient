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
using System.Windows.Media.Imaging;

namespace ButtomDefin
{
    public class ImageButtom : UserControl
    {
        public event EventHandler Click;
        Canvas _Canvas = new Canvas();
        Image img = new Image();
        private int ImgHeight = 16;
        private int ImgWidth = 16;

        //渐变
        LinearGradientBrush lin = new LinearGradientBrush();
        GradientStop gsStart = new GradientStop();

        Brush _Brush = null;
        public ImageButtom()
        {

            img.Width = ImgWidth;
            img.Height = ImgHeight;
            _Canvas.Children.Add(img);
            this.Content = _Canvas;

            InitJB();
            _Brush = new SolidColorBrush();

            this.MouseLeftButtonDown += Parent_MouseLeftButtonDown;
            this.MouseLeftButtonUp += Parent_MouseLeftButtonUp;

            this.SizeChanged += new SizeChangedEventHandler(ImageButtom_SizeChanged);
            this.MouseEnter += new MouseEventHandler(ImageButtom_MouseEnter);
            this.MouseLeave += new MouseEventHandler(ImageButtom_MouseLeave);
        }

        public void Select(bool IsSelect)
        {
            if (!IsSelect)
            {
                _Brush = new SolidColorBrush();
            }
            else
            {
                gsStart.Color = Common.StringToColor("#FFBFBFBF");
                _Brush = lin;
            }
            _Canvas.Background = _Brush;
        }

        private void InitJB()
        {
            lin.EndPoint = new Point(0.5, 1);
            lin.StartPoint = new Point(0.5, 0);
            GradientStopCollection gsc = new GradientStopCollection();
            gsStart.Color = Common.StringToColor("#FFBFBFBF");
            gsStart.Offset = 1.0;
            gsc.Add(gsStart);

            GradientStop gs1 = new GradientStop();
            gs1.Color = Colors.White;
            gsc.Add(gs1);
            lin.GradientStops = gsc;
        }
        private void ImageButtom_MouseEnter(object sender, MouseEventArgs e)
        {
            gsStart.Color = Common.StringToColor("#FFC2D2EB");
            _Canvas.Background = lin;
        }
        private void ImageButtom_MouseLeave(object sender, MouseEventArgs e)
        {
            gsStart.Color = Common.StringToColor("#FFBFBFBF");
            _Canvas.Background = _Brush;
        }

        private void ImageButtom_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = e.NewSize.Width;
            this.Height = e.NewSize.Height;

            double imgLeft = (Width - ImgWidth) / 2;
            double imgTop = (Height - ImgHeight) / 2;

            img.SetValue(Canvas.LeftProperty, imgLeft);
            img.SetValue(Canvas.TopProperty, imgTop);
        }

        public string Text { get; set; }

        private string _ImageSource;
        /// <summary>
        /// 图标
        /// </summary>
        public string ImageSource
        {
            get { return _ImageSource; }
            set { _ImageSource = value; SetImgPath(value); }
        }

        private void SetImgPath(string strVal)
        {
            img.Source = new BitmapImage(new Uri(strVal, UriKind.RelativeOrAbsolute));
        }

        #region 双击事件
        DateTime d;


        protected void Parent_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            TimeSpan ts = DateTime.Now - d;
            if (ts.Seconds == 0 && ts.Milliseconds < 600)
            {
                if (Click != null)
                    Click(this, null);
            }
        }

        protected void Parent_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            d = DateTime.Now;

        }
        #endregion
    }
}
