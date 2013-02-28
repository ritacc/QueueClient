using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class NearbyInfoOR
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

		private int _Nearbyindex;
		/// <summary>
		/// 网点编号(1-5)
		/// </summary>
		public int Nearbyindex
		{
			get { return _Nearbyindex; }
			set { _Nearbyindex = value; }
		}

		private int _Orgno;
		/// <summary>
		/// 网点编号
		/// </summary>
		public int Orgno
		{
			get { return _Orgno; }
			set { _Orgno = value; }
		}

		private string _Bankname;
		/// <summary>
		/// 邻近网点名称
		/// </summary>
		public string Bankname
		{
			get { return _Bankname; }
			set { _Bankname = value; }
		}

		private string _Bankaddr;
		/// <summary>
		/// 邻近网点地址
		/// </summary>
		public string Bankaddr
		{
			get { return _Bankaddr; }
			set { _Bankaddr = value; }
		}

		private string _Businfo;
		/// <summary>
		/// 公交线路
		/// </summary>
		public string Businfo
		{
			get { return _Businfo; }
			set { _Businfo = value; }
		}

		private int _Flag;
		/// <summary>
		/// 启用标记，1为启用，0为禁用
		/// </summary>
		public int Flag
		{
			get { return _Flag; }
			set { _Flag = value; }
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
		/// NearbyInfo构造函数
		/// </summary>
		public NearbyInfoOR()
		{

		}

		/// <summary>
		/// NearbyInfo构造函数
		/// </summary>
		public NearbyInfoOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 所属机构
			_Orgbh = row["OrgBH"].ToString().Trim();
			// 网点编号(1-5)
			_Nearbyindex = Convert.ToInt32(row["NearbyIndex"]);
			// 网点编号
			_Orgno = Convert.ToInt32(row["OrgNo"]);
			// 邻近网点名称
			_Bankname = row["BankName"].ToString().Trim();
			// 邻近网点地址
			_Bankaddr = row["BankAddr"].ToString().Trim();
			// 公交线路
			_Businfo = row["BusInfo"].ToString().Trim();
			// 启用标记，1为启用，0为禁用
			_Flag = Convert.ToInt32(row["Flag"]);
			// 描述
			_Description = row["Description"].ToString().Trim();
		}
    }
}

