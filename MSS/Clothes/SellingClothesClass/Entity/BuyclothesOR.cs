using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MSSClass.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class BuyclothesOR
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

        private string _Clothesbh;
        /// <summary>
        /// 
        /// </summary>
        public string Clothesbh
        {
            get { return _Clothesbh; }
            set { _Clothesbh = value; }
        }

        private string _Buywhere;
        /// <summary>
        /// 
        /// </summary>
        public string Buywhere
        {
            get { return _Buywhere; }
            set { _Buywhere = value; }
        }

        private float _Price;
        /// <summary>
        /// 
        /// </summary>
        public float Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private string _Remark;
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _Buydata;
        /// <summary>
        /// 
        /// </summary>
        public string Buydata
        {
            get { return _Buydata; }
            set { _Buydata = value; }
        }

        /// <summary>
        /// Buyclothes构造函数
        /// </summary>
        public BuyclothesOR()
        {

        }

        /// <summary>
        /// Buyclothes构造函数
        /// </summary>
        public BuyclothesOR(DataRow row)
        {
            // 
            _Id = Convert.ToInt32(row["id"]);
            // 
            _Clothesbh = row["ClothesBH"].ToString().Trim();
            // 
            _Buywhere = row["buyWhere"].ToString().Trim();
            // 
            _Price = float.Parse(row["price"].ToString());
            // 
            _Remark = row["remark"].ToString().Trim();
            // 
            _Buydata = row["buyData"].ToString().Trim();
        }
    }
}

