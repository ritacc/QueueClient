using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    public class QhandyOR
    {
        private string _Id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Orgbh;
        /// <summary>
        /// 
        /// </summary>
        public string Orgbh
        {
            get { return _Orgbh; }
            set { _Orgbh = value; }
        }

        private int _LabelIdx;
        /// <summary>
        /// 
        /// </summary>
        public int LabelIdx
        {
            get { return _LabelIdx; }
            set { _LabelIdx = value; }
        }

        private bool _LabelVisible;
        /// <summary>
        /// 标签是否显示
        /// </summary>
        public bool LabelVisible
        {
            get { return _LabelVisible; }
            set { _LabelVisible = value; }
        }

        private string _LabelCaption;
        /// <summary>
        /// 标签显示内容
        /// </summary>
        public string LabelCaption
        {
            get { return _LabelCaption; }
            set { _LabelCaption = value; }
        }

        private int _LabelFontcolor;
        /// <summary>
        /// 标签颜色
        /// </summary>
        public int LabelFontcolor
        {
            get { return _LabelFontcolor; }
            set { _LabelFontcolor = value; }
        }

        private string _LabelFontname;
        /// <summary>
        /// 标签字体名称
        /// </summary>
        public string LabelFontname
        {
            get { return _LabelFontname; }
            set { _LabelFontname = value; }
        }

        private bool _LabelFontunderline;
        /// <summary>
        /// 标签下划线
        /// </summary>
        public bool LabelFontunderline
        {
            get { return _LabelFontunderline; }
            set { _LabelFontunderline = value; }
        }

        private bool _LabelFontitalic;
        /// <summary>
        /// 标签是否斜体
        /// </summary>
        public bool LabelFontitalic
        {
            get { return _LabelFontitalic; }
            set { _LabelFontitalic = value; }
        }

        private bool _LabelFontbold;
        /// <summary>
        /// 标签是否加粗
        /// </summary>
        public bool LabelFontbold
        {
            get { return _LabelFontbold; }
            set { _LabelFontbold = value; }
        }

        private int _LabelFontsize;
        /// <summary>
        /// 标签字体大小
        /// </summary>
        public int LabelFontsize
        {
            get { return _LabelFontsize; }
            set { _LabelFontsize = value; }
        }

        private int _LabelTop;
        /// <summary>
        /// 
        /// </summary>
        public int LabelTop
        {
            get { return _LabelTop; }
            set { _LabelTop = value; }
        }

        private int _LabelLeft;
        /// <summary>
        /// 
        /// </summary>
        public int LabelLeft
        {
            get { return _LabelLeft; }
            set { _LabelLeft = value; }
        }

        private string _LabelJobno;
        /// <summary>
        /// 标签业务No
        /// </summary>
        public string LabelJobno
        {
            get { return _LabelJobno; }
            set { _LabelJobno = value; }
        }

        private string _LabelJobname;
        /// <summary>
        /// 标签业务名称
        /// </summary>
        public string LabelJobname
        {
            get { return _LabelJobname; }
            set { _LabelJobname = value; }
        }

        private string _LabelPrintstr;
        /// <summary>
        /// 标签打印字字符串
        /// </summary>
        public string LabelPrintstr
        {
            get { return _LabelPrintstr; }
            set { _LabelPrintstr = value; }
        }

        private bool _LabelShade;
        /// <summary>
        /// 标签是否显示边框
        /// </summary>
        public bool LabelShade
        {
            get { return _LabelShade; }
            set { _LabelShade = value; }
        }

        private bool _TagVisible;
        /// <summary>
        /// Tag是否显示
        /// </summary>
        public bool TagVisible
        {
            get { return _TagVisible; }
            set { _TagVisible = value; }
        }

        private string _TagCaption;
        /// <summary>
        /// Tag显示内容
        /// </summary>
        public string TagCaption
        {
            get { return _TagCaption; }
            set { _TagCaption = value; }
        }

        private int _TagFontcolor;
        /// <summary>
        /// Tag字体颜色
        /// </summary>
        public int TagFontcolor
        {
            get { return _TagFontcolor; }
            set { _TagFontcolor = value; }
        }

        private string _TagFontname;
        /// <summary>
        /// Tag字体
        /// </summary>
        public string TagFontname
        {
            get { return _TagFontname; }
            set { _TagFontname = value; }
        }

        private bool _TagFontunderline;
        /// <summary>
        /// Tag下划线
        /// </summary>
        public bool TagFontunderline
        {
            get { return _TagFontunderline; }
            set { _TagFontunderline = value; }
        }

        private bool _TagFontitalic;
        /// <summary>
        /// Tag是否斜体
        /// </summary>
        public bool TagFontitalic
        {
            get { return _TagFontitalic; }
            set { _TagFontitalic = value; }
        }

        private bool _TagFontbold;
        /// <summary>
        /// Tag是否加粗
        /// </summary>
        public bool TagFontbold
        {
            get { return _TagFontbold; }
            set { _TagFontbold = value; }
        }

        private int _TagFontsize;
        /// <summary>
        /// Tag字体大小
        /// </summary>
        public int TagFontsize
        {
            get { return _TagFontsize; }
            set { _TagFontsize = value; }
        }

        private int _TagTopoffset;
        /// <summary>
        /// 
        /// </summary>
        public int TagTopoffset
        {
            get { return _TagTopoffset; }
            set { _TagTopoffset = value; }
        }

        private int _TagLeftoffset;
        /// <summary>
        /// 
        /// </summary>
        public int TagLeftoffset
        {
            get { return _TagLeftoffset; }
            set { _TagLeftoffset = value; }
        }

        private string _LabelType;
        /// <summary>
        /// 类型
        /// </summary>
        public string LabelType
        {
            get { return _LabelType; }
            set { _LabelType = value; }
        }

        private bool _EnlabelVisible;
        /// <summary>
        /// 英文标签是否显示
        /// </summary>
        public bool EnlabelVisible
        {
            get { return _EnlabelVisible; }
            set { _EnlabelVisible = value; }
        }

        private string _EnlabelCaption;
        /// <summary>
        /// 英文标签显示内容
        /// </summary>
        public string EnlabelCaption
        {
            get { return _EnlabelCaption; }
            set { _EnlabelCaption = value; }
        }

        private int _EnlabelFontcolor;
        /// <summary>
        /// 英文标签颜色
        /// </summary>
        public int EnlabelFontcolor
        {
            get { return _EnlabelFontcolor; }
            set { _EnlabelFontcolor = value; }
        }

        private string _EnlabelFontname;
        /// <summary>
        /// 英文标签字体名称
        /// </summary>
        public string EnlabelFontname
        {
            get { return _EnlabelFontname; }
            set { _EnlabelFontname = value; }
        }

        private bool _EnlabelFontitalic;
        /// <summary>
        /// 英文标签是否斜体
        /// </summary>
        public bool EnlabelFontitalic
        {
            get { return _EnlabelFontitalic; }
            set { _EnlabelFontitalic = value; }
        }

        private bool _EnlabelFontunderline;
        /// <summary>
        /// 英文标签下划线
        /// </summary>
        public bool EnlabelFontunderline
        {
            get { return _EnlabelFontunderline; }
            set { _EnlabelFontunderline = value; }
        }

        private bool _EnlabelFontbold;
        /// <summary>
        /// 英文标签是否加粗
        /// </summary>
        public bool EnlabelFontbold
        {
            get { return _EnlabelFontbold; }
            set { _EnlabelFontbold = value; }
        }

        private int _EnlabelFontsize;
        /// <summary>
        /// 英文标签字体大小
        /// </summary>
        public int EnlabelFontsize
        {
            get { return _EnlabelFontsize; }
            set { _EnlabelFontsize = value; }
        }

        private int _Screentype;
        /// <summary>
        /// 
        /// </summary>
        public int Screentype
        {
            get { return _Screentype; }
            set { _Screentype = value; }
        }

        private int _EnlabelLeftoffset;
        /// <summary>
        /// 
        /// </summary>
        public int EnlabelLeftoffset
        {
            get { return _EnlabelLeftoffset; }
            set { _EnlabelLeftoffset = value; }
        }

        private int _EnlabelTopoffset;
        /// <summary>
        /// 
        /// </summary>
        public int EnlabelTopoffset
        {
            get { return _EnlabelTopoffset; }
            set { _EnlabelTopoffset = value; }
        }

        /// <summary>
        /// 按钮类型
        /// </summary>
        public bool Buttomtype { get; set; }

        private string _Windowonid;
        /// <summary>
        /// 按钮关联窗口ID
        /// </summary>
        public string Windowonid
        {
            get { return _Windowonid; }
            set { _Windowonid = value; }
        }

        private string _Windowid;
        /// <summary>
        /// 窗口ID
        /// </summary>
        public string Windowid
        {
            get { return _Windowid; }
            set { _Windowid = value; }
        }

		public double ButtonWidth { get; set; }
		public double ButtonHeight { get; set; }

		private string _bg;
		public string Bg
		{
			get { return _bg; }
			set { _bg = value; }
		}

        /// <summary>
        /// Qhandy构造函数
        /// </summary>
        public QhandyOR()
        {
            _Id = Guid.NewGuid().ToString();


            _Orgbh = "";
            // 
            _LabelIdx = 0;
            // 
            _LabelVisible = true;
            // 
            _LabelCaption = "text";
            // 
            _LabelFontcolor = 0;
            // 
            _LabelFontname = "宋体";
            // 
            _LabelFontunderline = false;
            // 
            _LabelFontitalic = false;
            // 
            _LabelFontbold = false;
            // 
            _LabelFontsize = 12;
            // 
            _LabelTop = 0;
            // 
            _LabelLeft = 0;
            // 
            _LabelJobno = "";
            // 
            _LabelJobname = "";
            // 
            _LabelPrintstr = "";
            // 
            _LabelShade = false;
            // 
            _TagVisible = true;
            // 
            _TagCaption = "text";
            // 
            _TagFontcolor = 0;
            // 
            _TagFontname = "宋体";
            // 
            _TagFontunderline = false;
            // 
            _TagFontitalic = false;
            // 
            _TagFontbold = false;
            // 
            _TagFontsize = 9;
            // 
            _TagTopoffset = 0;
            // 
            _TagLeftoffset = 0;
            // 
            _LabelType = "1";
            // 
            _EnlabelVisible = true;
            // 
            _EnlabelCaption = "text";
            // 
            _EnlabelFontcolor = 0;
            // 
            _EnlabelFontname = "宋体";
            // 
            _EnlabelFontitalic = false;
            // 
            _EnlabelFontunderline = false;
            // 
            _EnlabelFontbold = false;
            // 
            _EnlabelFontsize = 9;
            // 
            _Screentype = 0;
            // 
            _EnlabelLeftoffset = 0;
            // 
            _EnlabelTopoffset = 0;
            // 
            _Windowonid = "";
            // 
            _Windowid = "";

			ButtonWidth = 200;
			ButtonHeight = 50;
			Bg = "bg1.png";
        }

        /// <summary>
        /// Qhandy构造函数
        /// </summary>
        public QhandyOR(DataRow row)
        {
            // 
            _Id = row["ID"].ToString().Trim();
            // 
            _Orgbh = row["OrgBH"].ToString().Trim();
            // 
            _LabelIdx = Convert.ToInt32(row["LABEL_IDX"]);
            // 标签是否显示
            _LabelVisible = Convert.ToBoolean(row["LABEL_VISIBLE"]);
            // 标签显示内容
            _LabelCaption = row["LABEL_CAPTION"].ToString().Trim();
            // 标签颜色
            _LabelFontcolor = Convert.ToInt32(row["LABEL_FONTCOLOR"]);
            // 标签字体名称
            _LabelFontname = row["LABEL_FONTNAME"].ToString().Trim();
            // 标签下划线
            _LabelFontunderline = Convert.ToBoolean(row["LABEL_FONTUNDERLINE"]);
            // 标签是否斜体
            _LabelFontitalic = Convert.ToBoolean(row["LABEL_FONTITALIC"]);
            // 标签是否加粗
            _LabelFontbold = Convert.ToBoolean(row["LABEL_FONTBOLD"]);
            // 标签字体大小
            _LabelFontsize = Convert.ToInt32(row["LABEL_FONTSIZE"]);
            // 
            _LabelTop = Convert.ToInt32(row["LABEL_TOP"]);
            // 
            _LabelLeft = Convert.ToInt32(row["LABEL_LEFT"]);
            // 标签业务No
            _LabelJobno = row["LABEL_JOBNO"].ToString().Trim();
            // 标签业务名称
            _LabelJobname = row["LABEL_JOBNAME"].ToString().Trim();
            // 标签打印字字符串
            _LabelPrintstr = row["LABEL_PRINTSTR"].ToString().Trim();
            // 标签是否显示边框
            _LabelShade = Convert.ToBoolean(row["LABEL_SHADE"]);
            // Tag是否显示
            _TagVisible = Convert.ToBoolean(row["TAG_VISIBLE"]);
            // Tag显示内容
            _TagCaption = row["TAG_CAPTION"].ToString().Trim();
            // Tag字体颜色
            _TagFontcolor = Convert.ToInt32(row["TAG_FONTCOLOR"]);
            // Tag字体
            _TagFontname = row["TAG_FONTNAME"].ToString().Trim();
            // Tag下划线
            _TagFontunderline = Convert.ToBoolean(row["TAG_FONTUNDERLINE"]);
            // Tag是否斜体
            _TagFontitalic = Convert.ToBoolean(row["TAG_FONTITALIC"]);
            // Tag是否加粗
            _TagFontbold = Convert.ToBoolean(row["TAG_FONTBOLD"]);
            // Tag字体大小
            _TagFontsize = Convert.ToInt32(row["TAG_FONTSIZE"]);
            // 
            _TagTopoffset = Convert.ToInt32(row["TAG_TOPOFFSET"]);
            // 
            _TagLeftoffset = Convert.ToInt32(row["TAG_LEFTOFFSET"]);
            // 类型
            _LabelType = row["LABEL_TYPE"].ToString().Trim();
            // 英文标签是否显示
            _EnlabelVisible = Convert.ToBoolean(row["ENLABEL_VISIBLE"]);
            // 英文标签显示内容
            _EnlabelCaption = row["ENLABEL_CAPTION"].ToString().Trim();
            // 英文标签颜色
            _EnlabelFontcolor = Convert.ToInt32(row["ENLABEL_FONTCOLOR"]);
            // 英文标签字体名称
            _EnlabelFontname = row["ENLABEL_FONTNAME"].ToString().Trim();
            // 英文标签是否斜体
            _EnlabelFontitalic = Convert.ToBoolean(row["ENLABEL_FONTITALIC"]);
            // 英文标签下划线
            _EnlabelFontunderline = Convert.ToBoolean(row["ENLABEL_FONTUNDERLINE"]);
            // 英文标签是否加粗
            _EnlabelFontbold = Convert.ToBoolean(row["ENLABEL_FONTBOLD"]);
            // 英文标签字体大小
            _EnlabelFontsize = Convert.ToInt32(row["ENLABEL_FONTSIZE"]);
            // 
            _Screentype = Convert.ToInt32(row["SCREENTYPE"]);
            // 
            _EnlabelLeftoffset = Convert.ToInt32(row["ENLABEL_LEFTOFFSET"]);

            _EnlabelTopoffset = Convert.ToInt32(row["ENLABEL_TOPOFFSET"]);

            //按钮类型
            Buttomtype = Convert.ToBoolean(row["ButtomType"]);
            // 按钮关联窗口ID
            _Windowonid = row["windowOnID"].ToString().Trim();
            // 窗口ID
            _Windowid = row["windowID"].ToString().Trim();

			if (!string.IsNullOrEmpty(row["LABEL_Width"].ToString().Trim()))
				ButtonWidth = Convert.ToDouble(row["LABEL_Width"].ToString().Trim());

			if (!string.IsNullOrEmpty(row["LABEL_Height"].ToString().Trim()))
				ButtonHeight = Convert.ToDouble(row["LABEL_Height"].ToString().Trim());
			Bg = row["LABEL_BG"].ToString().Trim();
        }
    }
}
