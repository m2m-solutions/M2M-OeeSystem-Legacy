using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2M.Monitor.Library
{
    public class MonitorDetail
    {
        public string MachineId { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
    }

    public class MonitorData
    {
        public string Pace { get; set; }
        public string PaceColor { get; set; }
        public string PaceIdeal { get; set; }
        public string PaceIdeal2 { get; set; }
        public string Oee { get; set; }
        public string ChangeOvers { get; set; }
        public string Latest { get; set; }
        public string Average { get; set; }
        public string Ideal { get; set; }
        public List<MonitorDetail> MonitorDetails { get; set; }
    }
}
