using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace QM.Client.Entity
{
    public class QueueInfoOR
    {
        //是否VIP、取号时间、换算后排队时间、转移窗口号、延后人数、延后时间。
        #region 扩展的
        /// <summary>
        /// 是否VIP
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// 取号状态 0：取号,1:叫号、2：欢迎、3：结束、4上传完成。
        /// </summary>
        public int Status { get; set; }

        #endregion

        private string _Id;
		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _Bankno;
		/// <summary>
		/// 网点机构号
		/// </summary>
		public string Bankno
		{
			get { return _Bankno; }
			set { _Bankno = value; }
		}

		private string _Billno;
		/// <summary>
		/// 票号
		/// </summary>
		public string Billno
		{
			get { return _Billno; }
			set { _Billno = value; }
		}

		private string _Bussinessid;
		/// <summary>
		/// 业务代码
		/// </summary>
		public string Bussinessid
		{
			get { return _Bussinessid; }
			set { _Bussinessid = value; }
		}

		private DateTime _Prillbilltime;
		/// <summary>
		/// 取号时间
		/// </summary>
		public DateTime Prillbilltime
		{
			get { return _Prillbilltime; }
			set { _Prillbilltime = value; }
		}

		
		/// <summary>
		/// 硬呼叫器或软呼叫按下转移键时记录转移到的目的窗口号，用于排队计算用
		/// </summary>
        public string Transferdestwin
        {
            get;
            set;
        }

		private int _Delaynum;
		/// <summary>
		/// 延后的人数，用于排队计算；按下延后时更新此人数，以后有人办理时也需更新此人数，暂不使用这种策略
		/// </summary>
		public int Delaynum
		{
			get { return _Delaynum; }
			set { _Delaynum = value; }
		}

		private int _Delaytime;
		/// <summary>
		/// 延后秒数。记得在软呼叫或硬件时单位为分钟，需要换算后传过来。延后采用这种策略
		/// </summary>
		public int Delaytime
		{
			get { return _Delaytime; }
			set { _Delaytime = value; }
		}

		private DateTime _Calltime;
		/// <summary>
		/// 呼叫时间
		/// </summary>
		public DateTime Calltime
		{
			get { return _Calltime; }
			set { _Calltime = value; }
		}

		private DateTime _Processtime;
		/// <summary>
		/// 办理时间（等于按下欢迎光临的时间或呼叫时间）
		/// </summary>
		public DateTime Processtime
		{
			get { return _Processtime; }
			set { _Processtime = value; }
		}

		private DateTime _Finishtime;
		/// <summary>
		/// 完成时间（等于按请评价时间或呼叫下一位的时间）
		/// </summary>
		public DateTime Finishtime
		{
			get { return _Finishtime; }
			set { _Finishtime = value; }
		}

		private string _Windowno;
		/// <summary>
		/// 服务窗口号
		/// </summary>
		public string Windowno
		{
			get { return _Windowno; }
			set { _Windowno = value; }
		}

		private string _Employno;
		/// <summary>
		/// 柜员号，外键
		/// </summary>
		public string Employno
		{
			get { return _Employno; }
			set { _Employno = value; }
		}

		private string _Employname;
		/// <summary>
		/// 柜员姓名
		/// </summary>
		public string Employname
		{
			get { return _Employname; }
			set { _Employname = value; }
		}

		private string _Cardno;
		/// <summary>
		/// 取号的卡号
		/// </summary>
		public string Cardno
		{
			get { return _Cardno; }
			set { _Cardno = value; }
		}

		private int _Judge;
		/// <summary>
		/// 评价结果
		/// </summary>
		public int Judge
		{
			get { return _Judge; }
			set { _Judge = value; }
		}

		private int _Waitinterval;
		/// <summary>
		/// 等待时长(秒)
		/// </summary>
		public int Waitinterval
		{
			get { return _Waitinterval; }
			set { _Waitinterval = value; }
		}

		private int _Processinterval;
		/// <summary>
		/// 办理时长(秒)
		/// </summary>
		public int Processinterval
		{
			get { return _Processinterval; }
			set { _Processinterval = value; }
		}

		private int _Waitpeoplebusssiness;
		/// <summary>
		/// 取号时该业务的等待人数
		/// </summary>
		public int Waitpeoplebusssiness
		{
			get { return _Waitpeoplebusssiness; }
			set { _Waitpeoplebusssiness = value; }
		}

		private int _Waitpeoplebank;
		/// <summary>
		/// 取号时该网点的等待人数
		/// </summary>
		public int Waitpeoplebank
		{
			get { return _Waitpeoplebank; }
			set { _Waitpeoplebank = value; }
		}

		private int _Custemclass;
		/// <summary>
		/// 客户等级
		/// </summary>
		public int Custemclass
		{
			get { return _Custemclass; }
			set { _Custemclass = value; }
		}

		private string _Description;
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// QueueInfo构造函数
		/// </summary>
		public QueueInfoOR()
		{
            Status = 0; 
            _Id = Guid.NewGuid().ToString();
		}
        /// <param name="mCustemclass">客户级别</param>
 
        /// <summary>
        /// 用于取号初使化
        /// </summary>
        /// <param name="mBankNo"></param>
        /// <param name="mBillno">取号</param>
        /// <param name="mBussinessid"></param>
        /// <param name="mCardno">取号卡号</param>
        /// <param name="mWaitpeoplebusssiness">队列等待人数</param>
        /// <param name="mWaitpeoplebank">银行(网点等待人数量)</param>
       
        public QueueInfoOR(string mBankNo, string mBillno, string mBussinessid,
            string mCardno, int mWaitpeoplebusssiness, int mWaitpeoplebank)//, int mCustemclass)
        {
            Status = 0;

            _Id = Guid.NewGuid().ToString();
            _Bankno = mBankNo;// 网点机构号
            _Billno = mBillno;// 票号
            _Bussinessid = mBussinessid;// 业务代码
            _Cardno = mCardno;// 取号的卡号
            _Waitpeoplebusssiness = mWaitpeoplebusssiness;
            _Waitpeoplebank = mWaitpeoplebank;


            _Custemclass = 0;// mCustemclass;

            
            DateTime _Now = DateTime.Now;            
            // 取号时间
            _Prillbilltime = _Now;
            // 硬呼叫器或软呼叫按下转移键时记录转移到的目的窗口号，用于排队计算用
            Transferdestwin = "";
            // 延后的人数，用于排队计算；按下延后时更新此人数，以后有人办理时也需更新此人数，暂不使用这种策略
            _Delaynum =0;
            // 延后秒数。记得在软呼叫或硬件时单位为分钟，需要换算后传过来。延后采用这种策略
            _Delaytime =0;
            // 呼叫时间
            _Calltime = _Now;
            // 办理时间（等于按下欢迎光临的时间或呼叫时间）
            _Processtime = _Now;
            // 完成时间（等于按请评价时间或呼叫下一位的时间）
            _Finishtime = _Now;
            // 服务窗口号
            _Windowno = "";
            // 柜员号，外键
            _Employno = "";
            // 柜员姓名
            _Employname = "";
            // 评价结果
            _Judge = 0;
            // 等待时长(秒)
            _Waitinterval = 0;
            // 办理时长(秒)
            _Processinterval = 0;
            // 取号时该业务的等待人数
            _Waitpeoplebusssiness = 0;
            // 取号时该网点的等待人数
            _Waitpeoplebank = 0;
            // 客户等级
            _Custemclass = 0;
            _Description = "";
        }
		/// <summary>
		/// QueueInfo构造函数
		/// </summary>
		public QueueInfoOR(DataRow row)
        {
            
			// 
			_Id = row["Id"].ToString().Trim();
			// 网点机构号
			_Bankno = row["BankNo"].ToString().Trim();
			// 票号
			_Billno = row["BillNo"].ToString().Trim();
			// 业务代码
			_Bussinessid = row["BussinessId"].ToString().Trim();
			// 取号时间
			_Prillbilltime = Convert.ToDateTime(row["PrillBillTime"]);
			// 硬呼叫器或软呼叫按下转移键时记录转移到的目的窗口号，用于排队计算用
			Transferdestwin = row["TransferDestWin"].ToString();
			// 延后的人数，用于排队计算；按下延后时更新此人数，以后有人办理时也需更新此人数，暂不使用这种策略
			_Delaynum = Convert.ToInt32(row["DelayNum"]);
			// 延后秒数。记得在软呼叫或硬件时单位为分钟，需要换算后传过来。延后采用这种策略
			_Delaytime = Convert.ToInt32(row["DelayTime"]);
			// 呼叫时间
			_Calltime = Convert.ToDateTime(row["CallTime"]);
			// 办理时间（等于按下欢迎光临的时间或呼叫时间）
			_Processtime = Convert.ToDateTime(row["ProcessTime"]);
			// 完成时间（等于按请评价时间或呼叫下一位的时间）
			_Finishtime = Convert.ToDateTime(row["FinishTime"]);
			// 服务窗口号
			_Windowno = row["WindowNo"].ToString().Trim();
			// 柜员号，外键
			_Employno = row["EmployNo"].ToString().Trim();
			// 柜员姓名
			_Employname = row["EmployName"].ToString().Trim();
			// 取号的卡号
			_Cardno = row["CardNo"].ToString().Trim();
			// 评价结果
			_Judge = Convert.ToInt32(row["Judge"]);
			// 等待时长(秒)
			_Waitinterval = Convert.ToInt32(row["WaitInterval"]);
			// 办理时长(秒)
			_Processinterval = Convert.ToInt32(row["ProcessInterval"]);
			// 取号时该业务的等待人数
			_Waitpeoplebusssiness = Convert.ToInt32(row["WaitPeopleBusssiness"]);
			// 取号时该网点的等待人数
			_Waitpeoplebank = Convert.ToInt32(row["WaitPeopleBank"]);
			// 客户等级
			_Custemclass = Convert.ToInt32(row["CustemClass"]);
			// 
			_Description = row["Description"].ToString().Trim();

            Status = Convert.ToInt32(row["status"]);
		}
    }
}