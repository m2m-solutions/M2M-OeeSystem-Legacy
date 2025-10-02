using System;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI.BusinessObjects
{
    public class EventInfo
    {
        public Guid EventId { get; set; }
        public string TagId { get; set; }
        public string DisplayName { get; set; }
        public string MachineId { get; set; }
        public DateTime EventRaised { get; set; }
        
        public EventInfo(Guid eventId, string tagId, string displayName, string machineId, DateTime eventRaised)
        {
            this.EventId = eventId;
            this.TagId = tagId;
            this.DisplayName = displayName;
            this.MachineId = machineId;
            this.EventRaised = eventRaised;
        }

        public static Predicate<EventInfo> ByEventId(Guid eventId)
        {
            return delegate(EventInfo item) { return item.EventId == eventId; };
        }
    }
}
