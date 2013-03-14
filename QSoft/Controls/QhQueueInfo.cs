using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace QSoft.Controls
{
   public class QhQueueInfo : UserControl
    {
       Grid g = new Grid();
       TextBlock txt = new TextBlock();
       public QhQueueInfo()
       {
           g.ColumnDefinitions.Add(new ColumnDefinition());
           g.ColumnDefinitions.Add(new ColumnDefinition());
           this.Content = g;

           txt.SetValue(Grid.ColumnProperty, 1);
           txt.Text = "txt";
           g.Children.Add(txt);
       }

       #region  属性
       #region ShowContent
       private static readonly DependencyProperty ShowContentProperty =
           DependencyProperty.Register("ShowContent",
           typeof(string), typeof(QhQueueInfo), new PropertyMetadata("", ShowContentPropertyChanged));
       public string ShowContent
       {
           set
           {
               txt.Text = value;
           }

       }
       private static void ShowContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
           var element = d as QhQueueInfo;
           if (null != element)
           {
               element.ShowContent = e.NewValue.ToString();
           }
       }
       #endregion

       #endregion
    }
}
