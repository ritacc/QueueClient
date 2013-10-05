using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MSSClass.DBCommon;

namespace MSSClass.Dal
{
   public class PhoneDA
    {
       CommonDB db = new CommonDB();

       public DataTable selectViewData(string where)
       {
           string sql = @"select id as [编号],
JX as [机型],
SS as [实收],
CB as [成本],
LR as [利润],
CH as [串号],
GHS as [供货商],
GMR as [购买人],
LXDH as [联系电话],
XSRQ as [销售日期],
SHZK as [售后状况
from phone ";


           if (!string.IsNullOrEmpty(where))
           {
               sql = string.Format(" {0} where {1}", sql, where);
           }
           DataTable dt = null;
           try
           {
               dt = db.executeQuery(sql).Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }

           return dt;
       }

       public DataTable selectCountData(string where)
       {
           string sql = @"select sum(SS) as purchaseCount,sum(CB) as sellPriceCount,sum(LR) as profitCount  from phone ";
           if (!string.IsNullOrEmpty(where))
           {
               sql = string.Format(" {0} where {1}", sql, where);
           }
           DataTable dt = null;
           try
           {
               dt = db.executeQuery(sql).Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }

           return dt;
       }

    }
}
