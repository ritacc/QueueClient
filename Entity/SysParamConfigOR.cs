using System;
using System.Collections.Generic;
using System.Text;

namespace QM.Client.Entity
{
    public class SysParamConfigOR
    {
        private string _Popswiptime;
        /// <summary>
        /// 提示刷卡界面停留时间
        /// </summary>
        public string Popswiptime
        {
            get { return _Popswiptime; }
            set { _Popswiptime = value; }
        }

        private string _Contickettime;
        /// <summary>
        /// 连续取号最短时间间隔等
        /// </summary>
        public string Contickettime
        {
            get { return _Contickettime; }
            set { _Contickettime = value; }
        }

        private string _Cartickettime;
        /// <summary>
        /// 同一张卡连续取号时间间隔
        /// </summary>
        public string Cartickettime
        {
            get { return _Cartickettime; }
            set { _Cartickettime = value; }
        }

        private string _Calllimittime;
        /// <summary>
        /// 呼叫限制
        /// </summary>
        public string Calllimittime
        {
            get { return _Calllimittime; }
            set { _Calllimittime = value; }
        }

        private string _Curshowtime;
        /// <summary>
        /// 每个排队曲线图显示时间，为0表示不显示
        /// </summary>
        public string Curshowtime
        {
            get { return _Curshowtime; }
            set { _Curshowtime = value; }
        }

        private string _Windowinfo;
        /// <summary>
        /// 窗口屏广告信息
        /// </summary>
        public string Windowinfo
        {
            get { return _Windowinfo; }
            set { _Windowinfo = value; }
        }

        private string _Mainwindowinfo;
        /// <summary>
        /// 主显屏广告信息
        /// </summary>
        public string Mainwindowinfo
        {
            get { return _Mainwindowinfo; }
            set { _Mainwindowinfo = value; }
        }

        private string _Backgroundsound;
        /// <summary>
        /// 呼叫提示音(1-无;2-提示音1;3-提示音2;4-提示音3)
        /// </summary>
        public string Backgroundsound
        {
            get { return _Backgroundsound; }
            set { _Backgroundsound = value; }
        }

        private string _Firstsound;
        /// <summary>
        /// 第一遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
        /// </summary>
        public string Firstsound
        {
            get { return _Firstsound; }
            set { _Firstsound = value; }
        }

        private string _Secondsound;
        /// <summary>
        /// 第二遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
        /// </summary>
        public string Secondsound
        {
            get { return _Secondsound; }
            set { _Secondsound = value; }
        }

        private string _Thirdsound;
        /// <summary>
        /// 第三遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
        /// </summary>
        public string Thirdsound
        {
            get { return _Thirdsound; }
            set { _Thirdsound = value; }
        }

        private string _Callvolumn;
        /// <summary>
        /// 语音呼叫音量（范围0-9）
        /// </summary>
        public string Callvolumn
        {
            get { return _Callvolumn; }
            set { _Callvolumn = value; }
        }

        private string _Backgroundvolumn;
        /// <summary>
        /// 背景音乐音量（范围0-9）
        /// </summary>
        public string Backgroundvolumn
        {
            get { return _Backgroundvolumn; }
            set { _Backgroundvolumn = value; }
        }

        private string _Vipcardinfo;
        /// <summary>
        /// 贵宾服务刷卡取号提示语
        /// </summary>
        public string Vipcardinfo
        {
            get { return _Vipcardinfo; }
            set { _Vipcardinfo = value; }
        }

        private string _Othercardinfo;
        /// <summary>
        /// 其他业务刷卡取号提示语
        /// </summary>
        public string Othercardinfo
        {
            get { return _Othercardinfo; }
            set { _Othercardinfo = value; }
        }

        private string _Invalidcardinfo;
        /// <summary>
        /// 无效卡提示语
        /// </summary>
        public string Invalidcardinfo
        {
            get { return _Invalidcardinfo; }
            set { _Invalidcardinfo = value; }
        }

        /// <summary>
        /// 有效卡code
        /// </summary>
        public string ValidCardCode { get; set; }

        public SysParamConfigOR()
        {
            // 提示刷卡界面停留时间
            _Popswiptime = "15";
            // 连续取号最短时间间隔等
            _Contickettime = "5";
            // 同一张卡连续取号时间间隔
            _Cartickettime = "5";
            // 呼叫限制
            _Calllimittime = "5";
            // 每个排队曲线图显示时间，为0表示不显示
            _Curshowtime = "1";
            // 窗口屏广告信息
            _Windowinfo = "欢迎光临";
            // 主显屏广告信息
            _Mainwindowinfo = "欢迎光临";

            // 呼叫提示音(1-无;2-提示音1;3-提示音2;4-提示音3)
            _Backgroundsound = "1";
            // 第一遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
            _Firstsound = "1";
            // 第二遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
            _Secondsound = "1";
            // 第三遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
            _Thirdsound = "1";


            // 语音呼叫音量（范围0-9）
            _Callvolumn = "5";
            // 背景音乐音量（范围0-9）
            _Backgroundvolumn = "5";

            // 贵宾服务刷卡取号提示语
            _Vipcardinfo = "请你刷贵宾卡取号，谢谢！";
            // 其他业务刷卡取号提示语
            _Othercardinfo = "请你刷卡取号，谢谢！";
            // 无效卡提示语
            _Invalidcardinfo = "对不起，此卡无效，请与大堂经理联系，谢谢！";
        }

        /// <summary>
        /// Temp构造函数
        /// </summary>
        //    public TempOR(DataRow row)
        //    {
        //        // 提示刷卡界面停留时间
        //        _Popswiptime = row["PopSwipTime"].ToString().Trim();
        //        // 连续取号最短时间间隔等
        //        _Contickettime = row["ConTicketTime"].ToString().Trim();
        //        // 同一张卡连续取号时间间隔
        //        _Cartickettime = row["CarTicketTime"].ToString().Trim();
        //        // 呼叫限制
        //        _Calllimittime = row["CallLimitTime"].ToString().Trim();
        //        // 每个排队曲线图显示时间，为0表示不显示
        //        _Curshowtime = row["CurShowTime"].ToString().Trim();
        //        // 窗口屏广告信息
        //        _Windowinfo = row["WindowInfo"].ToString().Trim();
        //        // 主显屏广告信息
        //        _Mainwindowinfo = row["MainWindowInfo"].ToString().Trim();
        //        // 呼叫提示音(1-无;2-提示音1;3-提示音2;4-提示音3)
        //        _Backgroundsound = row["BackgroundSound"].ToString().Trim();
        //        // 第一遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
        //        _Firstsound = row["FirstSound"].ToString().Trim();
        //        // 第二遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
        //        _Secondsound = row["SecondSound"].ToString().Trim();
        //        // 第三遍呼叫(1-普通话、2-粤语、3-英语、4-不播报)
        //        _Thirdsound = row["ThirdSound"].ToString().Trim();
        //        // 语音呼叫音量（范围0-9）
        //        _Callvolumn = row["CallVolumn"].ToString().Trim();
        //        // 背景音乐音量（范围0-9）
        //        _Backgroundvolumn = row["BackgroundVolumn"].ToString().Trim();
        //        // 贵宾服务刷卡取号提示语
        //        _Vipcardinfo = row["VIPCardInfo"].ToString().Trim();
        //        // 其他业务刷卡取号提示语
        //        _Othercardinfo = row["OtherCardInfo"].ToString().Trim();
        //        // 无效卡提示语
        //        _Invalidcardinfo = row["InvalidCardInfo"].ToString().Trim();
        //}
    }
}
