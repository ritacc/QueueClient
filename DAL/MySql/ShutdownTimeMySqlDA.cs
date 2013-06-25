using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class ShutdownTimeMySqlDA : DALBase
    {
        public ShutdownTimeOR SelectShutdownTime()
        {
            string sql = @"select * from t_ShutdownTime";
            DataTable dt = null;
            try
            {
                dt = dbMySql.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
          return  new  ShutdownTimeOR(dt.Rows[0]);
        }        
        #region 更新
        public void UpdateShutdownTime(List<ShutdownTimeOR> listshutdownTime)
        {
            string sql = "truncate table t_ShutdownTime";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (ShutdownTimeOR obj in listshutdownTime)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(ShutdownTimeOR shutdownTime)
        {
            string sql = @"insert into t_ShutdownTime (Id,MondayTime,TuesdayTime,WednesdayTime,ThurdayTime,
FridayTime,SaturdayTime,SundayTime,Description,orgbh)
values ('@Id','@MondayTime','@TuesdayTime','@WednesdayTime','@ThurdayTime',
'@FridayTime','@SaturdayTime','@SundayTime','@Description','@orgbh')";
            sql = sql.Replace("@Id", shutdownTime.Id);	//
            sql = sql.Replace("@MondayTime", shutdownTime.Mondaytime);	//周一关机时间
            sql = sql.Replace("@TuesdayTime", shutdownTime.Tuesdaytime);	//周二关机时间
            sql = sql.Replace("@WednesdayTime", shutdownTime.Wednesdaytime);	//周三关机时间
            sql = sql.Replace("@ThurdayTime", shutdownTime.Thurdaytime);	//周四关机时间
            sql = sql.Replace("@FridayTime", shutdownTime.Fridaytime);	//周五关机时间
            sql = sql.Replace("@SaturdayTime", shutdownTime.Saturdaytime);	//周六关机时间
            sql = sql.Replace("@SundayTime", shutdownTime.Sundaytime);	//周日关机时间
            sql = sql.Replace("@Description", shutdownTime.Description);	//描述
            sql = sql.Replace("@orgbh", shutdownTime.Orgbh);	//所属机构

            return sql;
        }
        #endregion

    }
}

