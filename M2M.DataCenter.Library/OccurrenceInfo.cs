using System;

namespace M2M.DataCenter
{
    public class OccurrenceInfo
    {
	    public OccurrenceInfo(DateTime start, DateTime end)
	    {
		    Start = start;
		    End = end;
	    }

	    public DateTime Start
	    {
		    get;
		    set;
	    }

	    public DateTime End
	    {
		    get;
		    set;
	    }
}
}
