using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BussinessOR
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

		private string _Name;
		/// <summary>
		/// 业务名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Englishname;
		/// <summary>
		/// 英文的业务名称，用于界面显示（可选）
		/// </summary>
		public string Englishname
		{
			get { return _Englishname; }
			set { _Englishname = value; }
		}

		private string _Typename;
		/// <summary>
		/// 业务种类，相当于业务名称的缩写，比如业务名称为“存取款和缴费”，则业务种类为“M1”
		/// </summary>
		public string Typename
		{
			get { return _Typename; }
			set { _Typename = value; }
		}

		private int _Waittime1;
		/// <summary>
		/// 等候时间1
		/// </summary>
		public int Waittime1
		{
			get { return _Waittime1; }
			set { _Waittime1 = value; }
		}

		private int _Priortime1;
		/// <summary>
		/// 优先时间1 。“等候时间1”和“优先时间1”指客户等待时间1大于XX秒时，排队优先时间1等于YY秒
		/// </summary>
		public int Priortime1
		{
			get { return _Priortime1; }
			set { _Priortime1 = value; }
		}

		private int _Waittime2;
		/// <summary>
		/// 等候时间2
		/// </summary>
		public int Waittime2
		{
			get { return _Waittime2; }
			set { _Waittime2 = value; }
		}

		private int _Priortime2;
		/// <summary>
		/// 优先时间2。同理，等候时间2需大于等候时间1
		/// </summary>
		public int Priortime2
		{
			get { return _Priortime2; }
			set { _Priortime2 = value; }
		}

		private int _Waittime3;
		/// <summary>
		/// 等候时间3
		/// </summary>
		public int Waittime3
		{
			get { return _Waittime3; }
			set { _Waittime3 = value; }
		}

		private int _Priortime3;
		/// <summary>
		/// 优先时间3。同理，等候时间3需大于等候时间2
		/// </summary>
		public int Priortime3
		{
			get { return _Priortime3; }
			set { _Priortime3 = value; }
		}

		private int _Ticketmethod;
		/// <summary>
		/// 取号方式。1是刷卡取号----此队列必须刷卡取号。2是直接取号----直接取号无需刷卡。3是刷卡直接取号----可以直接取号也可刷卡取号
		/// </summary>
		public int Ticketmethod
		{
			get { return _Ticketmethod; }
			set { _Ticketmethod = value; }
		}

		private bool _Mondayflag;
		/// <summary>
		/// 周一是否办理的标记，1表示办理，0表示不能办理
		/// </summary>
		public bool Mondayflag
		{
			get { return _Mondayflag; }
			set { _Mondayflag = value; }
		}

		private string _Mondaytime;
		/// <summary>
		/// 周一工作时间，不能超过3个时间段，各时间段以分号隔开。如08301200;13001400;15001800;表示从8:30到12:00，然后13:00到14:00,然后15:00到18:00.只有1个时间段时为08301200;;;
		/// </summary>
		public string Mondaytime
		{
			get { return _Mondaytime; }
			set { _Mondaytime = value; }
		}

		private bool _Tuesdayflag;
		/// <summary>
		/// 周二办理标记
		/// </summary>
		public bool Tuesdayflag
		{
			get { return _Tuesdayflag; }
			set { _Tuesdayflag = value; }
		}

		private string _Tuesdaytime;
		/// <summary>
		/// 周二工作时间
		/// </summary>
		public string Tuesdaytime
		{
			get { return _Tuesdaytime; }
			set { _Tuesdaytime = value; }
		}

		private bool _Wednesdayflag;
		/// <summary>
		/// 周三办理标记
		/// </summary>
		public bool Wednesdayflag
		{
			get { return _Wednesdayflag; }
			set { _Wednesdayflag = value; }
		}

		private string _Wednesdaytime;
		/// <summary>
		/// 周三工作时间
		/// </summary>
		public string Wednesdaytime
		{
			get { return _Wednesdaytime; }
			set { _Wednesdaytime = value; }
		}

		private bool _Thurdayflag;
		/// <summary>
		/// 周l四办理标记
		/// </summary>
		public bool Thurdayflag
		{
			get { return _Thurdayflag; }
			set { _Thurdayflag = value; }
		}

		private string _Thurdaytime;
		/// <summary>
		/// 周四工作时间
		/// </summary>
		public string Thurdaytime
		{
			get { return _Thurdaytime; }
			set { _Thurdaytime = value; }
		}

		private bool _Fridayflag;
		/// <summary>
		/// 周五办理标记
		/// </summary>
		public bool Fridayflag
		{
			get { return _Fridayflag; }
			set { _Fridayflag = value; }
		}

		private string _Fridaytime;
		/// <summary>
		/// 周五工作时间
		/// </summary>
		public string Fridaytime
		{
			get { return _Fridaytime; }
			set { _Fridaytime = value; }
		}

		private bool _Saturdayflag;
		/// <summary>
		/// 周六办理标记
		/// </summary>
		public bool Saturdayflag
		{
			get { return _Saturdayflag; }
			set { _Saturdayflag = value; }
		}

		private string _Saturdaytime;
		/// <summary>
		/// 周六办理标记
		/// </summary>
		public string Saturdaytime
		{
			get { return _Saturdaytime; }
			set { _Saturdaytime = value; }
		}

		private bool _Sundayflag;
		/// <summary>
		/// 周日办理标记
		/// </summary>
		public bool Sundayflag
		{
			get { return _Sundayflag; }
			set { _Sundayflag = value; }
		}

		private string _Sundaytime;
		/// <summary>
		/// 周日工作时间
		/// </summary>
		public string Sundaytime
		{
			get { return _Sundaytime; }
			set { _Sundaytime = value; }
		}

		private string _Description;
		/// <summary>
		/// 描述
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		private string _Orgbh;
		/// <summary>
		/// 机构编号
		/// </summary>
		public string Orgbh
		{
			get { return _Orgbh; }
			set { _Orgbh = value; }
		}

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }

		/// <summary>
		/// Bussiness构造函数
		/// </summary>
		public BussinessOR()
		{

		}

		/// <summary>
		/// Bussiness构造函数
		/// </summary>
		public BussinessOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 业务名称
			_Name = row["Name"].ToString().Trim();
			// 英文的业务名称，用于界面显示（可选）
			_Englishname = row["EnglishName"].ToString().Trim();
			// 业务种类，相当于业务名称的缩写，比如业务名称为“存取款和缴费”，则业务种类为“M1”
			_Typename = row["TypeName"].ToString().Trim();
			// 等候时间1
			_Waittime1 = Convert.ToInt32(row["WaitTime1"]);
			// 优先时间1 。“等候时间1”和“优先时间1”指客户等待时间1大于XX秒时，排队优先时间1等于YY秒
			_Priortime1 = Convert.ToInt32(row["PriorTime1"]);
			// 等候时间2
			_Waittime2 = Convert.ToInt32(row["WaitTime2"]);
			// 优先时间2。同理，等候时间2需大于等候时间1
			_Priortime2 = Convert.ToInt32(row["PriorTime2"]);
			// 等候时间3
			_Waittime3 = Convert.ToInt32(row["WaitTime3"]);
			// 优先时间3。同理，等候时间3需大于等候时间2
			_Priortime3 = Convert.ToInt32(row["PriorTime3"]);
			// 取号方式。1是刷卡取号----此队列必须刷卡取号。2是直接取号----直接取号无需刷卡。3是刷卡直接取号----可以直接取号也可刷卡取号
			_Ticketmethod = Convert.ToInt32(row["TicketMethod"]);
			
            // 周一是否办理的标记，1表示办理，0表示不能办理
            _Mondayflag = false;
            if (row["MondayFlag"] != DBNull.Value)
            {
                _Mondayflag = Convert.ToBoolean(row["MondayFlag"]);
            }
            // 周一工作时间，不能超过3个时间段，各时间段以分号隔开。如08301200;13001400;15001800;表示从8:30到12:00，然后13:00到14:00,然后15:00到18:00.只有1个时间段时为08301200;;;
            _Mondaytime = row["MondayTime"].ToString().Trim();
           
			// 周二办理标记
            _Tuesdayflag = false;
            if (row["TuesdayFlag"] != DBNull.Value)
                _Tuesdayflag = Convert.ToBoolean(row["TuesdayFlag"]);
			// 周二工作时间
			_Tuesdaytime = row["TuesdayTime"].ToString().Trim();
			// 周三办理标记
            _Wednesdayflag = false;
            if(row["WednesdayFlag"] != DBNull.Value)
			_Wednesdayflag = Convert.ToBoolean(row["WednesdayFlag"]);
			// 周三工作时间
			_Wednesdaytime = row["WednesdayTime"].ToString().Trim();
			// 周l四办理标记
            _Thurdayflag = false;
            if (row["ThurdayFlag"] != DBNull.Value)
                _Thurdayflag = Convert.ToBoolean(row["ThurdayFlag"]);
			// 周四工作时间
			_Thurdaytime = row["ThurdayTime"].ToString().Trim();

			// 周五办理标记
            _Fridayflag = false;
            if (row["FridayFlag"] != DBNull.Value)
                _Fridayflag = Convert.ToBoolean(row["FridayFlag"]);

			// 周五工作时间
			_Fridaytime = row["FridayTime"].ToString().Trim();
			// 周六办理标记
            _Saturdayflag = false;
            if (row["SaturdayFlag"] != DBNull.Value)
                _Saturdayflag = Convert.ToBoolean(row["SaturdayFlag"]);
			// 周六办理标记
			_Saturdaytime = row["SaturdayTime"].ToString().Trim();

			// 周日办理标记
            _Sundayflag = false;
            if (row["SundayFlag"] != DBNull.Value)
                _Sundayflag = Convert.ToBoolean(row["SundayFlag"]);

			// 周日工作时间
			_Sundaytime = row["SundayTime"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 机构编号
			_Orgbh = row["OrgBH"].ToString().Trim();
            //前缀
            Prefix = row["prefix"].ToString().Trim();
		}
    }
}

