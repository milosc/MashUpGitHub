using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Car.Common.Model;
using Bizis.Common.DL.MsSql;
using Bizis.Site.Car.Common.Properties;

namespace Bizis.Site.Car.Common.Manager
{
    public class AutoBL
    {
        private const int _SearchCount=25;
        public RmAutoSearchList GetSearchList(int page, RmAutoFilterSearch req)
        {
            RmAutoSearchList res = new RmAutoSearchList();
            int countAll;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCarConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                res.Items.AddRange(new AutoDL(t).GetSearchList(page, _SearchCount, req, out countAll));
                t.Commit();
            }
            return res;
        }
    }
}
