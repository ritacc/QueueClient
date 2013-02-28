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
    public class NearbyInfoMSSqlDA : DALBase
    {
        public List<NearbyInfoOR> selectNearbyInfoData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_NearbyInfo bu
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
            List<NearbyInfoOR> listNear = new List<NearbyInfoOR>();
            foreach (DataRow dr in dt.Rows)
            {
                NearbyInfoOR obj = new NearbyInfoOR(dr);
                listNear.Add(obj);
            }
            return listNear;
        }        
    }
}


