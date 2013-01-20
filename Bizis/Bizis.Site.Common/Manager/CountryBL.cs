using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;
using Bizis.Common.DL.MsSql;
using Bizis.Site.Common.Properties;

namespace Bizis.Site.Common.Manager
{
    class CountryBL
    {
        public static List<Country> GetCountries()
        {
            List<Country> result;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCommonConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                result = new CountryDL(t).GetCountries();
                t.Commit();
            }
            return result;

        }

        internal static int? GetCounryIdByIp(long ip)
        {
            int? result;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCommonConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                result = new CountryDL(t).GetCounryIdByIp(ip);
                t.Commit();
            }
            return result;
        }
    }
}
