using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Telerik.Reporting;

namespace M2M.DataCenter.Reports
{
    

    /// <summary>
    /// Summary description for ReportExplorer
    /// </summary>
    public static class ReportExplorer
    {
        public static List<Type> GetReports()
        {
            List<Type> list = new List<Type>();
            Assembly assembly = typeof(ReportExplorer).Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAbstract)
                    continue;

                if (typeof(IReportDocument).IsAssignableFrom(type)
                    && TypeDescriptor.GetAttributes(type)[typeof(BrowsableAttribute)].Equals(BrowsableAttribute.Yes)
                    && IsAvailable(type))
                {
                    list.Add(type);
                }
            }
            list.Sort(ReportExplorer.CompareByName);
            return list;
        }

        /// <summary>
        /// The DescriptionAttribute of a report must have the value Default or the name of a specific module.
        /// The only exception is that a template report has the value Template.
        /// Default reports are available for all, Template for noone and the rest are customer depended
        /// </summary>
        static bool IsAvailable(Type type)
        {
            DescriptionAttribute description =
                    TypeDescriptor.GetAttributes(type)[typeof(DescriptionAttribute)] as DescriptionAttribute;

            if (description == null)
                return false;

            switch (description.Description)
            {
                case "Default":
                    return true;
                case "Template":
                    return false;
                default:
                    return M2MDataCenter.GetAvailableModules().Contains(description.Description);
            }

        }

        /// <summary>
        /// The DisplayNameAttribute of a report must have sortorder value.
        /// </summary>
        static int CompareByName(Type t1, Type t2)
        {
            DisplayNameAttribute displayName1 =
                    TypeDescriptor.GetAttributes(t1)[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

            DisplayNameAttribute displayName2 =
                    TypeDescriptor.GetAttributes(t2)[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

            return displayName1.DisplayName.CompareTo(displayName2.DisplayName);
        }

        
    }
}
