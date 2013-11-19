using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using QM.Entity.ParaSet;


namespace QM.Web.WCF
{
    [ServiceContract]
    public class ButtomControl
    {
        [DataMember]
        public string ID{get;set;}
        [DataMember]
        public int OpType { get; set; }
        [DataMember]
        public QhandyOR ButtomOR { get; set; }
    }

    [ServiceContract]
    public class YWOR
    {
        [DataMember]
        public string NO { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [ServiceContract]
    public class PageWinControl
    {
        [DataMember]
        public int OpType { get; set; }
        [DataMember]
        public PageWinOR ButtomOR { get; set; }
    }
}