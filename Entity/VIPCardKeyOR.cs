using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class VIPCardKeyOR
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

		private string _Vipcardkey;
		/// <summary>
		/// VIP卡识别码
		/// </summary>
		public string Vipcardkey
		{
			get { return _Vipcardkey; }
			set { _Vipcardkey = value; }
		}

		private string _Vipcardtype;
		/// <summary>
		/// VIP卡类型
		/// </summary>
		public string Vipcardtype
		{
			get { return _Vipcardtype; }
			set { _Vipcardtype = value; }
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
		/// VIPCardKey构造函数
		/// </summary>
		public VIPCardKeyOR()
		{
_Id = System.Guid.NewGuid().ToString();

		}

		/// <summary>
		/// VIPCardKey构造函数
		/// </summary>
		public VIPCardKeyOR(DataRow row)
		{
			// 
			_Id = row["ID"].ToString().Trim();
			// VIP卡识别码
			_Vipcardkey = row["VIPCardKey"].ToString().Trim();
			// VIP卡类型
			_Vipcardtype = row["VipCardType"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 所属机构
			_Orgbh = row["orgbh"].ToString().Trim();
		}
    }
}

