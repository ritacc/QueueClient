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
using ButtomDefin.Control;
using ButtomDefin.WCFSV;
using System.Collections.ObjectModel;
using System.Windows.Browser;

namespace ButtomDefin
{
    public class ButtomAdmin
    {
        public   QhandyOR Init(QhandyOR mButtom,string _wdbh)
        {
            mButtom.Id = Guid.NewGuid().ToString();
            mButtom.Windowid = "";
            mButtom.Windowonid = "";
            mButtom.Orgbh = _wdbh;// this._WDBH;

            // 标签ID
            //_LabelIdx = Convert.ToInt32(row["LABEL_IDX"]);
            // 标签是否显示
            mButtom.LabelVisible = true;
            // 标签显示内容
            mButtom.LabelCaption = "Text";
            // 标签颜色
            mButtom.LabelFontcolor = 0;
            // 标签字体名称
            mButtom.LabelFontname = "宋体";
            // 标签下划线
            mButtom.LabelFontunderline = false;
            // 标签是否斜体
            mButtom.LabelFontitalic = false;
            // 标签是否加粗
            mButtom.LabelFontbold = false;
            // 标签字体大小
            mButtom.LabelFontsize = 12;
            //标签Top

            // 标签业务No
            mButtom.LabelJobno = "";
            // 标签业务名称
            mButtom.LabelJobname = "";
            // 标签打印字字符串
            mButtom.LabelPrintstr = "";
            // 标签是否显示边框
            mButtom.LabelShade = false;

            // Tag是否显示
            mButtom.TagVisible = true;
            // Tag显示内容
            mButtom.TagCaption = "TagText";
            // Tag字体颜色
            mButtom.TagFontcolor = 0;
            // Tag字体
            mButtom.TagFontname = "宋体";
            // Tag下划线
            mButtom.TagFontunderline = false;
            // Tag是否斜体
            mButtom.TagFontitalic = false;
            // Tag是否加粗
            mButtom.TagFontbold = false;
            // Tag字体大小
            mButtom.TagFontsize = 9;


            // Tag类型
            mButtom.LabelType = "";


            // 英文标签是否显示
            mButtom.EnlabelVisible = true;
            // 英文标签显示内容
            mButtom.EnlabelCaption = "EnLabelText";
            // 英文标签颜色
            mButtom.EnlabelFontcolor = 0;
            // 英文标签字体名称
            mButtom.EnlabelFontname = "宋体";
            // 英文标签下划线
            mButtom.EnlabelFontunderline = false;
            // 英文标签是否斜体
            mButtom.EnlabelFontitalic = false;
            // 英文标签是否加粗
            mButtom.EnlabelFontbold = true;
            // 英文标签字体大小
            mButtom.EnlabelFontsize = 12;

            mButtom.Screentype = 0;// Convert.ToInt32(row["SCREENTYPE"]);
            return mButtom;
        }

        private void BindeEvent(FrameworkElement Frawe)
        {
            Frawe.MouseLeftButtonDown += new MouseButtonEventHandler(BackgroundAdorner_MouseLeftButtonDown);
            Frawe.MouseLeftButtonUp += new MouseButtonEventHandler(BackgroundAdorner_MouseLeftButtonUp);
            Frawe.MouseMove += new MouseEventHandler(BackgroundAdorner_MouseMove);
        }

        public Canvas CBottom { get; set; }

        #region 处理按钮移动
        FrameworkElement MoveObj;
        FrameworkElement MoveObj2;
        FrameworkElement MoveObj3;
        bool MoveIsDown = false;
        Point BeginPoint;
        public void BackgroundAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MoveObj = null;
            MoveObj2 = null;
            MoveObj3 = null;

            MoveObj = sender as FrameworkElement;
            e.Handled = true;

            if (MoveObj is BottomKJ)
            {
                ButtomControl temp = MoveObj.Tag as ButtomControl;

                MoveObj2 = CBottom.FindName("x2" + temp.ID) as FrameworkElement;
                MoveObj3 = CBottom.FindName("x3" + temp.ID) as FrameworkElement;
            }

            MoveObj.CaptureMouse();
            MoveIsDown = true;
            BeginPoint = e.GetPosition(CBottom);
        }

        private void BackgroundAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MoveIsDown = false;

