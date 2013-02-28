using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class BussinessRoleMySqlDA : DALBase
    {
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

