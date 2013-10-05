using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OR
{
    /// <summary>
    /// 
    /// </summary>
    public class UsecontrolOR
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

		private string _Starttime;
		/// <summary>
		/// 
		/// </summary>
		public string Starttime
		{
			get { return _Starttime; }
			set { _Starttime = value; }
		}

		private string _Lasttime;
		/// <summary>
		/// 
		/// </summary>
		public string Lasttime
		{
			get { return _Lasttime; }
			set { _Lasttime = value; }
		}

		private int _Useday;
		/// <summary>
		/// 
		/// </summary>
		public int Useday
		{
			get { return _Useday; }
			set { _Useday = value; }
		}

		private int _Allcanuseday;
		/// <summary>
		/// 
		/// </summary>
		public int Allcanuseday
		{
			get { return _Allcanuseday; }
			set { _Allcanuseday = value; }
		}

		private int _Isover;
		/// <summary>
		/// 
		/// </summary>
		public int Isover
		{
			get { return _Isover; }
			set { _Isover = value; }
		}

		/// <summary>
		/// Usecontrol构造函数
		/// </summary>
		public UsecontrolOR()
		{

		}

		/// <summary>
		/// Usecontrol构造函数
		/// </summary>
		public UsecontrolOR(DataRow row)
		{
			// 
			_Id = row["id"].ToString().Trim();
			// 
			_Starttime = row["startTime"].ToString().Trim();
			// 
			_Lasttime = row["lastTime"].ToString().Trim();
			// 
			_Useday = Convert.ToInt32(row["useDay"]);
			// 
			_Allcanuseday = Convert.ToInt32(row["allCanUseDay"]);
			// 
			_Isover = Convert.ToInt32(row["isOver"]);
		}
    }
}

