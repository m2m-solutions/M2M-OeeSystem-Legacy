using System;

namespace M2M.DataCenter
{
    
	public enum StateType
	{
		NotApplicable = 0,
		NoProduction = 1,
		ArticleSwitch = 2,
		Auto = 3,
        NotConnected = 4,
        FlowError = 5,
        ChangeOver = 6
	}

	public enum TagType
	{
		NotApplicable = 0,
		Informational = 1,		// informativ h�ndelse (1)
		Stop = 3,			    // stoppande h�ndelse (2,4)
		MainAlarm = 4,          // Summalarm (4)
        Auto = 10,				// Automatflagga (8)
		ProductionSwitch = 11,	// Flagga f�r producerande maskin (16)	
		ArticleNumber = 12,		// Artikelnummer (32)
		ReasonCode = 13,	    // Orsakskod (4096)
        ConnectionCheck = 14,   // ConnectionCheck
        Uptime = 20,			// Drifttid ackumulerad (f�r service) (64)
		UptimeResettable = 21,	// Drifttid �terst�llbar (f�r service) (128)
		Moments = 22,			// Antal slag/svets ackumulerad (f�r service) (256)
		MomentsResettable = 23, // Antal slag/svets �terst�llbar (f�r service) (512)
		Cycles = 24,			// Antal cykler ackumulerad, taktr�knare (1024)
		CyclesResettable = 25,	// Antal cykler �terst�llbar, antal i order (2048)
        CurrentRunRate = 26,    // Nuvarande hastighet (8192)
        Rejected = 27,          // Kasserat antal, r�knare
        
        //Interna taggar
        UnidentifiedStop = 80,	// Oidentifierade stopp
        CommunicationError = 90,// Kommunikationsfel - trigged by value on ConnectionCheck tag
        CommunicationBadQuality = 91,// Kommunikationsfel - trigged by bad quality on ConnectionCheck tag
        ExpectedRestart = 100,	// Insamling omstartad ok
        UnexpectedRestart = 101,	// Insamling omstartad abrupt, krash?
        InitiatingCommunication = 102 // Initierar kommunikation efter �terstart
    }

    /// <summary>
    /// Defines the Intervals for OEE graphs
    /// </summary>
    public enum Intervals
    {
	    /// <summary>
	    /// Interval not defined
	    /// </summary>
        NotDefined = -1,

	    /// <summary>
	    /// Daily interval (two weeks back) 
	    /// </summary>
        Daily = 0,

	    /// <summary>
	    /// Weekly interval (six months back)
	    /// </summary>
        Weekly,

	    /// <summary>
	    /// Monthly interval (two years back)
	    /// </summary>
        Monthly,

	    /// <summary>
	    /// Quarterly interval (six years back)
	    /// </summary>
        Quarterly,

	    /// <summary>
	    /// Yearly interval (illimatable years back)
	    /// </summary>
        Yearly
    };

    /// <summary>
    /// Defines the different unit types that can be used for run rates
    /// </summary>
    public enum RunRateUnit
    {
	    /// <summary>
	    /// cycle time in ms
	    /// </summary>
	    CycleTimeInMilliSeconds = 0,

	    /// <summary>
	    /// Cycles / hour 
	    /// </summary>
	    CyclesPerHour = 1,

	    /// <summary>
	    /// Cycles / minute
	    /// </summary>
	    CyclesPerMinute = 2
    };

    /// <summary>
    /// Defines the moment unit types that can be used for moments
    /// </summary>
    public enum MomentUnit
    {
        Cycles = 0,

        Strokes = 1,

        Welds = 2,
    };

    public enum OeePart
    {
        NotSet = -1,

        Oee = 0,

        Availability = 1,

        Performance = 2,

        Quality = 3,
    };

    public enum DeviceUnitLevel
    {
        Root = 0,
        Child
    }

    /// <summary>
    /// Defines a grouping type
    /// </summary>
    public enum GroupingType
    {
        NotSet = -1,

        /// <summary>
        /// Divisions grouped in modules
        /// </summary>
        Module = 0,
    };

    /// <summary>
    /// Defines a stoppage orderby 
    /// </summary>
    public enum StoppageOrderBy
    {
        /// <summary>
        /// Order by downtime
        /// </summary>
        Downtime = 0,

        /// <summary>
        /// Order by number of stops
        /// </summary>
        NumberOfStops = 1,
    };

    /// <summary>
    /// Defines a analyze show type 
    /// </summary>
    public enum AnalyzeShowType
    {
        /// <summary>
        /// Show weighted number stops
        /// </summary>
        WeightedNumberOfStops = 0,

        /// <summary>
        /// Order by number of stops
        /// </summary>
        NumberOfStops = 1,

        /// <summary>
        /// Show weighted elapsed time
        /// </summary>
        WeightedElapsedTime = 2,

        /// <summary>
        /// Order by number of stops
        /// </summary>
        ElapsedTime = 3,
    };
}