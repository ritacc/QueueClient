using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace QM.Entity.ParaSet
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public class PageWinOR
    {
       
		private string _Id;
		/// <summary>
		/// 
		/// </summary>
        [DataMember]
        public string Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private string _Name;
		/// <summary>
		/// 名称
		/// </summary>
        [DataMember]
        public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private int _Width;
		/// <summary>
		/// 宽
		/// </summary>
        [DataMember]
        public int Width
		{
			get { return _Width; }
			set { _Width = value; }
		}

		private int _Height;
		/// <summary>
		/// 高
		/// </summary>
        [DataMember]
        public int Height
		{
			get { return _Height; }
			set { _Height = value; }
		}

		private string _Orgbh;
		/// <summary>
		/// 
		/// </summary>
        [DataMember]
        public string Orgbh
		{
			get { return _Orgbh; }
			set { _Orgbh = value; }
		}

        /// <summary>
        /// 用于选
        /// </summary>
        public bool ISSelect { get; set; }

		/// <summary>
		/// PageWin构造函数
		/// </summary>
		public PageWinOR()
		{

		}

		/// <summary>
		/// PageWin构造函数
		/// </summary>
		public PageWinOR(DataRow row)
		{
			// 
			_Id = row["Id"].ToString().Trim();
			// 名称
			_Name = row["Name"].ToString().Trim();
			// 宽
			_Width = Convert.ToInt32(row["Width"]);
			// 高
			_Height = Convert.ToInt32(row["Height"]);
			// 
			_Orgbh = row["orgBH"].ToString().Trim();
		}
    }
}

