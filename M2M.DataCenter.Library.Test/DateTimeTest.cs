using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Globalization;
using System.Threading;
using M2M.DataCenter.Utilities;

namespace M2M.DataCenter.Library.Test
{
    [TestFixture]
    public class DateTimeTest
    {

        [Test]
        public void TestWeekOfYear()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");
            
            Console.WriteLine("************sv-SE**********");

            for (int dateOffset = -8; dateOffset < 8; dateOffset++)
            {
                DateTime date = new DateTime(2011, 1, 1).AddDays(dateOffset);

                Console.WriteLine("{0} week {1} first {2}", date.ToString(), date.GetWeek(), date.FirstDateOfWeek());
            }
            Console.WriteLine();

            for (int dateOffset = -8; dateOffset < 8; dateOffset++)
            {
                DateTime date = new DateTime(2012, 1, 1).AddDays(dateOffset);

                Console.WriteLine("{0} week {1} first {2}", date.ToString(), date.GetWeek(), date.FirstDateOfWeek());
            }
            Console.WriteLine();

            Console.WriteLine("2011 week 52: {0}", Extensions.FirstDateOfWeek(2011,52));
            Console.WriteLine("2011 week 53: {0}", Extensions.FirstDateOfWeek(2011, 53));
            Console.WriteLine("2012 week  1: {0}", Extensions.FirstDateOfWeek(2012, 1));
            Console.WriteLine("2012 week  2: {0}", Extensions.FirstDateOfWeek(2012, 2));
         
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Console.WriteLine();
            Console.WriteLine("************en-US**********");
            Console.WriteLine("2011 week 52: {0}", Extensions.FirstDateOfWeek(2011, 52));
            Console.WriteLine("2011 week 53: {0}", Extensions.FirstDateOfWeek(2011, 53));
            Console.WriteLine("2012 week  1: {0}", Extensions.FirstDateOfWeek(2012, 1));
            Console.WriteLine("2012 week  2: {0}", Extensions.FirstDateOfWeek(2012, 2));
            Console.WriteLine();
            for (int dateOffset = -8; dateOffset < 8; dateOffset++)
            {
                DateTime date = new DateTime(2011, 1, 1).AddDays(dateOffset);

                Console.WriteLine("{0} week {1} first {2}", date.ToString(), date.GetWeek(), date.FirstDateOfWeek());
            }
            Console.WriteLine();
            for (int dateOffset = -8; dateOffset < 8; dateOffset++)
            {
                DateTime date = new DateTime(2012, 1, 1).AddDays(dateOffset);

                Console.WriteLine("{0} week {1} first {2}", date.ToString(), date.GetWeek(), date.FirstDateOfWeek());
            }

            Console.WriteLine();
        }
    }
}
