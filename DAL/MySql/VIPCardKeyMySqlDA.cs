using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class VIPCardKeyMySqlDA : DALBase
    {
        public List<VIPCardKeyOR> selectAllVipCard()
        {
            string sql = "select * from t_VIPCardKey";

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
            List<VIPCardKeyOR> listBuss = new List<VIPCardKeyOR>();
            foreach (DataRow dr in dt.Rows)
            {
                VIPCardKeyOR obj = new VIPCardKeyOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }

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

