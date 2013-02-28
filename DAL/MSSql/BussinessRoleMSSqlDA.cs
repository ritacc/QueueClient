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
    public class BussinessRoleMSSqlDA : DALBase
    {
        public List<BussinessRoleOR> selectBussinessRoleData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_BussinessRole bu
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
            List<BussinessRoleOR> listBuss = new List<BussinessRoleOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessRoleOR obj = new BussinessRoleOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }        
    }
}


