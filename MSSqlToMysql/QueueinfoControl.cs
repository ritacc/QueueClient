using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using QM.Client.DA.MySql;
using QM.Client.DA.MSSql;

namespace QM.Client.UpdateDB
{
    /// <summary>
    /// 用于控件排队记录同步处理
    /// </summary>
    public class QueueinfoControl
    {

/*
ALTER TABLE `t_queueinfo`
CHANGE COLUMN `Staus` `Status`  int(11) NULL DEFAULT 0 COMMENT '0：取号,1:叫号、2：欢迎、3：结束、4上传完成。' AFTER `Description`,
ADD COLUMN `UpStatus`  int NOT NULL DEFAULT '-1' AFTER `Status`;
 * */
        /// <summary>
        /// 上传数据
        /// </summary>
        /// <returns></returns>
        public bool UpQueueData()
        {
            try
            {
                QueueInfoMySqlDA _queMysql = new QueueInfoMySqlDA();
                QueueInfoMSSqlDA _queMSSql = new QueueInfoMSSqlDA();
                //查询需要更新的数据
                List<QueueInfoOR> ListQue = _queMysql.SelectUpdata();
                if (ListQue != null && ListQue.Count > 0)
                {
                    //上传数据
                    _queMSSql.Updata(ListQue);
                    //更新mysql状态
                    _queMysql.UpdateQueueUploadStatus(ListQue);
                    WriteLog.writLog("0000", string.Format("取号更新数据:{0}条", ListQue.Count));
                }
                else
                {
                    WriteLog.writLog("0000", "没有可更新数据。");
                }
            }
            catch (Exception ex)
            {
                WriteLog.writLog("1003", ex.Message);
            }

            return true;
        }

    }
}
