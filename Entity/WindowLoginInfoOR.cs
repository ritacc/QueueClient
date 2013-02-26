using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
   public class WindowLoginInfoOR
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 窗口编号
        /// </summary>
        public string WindowNo { get; set; }
        /// <summary>
        /// 柜员编号
        /// </summary>
        public string EmployNo { get; set; }
        /// <summary>
        /// 登录窗口柜员名称
        /// </summary>
        public string EmployName { get; set; }
        /// <summary>
        /// 当关状态 (0:正常,1:结束, 2: 暂停 )
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 状态更新时间
        /// </summary>
        public DateTime AlertTime { get; set; }

        public WindowLoginInfoOR()
        {
            ID = Guid.NewGuid().ToString();
        }
        public WindowLoginInfoOR(DataRow dr)
        {
            ID = dr["id"].ToString();
            LoginTime = Convert.ToDateTime(dr["LoginTime"]);
            WindowNo = dr["WindowNo"].ToString();
            EmployNo = dr["EmployNo"].ToString();
            EmployName = dr["EmployName"].ToString();
            Status = Convert.ToInt32(dr["Status"]);
            AlertTime = Convert.ToDateTime(dr["AlertTime"]);
        }
    }
}
