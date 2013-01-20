using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Manager;

namespace Bizis.Site.Common.Model
{
    public class VmContext
    {
        public long Ip { get; private set; }
        public Country IpCountry { get; private set; }
        public string Lang { get; private set; }
        
        private Translation _Trans;
        public Translation Trans
        {
            get 
            {
                if (_Trans == null)
                    _Trans = TranslationMng.Current.Get(Lang);
                return _Trans;
            }
        }
        public VmContext(string lang)
        {
            Lang = lang;
            Ip = IpMng.CurrentContextIp;
            IpCountry = CountryMng.GetCountryByIp(Ip);
        }
    }
}
