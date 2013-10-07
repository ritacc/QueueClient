using System;
using System.Collections.Generic;
using System.Text;
using MSSClass.DBCommon;
using System.Data;
using MSSClass.Entity;

namespace MSSClass.Dal
{
	public class PartsDA
	{
		CommonDB db = new CommonDB();

		#region  查询
		public DataTable selectViewData(string where)
		{
			string sql = @"select id as [编号],
MC as [名称],
SS as [实收],
CB as [成本],
LR as [利润], 
GHS as [供货商],
RJ as [销售日期]
from Parts ";


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
			string sql = @"select sum(CB) as purchaseCount,sum(SS) as sellPriceCount,sum(LR) as profitCount  from Parts ";
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

		public PartsOR selectARowDate(string m_id)
		{
			string sql = string.Format("select * from Parts where   id={0}", m_id);
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
			PartsOR mObj = new PartsOR(dr);
			return mObj;

		}

		#region 插入
		/// <summary>
		/// 插入BuyClothes
		/// </summary>
		public bool Insert(PartsOR mobj)
		{
			string sql = string.Format("insert into Parts ( MC,SS,CB, LR,GHS,RQ) values ('{0}',{1}, {2},{3}, '{4}', '{5}')",
			  mobj.MC, mobj.SS, mobj.CB, mobj.LR,   mobj.GHS,mobj.RQ);

			return db.excuteNonquery(sql);
		}
		#endregion

		#region 修改
		public bool Update(PartsOR mobj)
		{
			string sql = string.Format("update Parts set MC='{0}',SS={1},CB={2}, LR={3},GHS='{4}',RQ='{5}' where id={6}",
			  mobj.MC, mobj.SS, mobj.CB, mobj.LR, mobj.GHS, mobj.RQ, mobj.ID);
			return db.excuteNonquery(sql);
		}
		#endregion

		#region DELETE
		/// <summary>
		/// 删除BuyClothes
		/// </summary>
		public virtual bool Delete(string strId)
		{
			string sql = string.Format("delete from Parts where  ID ={0}", strId);
			return db.excuteNonquery(sql);
		}
		#endregion
	}
}
