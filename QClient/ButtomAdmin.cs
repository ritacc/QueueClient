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
using System.Collections.ObjectModel;
using QClient.QueueClinetServiceReference;
using System.Threading;
using System.Windows.Threading;
using QClient.Core.Uitl.Logger;

namespace QClient
{
    public class ButtomAdmin
    { 
        public QhandyOR Init(QhandyOR mButtom,string _wdbh)
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

        public Canvas CBottom { get; set; }
        public bool StopRef { get; set; }

        double lableWidth = 200;
        double lableHeight = 50;

        double EnLableWidth = 200;
        double EnLableHeight = 35;

        double TagWidth = 200;
        double TagHeight = 35;


        /// <summary>
        /// 添加一个按钮
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public BottomKJ AddAButtom(ButtomControl mbc)
        {
            StopRef = false;
            RefButtomText BtnOR = new RefButtomText();
            
            BottomKJ bc = new BottomKJ();
            bc.Width = lableWidth;
            bc.Height = lableHeight;
            bc.Tag = mbc;
            bc.DataContext = mbc.ButtomOR;
            bc.SetValue(Canvas.LeftProperty, Convert.ToDouble(mbc.ButtomOR.LabelLeft));
            bc.SetValue(Canvas.TopProperty, Convert.ToDouble(mbc.ButtomOR.LabelTop));
			bc.SetSizeBg();
            bc.SetTextInfo();
            //string mName = "kj" + mbc.ID;
            //bc.Name = mName;
            CBottom.Children.Add(bc);
            BtnOR.BtnKJ = bc;

            ENLableControl bc1 = new ENLableControl();
            bc1.Width = EnLableWidth;
            bc1.Height = EnLableHeight;
            bc1.Tag = mbc;
            //mbc.ButtomOR
            //mName = "en" + mbc.ID;
            //bc.Name = mName;
            bc1.SetTextInfo();
            bc1.SetValue(Canvas.LeftProperty, Convert.ToDouble(mbc.ButtomOR.EnlabelLeftoffset));
            bc1.SetValue(Canvas.TopProperty, Convert.ToDouble(mbc.ButtomOR.EnlabelTopoffset));
        
            CBottom.Children.Add(bc1);
            BtnOR.BtnEn = bc1;

            TagControl tab = new TagControl();
            tab.Width = TagWidth;
            tab.Height = TagHeight;
            tab.Tag = mbc;
            
            //mName = "tag" + mbc.ID;
            //tab.Name = mName;
            tab.SetTextInfo();
            tab.SetValue(Canvas.LeftProperty, Convert.ToDouble(mbc.ButtomOR.TagLeftoffset));
            tab.SetValue(Canvas.TopProperty, Convert.ToDouble(mbc.ButtomOR.TagTopoffset));
            CBottom.Children.Add(tab);
            
            BtnOR.BtnTag = tab;
            BtnOR.QHOR = mbc.ButtomOR;

            ListQH.Add(BtnOR);

            return bc;
        }

        List<RefButtomText> ListQH = new List<RefButtomText>();
        public void RefButtomWaitNumber()
        {
            var client = new QueueClientSoapClient();
            do
            {
                if (StopRef)
                    return;

                foreach (RefButtomText obj in ListQH)
                {
                    try
                    {
                        if (obj.QHOR.LabelCaption.IndexOf("#wait") >= 0 || obj.QHOR.EnlabelCaption.IndexOf("#wait") >= 0 || obj.QHOR.TagCaption.IndexOf("#wait") >= 0)
                        {
                            int UserNum = 0;
                            if (!string.IsNullOrEmpty(obj.QHOR.LabelJobno))
                            {
                                UserNum = client.GetBussinessWiatUser(obj.QHOR.LabelJobno);
                            }
                            else
                            {
                                UserNum = 0;
                            }

                            if (obj.BtnKJ != null)
                            {
                                obj.BtnKJ.SetText(obj.QHOR.LabelCaption.Replace("#wait", UserNum.ToString()));
                            }

                            if (obj.BtnEn != null)
                            {
                                obj.BtnEn.SetText(obj.QHOR.EnlabelCaption.Replace("#wait", UserNum.ToString()));
                            }

                            if (obj.BtnTag != null)
                            {
                                obj.BtnTag.SetText(obj.QHOR.TagCaption.Replace("#wait", UserNum.ToString()));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.WriteLog("RefButtomText：#wait", ex.Message);
                    }
                }
                Thread.Sleep(10 * 1000);

            } while (true);
        }

        public ButtomControl InitAddPosition(Point position, string _wdbh)
        {
            ButtomControl mbc = new ButtomControl();
            mbc.OpType = 0;
            mbc.ID = Guid.NewGuid().ToString();
            QhandyOR mButtom = new QhandyOR();

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
