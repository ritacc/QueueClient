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

       #region  查询
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
       public DataTable selectCountData(string where)
       {
           string sql = @"select sum(CB) as purchaseCount,sum(SS) as sellPriceCount,sum(LR) as profitCount  from phone ";
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
       #endregion

       public PhoneOR selectARowDate(string m_id)
       {
           string sql = string.Format("select * from phone where   id={0}", m_id);
           DataTable dt = null;
           try
           {
               dt = db.executeQuery(sql).Tables[0];
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
           PhoneOR mObj = new PhoneOR(dr);
           return mObj;

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

       #region 修改
       public bool Update(PhoneOR mobj)
       {
           string sql = string.Format("update phone set JX='{0}',SS={1},CB={2}, LR={3}, CH='{4}',GHS='{5}',GMR='{6}',LXDH='{7}',XSRQ='{8}',SHZK='{9}' where id={10}",
             mobj.JX, mobj.SS, mobj.CB, mobj.LR, mobj.CH, mobj.GHS, mobj.GMR, mobj.LXDH, mobj.XSRQ, mobj.SHZK,mobj.ID);

           return db.excuteNonquery(sql);
       }
       #endregion

       #region DELETE
       /// <summary>
       /// 删除BuyClothes
       /// </summary>
       public virtual bool Delete(string strId)
       {
           string sql = string.Format("delete from phone where  ID ={0}", strId);
           return db.excuteNonquery(sql);
       }
       #endregion

       

    }
}
