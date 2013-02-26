using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MSSql
{
   public class PageWinMSSqlDA:DALBase
   {
       public List<BussinessOR> selectBankData(string orgbhWhere)
       {
           if (string.IsNullOrEmpty(orgbhWhere))
               return null;

           string sql = @"select b.* from t_Bussiness b
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
           List<BussinessOR> listBussi = new List<BussinessOR>();
           foreach (DataRow dr in dt.Rows)
           {
               BussinessOR obj = new BussinessOR(dr);
               listBussi.Add(obj);
           }
           return listBussi;
       }
    }
}
