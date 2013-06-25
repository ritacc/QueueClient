using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{

    public class BussinessRoleOnBussOR : BussinessRoleOR
    {
        public BussinessRoleOnBussOR(DataRow dr) : base(dr) { }

        public List<BussinessRoleONOR> BussRoleOnList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BussinessRoleOR
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
		/// 业务角色名称
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
		/// BussinessRole构造函数
		/// </summary>
		public BussinessRoleOR()
		{

		}

		/// <summary>
		/// BussinessRole构造函数
		/// </summary>
		public BussinessRoleOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 业务角色名称
			_Name = row["Name"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 
			_Orgbh = row["OrgBH"].ToString().Trim();
		}
    }
}

