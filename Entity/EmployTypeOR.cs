using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployTypeOR
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
		/// 柜员类型名称，如普通柜员、高级柜员、个人业务顾问等
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
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
		/// 
		/// </summary>
		public string Orgbh
		{
			get { return _Orgbh; }
			set { _Orgbh = value; }
		}

		/// <summary>
		/// EmployType构造函数
		/// </summary>
		public EmployTypeOR()
		{

		}

		/// <summary>
		/// EmployType构造函数
		/// </summary>
		public EmployTypeOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 柜员类型名称，如普通柜员、高级柜员、个人业务顾问等
			_Name = row["Name"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 
			_Orgbh = row["OrgBH"].ToString().Trim();
		}
    }
}

