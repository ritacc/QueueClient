using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsPeopleOR
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
		/// 姓名
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Mobileno;
		/// <summary>
		/// 手机号码
		/// </summary>
		public string Mobileno
		{
			get { return _Mobileno; }
			set { _Mobileno = value; }
		}

		private int _Sendmoney;
		/// <summary>
		/// 发送金额
		/// </summary>
		public int Sendmoney
		{
			get { return _Sendmoney; }
			set { _Sendmoney = value; }
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
		/// 所属机构
		/// </summary>
		public string Orgbh
		{
			get { return _Orgbh; }
			set { _Orgbh = value; }
		}

		/// <summary>
		/// SmsPeople构造函数
		/// </summary>
		public SmsPeopleOR()
		{

		}

		/// <summary>
		/// SmsPeople构造函数
		/// </summary>
		public SmsPeopleOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 姓名
			_Name = row["Name"].ToString().Trim();
			// 手机号码
			_Mobileno = row["MobileNO"].ToString().Trim();
			// 发送金额
			_Sendmoney = Convert.ToInt32(row["SendMoney"]);
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 所属机构
			_Orgbh = row["orgbh"].ToString().Trim();
		}
    }
}

