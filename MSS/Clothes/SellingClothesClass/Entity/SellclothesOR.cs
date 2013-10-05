using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MSSClass.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class SellclothesOR
    {

        private string _Id;
        /// <summary>
        /// GUID
        /// </summary>
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Selltype;
        /// <summary>
        /// 类型:T恤,裙子，上衣等
        /// </summary>
        public string Selltype
        {
            get { return _Selltype; }
            set { _Selltype = value; }
        }

        private string _Clotheno;
        /// <summary>
        /// 进货编号
        /// </summary>
        public string Clotheno
        {
            get { return _Clotheno; }
            set { _Clotheno = value; }
        }

        private string _Clothename;
        /// <summary>
        ///  衣服名称
        /// </summary>
        public string Clothename
        {
            get { return _Clothename; }
            set { _Clothename = value; }
        }

        private string _Purchaseprice;
        /// <summary>
        /// 进货价格,可以多件一起
        /// </summary>
        public string Purchaseprice
        {
            get { return _Purchaseprice; }
            set { _Purchaseprice = value; }
        }

        private float _Purchasecountprice;
        /// <summary>
        ///进货总价
        /// </summary>
        public float Purchasecountprice
        {
            get { return _Purchasecountprice; }
            set { _Purchasecountprice = value; }
        }

        private float _Sellprice;
        /// <summary>
        /// 销售价
        /// </summary>
        public float Sellprice
        {
            get { return _Sellprice; }
            set { _Sellprice = value; }
        }

        private float _Profit;
        /// <summary>
        /// 利润
        /// </summary>
        public float Profit
        {
            get { return _Profit; }
            set { _Profit = value; }
        }

        private string _Selltime;
        /// <summary>
        /// 销售时间
        /// </summary>
        public string Selltime
        {
            get { return _Selltime; }
            set { _Selltime = value; }
        }

        private string m_remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return m_remark; }
            set { m_remark = value; }
        }


        /// <summary>
        /// Sellclothes构造函数
        /// </summary>
        public SellclothesOR()
        {

        }

        /// <summary>
        /// Sellclothes构造函数
        /// </summary>
        public SellclothesOR(DataRow row)
        {
            // 
            _Id = row["id"].ToString().Trim();
            // 
            _Selltype = row["SellType"].ToString().Trim();
            // 
            _Clotheno = row["ClotheNo"].ToString().Trim();
            // 
            _Clothename = row["ClotheName"].ToString().Trim();
            // 
            _Purchaseprice = row["purchasePrice"].ToString().Trim();
            // 
            _Purchasecountprice = float.Parse(row["purchaseCountPrice"].ToString());
            // 
            _Sellprice = float.Parse(row["sellPrice"].ToString());
            // 
            _Profit = float.Parse(row["profit"].ToString());
            // 
            _Selltime = row["sellTime"].ToString().Trim();

            m_remark = row["remark"].ToString().Trim();
        }
    }
}

