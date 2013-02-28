using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class VipCardTypeOR
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
		/// 名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private int _Firsttime;
		/// <summary>
		/// 优先时间
		/// </summary>
		public int Firsttime
		{
			get { return _Firsttime; }
			set { _Firsttime = value; }
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
		/// VipCardType构造函数
		/// </summary>
		public VipCardTypeOR()
		{

		}

		/// <summary>
		/// VipCardType构造函数
		/// </summary>
		public VipCardTypeOR(DataRow row)
		{
			// 
			_Id = row["id"].ToString().Trim();
			// 名称
			_Name = row["name"].ToString().Trim();
			// 优先时间
			_Firsttime = Convert.ToInt32(row["FirstTime"]);
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 所属机构
			_Orgbh = row["orgBH"].ToString().Trim();
		}
    }
}

