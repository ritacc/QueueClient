using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data;

namespace QM.Client.DA.MySql
{
    public class VipCardTypeMySqlDA : DALBase
    {
        public List<VipCardTypeOR> selectAllVipCardType()
        {
            string sql = "select * from t_VipCardType";

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
            List<VipCardTypeOR> listBuss = new List<VipCardTypeOR>();
            foreach (DataRow dr in dt.Rows)
            {
                VipCardTypeOR obj = new VipCardTypeOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;

        }
        #region 更新
        public void UpdateVipCardType(List<VipCardTypeOR> listvipCardType)
        {
            string sql = "truncate table t_VipCardType";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (VipCardTypeOR obj in listvipCardType)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(VipCardTypeOR vipCardType)
        {
            string sql = @"insert into t_VipCardType (id,name,FirstTime,Description,orgBH)
values ('@id','@name',@FirstTime,'@Description','@orgBH')";
            sql = sql.Replace("@id", vipCardType.Id);	//
            sql = sql.Replace("@name", vipCardType.Name);	//名称
            sql = sql.Replace("@FirstTime", vipCardType.Firsttime.ToString());	//优先时间
            sql = sql.Replace("@Description", vipCardType.Description);	//描述
            sql = sql.Replace("@orgBH", vipCardType.Orgbh);	//所属机构

            return sql;
        }
        #endregion

    }
}

