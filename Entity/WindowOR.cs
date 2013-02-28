using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowOR
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
		/// 窗口名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Role;
		/// <summary>
		/// 业务角色
		/// </summary>
		public string Role
		{
			get { return _Role; }
			set { _Role = value; }
		}

		private int _Sounddev;
		/// <summary>
		/// 声音设备
		/// </summary>
		public int Sounddev
		{
			get { return _Sounddev; }
			set { _Sounddev = value; }
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
		/// 机构
		/// </summary>
		public string Orgbh
		{
			get { return _Orgbh; }
			set { _Orgbh = value; }
		}

		/// <summary>
		/// Window构造函数
		/// </summary>
		public WindowOR()
		{

		}

		/// <summary>
		/// Window构造函数
		/// </summary>
		public WindowOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 窗口名称
			_Name = row["Name"].ToString().Trim();
			// 业务角色
			_Role = row["Role"].ToString().Trim();
			// 声音设备
			_Sounddev = Convert.ToInt32(row["SoundDev"]);
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 机构
			_Orgbh = row["OrgBH"].ToString().Trim();
		}
    }
}

