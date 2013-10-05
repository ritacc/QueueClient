using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OR
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemsetOR
    {
        
		private int _Id;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _Keyword;
		/// <summary>
		/// 
		/// </summary>
		public string Keyword
		{
			get { return _Keyword; }
			set { _Keyword = value; }
		}

		private string _Keyname;
		/// <summary>
		/// 
		/// </summary>
		public string Keyname
		{
			get { return _Keyname; }
			set { _Keyname = value; }
		}

		/// <summary>
		/// Systemset构造函数
		/// </summary>
		public SystemsetOR()
		{

		}

		/// <summary>
		/// Systemset构造函数
		/// </summary>
		public SystemsetOR(DataRow row)
		{
			// 
			_Id = Convert.ToInt32(row["id"]);
			// 
			_Keyword = row["keyWord"].ToString().Trim();
			// 
			_Keyname = row["keyName"].ToString().Trim();
		}
    }
}

