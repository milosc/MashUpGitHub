using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;
using Bizis.Site.Common.Manager;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoOldType
    {
        private static Dictionary<string, Sif_AutoOldType> _Current = new Dictionary<string, Sif_AutoOldType>();
        private static object _Lock = new object();
        public static Sif_AutoOldType Current(string lang)
        {
            Sif_AutoOldType sif;
            lock (_Lock)
            {
                if (_Current.TryGetValue(lang, out sif))
                    return sif;
            }
            sif = new Sif_AutoOldType(lang);
            lock (_Lock)
            {
                _Current[lang] = sif;
            }
            return sif;
        }

        public Sif_Base<byte> All {get; private set;}
        public Sif_Base<byte> Filter { get; private set; }
        public Sif_AutoOldType(string lang)
        {
            Translation t = TranslationMng.Current.Get(lang);

            Dictionary<byte, string> filter = new Dictionary<byte, string>()
            {
                {1,"New vehicle"},
                {2,"Test vehicle"},
                {3, "Used vehicle"}
            };
            Dictionary<byte, string> all = filter;
            All = new Sif_Base<byte>(all, lang, "Auto old type", (v) => "car_old_" + v);
            Filter = new Sif_Base<byte>(filter, lang, "Auto old type", (v) => "car_old_" + v);


        }


    }
}
