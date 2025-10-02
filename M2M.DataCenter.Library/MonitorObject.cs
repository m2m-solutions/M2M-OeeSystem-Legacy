using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace M2M.DataCenter
{
    public class MonitorObject
    {
        public Point Position { get; set; }
        public int Width { get; set; }
        public int FontSize { get; set; }
        
        public MonitorObject()
        {
            this.Position = Point.Empty;
            this.Width = 0;
            this.FontSize = 0;
        }

        public bool HasValue
        {
            get { return this.Position != Point.Empty;  }
        }

        public string Serialize()
        {
            return String.Format("{0};{1};{2};{3}", this.Position.X, this.Position.Y, this.Width, this.FontSize);
        }

        public void Deserialize(string data)
        {
            string[] splitValues = data.Split(new char[] { ';' });
            if (splitValues.Length == 4)
            {
                this.Position = new Point(Convert.ToInt32(splitValues[0]), Convert.ToInt32(splitValues[1]));
                this.Width = Convert.ToInt32(splitValues[2]);
                this.FontSize = Convert.ToInt32(splitValues[3]);
            }
        }
    }
}
