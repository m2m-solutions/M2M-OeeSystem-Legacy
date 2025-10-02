using System;
using System.Collections.Generic;
using System.Linq;

using System.Collections;
using Telerik.Web.UI;

namespace M2M.DataCenter
{
    public class SchedulerManager
    {
        public static IEnumerable ExpandRecurrence(string recurrenceRule, DateTime rangeStart, DateTime rangeEnd, bool offset)
	    {
		    var occurrences = new List<OccurrenceInfo>();
		    RecurrenceRule rrule;
		    if (RecurrenceRule.TryParse(recurrenceRule, out rrule))
		    {
                
                DateTime fixedRangeStart = rangeStart.AddDays(-1);
                rrule.MaximumCandidates = int.MaxValue;
                rrule.SetEffectiveRange(fixedRangeStart, rangeEnd);
                
			    foreach (DateTime occStart in rrule.Occurrences)
			    {
                    DateTime occEnd = occStart.Add(rrule.Range.EventDuration);
                    if (occEnd > rangeStart)
                    {
                        OccurrenceInfo info = new OccurrenceInfo(occStart, occEnd);
                        occurrences.Add(info);
                    }
			    }
		    }
            

            return occurrences;
        }
    }
}
