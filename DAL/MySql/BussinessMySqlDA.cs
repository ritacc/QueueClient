using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using DBUtility;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
    /// <summary>
    /// 
    /// </summary>
    public class BussinessMySqlDA : DALBase
    {

        #region 查询
        public List<BussinessOR> selectAllBussiness()
        {
            string sql = "select * from t_Bussiness";
            
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
            List<BussinessOR> listBuss = new List<BussinessOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessOR obj = new BussinessOR(dr);
                listBuss.Add(obj);
            }
            return listBuss;
        }
        #endregion
        #region 更新业务类型
        public void UpdateBussiness(List<BussinessOR> listBus)
        {
            string sql = "truncate table t_Bussiness";
            List<string> listCmd = new List<string>();
            listCmd.Add(sql);

            foreach (BussinessOR obj in listBus)
            {
                sql = GetInsertSql(obj);
                listCmd.Add(sql);
            }
            dbMySql.ExecuteNoQueryTran(listCmd);
        }

       

        /// <summary>
        /// 获取插入数据
        /// </summary>
        public string GetInsertSql(BussinessOR bussiness)
        {
            string sql = string.Format(@"insert into t_Bussiness (Id, Name, EnglishName, TypeName, WaitTime1, 
PriorTime1, WaitTime2, PriorTime2, WaitTime3, PriorTime3,
TicketMethod, MondayFlag, MondayTime, TuesdayFlag, TuesdayTime, 
WednesdayFlag, WednesdayTime, ThurdayFlag, ThurdayTime, FridayFlag,
FridayTime, SaturdayFlag, SaturdayTime, SundayFlag, SundayTime,
Description, OrgBH) 
values ('@Id', '@Name', '@EnglishName', '@TypeName', @WaitTime1,
@PriorTime1, @WaitTime2,@PriorTime2, @WaitTime3, @PriorTime3, 
@TicketMethod, @MondayFlag, '@MondayTime', @TuesdayFlag, '@TuesdayTime', 
@WednesdayFlag, '@WednesdayTime', @ThurdayFlag, '@ThurdayTime', @FridayFlag, 
'@FridayTime', @SaturdayFlag, '@SaturdayTime', @SundayFlag, '@SundayTime', 
'@Description', '@OrgBH')");

                sql = sql.Replace("@Id", bussiness.Id);
                sql = sql.Replace("@Name", bussiness.Name);
                sql = sql.Replace("@EnglishName", bussiness.Englishname);
                sql = sql.Replace("@TypeName", bussiness.Typename);
                sql = sql.Replace("@WaitTime1", bussiness.Waittime1.ToString());
                sql = sql.Replace("@PriorTime1", bussiness.Priortime1.ToString());
                sql = sql.Replace("@WaitTime2", bussiness.Waittime2.ToString());
                sql = sql.Replace("@PriorTime2", bussiness.Priortime2.ToString());
                sql = sql.Replace("@WaitTime3", bussiness.Waittime3.ToString());
                sql = sql.Replace("@PriorTime3", bussiness.Priortime3.ToString());
                sql = sql.Replace("@TicketMethod", bussiness.Ticketmethod.ToString());
                sql = sql.Replace("@MondayFlag", boolGetFlag(bussiness.Mondayflag));
                sql = sql.Replace("@MondayTime", bussiness.Mondaytime);
                sql = sql.Replace("@TuesdayFlag", boolGetFlag(bussiness.Tuesdayflag));
                sql = sql.Replace("@TuesdayTime", bussiness.Tuesdaytime);
                sql = sql.Replace("@WednesdayFlag", boolGetFlag(bussiness.Wednesdayflag));
                sql = sql.Replace("@WednesdayTime", bussiness.Wednesdaytime);
                sql = sql.Replace("@ThurdayFlag", boolGetFlag(bussiness.Thurdayflag));
                sql = sql.Replace("@ThurdayTime", bussiness.Thurdaytime);
                sql = sql.Replace("@FridayFlag", boolGetFlag(bussiness.Fridayflag));
                sql = sql.Replace("@FridayTime", bussiness.Fridaytime);
                sql = sql.Replace("@SaturdayFlag", boolGetFlag(bussiness.Saturdayflag));
                sql = sql.Replace("@SaturdayTime", bussiness.Saturdaytime);
                sql = sql.Replace("@SundayFlag", boolGetFlag(bussiness.Sundayflag));
                sql = sql.Replace("@SundayTime", bussiness.Sundaytime);
                sql = sql.Replace("@Description", bussiness.Description);
                sql = sql.Replace("@OrgBH", bussiness.Orgbh);

                return sql;
        }
        #endregion

       

       
    }
}

