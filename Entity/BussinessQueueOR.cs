﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QM.Client.Entity
{
    /// <summary>
    /// 网点业务列名 (业务、此业务的取号记录)
    /// </summary>
    public class BussinessQueueOR : BussinessBasicInfoOR
    {
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
