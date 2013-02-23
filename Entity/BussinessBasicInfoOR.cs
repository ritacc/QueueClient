﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QM.Client.Entity
{
    /// <summary>
    /// 业务队列基本信息，用于返回
    /// </summary>
  public  class BussinessBasicInfoOR
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
      /// 英文名称(缩写)
      /// </summary>
      public string EnglishName { get; set; }

      public BussinessBasicInfoOR()
      {

      }

      public BussinessBasicInfoOR(BussinessQueueOR obj)
      {
          ID = obj.ID;
          Name = obj.Name;
          EnglishName = obj.EnglishName;
      }
    }
}
