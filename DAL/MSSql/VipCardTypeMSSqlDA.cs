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
    public class VipCardTypeMSSqlDA : DALBase
    {
        public List<VipCardTypeOR> selectVipCardTypeData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_VipCardType bu
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
            List<VipCardTypeOR> listVipC = new List<VipCardTypeOR>();
            foreach (DataRow dr in dt.Rows)
            {
                VipCardTypeOR obj = new VipCardTypeOR(dr);
                listVipC.Add(obj);
            }
            return listVipC;
        }        
    }
}


