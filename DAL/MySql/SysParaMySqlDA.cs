using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class SysParaMySqlDA : DALBase
    {
        #region 更新
        public void UpdateSysPara(List<SysParaOR> listsysPara)
        {
            string sql = "truncate table t_SysPara";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (SysParaOR obj in listsysPara)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(SysParaOR sysPara)
        {
            string sql = @"insert into t_SysPara (Id,OrgBH,KeyStr,ValueStr,Description)
values ('@Id','@OrgBH','@KeyStr','@ValueStr','@Description')";
            sql = sql.Replace("@Id", sysPara.Id);	//
            sql = sql.Replace("@OrgBH", sysPara.Orgbh);	//所属机构
            sql = sql.Replace("@KeyStr", sysPara.Keystr);	//关键字
            sql = sql.Replace("@ValueStr", sysPara.Valuestr);	//值
            sql = sql.Replace("@Description", sysPara.Description);	//描述

            return sql;
        }
        #endregion

    }
}

