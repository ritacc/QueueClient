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
using System.ComponentModel;

namespace ButtomDefin.Control
{
    public abstract class MonitorControl : UserControl
    {
        /// <summary>
        /// 是否为ToolTip
        /// </summary>
        public bool IsToolTip { get; protected set; }

        public MonitorControl ParentControl { get; set; }

        private bool _allowToolTip = true;
        public bool AllowToolTip
        {
            get { return _allowToolTip; }
            set { _allowToolTip = value; }
        }

        public bool IsDesignMode { get { return null != AdornerLayer; } }
        public Adorner AdornerLayer { get; protected set; }
        public abstract void DesignMode();
        public abstract void UnDesignMode();
       // public abstract object GetRootControl();
       

        public abstract event EventHandler Selected;

        public abstract event EventHandler Unselected;

       
      
        /// <summary>
        /// 控件状态，新添加的，或以保存的
        /// </summary>
        public ElementSate ElementState;

        [DefaultValue(""), Description("距左边位置")]
        public double Left
        {
            get { return (double)GetValue(Canvas.LeftProperty); }
            set { SetValue(Canvas.LeftProperty, value); AdornerLayer.SetValue(Canvas.LeftProperty, value); }
        }
        [DefaultValue(""), Description("距上面位置高度")]
        public double Top
        {
            get { return (double)GetValue(Canvas.TopProperty); }
            set { SetValue(Canvas.TopProperty, value); AdornerLayer.SetValue(Canvas.TopProperty, value); }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            if (!IsToolTip && !IsDesignMode)
            {
            }
            base.OnMouseEnter(e);
        }


        protected override void OnMouseLeave(MouseEventArgs e)
        {
            if (!IsToolTip && !IsDesignMode)
            {
                
            }
            base.OnMouseLeave(e);
        }
    }

    public enum ElementSate
    {
        New, Save
    }

   

  
    
}
