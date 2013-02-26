using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BankOR
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

		private string _Orgno;
		/// <summary>
		/// 机构编号
		/// </summary>
		public string Orgno
		{
			get { return _Orgno; }
			set { _Orgno = value; }
		}

		private string _Orgname;
		/// <summary>
		/// 机构名称
		/// </summary>
		public string Orgname
		{
			get { return _Orgname; }
			set { _Orgname = value; }
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

		private string _Parentorgbh;
		/// <summary>
		/// 上级机构编号
		/// </summary>
		public string Parentorgbh
		{
			get { return _Parentorgbh; }
			set { _Parentorgbh = value; }
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

		private int _Banksort;
		/// <summary>
		/// 
		/// </summary>
		public int Banksort
		{
			get { return _Banksort; }
			set { _Banksort = value; }
		}

		/// <summary>
		/// Bank构造函数
		/// </summary>
		public BankOR()
		{

		}

		/// <summary>
		/// Bank构造函数
		/// </summary>
		public BankOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 机构编号
			_Orgno = row["OrgNo"].ToString().Trim();
			// 机构名称
			_Orgname = row["OrgName"].ToString().Trim();
			// 机构编号
			_Orgbh = row["OrgBH"].ToString().Trim();
			// 上级机构编号
			_Parentorgbh = row["ParentOrgBH"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 
			_Banksort = Convert.ToInt32(row["BankSort"]);
		}
    }
}

