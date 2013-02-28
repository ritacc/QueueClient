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
    public class VIPCardKeyMSSqlDA : DALBase
    {
        public List<VIPCardKeyOR> selectVIPCardKeyData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_VIPCardKey bu
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
            List<VIPCardKeyOR> listVIPC = new List<VIPCardKeyOR>();
            foreach (DataRow dr in dt.Rows)
            {
                VIPCardKeyOR obj = new VIPCardKeyOR(dr);
                listVIPC.Add(obj);
            }
            return listVIPC;
        }        
    }
}


