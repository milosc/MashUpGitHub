using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_VendorTypes:Sif_Base<byte>
    {
        private static SifLangStore<Sif_VendorTypes> _Store = new SifLangStore<Sif_VendorTypes>();
        public static Sif_VendorTypes GetCurrent(string lang)
        {
            return _Store.Get(lang, () => new Sif_VendorTypes(lang));
        }

        public Sif_VendorTypes(string lang)
            :base(new Dictionary<byte,string>()
            {
                {1,"Private Person"},
                {2,"Dealer"},
            }, 
            lang, 
            "Auto vendor type",
            (t) => "car_VendorType_" + t)
        {
        }
    }
}
