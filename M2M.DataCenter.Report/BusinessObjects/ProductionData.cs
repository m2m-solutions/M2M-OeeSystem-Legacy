using System;
using System.Collections.Generic;
using System.Linq;

namespace M2M.DataCenter
{
    class ProductionData
    {
        public int Year { get; set; }
        public string Week { get; set; }
        public string Division { get; set; }
        List<MachineOee> m_PeriodicData = null;

        public List<MachineOee> PeriodicData { get { return m_PeriodicData; } set { m_PeriodicData = value; } }
    }
}
