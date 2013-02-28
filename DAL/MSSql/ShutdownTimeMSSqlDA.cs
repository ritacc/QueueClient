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
    public class ShutdownTimeMSSqlDA : DALBase
    {
        public List<ShutdownTimeOR> selectShutdownTimeData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_ShutdownTime bu
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
            List<ShutdownTimeOR> listShut = new List<ShutdownTimeOR>();
            foreach (DataRow dr in dt.Rows)
            {
                ShutdownTimeOR obj = new ShutdownTimeOR(dr);
                listShut.Add(obj);
            }
            return listShut;
        }        
    }
}


