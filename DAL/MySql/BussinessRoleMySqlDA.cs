using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class BussinessRoleMySqlDA : DALBase
    {
        public List<BussinessRoleOR> selectAllRole()
        {
            string sql = "select * from t_BussinessRole";

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
            List<BussinessRoleOR> listBuss = new List<BussinessRoleOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessRoleOR obj = new BussinessRoleOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }
        public List<BussinessRoleOnBussOR> selectAllBussinessRoleOnBuss()
        {
            string sql = "select * from t_BussinessRole";

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
            List<BussinessRoleOnBussOR> listBuss = new List<BussinessRoleOnBussOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessRoleOnBussOR obj = new BussinessRoleOnBussOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }
        #region 更新
        public void UpdateBussinessRole(List<BussinessRoleOR> listbussinessRole)
        {
            string sql = "truncate table t_BussinessRole";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (BussinessRoleOR obj in listbussinessRole)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(BussinessRoleOR bussinessRole)
        {
            string sql = @"insert into t_BussinessRole (Id,Name,Description,OrgBH)
values ('@Id','@Name','@Description','@OrgBH')";
            sql = sql.Replace("@Id", bussinessRole.Id);	//
            sql = sql.Replace("@Name", bussinessRole.Name);	//业务角色名称
            sql = sql.Replace("@Description", bussinessRole.Description);	//描述
            sql = sql.Replace("@OrgBH", bussinessRole.Orgbh);	//

            return sql;
        }
        #endregion

    }
}

