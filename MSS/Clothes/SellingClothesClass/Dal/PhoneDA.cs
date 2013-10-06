using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MSSClass.DBCommon;
using MSSClass.Entity;

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
SHZK as [售后状况]
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

	   #region 插入
	   /// <summary>
	   /// 插入BuyClothes
	   /// </summary>
	   public bool Insert(PhoneOR mobj)
	   {
		   string sql = string.Format("insert into phone ( JX,SS,CB, LR, CH,GHS,GMR,LXDH,XSRQ,SHZK) values ('{0}',{1}, {2},{3}, '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
			 mobj.JX, mobj.SS, mobj.CB, mobj.LR, mobj.CH, mobj.GHS, mobj.GMR, mobj.LXDH, mobj.XSRQ, mobj.SHZK);

		   return db.excuteNonquery(sql);
	   }
	   #endregion

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
