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
    public class SmsPeopleMSSqlDA : DALBase
    {
        public List<SmsPeopleOR> selectSmsPeopleData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_SmsPeople bu
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
            List<SmsPeopleOR> listSmsP = new List<SmsPeopleOR>();
            foreach (DataRow dr in dt.Rows)
            {
                SmsPeopleOR obj = new SmsPeopleOR(dr);
                listSmsP.Add(obj);
            }
            return listSmsP;
        }        
    }
}


