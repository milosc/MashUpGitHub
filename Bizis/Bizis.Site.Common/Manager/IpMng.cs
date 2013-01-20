using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

namespace Bizis.Site.Common.Manager
{
    public class IpMng
    {
        private const string _Ip4RegPattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

        public static bool _IsIP4Address(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;
            Regex check = new Regex(_Ip4RegPattern);
            return check.IsMatch(address, 0);
        }

        private static string _GetIP4Address(string address)
        {
            string ip4Address = String.Empty;
            foreach (IPAddress IPA in Dns.GetHostAddresses(address))
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    ip4Address = IPA.ToString();
                    break;
                }
            if (ip4Address != String.Empty)
                return ip4Address;

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    ip4Address = IPA.ToString();
                    break;
                }
            return ip4Address;
        }
        public static long CurrentContextIp
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                    return 0;// throw new NullReferenceException("Missing HttpContext");
                //string ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                //if (string.IsNullOrEmpty(ip))
                //    ip = context.Request.UserHostAddress;
                return _Ip2Long(context.Request.UserHostAddress);
            }
        }

        //internal static bool TryGetCountry(out int? countryId)
        //{
        //    HttpContext context = HttpContext.Current;
        //    if (context == null)
        //        throw new NullReferenceException("Missing HttpContext");
        //    if (context.Items.Contains("IpCountry"))
        //    {
        //        countryId = (int?)context.Items["IpCountry"];
        //        return countryId.HasValue;
        //    }
        //    bool result = Models.Ip2CBL.TryGetCounty(CurrentContextIp, out countryId);
        //    if (result)
        //        context.Items["IpCountry"] = countryId;
        //    else
        //        context.Items["IpCountry"] = (int?)null;
        //    return result;
        //}

        private static long _Ip2Long(string address)
        {
            long val = 0;
            if (string.IsNullOrWhiteSpace(address))
                return val;
            if (!_IsIP4Address(address))
                address = _GetIP4Address(address);
            string[] ipParts = address.Split('.');
            if (ipParts.Length < 4)
                throw new ApplicationException("Invalid ipAddress");
            val = Int64.Parse(ipParts[3]) + Int64.Parse(ipParts[2]) * 256 + Int64.Parse(ipParts[1]) * 65536 + Int64.Parse(ipParts[0]) * 16777216;
            return val;
        }
        private static string _Int2Ip(long val)
        {
            long part3 = val % 256;
            val = (val - part3) / 256;
            long part2 = val % 256;
            val = (val - part2) / 256;
            long part1 = val % 256;
            val = (val - part1) / 256;
            long part0 = val % 256;
            return string.Format("{0}.{1}.{2}.{3}", part0, part1, part2, part3);
        }
    }
}
