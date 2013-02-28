using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ShutdownTimeOR
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

		private string _Mondaytime;
		/// <summary>
		/// 周一关机时间
		/// </summary>
		public string Mondaytime
		{
			get { return _Mondaytime; }
			set { _Mondaytime = value; }
		}

		private string _Tuesdaytime;
		/// <summary>
		/// 周二关机时间
		/// </summary>
		public string Tuesdaytime
		{
			get { return _Tuesdaytime; }
			set { _Tuesdaytime = value; }
		}

		private string _Wednesdaytime;
		/// <summary>
		/// 周三关机时间
		/// </summary>
		public string Wednesdaytime
		{
			get { return _Wednesdaytime; }
			set { _Wednesdaytime = value; }
		}

		private string _Thurdaytime;
		/// <summary>
		/// 周四关机时间
		/// </summary>
		public string Thurdaytime
		{
			get { return _Thurdaytime; }
			set { _Thurdaytime = value; }
		}

		private string _Fridaytime;
		/// <summary>
		/// 周五关机时间
		/// </summary>
		public string Fridaytime
		{
			get { return _Fridaytime; }
			set { _Fridaytime = value; }
		}

		private string _Saturdaytime;
		/// <summary>
		/// 周六关机时间
		/// </summary>
		public string Saturdaytime
		{
			get { return _Saturdaytime; }
			set { _Saturdaytime = value; }
		}

		private string _Sundaytime;
		/// <summary>
		/// 周日关机时间
		/// </summary>
		public string Sundaytime
		{
			get { return _Sundaytime; }
			set { _Sundaytime = value; }
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
		/// ShutdownTime构造函数
		/// </summary>
		public ShutdownTimeOR()
		{

		}

		/// <summary>
		/// ShutdownTime构造函数
		/// </summary>
		public ShutdownTimeOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 周一关机时间
			_Mondaytime = row["MondayTime"].ToString().Trim();
			// 周二关机时间
			_Tuesdaytime = row["TuesdayTime"].ToString().Trim();
			// 周三关机时间
			_Wednesdaytime = row["WednesdayTime"].ToString().Trim();
			// 周四关机时间
			_Thurdaytime = row["ThurdayTime"].ToString().Trim();
			// 周五关机时间
			_Fridaytime = row["FridayTime"].ToString().Trim();
			// 周六关机时间
			_Saturdaytime = row["SaturdayTime"].ToString().Trim();
			// 周日关机时间
			_Sundaytime = row["SundayTime"].ToString().Trim();
			// 描述
			_Description = row["Description"].ToString().Trim();
			// 所属机构
			_Orgbh = row["orgbh"].ToString().Trim();
		}
    }
}

