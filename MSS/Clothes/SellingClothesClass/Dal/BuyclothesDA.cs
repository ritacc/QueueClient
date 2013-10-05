using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OR;
using MSSClass.Entity;
using MSSClass.DBCommon;


namespace MSSClass.Dal
{
    /// <summary>
    /// 
    /// </summary>
    public class BuyclothesDA
    {
        DBCommon.CommonDB db = new CommonDB();

        #region 查询
        public DataTable selectAllDateByWhere(string where)
        {
            string sql = "select * from BuyClothes";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.executeQuery(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public BuyclothesOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from BuyClothes where string id={0}", m_id);
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
            BuyclothesOR m_Buyc = new BuyclothesOR(dr);
            return m_Buyc;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入BuyClothes
        /// </summary>
        public bool Insert(BuyclothesOR buyclothes)
        {
            string sql = string.Format("insert into BuyClothes ( ClothesBH, buyWhere, price, remark, buyData) values ('{0}', '{1}', {2}, '{3}', '{4}')",
             buyclothes.Clothesbh,
                 buyclothes.Buywhere,
                 buyclothes.Price,
                buyclothes.Remark,
                 buyclothes.Buydata);

            return db.excuteNonquery(sql);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新BuyClothes
        /// </summary>
        public virtual bool Update(BuyclothesOR buyclothes)
        {
            string sql = string.Format("update BuyClothes set  ClothesBH = '{0}',  buyWhere ='{1}',  price = {2},  remark = {3},  buyData = '{4}' where  ID = {5}",

                buyclothes.Clothesbh,
                buyclothes.Buywhere,
                buyclothes.Price,
                 buyclothes.Remark,
                 buyclothes.Buydata, buyclothes.Id);

            return db.excuteNonquery(sql);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除BuyClothes
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = string.Format("delete from BuyClothes where  ID ={0}", strId);
            return db.excuteNonquery(sql);
        }
        #endregion
    }
}

