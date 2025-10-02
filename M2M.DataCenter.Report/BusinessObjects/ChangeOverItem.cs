using System;
using System.Linq;

namespace M2M.DataCenter
{
    public class ChangeOverItem
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public string PreviousArticle { get; set; }
        public string ChangeOverText { get; set; }

        public double ElapsedTimeInMinutes { get { return ElapsedTime.TotalMinutes; } }
        
        public ChangeOverItem(string prevoiusArticle)
        {
            this.PreviousArticle = prevoiusArticle;
            this.ElapsedTime = new TimeSpan(0);
            this.ChangeOverText = "";
        }
    }
}
