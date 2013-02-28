using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class SmsPeopleMySqlDA : DALBase
    {
        #region 更新
        public void UpdateSmsPeople(List<SmsPeopleOR> listsmsPeople)
        {
            string sql = "truncate table t_SmsPeople";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (SmsPeopleOR obj in listsmsPeople)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(SmsPeopleOR smsPeople)
        {
            string sql = @"insert into t_SmsPeople (Id,Name,MobileNO,SendMoney,Description,
orgbh)
values ('@Id','@Name','@MobileNO',SendMoney,'@Description',
'@orgbh')";
            sql = sql.Replace("@Id", smsPeople.Id);	//
            sql = sql.Replace("@Name", smsPeople.Name);	//姓名
            sql = sql.Replace("@MobileNO", smsPeople.Mobileno);	//手机号码
            sql = sql.Replace("@SendMoney", smsPeople.Sendmoney.ToString());	//发送金额
            sql = sql.Replace("@Description", smsPeople.Description);	//描述
            sql = sql.Replace("@orgbh", smsPeople.Orgbh);	//所属机构

            return sql;
        }
        #endregion

    }
}

