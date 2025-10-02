using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2M.Integrator.Lexit.Library
{
    public class LexitObject
    {
        public string TransactionId { get; set; }
        public string RegisterTime { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }

        public LexitObject()
        {
            
        }

        public bool IsValid()
        {
            return !String.IsNullOrEmpty(this.ProductNumber);
        }

        public void ParseData(string line)
        {
            string[] data = line.Split(new char[]{';'});

            if(data.Length == 4)
            {
                this.TransactionId = data[0];
                this.RegisterTime = data[1];
                this.ProductNumber = data[2];
                this.ProductName = data[3];
            }
        }
    }
}
