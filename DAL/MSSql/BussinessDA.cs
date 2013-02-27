using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QM.Client.Entity;

namespace QM.Client.DA.MSSql
{
    /// <summary>
    /// 
    /// </summary>
    public class BussinessMSSqlDA : DALBase
    {
        public List<BussinessOR> selectBankData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_Bussiness bu
inner join t_Bank b on b.orgbh= bu.orgbh where " + orgbhWhere;
            DataTable dt = null;
            try
            {
                dt = dbMsSql.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            List<BussinessOR> listBussi = new List<BussinessOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessOR obj = new BussinessOR(dr);
                listBussi.Add(obj);
            }
            return listBussi;
        }
        public BussinessOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_Bussiness where  Id='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = dbMsSql.ExecuteQueryDataSet(sql).Tables[0];
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
            BussinessOR m_Buss = new BussinessOR(dr);
            return m_Buss;

        }
    }
}

