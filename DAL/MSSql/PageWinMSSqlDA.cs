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
    public class PageWinMSSqlDA : DALBase
    {
        public List<PageWinOR> selectPageWinData(string orgbhWhere)
        {
            if (string.IsNullOrEmpty(orgbhWhere))
                return null;

            string sql = @"select bu.* from t_PageWin bu
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
            List<PageWinOR> listPage = new List<PageWinOR>();
            foreach (DataRow dr in dt.Rows)
            {
                PageWinOR obj = new PageWinOR(dr);
                listPage.Add(obj);
            }
            return listPage;
        }        
    }
}


