using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class VIPCardKeyMySqlDA : DALBase
    {
        #region 更新
        public void UpdateVIPCardKey(List<VIPCardKeyOR> listvIPCardKey)
        {
            string sql = "truncate table t_VIPCardKey";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (VIPCardKeyOR obj in listvIPCardKey)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(VIPCardKeyOR vIPCardKey)
        {
            string sql = @"insert into t_VIPCardKey (ID,VIPCardKey,VipCardType,Description,orgbh)
values ('@ID','@VIPCardKey','@VipCardType','@Description','@orgbh')";
            sql = sql.Replace("@ID", vIPCardKey.Id);	//
            sql = sql.Replace("@VIPCardKey", vIPCardKey.Vipcardkey);	//VIP卡识别码
            sql = sql.Replace("@VipCardType", vIPCardKey.Vipcardtype);	//VIP卡类型
            sql = sql.Replace("@Description", vIPCardKey.Description);	//描述
            sql = sql.Replace("@orgbh", vIPCardKey.Orgbh);	//所属机构

            return sql;
        }
        #endregion

    }
}

