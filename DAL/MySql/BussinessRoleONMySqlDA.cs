using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class BussinessRoleONMySqlDA : DALBase
    {

        public List<BussinessRoleONOR> selectRolesONByRoleID(string mRoleID)
        {
            string sql = string.Format("select * from t_BussinessRoleON where BussinessRoleID='{0}'", mRoleID);

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
            {
                return null;
            }
            List<BussinessRoleONOR> listBuss = new List<BussinessRoleONOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessRoleONOR obj = new BussinessRoleONOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }

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
            string sql = @"insert into t_BussinessRoleON (BussinessRoleID,BussinessId,PriorTimes,BackupPriorTimes,IsBackupPrio)
values ('@BussinessRoleID','@BussinessId',@PriorTimes,@BackupPriorTimes,@IsBackupPrio)";
            sql = sql.Replace("@BussinessRoleID", bussinessRoleON.Bussinessroleid);	//业务角色ID
            sql = sql.Replace("@BussinessId", bussinessRoleON.Bussinessid);	//业务类型
            sql = sql.Replace("@PriorTimes", bussinessRoleON.Priortimes.ToString());	//主队列优先时间
            sql = sql.Replace("@BackupPriorTimes", bussinessRoleON.Backuppriortimes.ToString());	//备用队列优先时间
            sql = sql.Replace("@IsBackupPrio", bussinessRoleON.IsBackupPrio ? "1" : "0");

            return sql;
        }
        #endregion

    }
}

