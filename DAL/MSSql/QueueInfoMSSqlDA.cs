using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace QM.Client.DA.MSSql
{
   public class QueueInfoMSSqlDA:DALBase
    {
       /// <summary>
       /// 客户端上传数据到服务器
       /// </summary>
       /// <param name="listQue"></param>
       /// <returns></returns>
       public void Updata(List<QueueInfoOR> listQue)
       {
           try
           {
               List<CommandList> listCommond = new List<CommandList>();
               foreach (QueueInfoOR obj in listQue)
               {
                   if (obj.UpStatus == -1)
                   {
                       listCommond.Add(Insert(obj));
                   }
                   else
                   {
                       listCommond.Add(UpdateQueue(obj));
                   }
               }
               dbMsSql.ExecuteNoQueryTranPro(listCommond);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       private CommandList Insert(QueueInfoOR queueInfo)
       {
           string sql = @"insert into t_QueueInfo (Id, BankNo, BillNo, BussinessId, PrillBillTime, TransferDestWin, DelayNum, DelayTime,
CallTime, ProcessTime, FinishTime, WindowNo, EmployNo, EmployName, CardNo, Judge, WaitInterval, ProcessInterval, WaitPeopleBusssiness,
WaitPeopleBank, CustemClass, Description, Staus)
values (@Id, @BankNo, @BillNo, @BussinessId, @PrillBillTime, @TransferDestWin, @DelayNum, @DelayTime,
@CallTime, @ProcessTime, @FinishTime, @WindowNo, @EmployNo, @EmployName, @CardNo, @Judge, @WaitInterval, @ProcessInterval, @WaitPeopleBusssiness, 
@WaitPeopleBank, @CustemClass, @Description, @Staus)";
           SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "Id", DataRowVersion.Default, queueInfo.Id),
				new SqlParameter("@BankNo", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "BankNo", DataRowVersion.Default, queueInfo.Bankno),
				new SqlParameter("@BillNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "BillNo", DataRowVersion.Default, queueInfo.Billno),
				new SqlParameter("@BussinessId", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "BussinessId", DataRowVersion.Default, queueInfo.Bussinessid),
				new SqlParameter("@PrillBillTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "PrillBillTime", DataRowVersion.Default, queueInfo.Prillbilltime),
				new SqlParameter("@TransferDestWin", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TransferDestWin", DataRowVersion.Default, queueInfo.Transferdestwin),
				new SqlParameter("@DelayNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "DelayNum", DataRowVersion.Default, queueInfo.Delaynum),
				new SqlParameter("@DelayTime", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "DelayTime", DataRowVersion.Default, queueInfo.Delaytime),
				new SqlParameter("@CallTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "CallTime", DataRowVersion.Default, queueInfo.Calltime),
				new SqlParameter("@ProcessTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "ProcessTime", DataRowVersion.Default, queueInfo.Processtime),
				new SqlParameter("@FinishTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "FinishTime", DataRowVersion.Default, queueInfo.Finishtime),
				new SqlParameter("@WindowNo", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "WindowNo", DataRowVersion.Default, queueInfo.Windowno),
				new SqlParameter("@EmployNo", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "EmployNo", DataRowVersion.Default, queueInfo.Employno),
				new SqlParameter("@EmployName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "EmployName", DataRowVersion.Default, queueInfo.Employname),
				new SqlParameter("@CardNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "CardNo", DataRowVersion.Default, queueInfo.Cardno),
				new SqlParameter("@Judge", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Judge", DataRowVersion.Default, queueInfo.Judge),
				new SqlParameter("@WaitInterval", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitInterval", DataRowVersion.Default, queueInfo.Waitinterval),
				new SqlParameter("@ProcessInterval", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ProcessInterval", DataRowVersion.Default, queueInfo.Processinterval),
				new SqlParameter("@WaitPeopleBusssiness", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitPeopleBusssiness", DataRowVersion.Default, queueInfo.Waitpeoplebusssiness),
				new SqlParameter("@WaitPeopleBank", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitPeopleBank", DataRowVersion.Default, queueInfo.Waitpeoplebank),
				new SqlParameter("@CustemClass", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "CustemClass", DataRowVersion.Default, queueInfo.Custemclass),
				new SqlParameter("@Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Default, queueInfo.Description),
				new SqlParameter("@Staus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Staus", DataRowVersion.Default, queueInfo.Status)
			};
           return new CommandList(sql, parameters);
       }

       private CommandList UpdateQueue(QueueInfoOR queueInfo)
       {
           string sql = @"update t_QueueInfo set  BillNo = @BillNo,TransferDestWin = @TransferDestWin,  DelayNum = @DelayNum, 
DelayTime = @DelayTime,  CallTime = @CallTime,  ProcessTime = @ProcessTime,  FinishTime = @FinishTime,  WindowNo = @WindowNo, 
EmployNo = @EmployNo,  EmployName = @EmployName,Judge = @Judge,  WaitInterval = @WaitInterval,  ProcessInterval = @ProcessInterval, 
CustemClass = @CustemClass,  Description = @Description,  Staus = @Staus where  Id = @Id";
           SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "Id", DataRowVersion.Default, queueInfo.Id),
				new SqlParameter("@BillNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "BillNo", DataRowVersion.Default, queueInfo.Billno),
				new SqlParameter("@TransferDestWin", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "TransferDestWin", DataRowVersion.Default, queueInfo.Transferdestwin),
				new SqlParameter("@DelayNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "DelayNum", DataRowVersion.Default, queueInfo.Delaynum),
				new SqlParameter("@DelayTime", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "DelayTime", DataRowVersion.Default, queueInfo.Delaytime),
				new SqlParameter("@CallTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "CallTime", DataRowVersion.Default, queueInfo.Calltime),
				new SqlParameter("@ProcessTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "ProcessTime", DataRowVersion.Default, queueInfo.Processtime),
				new SqlParameter("@FinishTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "FinishTime", DataRowVersion.Default, queueInfo.Finishtime),
				new SqlParameter("@WindowNo", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "WindowNo", DataRowVersion.Default, queueInfo.Windowno),
				new SqlParameter("@EmployNo", SqlDbType.Char, 36, ParameterDirection.Input, false, 0, 0, "EmployNo", DataRowVersion.Default, queueInfo.Employno),
				new SqlParameter("@EmployName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "EmployName", DataRowVersion.Default, queueInfo.Employname),
				//new SqlParameter("@CardNo", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "CardNo", DataRowVersion.Default, queueInfo.Cardno),
				new SqlParameter("@Judge", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Judge", DataRowVersion.Default, queueInfo.Judge),
				new SqlParameter("@WaitInterval", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "WaitInterval", DataRowVersion.Default, queueInfo.Waitinterval),
				new SqlParameter("@ProcessInterval", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ProcessInterval", DataRowVersion.Default, queueInfo.Processinterval),
				
				new SqlParameter("@CustemClass", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "CustemClass", DataRowVersion.Default, queueInfo.Custemclass),
				new SqlParameter("@Description", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Default, queueInfo.Description),
				new SqlParameter("@Staus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Staus", DataRowVersion.Default, queueInfo.Status)
			};
           return new CommandList(sql, parameters);
       }
    }
}
