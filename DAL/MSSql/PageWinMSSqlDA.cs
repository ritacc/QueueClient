using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MSSql
{
   public class PageWinMSSqlDA:DALBase
   {
       public List<PageWinOR> selectBankData(string orgbhWhere)
       {
           if (string.IsNullOrEmpty(orgbhWhere))
               return null;

           string sql = @"select bu.* from t_Bussiness bu
inner join t_Bank b on b.orgbh= bu.orgbh where " + orgbhWhere;
           DataTable dt = null;
           try
           {
               dt = dbSql.ExecuteQuery(sql);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           if (dt == null)
               return null;
           List<PageWinOR> listPWin = new List<PageWinOR>();
           foreach (DataRow dr in dt.Rows)
           {
               PageWinOR obj = new PageWinOR(dr);
               listPWin.Add(obj);
           }
           return listPWin;
       }
    }
}
