using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QM.Client.Entity;

namespace QM.Client.DA.MySql
{
   public class QueueInfoDA:DALBase
    {

       /// <summary>
       /// 查询队列中未办结的记录
       /// </summary>
       /// <param name="BussinesID"></param>
       /// <returns></returns>
       public List<QueueInfoOR> selectBussinessQueues(string BussinesID)
       {
           string sql = string.Format("select * from t_queueinfo where BussinessId='{0}' and status <4"
               , BussinesID);

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
           List<QueueInfoOR> listBuss = new List<QueueInfoOR>();
           foreach (DataRow dr in dt.Rows)
           {
               QueueInfoOR obj = new QueueInfoOR(dr);
               listBuss.Add(obj);
           }
           return listBuss;
       }

        #region 取号逻辑
       /// <summary>
       /// 取号
       /// </summary>
       /// <param name="_Qh"></param>
       /// <returns></returns>
       public bool QH(QueueInfoOR _Qh)
       {
           string sql = GetQHInsertSQL(_Qh);
           dbMySql.ExecuteNoQuery(sql);
           return true;
       }

       private string GetQHInsertSQL(QueueInfoOR queueInfo)
       {
           string sql = @"insert into t_QueueInfo (Id, BankNo, BillNo, BussinessId, PrillBillTime, 
TransferDestWin, DelayNum, DelayTime, CallTime, ProcessTime, 
FinishTime, WindowNo, EmployNo, EmployName, CardNo, 
Judge, WaitInterval, ProcessInterval, WaitPeopleBusssiness, WaitPeopleBank, 
CustemClass, Description, Status) 
values ('@Id', '@BankNo', '@BillNo', '@BussinessId', '@PrillBillTime',
'@TransferDestWin', @DelayNum, @DelayTime,'@CallTime', '@ProcessTime',
'@FinishTime', '@WindowNo', '@EmployNo', '@EmployName', '@CardNo', 
@Judge, @WaitInterval, @ProcessInterval, @WaitPeopleBusssiness, @WaitPeopleBank, 
@CustemClass, '@Description', @Status)";

           sql = sql.Replace("@Id", queueInfo.Id);
           sql = sql.Replace("@BankNo", queueInfo.Bankno);
           sql = sql.Replace("@BillNo", queueInfo.Billno);
           sql = sql.Replace("@BussinessId", queueInfo.Bussinessid);
           sql = sql.Replace("@PrillBillTime", queueInfo.Prillbilltime.ToString("yyyy-MM-dd HH:mm:ss"));

           sql = sql.Replace("@TransferDestWin", queueInfo.Transferdestwin.ToString());
           sql = sql.Replace("@DelayNum", queueInfo.Delaynum.ToString());
           sql = sql.Replace("@DelayTime", queueInfo.Delaytime.ToString());
           sql = sql.Replace("@CallTime", queueInfo.Calltime.ToString("yyyy-MM-dd HH:mm:ss"));
           sql = sql.Replace("@ProcessTime", queueInfo.Processtime.ToString("yyyy-MM-dd HH:mm:ss"));

           sql = sql.Replace("@FinishTime", queueInfo.Finishtime.ToString("yyyy-MM-dd HH:mm:ss"));
           sql = sql.Replace("@WindowNo", queueInfo.Windowno);
           sql = sql.Replace("@EmployNo", queueInfo.Employno);
           sql = sql.Replace("@EmployName", queueInfo.Employname);
           sql = sql.Replace("@CardNo", queueInfo.Cardno);

           sql = sql.Replace("@Judge", queueInfo.Judge.ToString());
           sql = sql.Replace("@WaitInterval", queueInfo.Waitinterval.ToString());
           sql = sql.Replace("@ProcessInterval", queueInfo.Processinterval.ToString());
           sql = sql.Replace("@WaitPeopleBusssiness", queueInfo.Waitpeoplebusssiness.ToString());
           sql = sql.Replace("@WaitPeopleBank", queueInfo.Waitpeoplebank.ToString());

           sql = sql.Replace("@CustemClass", queueInfo.Custemclass.ToString());
           sql = sql.Replace("@Description", queueInfo.Description.ToString());
           sql = sql.Replace("@Status", queueInfo.Status.ToString());

           return sql;
       }

       /// <summary>
       /// 获取网点今天排除人数。
       /// </summary>
       /// <returns></returns>
       public int GetQueueNumber()
       {
           string sql = string.Format("select count(*) from t_queueinfo where PrillBillTime > '{0} 00:00:00' and PrillBillTime < '{0} 23:59:59'",
               DateTime.Now.ToString("yyyy-MM-dd"));

           return Convert.ToInt32(dbMySql.ExecuteScalar(sql));
       }
        #endregion

        #region 呼叫接口更新数据

       /// <summary>
       /// 叫号
       /// </summary>
       /// <returns></returns>
       public bool UpdateCall( QueueInfoOR obj)
       {
           string sql =@"update t_queueinfo  set CallTime=now(),status=1,Waitinterval='@Waitinterval'
,CallTime='@CallTime' where  PrillBillTime > '@PrillBillTime 00:00:00' and PrillBillTime < '@PrillBillTime 23:59:59'
and BillNo='@BillNo' ";

           sql = sql.Replace("@Waitinterval", obj.Waitinterval.ToString());
           sql= sql.Replace("@CallTime",obj.Calltime.ToString("yyyy-MM-dd HH:mm:ss"));
           sql = sql.Replace("@PrillBillTime", DateTime.Now.ToString("yyyy-MM-dd"));
           
           sql = sql.Replace("@BillNo", obj.Billno);

           return dbMySql.ExecuteNoQuery(sql) > 0;
       }

       /// <summary>
       /// 更新欢迎状态
       /// </summary>
       /// <param name="obj"></param>
       /// <returns></returns>
       public bool UpdateWelcome(QueueInfoOR obj)
       {
           string sql = @"update t_queueinfo  set CallTime=now(),status=2,ProcessTime='@ProcessTime'
where  PrillBillTime > '@PrillBillTime 00:00:00' and PrillBillTime < '@PrillBillTime 23:59:59'
and BillNo='@BillNo' ";
           //sql = sql.Replace("@Waitinterval", obj.Waitinterval.ToString());
           sql = sql.Replace("@ProcessTime", obj.Processtime.ToString("yyyy-MM-dd HH:mm:ss"));
           sql = sql.Replace("@PrillBillTime", DateTime.Now.ToString("yyyy-MM-dd"));           
           sql = sql.Replace("@BillNo", obj.Billno);
           return dbMySql.ExecuteNoQuery(sql) > 0;
       }

       public bool UpdateCallJudge(QueueInfoOR obj)
       {
           string sql = @"update t_queueinfo  set CallTime=now(),status=3,FinishTime='@ProcessTime',
Processinterval=@Processinterval
where  PrillBillTime > '@PrillBillTime 00:00:00' and PrillBillTime < '@PrillBillTime 23:59:59'
and BillNo='@BillNo' ";
           sql = sql.Replace("@Processinterval", obj.Processinterval.ToString());
           sql = sql.Replace("@ProcessTime", obj.Finishtime.ToString("yyyy-MM-dd HH:mm:ss"));

           sql = sql.Replace("@PrillBillTime", DateTime.Now.ToString("yyyy-MM-dd"));           
           sql = sql.Replace("@BillNo", obj.Billno);
           return dbMySql.ExecuteNoQuery(sql) > 0;
       }

        #endregion

    }
}
