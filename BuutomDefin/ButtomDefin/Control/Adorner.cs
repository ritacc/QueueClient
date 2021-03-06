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
using System.Windows.Controls.Primitives;


namespace ButtomDefin.Control
{
    [TemplatePart(Name = "BackgroundAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "ContentAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "TopLeftAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "TopCenterAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "TopRightAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "CenterLeftAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "CenterRightAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "BottomLeftAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "BottomCenterAdorner", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "BottomRightAdorner", Type = typeof(FrameworkElement))]
    public class Adorner : ButtonBase, IDisposable
    {
        private static Adorner _lastFocusObject = null;
        public event EventHandler Selected;

        #region Fields

        private Canvas _parent;
        Point _initialPoint;
        double _initialTop;
        double _initialLeft;
        double _offsetLeft;
        double _offsetTop;
        private bool _associatedIsTapStop;
        private readonly FrameworkElement _associatedElement;
        private FrameworkElement _backgroundAdorner;
        private FrameworkElement _contentAdorner;
        private FrameworkElement _topLeftAdorner;
        private FrameworkElement _topCenterAdorner;
        private FrameworkElement _topRightAdorner;
        private FrameworkElement _centerLeftAdorner;
        private FrameworkElement _centerRightAdorner;
        private FrameworkElement _bottomLeftAdorner;
        private FrameworkElement _bottomCenterAdorner;
        private FrameworkElement _bottomRightAdorner;
        private const double MIN_SIZE = 0;
        #endregion

        #region Properties

        private static readonly DependencyProperty IsLockScaleProperty =
            DependencyProperty.Register("IsLockScale",
            typeof(bool), typeof(Adorner), new PropertyMetadata(default(bool), new PropertyChangedCallback(IsLockScale_Changed)));

        public bool IsLockScale
        {
            get { return (bool)this.GetValue(IsLockScaleProperty); }
            set { this.SetValue(IsLockScaleProperty, value); }
        }

        private static void IsLockScale_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            Adorner adorner = (Adorner)element;
            adorner.OnIsLockScaleChanged((bool)e.NewValue, (bool)e.OldValue);
        }

        public void OnIsLockScaleChanged(bool oldValue, bool newValue)
        {
            if (null != _topCenterAdorner
                && null != _centerLeftAdorner
                && null != _centerRightAdorner
                && null != _bottomCenterAdorner)
            {
                if (newValue)
                {
                    _topCenterAdorner.Visibility = Visibility.Collapsed;
                    _centerLeftAdorner.Visibility = Visibility.Collapsed;
                    _centerRightAdorner.Visibility = Visibility.Collapsed;
                    _bottomCenterAdorner.Visibility = Visibility.Collapsed;
                }
                else
                {
                    _topCenterAdorner.Visibility = Visibility.Visible;
                    _centerLeftAdorner.Visibility = Visibility.Visible;
                    _centerRightAdorner.Visibility = Visibility.Visible;
                    _bottomCenterAdorner.Visibility = Visibility.Visible;
                }
            }
        }

        private static readonly DependencyProperty EditabledProperty =
            DependencyProperty.Register("Editabled",
            typeof(bool), typeof(Adorner), new PropertyMetadata(default(bool), new PropertyChangedCallback(Editabled_Changed)));

        public bool Editabled
        {
            get { return (bool)this.GetValue(EditabledProperty); }
            set { this.SetValue(EditabledProperty, value); }
        }

