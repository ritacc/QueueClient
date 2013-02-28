using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class EmployTypeMySqlDA : DALBase
    {
        #region 更新
        public void UpdateEmployType(List<EmployTypeOR> listemployType)
        {
            string sql = "truncate table t_EmployType";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (EmployTypeOR obj in listemployType)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(EmployTypeOR employType)
        {
            string sql = @"insert into t_EmployType (Id,Name,Description,OrgBH)
values ('@Id','@Name','@Description','@OrgBH')";
            sql = sql.Replace("@Id", employType.Id);	//
            sql = sql.Replace("@Name", employType.Name);	//柜员类型名称，如普通柜员、高级柜员、个人业务顾问等
            sql = sql.Replace("@Description", employType.Description);	//描述
            sql = sql.Replace("@OrgBH", employType.Orgbh);	//

            return sql;
        }
        #endregion

    }
}

