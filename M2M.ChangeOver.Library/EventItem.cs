using System;
using System.Linq;
using M2M.DataCenter;

namespace M2M.ChangeOver.Library
{
    public class EventItem
    {
        public Guid EventId { get; set; }
        public string MachineId { get; set; }
        public string Article { get; set; }
        public TagType TagType { get; set; }
        public DateTime EventRaised { get; set; }
        public DateTime TimeForNextEvent { get; set; }
      
        public EventItem()
        {
            this.EventId = Guid.Empty;
            this.MachineId = "";
            this.Article = "";
            this.TagType = TagType.NotApplicable;
            this.EventRaised = DateTime.MinValue;
            this.TimeForNextEvent = DateTime.MinValue;
        }

        public bool Override
        {
            get { return (this.TagType == TagType.Stop || this.TagType == TagType.Auto || this.TagType == TagType.UnidentifiedStop || this.TagType == TagType.MainAlarm || this.TagType == TagType.Informational); }
        }
    }
}
