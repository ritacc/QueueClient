using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OR;
using MSSClass.DBCommon;
using MSSClass.Entity;


namespace MSSClass.Dal
{
    /// <summary>
    /// 
    /// </summary>
    public class SellclothesDA
    {
        DBCommon.CommonDB db = new CommonDB();

        #region 查询
        public DataTable selectAllDateByWhere(string where)
        {
            string sql = "select * from SellClothes";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable selectCountData(string where)
        {
            string sql = @"select sum(purchaseCountPrice) as purchaseCount,sum(sellPrice) as sellPriceCount,sum(profit) as profitCount  from SellClothes ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable selectViewData(string where)
        { 
            string sql = @"select id as [编号],
sellTime as [销售时间],
SellType as [类型],
ClotheNo as [衣服编号],
ClotheName as [衣服名称],
purchasePrice as [进货价],
purchaseCountPrice as 进货总价,
sellPrice as [销售价格],
profit as [利润],
remark as [备注]
from SellClothes ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public SellclothesOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from SellClothes where  id={0}", m_id);
            DataTable dt = null;
            try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            SellclothesOR m_Sell = new SellclothesOR(dr);
            return m_Sell;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入SellClothes
        /// </summary>
        public virtual bool Insert(SellclothesOR sellclothes)
        {
            string sql = string.Format(@"insert into SellClothes (SellType, ClotheNo, ClotheName, purchasePrice, purchaseCountPrice, sellPrice, profit, sellTime) 
values ('{0}', '{1}', '{2}', '{3}', {4}, {5}, {6}, '{7}')",
            sellclothes.Selltype,sellclothes.Clotheno,sellclothes.Clothename, sellclothes.Purchaseprice,
                 sellclothes.Purchasecountprice,sellclothes.Sellprice,sellclothes.Profit,
                 sellclothes.Selltime
            );           
            return db.excuteNonquery(sql);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新SellClothes
        /// </summary>
        public virtual bool Update(SellclothesOR sellclothes)
        {
            string sql = string.Format(@"update SellClothes set  SellType = '{0}',  ClotheNo = '{1}',  ClotheName = '{2}',  purchasePrice = '{3}',  purchaseCountPrice = {4},
sellPrice = {5},  profit ={6},remark='{7}'   where  ID = {8}", sellclothes.Selltype,
				sellclothes.Clotheno,sellclothes.Clothename,
				sellclothes.Purchaseprice,sellclothes.Purchasecountprice,
                sellclothes.Sellprice, sellclothes.Profit, sellclothes.Remark,
                sellclothes.Id);
            return db.excuteNonquery(sql);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除SellClothes
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = string.Format("delete from SellClothes where  ID = {0}", strId);            
            return db.excuteNonquery(sql);
        }
        #endregion
    }
}

