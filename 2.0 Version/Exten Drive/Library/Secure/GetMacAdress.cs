using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Library.Secure
{
    class GetMacAdress
    {
        public static string GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myip = string.Empty;
            foreach (IPAddress ia in host.AddressList)
            {
                if (ia.AddressFamily == AddressFamily.InterNetwork)
                {
                    myip = ia.ToString(); break;

                }
            }
            return myip;
        }


        public static string GetMacAddress(string ip)
        {
            string macAddress = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'"));
            foreach (ManagementObject obj in searcher.Get())
            {
                string[] ipAddress = (string[])obj["IPAddress"];
                if (ipAddress[0] == ip && obj["MACAddress"] != null)
                {
                    macAddress = obj["MACAddress"].ToString(); break;
                }
            }
            return macAddress;
        }
    }
}
