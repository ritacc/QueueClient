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
    public class SysParaMSSqlDA : DALBase
    {
        public List<SysParaOR> selectSysParaData(string orgbhWhere, string orgBH)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_SysPara bu
inner join t_Bank b on b.orgbh= bu.orgbh where " + orgbhWhere;
            if (orgbhWhere.Length > 6)
            {
                string topWdbh = orgBH.Substring(0, 6);

                sql += string.Format(@" or (b.orgbh='{0}' and (KeyStr='vipcardinfo' or KeyStr='othercardinfo' 
or KeyStr='invalidcardinfo'  or KeyStr='validcardcode'))", topWdbh);
            }
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
            List<SysParaOR> listSysP = new List<SysParaOR>();
            foreach (DataRow dr in dt.Rows)
            {
                SysParaOR obj = new SysParaOR(dr);
                listSysP.Add(obj);
            }
            return listSysP;
        }

    }
}