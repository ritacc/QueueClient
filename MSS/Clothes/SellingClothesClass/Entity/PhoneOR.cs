using System;
using System.Collections.Generic;
using System.Text;

namespace MSSClass.Entity
{
	public class PhoneOR
	{
		/// <summary>
		///  [机型]
		/// </summary>
		public string JX { get; set; }
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
		///  [串号]
		/// </summary>
		public string CH { get; set; }

		/// <summary>
		///  [供货商]
		/// </summary>
		public string GHS { get; set; }

		/// <summary>
		/// [购买人]
		/// </summary>
		public string GMR { get; set; }

		/// <summary>
		///  [联系电话]
		/// </summary>
		public string LXDH { get; set; }

		/// <summary>
		///  [销售日期]
		/// </summary>
		public DateTime XSRQ { get; set; }

		/// <summary>
		///  [售后状况]
		/// </summary>
		public string SHZK { get; set; }
	}
}
