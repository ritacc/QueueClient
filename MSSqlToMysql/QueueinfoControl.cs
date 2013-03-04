using System;
using System.Collections.Generic;
using System.Text;
using QM.Client.Entity;
using QM.Client.DA.MySql;

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
                List<QueueInfoOR> ListQue = new QueueInfoDA().SelectUpdata();

            }
            catch (Exception ex)
            {
                WriteLog.writLog("1003", ex.Message);
            }

            return true;
        }

    }
}
