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
    public class EmployTypeMSSqlDA : DALBase
    {
        public List<EmployTypeOR> selectEmployTypeData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_EmployType bu
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
            List<EmployTypeOR> listEmpl = new List<EmployTypeOR>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployTypeOR obj = new EmployTypeOR(dr);
                listEmpl.Add(obj);
            }
            return listEmpl;
        }        
    }
}