        private static void Editabled_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            Adorner adorner = (Adorner)element;
            adorner.OnEditabledChanged((bool)e.NewValue, (bool)e.OldValue);
        }

        public void OnEditabledChanged(bool oldValue, bool newValue)
        {
            if (null != _backgroundAdorner
                && null != _associatedElement)
            {
                if (newValue)
                {
                    _backgroundAdorner.Visibility = Visibility.Collapsed;
                    _backgroundAdorner.MouseLeftButtonDown -= BackgroundAdorner_MouseLeftButtonDown;
                    _backgroundAdorner.MouseLeftButtonUp -= BackgroundAdorner_MouseLeftButtonUp;

                    _associatedElement.MouseLeftButtonDown -= BackgroundAdorner_MouseLeftButtonDown;
                    _associatedElement.MouseLeftButtonDown += BackgroundAdorner_MouseLeftButtonDown;
                    _associatedElement.MouseLeftButtonUp -= BackgroundAdorner_MouseLeftButtonUp;
                    _associatedElement.MouseLeftButtonUp += BackgroundAdorner_MouseLeftButtonUp;
                }
                else
                {
                    _backgroundAdorner.Visibility = Visibility.Visible;

                    _associatedElement.MouseLeftButtonDown -= BackgroundAdorner_MouseLeftButtonDown;
                    _associatedElement.MouseLeftButtonUp -= BackgroundAdorner_MouseLeftButtonUp;

                    _backgroundAdorner.MouseLeftButtonDown -= BackgroundAdorner_MouseLeftButtonDown;
                    _backgroundAdorner.MouseLeftButtonDown += BackgroundAdorner_MouseLeftButtonDown;
                    _backgroundAdorner.MouseLeftButtonUp -= BackgroundAdorner_MouseLeftButtonUp;
                    _backgroundAdorner.MouseLeftButtonUp += BackgroundAdorner_MouseLeftButtonUp;
                }
            }
        }

        private static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected",
            typeof(bool), typeof(Adorner), new PropertyMetadata(default(bool), new PropertyChangedCallback(IsSelected_Changed)));

        public bool IsSelected
        {
            get { return (bool)this.GetValue(IsSelectedProperty); }
            set { this.SetValue(IsSelectedProperty, value); }
        }

        private static void IsSelected_Changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            Adorner adorner = (Adorner)element;
            adorner.OnIsSelectedChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        public void OnIsSelectedChanged(bool oldValue, bool newValue)
        {
            if (IsSelected)
            {
                SetSelect();
            }
            else
            {
                SetUnselect();
            }
        }

        #endregion

        #region Methods

        public Adorner(FrameworkElement associatedElement)
        {
            base.DefaultStyleKey = typeof(Adorner);
            base.Visibility = System.Windows.Visibility.Visible;
            _associatedElement = associatedElement;
            if (_associatedElement is ButtonBase)
            {
                var button = _associatedElement as ButtonBase;
                _associatedIsTapStop = button.IsTabStop;
                button.IsTabStop = false;
            }

            _parent = _associatedElement.Parent as Canvas;
            _parent.Children.Add(this);
            this.LayoutUpdated += PopupLayoutUpdated;

            this.SetValue(MinHeightProperty, associatedElement.MinHeight + 5d);
            this.SetValue(MinWidthProperty, associatedElement.MinWidth + 5d);

            associatedElement.SizeChanged += associatedElement_SizeChanged;
        }

        private void associatedElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SynchroHost();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            SetSelect();
        }
                

        private void SetSelect()
        {
            if (!IsSelected)
            {
                IsSelected = true;
                return;
            }
            if (null != _contentAdorner
                   && null != _topLeftAdorner
                   && null != _topRightAdorner
                   && null != _bottomLeftAdorner
                   && null != _bottomLeftAdorner
                   && null != _bottomRightAdorner
                   && null != _topLeftAdorner
                   && null != _topCenterAdorner
                   && null != _centerLeftAdorner
                   && null != _centerRightAdorner
                   && null != _bottomCenterAdorner)
            {
                _contentAdorner.Opacity = 1;
                _topLeftAdorner.Visibility = Visibility.Visible;
                _topRightAdorner.Visibility = Visibility.Visible;
                _bottomLeftAdorner.Visibility = Visibility.Visible;
                _bottomRightAdorner.Visibility = Visibility.Visible;
                if (!IsLockScale)
                {
                    _topCenterAdorner.Visibility = Visibility.Visible;
                    _centerLeftAdorner.Visibility = Visibility.Visible;
                    _centerRightAdorner.Visibility = Visibility.Visible;
                    _bottomCenterAdorner.Visibility = Visibility.Visible;
                }

                if (_lastFocusObject != this && null != _lastFocusObject)
                {
                    _lastFocusObject.SetUnselect();
                }
                _lastFocusObject = this;
            }
        }

        private void SetUnselect()
        {
            if (IsSelected)
            {
                IsSelected = false;
                return;
            }
            if (null != _contentAdorner
                && null != _topLeftAdorner
                && null != _topRightAdorner
                && null != _bottomLeftAdorner
                && null != _bottomLeftAdorner
                && null != _bottomRightAdorner
                && null != _topLeftAdorner
                && null != _topCenterAdorner
                && null != _centerLeftAdorner
                && null != _centerRightAdorner
                && null != _bottomCenterAdorner)
            {
                _contentAdorner.Opacity = 0;
                _topLeftAdorner.Visibility = Visibility.Collapsed;
                _topRightAdorner.Visibility = Visibility.Collapsed;
                _bottomLeftAdorner.Visibility = Visibility.Collapsed;
                _bottomRightAdorner.Visibility = Visibility.Collapsed;
                if (!IsLockScale)
                {
                    _topCenterAdorner.Visibility = Visibility.Collapsed;
                    _centerLeftAdorner.Visibility = Visibility.Collapsed;
                    _centerRightAdorner.Visibility = Visibility.Collapsed;
                    _bottomCenterAdorner.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void Dispose()
        {
            if (_associatedElement is ButtonBase)
            {
                var button = _associatedElement as ButtonBase;
                button.IsTabStop = _associatedIsTapStop;
            }

            _contentAdorner.MouseLeftButtonDown -= BackgroundAdorner_MouseLeftButtonDown;
            _contentAdorner.MouseLeftButtonUp -= BackgroundAdorner_MouseLeftButtonUp;
            
            _parent.Children.Remove(this);
            GC.SuppressFinalize(this);
        }

        public override void OnApplyTemplate()
        {
            _backgroundAdorner = base.GetTemplateChild("BackgroundAdorner") as FrameworkElement;
            OnEditabledChanged(false, Editabled);

            _contentAdorner = base.GetTemplateChild("ContentAdorner") as FrameworkElement;
            _contentAdorner.Opacity = 0;
            _contentAdorner.SetValue(MinHeightProperty, _associatedElement.MinHeight);
            _contentAdorner.SetValue(MinWidthProperty, _associatedElement.MinWidth);

            _topLeftAdorner = base.GetTemplateChild("TopLeftAdorner") as FrameworkElement;
            _topLeftAdorner.MouseLeftButtonDown += TopLeftAdorner_MouseLeftButtonDown;
            _topLeftAdorner.MouseLeftButtonUp += TopLeftAdorner_MouseLeftButtonUp;
            _topLeftAdorner.Visibility = Visibility.Collapsed;

            _topCenterAdorner = base.GetTemplateChild("TopCenterAdorner") as FrameworkElement;
            _topCenterAdorner.MouseLeftButtonDown += TopCenterAdorner_MouseLeftButtonDown;
            _topCenterAdorner.MouseLeftButtonUp += TopCenterAdorner_MouseLeftButtonUp;
            _topCenterAdorner.Visibility = Visibility.Collapsed;

            _topRightAdorner = base.GetTemplateChild("TopRightAdorner") as FrameworkElement;
            _topRightAdorner.MouseLeftButtonDown += TopRightAdorner_MouseLeftButtonDown;
            _topRightAdorner.MouseLeftButtonUp += TopRightAdorner_MouseLeftButtonUp;
            _topRightAdorner.Visibility = Visibility.Collapsed;

            _centerLeftAdorner = base.GetTemplateChild("CenterLeftAdorner") as FrameworkElement;
            _centerLeftAdorner.MouseLeftButtonDown += CenterLeftAdorner_MouseLeftButtonDown;
            _centerLeftAdorner.MouseLeftButtonUp += CenterLeftAdorner_MouseLeftButtonUp;
            _centerLeftAdorner.Visibility = Visibility.Collapsed;

            _centerRightAdorner = base.GetTemplateChild("CenterRightAdorner") as FrameworkElement;
            _centerRightAdorner.MouseLeftButtonDown += CenterRightAdorner_MouseLeftButtonDown;
            _centerRightAdorner.MouseLeftButtonUp += CenterRightAdorner_MouseLeftButtonUp;
            _centerRightAdorner.Visibility = Visibility.Collapsed;

            _bottomLeftAdorner = base.GetTemplateChild("BottomLeftAdorner") as FrameworkElement;
            _bottomLeftAdorner.MouseLeftButtonDown += BottomLeftAdorner_MouseLeftButtonDown;
            _bottomLeftAdorner.MouseLeftButtonUp += BottomLeftAdorner_MouseLeftButtonUp;
            _bottomLeftAdorner.Visibility = Visibility.Collapsed;

            _bottomCenterAdorner = base.GetTemplateChild("BottomCenterAdorner") as FrameworkElement;
            _bottomCenterAdorner.MouseLeftButtonDown += BottomCenterAdorner_MouseLeftButtonDown;
            _bottomCenterAdorner.MouseLeftButtonUp += BottomCenterAdorner_MouseLeftButtonUp;
            _bottomCenterAdorner.Visibility = Visibility.Collapsed;

            _bottomRightAdorner = base.GetTemplateChild("BottomRightAdorner") as FrameworkElement;
            _bottomRightAdorner.MouseLeftButtonDown += BottomRightAdorner_MouseLeftButtonDown;
            _bottomRightAdorner.MouseLeftButtonUp += BottomRightAdorner_MouseLeftButtonUp;
            _bottomRightAdorner.Visibility = Visibility.Collapsed;
        }

        private void PopupLayoutUpdated(object sender, EventArgs e)
        {
            this.LayoutUpdated -= PopupLayoutUpdated;
            Layout();
        }

        private void Layout()
        {
            try
            {
                var beginPoint = _associatedElement.TransformToVisual(_parent).Transform(new Point(0.0, 0.0));
                var endPoint = _associatedElement.TransformToVisual(_parent).Transform(new Point(_associatedElement.ActualWidth, this._associatedElement.ActualHeight));
                this._contentAdorner.SetValue(FrameworkElement.WidthProperty, endPoint.X - beginPoint.X);
                this._contentAdorner.SetValue(FrameworkElement.HeightProperty, endPoint.Y - beginPoint.Y);
                var margin = (Thickness)_contentAdorner.GetValue(FrameworkElement.MarginProperty);
                _offsetLeft = margin.Left;
                _offsetTop = margin.Top;
                var left = (double)_associatedElement.GetValue(Canvas.LeftProperty);
                var top = (double)_associatedElement.GetValue(Canvas.TopProperty);
                this.SetValue(Canvas.LeftProperty, left - _offsetLeft);
                this.SetValue(Canvas.TopProperty, top - _offsetTop);
            }
            catch
            {

            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                _backgroundAdorner.Visibility = Visibility.Collapsed;
                _parent.Children.Remove(_associatedElement);
                _parent.Children.Remove(this);
                this.Dispose();
            }
            base.OnKeyUp(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            ModifierKeys keys = ModifierKeys.Control;
            if (keys == ModifierKeys.Control && e.Key == Key.C)
            {
                if ((_associatedElement != null) && (_associatedElement is MonitorControl))
                {
                    //LoadScreen.CoptyObj = (MonitorControl)_associatedElement;
                }
            }
            base.OnKeyDown(e);
        }

        #endregion

        #region Conent Mouse Method

        public void BackgroundAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var source = sender as FrameworkElement;
            source.CaptureMouse();
            source.MouseMove -= BackgroundAdorner_MouseMove;
            source.MouseMove += BackgroundAdorner_MouseMove;
            _initialPoint = e.GetPosition(_contentAdorner);

           
        }

        private void BackgroundAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var source = sender as FrameworkElement;
            source.ReleaseMouseCapture();
            source.MouseMove -= BackgroundAdorner_MouseMove;
            OnSelected();
        }

        private void BackgroundAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetX = mousePoint.X - _initialPoint.X;
            var offsetY = mousePoint.Y - _initialPoint.Y;
            _associatedElement.SetValue(Canvas.LeftProperty, offsetX);
            _associatedElement.SetValue(Canvas.TopProperty, offsetY);
            this.SetValue(Canvas.LeftProperty, offsetX - _offsetLeft);
            this.SetValue(Canvas.TopProperty, offsetY - _offsetTop);
        }

        #endregion

        #region Top Left Mouse Method

        private void TopLeftAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _topLeftAdorner.CaptureMouse();
            _topLeftAdorner.MouseMove -= TopLeftAdorner_MouseMove;
            _topLeftAdorner.MouseMove += TopLeftAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialTop = (double)this.GetValue(Canvas.TopProperty);
            _initialLeft = (double)this.GetValue(Canvas.LeftProperty);
        }

        private void TopLeftAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _topLeftAdorner.ReleaseMouseCapture();
            _topLeftAdorner.MouseMove -= TopLeftAdorner_MouseMove;

            SynchroLayout();
        }

        private void TopLeftAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offset = mousePoint.X - _initialPoint.X + mousePoint.Y - _initialPoint.Y;
            var widthRatio = _associatedElement.ActualWidth / (_associatedElement.ActualWidth + _associatedElement.ActualHeight);
            var heightRatio = 1 - widthRatio;
            var offsetX = widthRatio * offset;
            var offsetY = heightRatio * offset;
            var targetWidth = _associatedElement.ActualWidth - offsetX;
            var targetHeight = _associatedElement.ActualHeight - offsetY;
            var targetLeft = _initialLeft + offsetX;
            var targetTop = _initialTop + offsetY;
            if (targetWidth < MIN_SIZE || targetHeight < MIN_SIZE)
            {
                targetWidth = MIN_SIZE;
                targetHeight = MIN_SIZE;
                targetLeft = _initialLeft + _associatedElement.ActualWidth - MIN_SIZE;
                targetTop = _initialTop + _associatedElement.ActualHeight - MIN_SIZE;
            }

            this._contentAdorner.SetValue(FrameworkElement.WidthProperty, targetWidth);
            this._contentAdorner.SetValue(FrameworkElement.HeightProperty, targetHeight);
            this.SetValue(Canvas.LeftProperty, targetLeft);
            this.SetValue(Canvas.TopProperty, targetTop);
        }

        #endregion

        #region Top Center Mouse Method

        private void TopCenterAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _topCenterAdorner.CaptureMouse();
            _topCenterAdorner.MouseMove -= TopCenterAdorner_MouseMove;
            _topCenterAdorner.MouseMove += TopCenterAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialTop = (double)this.GetValue(Canvas.TopProperty);
        }

        private void TopCenterAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _topCenterAdorner.ReleaseMouseCapture();
            _topCenterAdorner.MouseMove -= TopCenterAdorner_MouseMove;

            SynchroLayout();
        }

        private void TopCenterAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetY = mousePoint.Y - _initialPoint.Y;
            var targetHeight = _associatedElement.ActualHeight - offsetY;
            var targetTop = _initialTop + offsetY;
            if (targetHeight < MIN_SIZE)
            {
                targetHeight = MIN_SIZE;
                targetTop = _initialTop + _associatedElement.ActualHeight - MIN_SIZE;
            }
            else if (targetHeight < MIN_SIZE || targetHeight < _associatedElement.MinHeight
                || targetHeight > _associatedElement.MaxHeight)
            {
                return;
            }
            this._contentAdorner.SetValue(FrameworkElement.HeightProperty, targetHeight);
            this.SetValue(Canvas.TopProperty, targetTop);
        }

        #endregion

        #region Top Right Mouse Method

        private void TopRightAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _topRightAdorner.CaptureMouse();
            _topRightAdorner.MouseMove -= TopRightAdorner_MouseMove;
            _topRightAdorner.MouseMove += TopRightAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialTop = (double)this.GetValue(Canvas.TopProperty);
        }

        private void TopRightAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _topRightAdorner.ReleaseMouseCapture();
            _topRightAdorner.MouseMove -= TopRightAdorner_MouseMove;

            SynchroLayout();
        }

        private void TopRightAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetX = mousePoint.X - _initialPoint.X;
            var offsetY = mousePoint.Y - _initialPoint.Y;
            var widthRatio = _associatedElement.ActualWidth / (_associatedElement.ActualWidth + _associatedElement.ActualHeight);
            var heightRatio = 1 - widthRatio;
            var offset = offsetX - offsetY;
            var targetWidth = _associatedElement.ActualWidth + offset * widthRatio;
            var targetHeight = _associatedElement.ActualHeight + offset * heightRatio;
            var targetTop = _initialTop - offset * heightRatio;
            if (targetWidth < MIN_SIZE || targetHeight < MIN_SIZE)
            {
                targetWidth = MIN_SIZE;
                targetHeight = MIN_SIZE;
                targetTop = _initialTop + _associatedElement.ActualHeight - MIN_SIZE;
            }
            this._contentAdorner.SetValue(FrameworkElement.WidthProperty, targetWidth);
            this._contentAdorner.SetValue(FrameworkElement.HeightProperty, targetHeight);
            this.SetValue(Canvas.TopProperty, targetTop);
        }

        #endregion

        #region Center Left Mouse Method

        private void CenterLeftAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _centerLeftAdorner.CaptureMouse();
            _centerLeftAdorner.MouseMove -= CenterLeftAdorner_MouseMove;
            _centerLeftAdorner.MouseMove += CenterLeftAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialLeft = (double)this.GetValue(Canvas.LeftProperty);
        }

        private void CenterLeftAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _centerLeftAdorner.ReleaseMouseCapture();
            _centerLeftAdorner.MouseMove -= CenterLeftAdorner_MouseMove;

            SynchroLayout();
        }

        private void CenterLeftAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetX = mousePoint.X - _initialPoint.X;
            var targetWidth = _associatedElement.ActualWidth - offsetX;
            var targetLeft = _initialLeft + offsetX;
            if (targetWidth < MIN_SIZE)
            {
                targetWidth = MIN_SIZE;
                targetLeft = _initialLeft + _associatedElement.ActualWidth - MIN_SIZE;
            }
            else if (targetWidth < MIN_SIZE || targetWidth < _associatedElement.MinWidth
                || targetWidth > _associatedElement.MaxWidth)
            {
                return;
            }
            this._contentAdorner.SetValue(FrameworkElement.WidthProperty, targetWidth);
            this.SetValue(Canvas.LeftProperty, targetLeft);
        }

        #endregion

        #region Center Right Mouse Method

        private void CenterRightAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _centerRightAdorner.CaptureMouse();
            _centerRightAdorner.MouseMove -= CenterRightAdorner_MouseMove;
            _centerRightAdorner.MouseMove += CenterRightAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialLeft = (double)this.GetValue(Canvas.LeftProperty);
        }

        private void CenterRightAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _centerRightAdorner.ReleaseMouseCapture();
            _centerRightAdorner.MouseMove -= CenterRightAdorner_MouseMove;

            SynchroLayout();
        }

        private void CenterRightAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetX = mousePoint.X - _initialPoint.X;
            var targetWidth = _associatedElement.ActualWidth + offsetX;
            if (targetWidth < MIN_SIZE)
            {
                targetWidth = MIN_SIZE;
            }
            else if (targetWidth < MIN_SIZE || targetWidth < _associatedElement.MinWidth
                || targetWidth > _associatedElement.MaxWidth)
            {
                return;
            }
            this._contentAdorner.SetValue(FrameworkElement.WidthProperty, targetWidth);
        }

        #endregion

        #region Bottom Left Mouse Method

        private void BottomLeftAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _bottomLeftAdorner.CaptureMouse();
            _bottomLeftAdorner.MouseMove -= BottomLeftAdorner_MouseMove;
            _bottomLeftAdorner.MouseMove += BottomLeftAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialLeft = (double)this.GetValue(Canvas.LeftProperty);
        }

        private void BottomLeftAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _bottomLeftAdorner.ReleaseMouseCapture();
            _bottomLeftAdorner.MouseMove -= BottomLeftAdorner_MouseMove;

            SynchroLayout();
        }

        private void BottomLeftAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetX = mousePoint.X - _initialPoint.X;
            var offsetY = mousePoint.Y - _initialPoint.Y;
            var widthRatio = _associatedElement.ActualWidth / (_associatedElement.ActualWidth + _associatedElement.ActualHeight);
            var heightRatio = 1 - widthRatio;
            var offset = offsetY - offsetX;
            var targetWidth = _associatedElement.ActualWidth + offset * widthRatio;
            var targetHeight = _associatedElement.ActualHeight + offset * heightRatio;
            var targetLeft = _initialLeft - offset * widthRatio;
            if (targetWidth < MIN_SIZE || targetHeight < MIN_SIZE)
            {
                targetWidth = MIN_SIZE;
                targetHeight = MIN_SIZE;
                targetLeft = _initialLeft + _associatedElement.ActualWidth - MIN_SIZE;
            }

            this._contentAdorner.SetValue(FrameworkElement.WidthProperty, targetWidth);
            this._contentAdorner.SetValue(FrameworkElement.HeightProperty, targetHeight);
            this.SetValue(Canvas.LeftProperty, targetLeft);
        }

        #endregion

        #region Bottom Center Mouse Method

        private void BottomCenterAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _bottomCenterAdorner.CaptureMouse();
            _bottomCenterAdorner.MouseMove -= BottomCenterAdorner_MouseMove;
            _bottomCenterAdorner.MouseMove += BottomCenterAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
        }

        private void BottomCenterAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _bottomCenterAdorner.ReleaseMouseCapture();
            _bottomCenterAdorner.MouseMove -= BottomCenterAdorner_MouseMove;

            SynchroLayout();
        }

        private void BottomCenterAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offsetY = mousePoint.Y - _initialPoint.Y;
            var targetHeight = this._associatedElement.ActualHeight + offsetY;
            if (targetHeight < MIN_SIZE)
            {
                targetHeight = MIN_SIZE;
            }
            else if (targetHeight < MIN_SIZE || targetHeight < _associatedElement.MinHeight
                || targetHeight > _associatedElement.MaxHeight)
            {
                return;
            }
            this._contentAdorner.SetValue(FrameworkElement.HeightProperty, targetHeight);
        }

        #endregion

        #region Bottom Right Mouse Method

        private void BottomRightAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _bottomRightAdorner.CaptureMouse();
            _bottomRightAdorner.MouseMove -= BottomRightAdorner_MouseMove;
            _bottomRightAdorner.MouseMove += BottomRightAdorner_MouseMove;

            _initialPoint = e.GetPosition(_parent);
            _initialTop = (double)this.GetValue(Canvas.TopProperty);
            _initialLeft = (double)this.GetValue(Canvas.LeftProperty);
        }

        private void BottomRightAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _bottomRightAdorner.ReleaseMouseCapture();
            _bottomRightAdorner.MouseMove -= BottomRightAdorner_MouseMove;

            SynchroLayout();
        }

        private void BottomRightAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(_parent);
            var offset = mousePoint.X - _initialPoint.X + mousePoint.Y - _initialPoint.Y;
            var widthRatio = _associatedElement.ActualWidth / (_associatedElement.ActualWidth + _associatedElement.ActualHeight);
            var heightRatio = 1 - widthRatio;
            var offsetX = widthRatio * offset;
            var offsetY = heightRatio * offset;
            var targetWidth = _associatedElement.ActualWidth + offsetX;
            var targetHeight = _associatedElement.ActualHeight + offsetY;
            if (targetWidth < MIN_SIZE || targetHeight < MIN_SIZE)
            {
                targetWidth = MIN_SIZE;
                targetHeight = MIN_SIZE;
            }

            this._contentAdorner.SetValue(FrameworkElement.WidthProperty, targetWidth);
            this._contentAdorner.SetValue(FrameworkElement.HeightProperty, targetHeight);
        }

        #endregion

        public void OnSelected()
        {
            if (null != Selected)
            {
                Selected(this, EventArgs.Empty);
            }
        }

        private void SynchroLayout()
        {
            this._associatedElement.SetValue(FrameworkElement.WidthProperty, this._contentAdorner.ActualWidth);
            this._associatedElement.SetValue(FrameworkElement.HeightProperty, this._contentAdorner.ActualHeight);
            this._associatedElement.SetValue(Canvas.LeftProperty, (double)this.GetValue(Canvas.LeftProperty) + _offsetLeft);
            this._associatedElement.SetValue(Canvas.TopProperty, (double)this.GetValue(Canvas.TopProperty) + _offsetTop);
            OnSelected();
        }

        public void SynchroHost()
        {
            //_contentAdorner.SetValue(FrameworkElement.WidthProperty, _associatedElement.ActualWidth);
            //_contentAdorner.SetValue(FrameworkElement.HeightProperty, _associatedElement.ActualHeight);
            //this.SetValue(Canvas.LeftProperty, (double)_associatedElement.GetValue(Canvas.LeftProperty) - _offsetLeft);
            //this.SetValue(Canvas.TopProperty, (double)_associatedElement.GetValue(Canvas.TopProperty) - _offsetTop);
        }

        public static void CancelSelected()
        {
            if (null != _lastFocusObject)
            {
                _lastFocusObject.SetUnselect();
                _lastFocusObject = null;
            }
        }
    }
}
