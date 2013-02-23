using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 网点业务列名 (业务、此业务的取号记录)
    /// </summary>
   public class BussinessQueueOR
    {
       /// <summary>
       /// 业务ID
       /// </summary>
       public string ID { get; set; }

       /// <summary>
       /// 业务名称
       /// </summary>
       public string Name { get; set; }

       /// <summary>
       /// 队列 取号数据
       /// </summary>
      public List<QueueInfoOR> BussQueues { get; set; }

       public BussinessQueueOR()
       {

       }

       //public BussinessQueueOR(DataRow dr)
       //{
       //    ID = dr["id"].ToString();
       //    Name = dr["name"].ToString();
       //}
    }
}
