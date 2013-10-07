using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MSSClass.Entity
{
	public class MaintainOR
	{
		public int ID { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string MC { get; set; }
		/// <summary>
		///  [实收]
		/// </summary>
		public double SS { get; set; }

		/// <summary>
		/// [成本]
		/// </summary>
		public double CB { get; set; }
		/// <summary>
		///  [利润]
		/// </summary>
		public double LR { get; set; }
		 

		/// <summary>
		///  [供货商]
		/// </summary>
		public string GHS { get; set; }

		 

		 

		/// <summary>
		///  [销售日期]
		/// </summary>
		public DateTime RQ { get; set; }

		 
		public MaintainOR()
		{

		}

		public MaintainOR(DataRow dr)
		{
			MC = dr["MC"].ToString();
			SS = Convert.ToDouble(dr["SS"].ToString());
			CB = Convert.ToDouble(dr["CB"].ToString());
			LR = Convert.ToDouble(dr["LR"].ToString()); 
			RQ = Convert.ToDateTime(dr["RQ"].ToString()); 
		}
	}
}
