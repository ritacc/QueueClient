using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowLoginInfoOR
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

		private DateTime _Logintime;
		/// <summary>
		/// 
		/// </summary>
		public DateTime Logintime
		{
			get { return _Logintime; }
			set { _Logintime = value; }
		}

		private string _Windowno;
		/// <summary>
		/// 
		/// </summary>
		public string Windowno
		{
			get { return _Windowno; }
			set { _Windowno = value; }
		}

		private string _Employno;
		/// <summary>
		/// 
		/// </summary>
		public string Employno
		{
			get { return _Employno; }
			set { _Employno = value; }
		}

		private string _Employname;
		/// <summary>
		/// 
		/// </summary>
		public string Employname
		{
			get { return _Employname; }
			set { _Employname = value; }
		}

		private int _Status;
		/// <summary>
        /// 0：登录:1退出,2暂停
		/// </summary>
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		private DateTime _Alerttime;
		/// <summary>
		/// 
		/// </summary>
		public DateTime Alerttime
		{
			get { return _Alerttime; }
			set { _Alerttime = value; }
		}

		/// <summary>
		/// windowlogininfo构造函数
		/// </summary>
        public WindowLoginInfoOR()
        {
            _Id = System.Guid.NewGuid().ToString();
            _Logintime = _Alerttime = DateTime.Now;

        }

		/// <summary>
		/// windowlogininfo构造函数
		/// </summary>
        public WindowLoginInfoOR(DataRow row)
		{
			// 
			_Id = row["ID"].ToString().Trim();
			// 
			_Logintime = Convert.ToDateTime(row["LoginTime"]);
			// 
			_Windowno = row["WindowNo"].ToString().Trim();
			// 
			_Employno = row["EmployNo"].ToString().Trim();
			// 
			_Employname = row["EmployName"].ToString().Trim();
			// 
			_Status = Convert.ToInt32(row["Status"]);
			// 
			_Alerttime = Convert.ToDateTime(row["AlertTime"]);
		}
    }
}

