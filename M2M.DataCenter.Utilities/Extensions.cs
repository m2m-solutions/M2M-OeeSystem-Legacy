using System;
using System.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using M2M.DataCenter.Localization;

namespace M2M.DataCenter.Utilities
{
    public static class Extensions
    {
        public static DateTime FirstDateOfWeek(int year, int weekNum)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            DateTime firstDay = jan1.FirstDateOfWeek();

            if (jan1.GetWeek() <= 1)
            {
                weekNum -= 1;
            }

            return firstDay.AddDays((weekNum) * 7);
        }

        public static DateTime FirstDateOfWeek(this DateTime date)
        {
            int daysOffset = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - date.DayOfWeek;
            if (daysOffset > 0)
                daysOffset = daysOffset - 7;
            return date.AddDays(daysOffset);
        }

        public static int GetWeek(this DateTime date)
        {
            var cal = CultureInfo.CurrentCulture.Calendar;
            return cal.GetWeekOfYear(date, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
            
        }

        public static Month GetQuarterStartingMonth(this DateTime date)
        {
            switch (date.GetQuarter())
            {
                case Quarter.Q1:
                    return Month.January;
                case Quarter.Q2:
                    return Month.April;
                case Quarter.Q3:
                    return Month.July;
                case Quarter.Q4:
                default:
                    return Month.October;
            }
        }

        public static Quarter GetQuarter(this DateTime date)
        {
            switch ((Month)date.Month)
            {
                case Month.January:
                case Month.February:
                case Month.March:
                    return Quarter.Q1;
                case Month.April:
                case Month.May:
                case Month.June:
                    return Quarter.Q2;
                case Month.July:
                case Month.August:
                case Month.September:
                    return Quarter.Q3;
                case Month.October:
                case Month.November:
                case Month.December:
                default:
                    return Quarter.Q4;
            }
        }

		public static string SafeSubstring(this string str, int startIndex, int length)
		{
            if (startIndex > str.Length
                || startIndex < 0
                || length < 0)
                return "";

            int safeLength = str.Length - startIndex;

            return str.Substring(startIndex, safeLength < length ? safeLength : length);
		}

        public static string SafeSubstring(this string str, int length, bool ellipse)
        {
            if (ellipse && str.Length > length)
                return str.SafeSubstring(0, length) + "...";

            return str.SafeSubstring(0,  length);
        }

        /// <summary>
        /// This will add an array of parameters to a SqlCommand. This is used for an IN statement.
        /// Use the returned value for the IN part of your SQL call. (i.e. SELECT * FROM table WHERE field IN ({paramNameRoot}))
        /// </summary>
        /// <param name="cmd">The SqlCommand object to add parameters to.</param>
        /// <param name="values">The array of strings that need to be added as parameters.</param>
        /// <param name="paramNameRoot">What the parameter should be named followed by a unique value for each value. This value surrounded by {} in the CommandText will be replaced.</param>
        /// <param name="start">The beginning number to append to the end of paramNameRoot for each value.</param>
        /// <param name="separator">The string that separates the parameter names in the sql command.</param>
        public static SqlParameter[] AddArrayParameters<T>(this SqlCommand cmd, IEnumerable<T> values, string paramNameRoot, int start = 1, string separator = ", ")
        {
            /* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
             * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
             * IN statement in the CommandText.
             */
            var parameters = new List<SqlParameter>();
            var parameterNames = new List<string>();
            var paramNbr = start;
            foreach (var value in values)
            {
                var paramName = string.Format("@{0}{1}", paramNameRoot, paramNbr++);
                parameterNames.Add(paramName);
                parameters.Add(cmd.Parameters.AddWithValue(paramName, value));
            }

            cmd.CommandText = cmd.CommandText.Replace("{" + paramNameRoot + "}", string.Join(separator, parameterNames));

            return parameters.ToArray();
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Converts the <span class="code-SummaryComment"><see cref="Enum" /> type to an <see cref="IList" /> </span>
        /// compatible object.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="type">The <see cref="Enum"/> type.</param></span>
        /// <span class="code-SummaryComment"><returns>An <see cref="IList"/> containing the enumerated</span>
        /// type value and description.<span class="code-SummaryComment"></returns></span>
        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, ResourceStrings.GetString(value)));
            }

            return list;
        }

    }
}
