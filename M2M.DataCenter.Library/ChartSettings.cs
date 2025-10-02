using System;
using System.Linq;

namespace M2M.DataCenter
{
	public class ChartSettings
	{
        private readonly Intervals m_Interval = Intervals.NotDefined;

		public Intervals Interval
		{
			get { return m_Interval; }
		}
        private readonly int m_Steps;

		public int Steps
		{
			get { return m_Steps; }
		}
		
		public ChartSettings(DateTime startDate, DateTime endDate, Intervals interval)
		{
			TimeSpan totalRange = endDate.Subtract(startDate);

			m_Interval = interval;

            switch (interval)
            {
                case Intervals.Daily:
                    m_Steps = (int)totalRange.TotalDays;
                    if (totalRange.TotalDays % 1.0 > 0)
                        m_Steps++;
                    break;
                case Intervals.Weekly:
                    m_Steps = (int)totalRange.TotalDays / 7;
                    if (totalRange.TotalDays % 7.0 > 0)
                        m_Steps++;
                    break;
            }
		}
	}
}
