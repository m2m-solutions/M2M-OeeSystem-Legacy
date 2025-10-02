using System;
using System.Linq;

namespace M2M.DataCenter
{
    public class DeviceUnit
    {
        public string DeviceUnitId { get; set; }
        public int Level { get; set; }
        public string DisplayName { get; set; }
        public string ParentId { get; set; }
        public bool CollectData { get; set; }
    }
}
