using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ButtomDefin.WCFSV;
using System.Collections.ObjectModel;

namespace ButtomDefin.Control
{
    public partial class CWButtomProperty : ChildWindow
    {
        QhandyOR _Qh;
        ButtomControl _QHC;
             
        public CWButtomProperty(ButtomControl obj)
        {
            InitializeComponent();
            FontHeadle.InitCombox(LabelFontname);
            FontHeadle.InitCombox(TagFontname);
            FontHeadle.InitCombox(EnlabelFontname);

            _Qh = obj.ButtomOR;
            _QHC = obj;

            cbYW.ItemsSource = MainPage.ListYw;
            cbYW.DisplayMemberPath = "Name";
            
            //ListPageWin = Common.ListPageWin;
            cbPageWin.ItemsSource = Common.ListPageWin;
            cbPageWin.DisplayMemberPath = "Name";
            //this.DataContext= this;

            InitValue();
        }

        private BottomKJ _SendBottomKJ;
        /// <summary>
        /// 发送对像
        /// </summary>
        public BottomKJ SendBottomKJ
        {
            get { return _SendBottomKJ; }
            set { _SendBottomKJ = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            SaveValue();
            this.DialogResult = true;
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void SaveValue()
        {
            _Qh.LabelVisible = this.LabelVisible.IsChecked.Value ;/// 标签是否显示

            _Qh.LabelCaption = this.LabelCaption.Text;/// 标签显示内容
            /// 标签颜色
            _Qh.LabelFontcolor = this.LabelFontcolor.SelectedIndex;
            /// 标签字体名称
            if (this.LabelFontname.SelectedItem != null)
                _Qh.LabelFontname = this.LabelFontname.SelectedItem.ToString();

            /// 标签下划线
            _Qh.LabelFontunderline = this.LabelFontunderline.IsChecked.Value ;
            /// 标签是否斜体
            _Qh.LabelFontitalic = this.LabelFontitalic.IsChecked.Value;
            /// 标签是否加粗
            _Qh.LabelFontbold = this.LabelFontbold.IsChecked.Value;
            /// 标签字体大小
            _Qh.LabelFontsize = Convert.ToInt16(this.LabelFontsize.Value);

			  _Qh.ButtonWidth=Convert.ToDouble(this.txtLabWidth.Text);
			  _Qh.ButtonHeight = Convert.ToDouble(this.txtLabHeight.Text);
			  if (this.cbBg.SelectedValue != null)
				  _Qh.Bg = (this.cbBg.SelectedItem as ComboBoxItem).Content.ToString(); 

            /// 标签业务No
            //this.LabelJobno  
            /// 标签业务名称
            //this.LabelJobname
            if (cbYW.SelectedItem != null)
            {
                YWOR obj = cbYW.SelectedItem as YWOR;
                _Qh.LabelJobno = obj.NO;
                _Qh.LabelJobname = obj.Name;
            }

            /// 标签打印字字符串
            _Qh.LabelPrintstr = this.LabelPrintstr.Text;
            /// 标签是否显示边框
            _Qh.LabelShade = this.LabelShade.IsChecked.Value;

            /// Tag是否显示
            _Qh.TagVisible = this.TagVisible.IsChecked.Value;
            /// Tag显示内容
            _Qh.TagCaption = this.TagCaption.Text;
            /// Tag字体颜色
            _Qh.TagFontcolor = this.TagFontcolor.SelectedIndex;
            /// Tag字体
            if (this.TagFontname.SelectedItem != null)
                _Qh.TagFontname = this.TagFontname.SelectedItem.ToString();
            /// Tag下划线
            _Qh.TagFontunderline = this.TagFontunderline.IsChecked.Value ;
            /// Tag是否斜体
            _Qh.TagFontitalic = this.TagFontitalic.IsChecked.Value;
            /// Tag是否加粗
            _Qh.TagFontbold = this.TagFontbold.IsChecked.Value;
            /// Tag字体大小
            _Qh.TagFontsize = Convert.ToInt16(this.TagFontsize.Value);
            /// Tag类型
            if (this.LabelType.SelectedItem != null)
                _Qh.LabelType = (this.LabelType.SelectedItem as ComboBoxItem).Content.ToString();


            /// 英文标签是否显示
            _Qh.EnlabelVisible = this.EnlabelVisible.IsChecked.Value;
            /// 英文标签显示内容
            _Qh.EnlabelCaption = this.EnlabelCaption.Text;
            /// 英文标签颜色
            //_Qh.TagFontcolor = this.EnlabelFontcolor.SelectedIndex;
            /// 英文标签字体名称
            if (this.EnlabelFontname.SelectedItem != null)
                _Qh.EnlabelFontname = this.EnlabelFontname.SelectedItem.ToString();
            /// 英文标签下划线
            _Qh.EnlabelFontunderline = this.EnlabelFontunderline.IsChecked.Value;
            /// 英文标签是否斜体
            _Qh.EnlabelFontitalic = this.EnlabelFontitalic.IsChecked.Value;
            /// 英文标签是否加粗
            _Qh.EnlabelFontbold = this.EnlabelFontbold.IsChecked.Value;
            /// 英文标签字体大小
            _Qh.EnlabelFontsize = Convert.ToInt16(this.EnlabelFontsize.Value);
            _Qh.EnlabelFontcolor = EnlabelFontcolor.SelectedIndex;

            if (this._SendBottomKJ != null)
            {
                SendBottomKJ.SetPropert();
            }

            _Qh.ButtomType = cbButtomType.IsChecked.Value;
            if (cbButtomType.IsChecked.Value)
            {
                _Qh.Windowonid = (cbPageWin.SelectedItem as PageWinOR).Id;
            }

        }

        private void InitValue()
        {
            this.LabelVisible.IsChecked = _Qh.LabelVisible;/// 标签是否显示

            this.LabelCaption.Text = _Qh.LabelCaption;/// 标签显示内容
            /// 标签颜色
            this.LabelFontcolor.SelectedIndex = _Qh.LabelFontcolor;
            /// 标签字体名称
            this.LabelFontname.SelectedValue = _Qh.LabelFontname;

            /// 标签下划线
            this.LabelFontunderline.IsChecked = _Qh.LabelFontunderline;
            /// 标签是否斜体
            this.LabelFontitalic.IsChecked = _Qh.LabelFontitalic;
            /// 标签是否加粗
            this.LabelFontbold.IsChecked = _Qh.LabelFontbold ;
            /// 标签字体大小
            this.LabelFontsize.Value = _Qh.LabelFontsize;
            //标签类型
            this.LabelType.SelectedValue = _Qh.LabelType;
            /// 标签业务No
            //this.LabelJobno  
            /// 标签业务名称
            //this.LabelJobname
			this.txtLabWidth.Text = _Qh.ButtonWidth.ToString();
			this.txtLabHeight.Text = _Qh.ButtonHeight.ToString();
			foreach (ComboBoxItem cbi in cbBg.Items)
			{
				if (cbi.Content.ToString() == _Qh.Bg)
				{
					cbBg.SelectedItem = cbi;
					break;
				}
			}
			
            /// 标签打印字字符串
            this.LabelPrintstr.Text = _Qh.LabelPrintstr;
            /// 标签是否显示边框
            this.LabelShade.IsChecked = _Qh.LabelShade ;

            /// Tag是否显示
            this.TagVisible.IsChecked = _Qh.TagVisible ;
            /// Tag显示内容
            this.TagCaption.Text = _Qh.TagCaption;
            /// Tag字体颜色
            this.TagFontcolor.SelectedIndex = _Qh.TagFontcolor;
            /// Tag字体
            this.TagFontname.SelectedValue = _Qh.TagFontname;
            /// Tag下划线
            this.TagFontunderline.IsChecked = _Qh.TagFontunderline ;
            /// Tag是否斜体
            this.TagFontitalic.IsChecked = _Qh.TagFontitalic ;
            /// Tag是否加粗.IsChecked= _Qh.LabelShade=="0"?  true: false;
            this.TagFontbold.IsChecked = _Qh.TagFontbold ;
            /// Tag字体大小
            this.TagFontsize.Value = _Qh.TagFontsize;
            /// Tag类型
            if(!string.IsNullOrEmpty(_Qh.LabelType)){
                this.LabelType.SelectedIndex = Convert.ToInt16(_Qh.LabelType);
            }
            /// 英文标签是否显示
            this.EnlabelVisible.IsChecked = _Qh.EnlabelVisible ;
            /// 英文标签显示内容
            this.EnlabelCaption.Text = _Qh.EnlabelCaption;
            /// 英文标签颜色
            this.EnlabelFontcolor.SelectedIndex = _Qh.EnlabelFontcolor;
            /// 英文标签字体名称
            this.EnlabelFontname.SelectedValue = _Qh.EnlabelFontname;
            /// 英文标签下划线
            this.EnlabelFontunderline.IsChecked = _Qh.EnlabelFontunderline ;
            /// 英文标签是否斜体
            this.EnlabelFontitalic.IsChecked = _Qh.EnlabelFontitalic;
            /// 英文标签是否加粗
            this.EnlabelFontbold.IsChecked = _Qh.EnlabelFontbold;
            /// 英文标签字体大小
            this.EnlabelFontsize.Value = _Qh.EnlabelFontsize;

            //是否为页窗口
            cbButtomType.IsChecked = _Qh.ButtomType;
            int index = 0;
            if (_Qh.ButtomType)
            {
                if (!string.IsNullOrEmpty(_Qh.Windowonid))
                {
                    if (Common.ListPageWin != null)
                    {
                        foreach (PageWinOR obj in Common.ListPageWin)
                        {
                            if (obj.Id == _Qh.Windowonid)
                            {
                                cbPageWin.SelectedIndex = index;
                                break;
                            }
                            index++;
                        }
                    }
                }
                cbYW.IsEnabled = false;
            }
            else
            {  
                foreach (YWOR yw in MainPage.ListYw)
                {
                    if (yw.NO == _Qh.LabelJobno)
                    {
                        cbYW.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
                cbPageWin.IsEnabled = false;
            }
        }

        private void cbButtomType_Checked(object sender, RoutedEventArgs e)
        {
            cbYW.IsEnabled = false;
            cbPageWin.IsEnabled = true;
        }

        private void cbButtomType_Unchecked(object sender, RoutedEventArgs e)
        {
            cbYW.IsEnabled =true ;
            cbPageWin.IsEnabled = false;
        }

        /**
         /// 标签是否显示
LabelVisible
/// 标签显示内容
LabelCaption
/// 标签颜色
LabelFontcolor
/// 标签字体名称
LabelFontname
/// 标签下划线
LabelFontunderline
/// 标签是否斜体
LabelFontitalic
/// 标签是否加粗
LabelFontbold
/// 标签字体大小
LabelFontsize
/// 标签业务No
LabelJobno  
/// 标签业务名称
LabelJobname
/// 标签打印字字符串
LabelPrintstr
/// 标签是否显示边框
LabelShade
         
/// Tag是否显示
TagVisible
/// Tag显示内容
TagCaption
/// Tag字体颜色
TagFontcolor
/// Tag字体
TagFontname
/// Tag下划线
TagFontunderline
/// Tag是否斜体
TagFontitalic
/// Tag是否加粗
TagFontbold
/// Tag字体大小
TagFontsize
/// Tag类型
LabelType
/// 英文标签是否显示
EnlabelVisible
/// 英文标签显示内容
EnlabelCaption
/// 英文标签颜色
EnlabelFontcolor
/// 英文标签字体名称
EnlabelFontname
/// 英文标签下划线
EnlabelFontunderline
/// 英文标签是否斜体
EnlabelFontitalic
/// 英文标签是否加粗
EnlabelFontbold
/// 英文标签字体大小
EnlabelFontsize
         
         */
    }
}

