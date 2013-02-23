using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QM.Client.Entity;

namespace QM.Client.DA.MSSql
{
    /// <summary>
    /// 
    /// </summary>
    public class BussinessMSSqlDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from t_Bussiness";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = dbSql.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }
        public List<BussinessOR> selectAllDate()
        {
            string sql = "select * from t_Bussiness";           
            DataTable dt = null;
            try
            {
                dt = dbSql.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            List<BussinessOR> listBussi = new List<BussinessOR>();
            foreach (DataRow dr in dt.Rows)
            {
                BussinessOR obj = new BussinessOR(dr);
                listBussi.Add(obj);
            }
            return listBussi;
        }
        public BussinessOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_Bussiness where  Id='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = dbSql.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            BussinessOR m_Buss = new BussinessOR(dr);
            return m_Buss;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入t_Bussiness
        /// </summary>
        public virtual bool Insert(BussinessOR bussiness)
        {
            string sql = "insert into t_Bussiness (Id, Name, EnglishName, TypeName, WaitTime1, PriorTime1, WaitTime2, PriorTime2, WaitTime3, PriorTime3, TicketMethod, MondayFlag, MondayTime, TuesdayFlag, TuesdayTime, WednesdayFlag, WednesdayTime, ThurdayFlag, ThurdayTime, FridayFlag, FridayTime, SaturdayFlag, SaturdayTime, SundayFlag, SundayTime, Description, OrgBH) values (@Id, @Name, @EnglishName, @TypeName, @WaitTime1, @PriorTime1, @WaitTime2, @PriorTime2, @WaitTime3, @PriorTime3, @TicketMethod, @MondayFlag, @MondayTime, @TuesdayFlag, @TuesdayTime, @WednesdayFlag, @WednesdayTime, @ThurdayFlag, @ThurdayTime, @FridayFlag, @FridayTime, @SaturdayFlag, @SaturdayTime, @SundayFlag, @SundayTime, @Description, @OrgBH)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "Id", DataRowVersion.Default, bussiness.Id),
				new SqlParameter("@Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Default, bussiness.Name),
				new SqlParameter("@EnglishName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "EnglishName", DataRowVersion.Default, bussiness.Englishname),
				new SqlParameter("@TypeName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "TypeName", DataRowVersion.Default, bussiness.Typename),
				new SqlParameter("@WaitTime1", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitTime1", DataRowVersion.Default, bussiness.Waittime1),
				new SqlParameter("@PriorTime1", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PriorTime1", DataRowVersion.Default, bussiness.Priortime1),
				new SqlParameter("@WaitTime2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitTime2", DataRowVersion.Default, bussiness.Waittime2),
				new SqlParameter("@PriorTime2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PriorTime2", DataRowVersion.Default, bussiness.Priortime2),
				new SqlParameter("@WaitTime3", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitTime3", DataRowVersion.Default, bussiness.Waittime3),
				new SqlParameter("@PriorTime3", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PriorTime3", DataRowVersion.Default, bussiness.Priortime3),
				new SqlParameter("@TicketMethod", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TicketMethod", DataRowVersion.Default, bussiness.Ticketmethod),
				new SqlParameter("@MondayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "MondayFlag", DataRowVersion.Default, bussiness.Mondayflag),
				new SqlParameter("@MondayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "MondayTime", DataRowVersion.Default, bussiness.Mondaytime),
				new SqlParameter("@TuesdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TuesdayFlag", DataRowVersion.Default, bussiness.Tuesdayflag),
				new SqlParameter("@TuesdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "TuesdayTime", DataRowVersion.Default, bussiness.Tuesdaytime),
				new SqlParameter("@WednesdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "WednesdayFlag", DataRowVersion.Default, bussiness.Wednesdayflag),
				new SqlParameter("@WednesdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "WednesdayTime", DataRowVersion.Default, bussiness.Wednesdaytime),
				new SqlParameter("@ThurdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ThurdayFlag", DataRowVersion.Default, bussiness.Thurdayflag),
				new SqlParameter("@ThurdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ThurdayTime", DataRowVersion.Default, bussiness.Thurdaytime),
				new SqlParameter("@FridayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "FridayFlag", DataRowVersion.Default, bussiness.Fridayflag),
				new SqlParameter("@FridayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "FridayTime", DataRowVersion.Default, bussiness.Fridaytime),
				new SqlParameter("@SaturdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "SaturdayFlag", DataRowVersion.Default, bussiness.Saturdayflag),
				new SqlParameter("@SaturdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "SaturdayTime", DataRowVersion.Default, bussiness.Saturdaytime),
				new SqlParameter("@SundayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "SundayFlag", DataRowVersion.Default, bussiness.Sundayflag),
				new SqlParameter("@SundayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "SundayTime", DataRowVersion.Default, bussiness.Sundaytime),
				new SqlParameter("@Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Default, bussiness.Description),
				new SqlParameter("@OrgBH", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, "OrgBH", DataRowVersion.Default, bussiness.Orgbh)
			};
            return dbSql.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新t_Bussiness
        /// </summary>
        public virtual bool Update(BussinessOR bussiness)
        {
            string sql = "update t_Bussiness set  Name = @Name,  EnglishName = @EnglishName,  TypeName = @TypeName,  WaitTime1 = @WaitTime1,  PriorTime1 = @PriorTime1,  WaitTime2 = @WaitTime2,  PriorTime2 = @PriorTime2,  WaitTime3 = @WaitTime3,  PriorTime3 = @PriorTime3,  TicketMethod = @TicketMethod,  MondayFlag = @MondayFlag,  MondayTime = @MondayTime,  TuesdayFlag = @TuesdayFlag,  TuesdayTime = @TuesdayTime,  WednesdayFlag = @WednesdayFlag,  WednesdayTime = @WednesdayTime,  ThurdayFlag = @ThurdayFlag,  ThurdayTime = @ThurdayTime,  FridayFlag = @FridayFlag,  FridayTime = @FridayTime,  SaturdayFlag = @SaturdayFlag,  SaturdayTime = @SaturdayTime,  SundayFlag = @SundayFlag,  SundayTime = @SundayTime,  Description = @Description,  OrgBH = @OrgBH where  Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "Id", DataRowVersion.Default, bussiness.Id),
				new SqlParameter("@Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Default, bussiness.Name),
				new SqlParameter("@EnglishName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "EnglishName", DataRowVersion.Default, bussiness.Englishname),
				new SqlParameter("@TypeName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "TypeName", DataRowVersion.Default, bussiness.Typename),
				new SqlParameter("@WaitTime1", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitTime1", DataRowVersion.Default, bussiness.Waittime1),
				new SqlParameter("@PriorTime1", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PriorTime1", DataRowVersion.Default, bussiness.Priortime1),
				new SqlParameter("@WaitTime2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitTime2", DataRowVersion.Default, bussiness.Waittime2),
				new SqlParameter("@PriorTime2", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PriorTime2", DataRowVersion.Default, bussiness.Priortime2),
				new SqlParameter("@WaitTime3", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitTime3", DataRowVersion.Default, bussiness.Waittime3),
				new SqlParameter("@PriorTime3", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PriorTime3", DataRowVersion.Default, bussiness.Priortime3),
				new SqlParameter("@TicketMethod", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TicketMethod", DataRowVersion.Default, bussiness.Ticketmethod),
				new SqlParameter("@MondayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "MondayFlag", DataRowVersion.Default, bussiness.Mondayflag),
				new SqlParameter("@MondayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "MondayTime", DataRowVersion.Default, bussiness.Mondaytime),
				new SqlParameter("@TuesdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "TuesdayFlag", DataRowVersion.Default, bussiness.Tuesdayflag),
				new SqlParameter("@TuesdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "TuesdayTime", DataRowVersion.Default, bussiness.Tuesdaytime),
				new SqlParameter("@WednesdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "WednesdayFlag", DataRowVersion.Default, bussiness.Wednesdayflag),
				new SqlParameter("@WednesdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "WednesdayTime", DataRowVersion.Default, bussiness.Wednesdaytime),
				new SqlParameter("@ThurdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "ThurdayFlag", DataRowVersion.Default, bussiness.Thurdayflag),
				new SqlParameter("@ThurdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ThurdayTime", DataRowVersion.Default, bussiness.Thurdaytime),
				new SqlParameter("@FridayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "FridayFlag", DataRowVersion.Default, bussiness.Fridayflag),
				new SqlParameter("@FridayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "FridayTime", DataRowVersion.Default, bussiness.Fridaytime),
				new SqlParameter("@SaturdayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "SaturdayFlag", DataRowVersion.Default, bussiness.Saturdayflag),
				new SqlParameter("@SaturdayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "SaturdayTime", DataRowVersion.Default, bussiness.Saturdaytime),
				new SqlParameter("@SundayFlag", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "SundayFlag", DataRowVersion.Default, bussiness.Sundayflag),
				new SqlParameter("@SundayTime", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "SundayTime", DataRowVersion.Default, bussiness.Sundaytime),
				new SqlParameter("@Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Default, bussiness.Description),
				new SqlParameter("@OrgBH", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, "OrgBH", DataRowVersion.Default, bussiness.Orgbh)
			};
            return dbSql.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_Bussiness
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = "delete from t_Bussiness where  Id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", strId);
            return dbSql.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

