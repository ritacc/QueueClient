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
    public class BussinessRoleONMSSqlDA : DALBase
    {
        public List<BussinessRoleONOR> selectBussinessRoleONData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bron.* from t_BussinessRoleON bron
inner join t_BussinessRole bu on   bron.BussinessRoleID= bu.id
inner join t_Bank b on b.orgbh= bu.orgbh
 where " + orgbhWhere;
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
            List<BussinessRoleONOR> listBuss = new List<BussinessRoleONOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessRoleONOR obj = new BussinessRoleONOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }        
    }
}


