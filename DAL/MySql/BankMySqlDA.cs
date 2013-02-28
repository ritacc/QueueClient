using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class BankMySqlDA : DALBase
    {

        #region 更新业务类型
        public void UpdateBank(BankOR _bank)
        {
            string sql = "truncate table t_Bank";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);


            sql = GetInsertSql(_bank);
            listCmd.Add(sql);

            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(BankOR bank)
        {
            string sql = @"insert into t_Bank (Id,OrgNo,OrgName,OrgBH,ParentOrgBH,
Description,BankSort)
values ('@Id','@OrgNo','@OrgName','@OrgBH','@ParentOrgBH',
'@Description',BankSort)";
            sql = sql.Replace("@Id", bank.Id);	//
            sql = sql.Replace("@OrgNo", bank.Orgno);	//机构编号
            sql = sql.Replace("@OrgName", bank.Orgname);	//机构名称
            sql = sql.Replace("@OrgBH", bank.Orgbh);	//机构编号
            sql = sql.Replace("@ParentOrgBH", bank.Parentorgbh);	//上级机构编号
            sql = sql.Replace("@Description", bank.Description);	//描述
            sql = sql.Replace("@BankSort", bank.Banksort.ToString());	//

            return sql;
        }
        #endregion

    }
}
