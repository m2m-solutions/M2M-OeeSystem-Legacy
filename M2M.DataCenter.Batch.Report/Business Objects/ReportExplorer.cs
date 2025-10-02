using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Telerik.Reporting;

namespace M2M.DataCenter.Batch.Report
{
    /// <summary>
    /// Summary description for BatchReportExplorer
    /// </summary>
    public static class BatchReportExplorer
    {
        public static List<Type> GetReports()
        {
            List<Type> list = new List<Type>();
            Assembly assembly = typeof(BatchReportExplorer).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAbstract)
                    continue;

                if (typeof(IReportDocument).IsAssignableFrom(type)
                    && TypeDescriptor.GetAttributes(type)[typeof(BrowsableAttribute)].Equals(BrowsableAttribute.Yes))
                {
                    list.Add(type);
                }
            }
            list.Sort(BatchReportExplorer.CompareByName);
            return list;
        }

       

        static int CompareByName(Type t1, Type t2)
        {
            return t1.Name.CompareTo(t2.Name);
        }
    }
}
