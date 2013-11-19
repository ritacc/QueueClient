/**********************************************
** Author:          Administrator
** Create date:     2012年8月26日星期日
** Description:     QM.DAL.YwbDal.QM.DALYwbBase
**********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using QM.DAL;

namespace QM.DAL.ParaSet
{

    public class BussinessDA : DALBase
	{
		/// <summary>
		/// 查询T_YWB所有的记录
		/// </summary>
        public virtual DataTable SelectYwbByWD(string wdbh)
		{
            string sql = string.Format("select * from t_Bussiness  where orgbh='{0}'", wdbh);
			return db.ExecuteQuery(sql);
		}

     
	}
}

