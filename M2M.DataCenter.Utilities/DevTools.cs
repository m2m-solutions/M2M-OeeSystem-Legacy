using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace M2M.DataCenter.Utilities
{
    public static class DevTools
    {
        public static bool IsDeveloperEnvironment()
        {
            var macAddresses =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).ToArray();

            return macAddresses.Contains("00155D1E0A03");
        }
    }
}
