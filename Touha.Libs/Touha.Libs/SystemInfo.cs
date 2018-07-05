using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Libs
{
    /// <summary>
    /// 系统信息
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// 操作系统账户
        /// </summary>
        public static string UserName
        {
            get
            {
                try
                {
                    string strUserName = string.Empty;
                    using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                    {
                        using (ManagementObjectCollection moc = mc.GetInstances())
                        {
                            foreach (ManagementObject mo in moc)
                            {
                                strUserName = mo["UserName"].ToString();
                            }
                        }
                    }
                    return strUserName;
                }
                catch
                {
                    return "unknown";
                }
            }
        }

        public static string GetUserName()
        {
            var name = (from x in new ManagementObjectSearcher("select * from Win32_ComputerSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("UserName")).FirstOrDefault();
            return name != null ? name.ToString() : "unknown";
        }

        /// <summary>
        /// 本机Mac地址
        /// </summary>
        public static string MacAddress
        {
            get
            {
                try
                {
                    string strMac = string.Empty;
                    using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                    {
                        using (ManagementObjectCollection moc = mc.GetInstances())
                        {
                            foreach (ManagementObject mo in moc)
                            {
                                if ((bool)mo["IPEnabled"] == true)
                                {
                                    strMac = mo["MacAddress"].ToString();
                                }
                            }
                        }
                            
                    }
                    return strMac;
                }
                catch
                {
                    return "unknown";
                }
            }
        }

        public static string OperationSystem
        {
            get
            {
                var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault();
                return name != null ? name.ToString() : "Unknown";
            }
        }

        public  static string BIOSSerialNumber
        {
            get
            {
                var name = (from x in new ManagementObjectSearcher("Select * From Win32_BIOS").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("SerialNumber")).FirstOrDefault();
                return name != null ? name.ToString() : "Unknown";
            }
        }

        public static string GetBIOSSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BIOS");
                string sBIOSSerialNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    sBIOSSerialNumber = mo["SerialNumber"].ToString().Trim();
                }
                return sBIOSSerialNumber;
            }
            catch
            {
                return "";
            }
        }

        public static string GetString(string type, string hash, string key)
        {
            var name = (from x in new ManagementObjectSearcher("Select * From " + type).Get().Cast<ManagementObject>()
                        where x.GetHashCode().ToString() == hash
                        select x.GetPropertyValue(key)).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }
    }
}
