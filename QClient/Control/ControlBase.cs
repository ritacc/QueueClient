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

namespace QClient
{
    public class ControlBase : UserControl
    {
        public ControlBase()
        {
            
        }
        Point _initialPoint;
        double _offsetLeft;
        double _offsetTop;
        FrameworkElement _parent;
        #region Conent Mouse Method

        

        public void BackgroundAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var source = sender as FrameworkElement;
            source.CaptureMouse();
            source.MouseMove -= BackgroundAdorner_MouseMove;
            source.MouseMove += BackgroundAdorner_MouseMove;
        }

        private void BackgroundAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var source = sender as FrameworkElement;
            source.ReleaseMouseCapture();
            source.MouseMove -= BackgroundAdorner_MouseMove;
           
        }

        private void BackgroundAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetX = mousePoint.X - _initialPoint.X;
            var offsetY = mousePoint.Y - _initialPoint.Y;
            
            this.SetValue(Canvas.LeftProperty, offsetX - _offsetLeft);
            this.SetValue(Canvas.TopProperty, offsetY - _offsetTop);
        }

        #endregion
    }
}
