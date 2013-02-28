using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class BussinessRoleONMySqlDA : DALBase
    {
        #region 更新
        public void UpdateBussinessRoleON(List<BussinessRoleONOR> listbussinessRoleON)
        {
            string sql = "truncate table t_BussinessRoleON";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (BussinessRoleONOR obj in listbussinessRoleON)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(BussinessRoleONOR bussinessRoleON)
        {
            string sql = @"insert into t_BussinessRoleON (BussinessRoleID,BussinessId,PriorTimes,BackupPriorTimes)
values ('@BussinessRoleID','@BussinessId',PriorTimes,BackupPriorTimes)";
            sql = sql.Replace("@BussinessRoleID", bussinessRoleON.Bussinessroleid);	//业务角色ID
            sql = sql.Replace("@BussinessId", bussinessRoleON.Bussinessid);	//业务类型
            sql = sql.Replace("@PriorTimes", bussinessRoleON.Priortimes.ToString());	//主队列优先时间
            sql = sql.Replace("@BackupPriorTimes", bussinessRoleON.Backuppriortimes.ToString());	//备用队列优先时间

            return sql;
        }
        #endregion

    }
}

