using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class SysParaOR
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

		private string _Orgbh;
		/// <summary>
		/// 所属机构
		/// </summary>
		public string Orgbh
		{
			get { return _Orgbh; }
			set { _Orgbh = value; }
		}

		private string _Keystr;
		/// <summary>
		/// 关键字
		/// </summary>
		public string Keystr
		{
			get { return _Keystr; }
			set { _Keystr = value; }
		}

		private string _Valuestr;
		/// <summary>
		/// 值
		/// </summary>
		public string Valuestr
		{
			get { return _Valuestr; }
			set { _Valuestr = value; }
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

		/// <summary>
		/// SysPara构造函数
		/// </summary>
		public SysParaOR()
		{

		}

		/// <summary>
		/// SysPara构造函数
		/// </summary>
		public SysParaOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 所属机构
			_Orgbh = row["OrgBH"].ToString().Trim();
			// 关键字
			_Keystr = row["KeyStr"].ToString().Trim();
			// 值
			_Valuestr = row["ValueStr"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
		}
    }
}

