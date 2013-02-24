using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QClient.QueueClinetServiceReference;

namespace QClient
{
    public class ButtomControl
    {
        public string ID { get; set; }
        public int OpType { get; set; }
        public QhandyOR ButtomOR { get; set; }
    }
}
