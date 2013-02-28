using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    public class NearbyInfoMySqlDA : DALBase
    {
        #region 更新
        public void UpdateNearbyInfo(List<NearbyInfoOR> listnearbyInfo)
        {
            string sql = "truncate table t_NearbyInfo";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (NearbyInfoOR obj in listnearbyInfo)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(NearbyInfoOR nearbyInfo)
        {
            string sql = @"insert into t_NearbyInfo (Id,OrgBH,NearbyIndex,OrgNo,BankName,
BankAddr,BusInfo,Flag,Description)
values ('@Id','@OrgBH',NearbyIndex,OrgNo,'@BankName',
'@BankAddr','@BusInfo',Flag,'@Description')";
            sql = sql.Replace("@Id", nearbyInfo.Id);	//
            sql = sql.Replace("@OrgBH", nearbyInfo.Orgbh);	//所属机构
            sql = sql.Replace("@NearbyIndex", nearbyInfo.Nearbyindex.ToString());	//网点编号(1-5)
            sql = sql.Replace("@OrgNo", nearbyInfo.Orgno.ToString());	//网点编号
            sql = sql.Replace("@BankName", nearbyInfo.Bankname);	//邻近网点名称
            sql = sql.Replace("@BankAddr", nearbyInfo.Bankaddr);	//邻近网点地址
            sql = sql.Replace("@BusInfo", nearbyInfo.Businfo);	//公交线路
            sql = sql.Replace("@Flag", nearbyInfo.Flag.ToString());	//启用标记，1为启用，0为禁用
            sql = sql.Replace("@Description", nearbyInfo.Description);	//描述

            return sql;
        }
        #endregion

    }
}

