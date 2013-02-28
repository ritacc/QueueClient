using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QM.Client.Entity;

namespace QM.Client.DA.MSSql
{
   public class BankMSSqlDA:DALBase
    {
       /// <summary>
       /// 根据一个网点编号(5300)，查询网点
       /// </summary>
       /// <param name="orgNO"></param>
       /// <returns></returns>
       public BankOR selectABank(string orgNO)
       {
           string sql = string.Format("select * from t_Bank where  orgno='{0}'", orgNO);
           DataTable dt = null;
           try
           {
               dt = dbMsSql.ExecuteQueryDataSet(sql).Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
           if (dt == null)
               return null;
           if (dt.Rows.Count == 0)
               return null;
           DataRow dr = dt.Rows[0];
           BankOR m_Bank = new BankOR(dr);
           return m_Bank;

       }
    }
}
