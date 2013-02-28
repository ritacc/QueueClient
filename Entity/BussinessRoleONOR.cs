using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BussinessRoleONOR
    {
       
		private string _Bussinessroleid;
		/// <summary>
		/// 业务角色ID
		/// </summary>
		public string Bussinessroleid
		{
			get { return _Bussinessroleid; }
			set { _Bussinessroleid = value; }
		}

		private string _Bussinessid;
		/// <summary>
		/// 业务类型
		/// </summary>
		public string Bussinessid
		{
			get { return _Bussinessid; }
			set { _Bussinessid = value; }
		}

		private int _Priortimes;
		/// <summary>
		/// 主队列优先时间
		/// </summary>
		public int Priortimes
		{
			get { return _Priortimes; }
			set { _Priortimes = value; }
		}

		private int _Backuppriortimes;
		/// <summary>
		/// 备用队列优先时间
		/// </summary>
		public int Backuppriortimes
		{
			get { return _Backuppriortimes; }
			set { _Backuppriortimes = value; }
		}

		/// <summary>
		/// BussinessRoleON构造函数
		/// </summary>
		public BussinessRoleONOR()
		{

		}

		/// <summary>
		/// BussinessRoleON构造函数
		/// </summary>
		public BussinessRoleONOR(DataRow row)
		{
			// 业务角色ID
			_Bussinessroleid = row["BussinessRoleID"].ToString().Trim();
			// 业务类型
			_Bussinessid = row["BussinessId"].ToString().Trim();
			// 主队列优先时间
			_Priortimes = Convert.ToInt32(row["PriorTimes"]);
			// 备用队列优先时间
			_Backuppriortimes = Convert.ToInt32(row["BackupPriorTimes"]);
		}
    }
}