            if (MoveObj == null)
                return;
            MoveObj.ReleaseMouseCapture();
        }

        private void BackgroundAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (MoveIsDown)
            {
                Point EndPoint = e.GetPosition(CBottom);

                double x = EndPoint.X - BeginPoint.X;
                double y = EndPoint.Y - BeginPoint.Y;
                SetPosition(MoveObj, x, y);
                SetPosition(MoveObj2, x, y);
                SetPosition(MoveObj3, x, y);
                BeginPoint = EndPoint;
            }
        }

        private void SetPosition(FrameworkElement obj, double x, double y)
        {
            if (obj == null)
                return;

            double left = Convert.ToDouble(obj.GetValue(Canvas.LeftProperty));
            double top = Convert.ToDouble(obj.GetValue(Canvas.TopProperty));

            double leftx = left + x;
            double topy = top + y;

            obj.SetValue(Canvas.LeftProperty, leftx);
            obj.SetValue(Canvas.TopProperty, topy);
            if (obj is BottomKJ)
            {
                (obj.Tag as ButtomControl).ButtomOR.LabelLeft = Convert.ToInt16(leftx);
                (obj.Tag as ButtomControl).ButtomOR.LabelTop = Convert.ToInt16(topy);
            }
            else if (obj is ENLableControl)
            {
                (obj.Tag as ButtomControl).ButtomOR.EnlabelLeftoffset = Convert.ToInt16(leftx);
                (obj.Tag as ButtomControl).ButtomOR.EnlabelTopoffset = Convert.ToInt16(topy);
            }
            else if (obj is TagControl)
            {
                (obj.Tag as ButtomControl).ButtomOR.TagLeftoffset = Convert.ToInt16(leftx);
                (obj.Tag as ButtomControl).ButtomOR.TagTopoffset = Convert.ToInt16(topy);
            }
        }

        #endregion

		//double lableWidth = 200;
		double lableHeight = 50;

        double EnLableWidth = 300;
        double EnLableHeight = 50;

        double TagWidth = 300;
        double TagHeight =50;


        /// <summary>
        /// 添加一个按钮
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool AddAButtom(ButtomControl mbc)
        {
			if (mbc.ButtomOR.ButtonWidth <= 10)
				mbc.ButtomOR.ButtonWidth = 200;
			if (mbc.ButtomOR.ButtonHeight <= 10)
				mbc.ButtomOR.ButtonHeight = 50;
			lableHeight = mbc.ButtomOR.ButtonHeight;

            BottomKJ bc = new BottomKJ();
            bc.Name = "x1" + mbc.ID;
			bc.Width = mbc.ButtomOR.ButtonWidth;
			bc.Height = mbc.ButtomOR.ButtonHeight;
            bc.Tag = mbc;
            bc.SetValue(Canvas.LeftProperty, Convert.ToDouble(mbc.ButtomOR.LabelLeft));
            bc.SetValue(Canvas.TopProperty, Convert.ToDouble(mbc.ButtomOR.LabelTop));
			bc.SetSizeBg();
            bc.SetTextInfo();
            BindeEvent(bc);
            CBottom.Children.Add(bc);

            ENLableControl bc1 = new ENLableControl();
            bc1.Name = "x2" + mbc.ID;
            bc1.Width = EnLableWidth;
            bc1.Height = EnLableHeight;
            bc1.Tag = mbc;
            bc1.SetTextInfo();
            bc1.SetValue(Canvas.LeftProperty, Convert.ToDouble(mbc.ButtomOR.EnlabelLeftoffset));
            bc1.SetValue(Canvas.TopProperty, Convert.ToDouble(mbc.ButtomOR.EnlabelTopoffset));
            BindeEvent(bc1);
            CBottom.Children.Add(bc1);

            TagControl tab = new TagControl();
            tab.Name = "x3" + mbc.ID;
            tab.Width = TagWidth;
            tab.Height = TagHeight;
            tab.Tag = mbc;
            tab.SetTextInfo();
            tab.SetValue(Canvas.LeftProperty, Convert.ToDouble(mbc.ButtomOR.TagLeftoffset));
            tab.SetValue(Canvas.TopProperty, Convert.ToDouble(mbc.ButtomOR.TagTopoffset));
            BindeEvent(tab);
            CBottom.Children.Add(tab);
            return true;
        }

        public ButtomControl InitAddPosition(Point position, string _wdbh)
        {
            ButtomControl mbc = new ButtomControl();
            mbc.OpType = 0;
            mbc.ID = Guid.NewGuid().ToString();
            WCFSV.QhandyOR mButtom = new WCFSV.QhandyOR();

            mButtom = Init(mButtom, _wdbh);// Init(mButtom);
            mButtom.Orgbh = _wdbh;
            mbc.ButtomOR = mButtom;
            

            mbc.ButtomOR.LabelLeft = Convert.ToInt16(position.X);
            mbc.ButtomOR.LabelTop = Convert.ToInt16(position.Y);

            mbc.ButtomOR.EnlabelLeftoffset = Convert.ToInt16(position.X);
            mbc.ButtomOR.EnlabelTopoffset = Convert.ToInt16(position.Y + lableHeight * 0.7);

            mbc.ButtomOR.TagLeftoffset = Convert.ToInt16(position.X + TagWidth * 0.7);
            mbc.ButtomOR.TagTopoffset = Convert.ToInt16(position.Y);

            AddAButtom(mbc);
            return mbc;
        }
    }

     

}
