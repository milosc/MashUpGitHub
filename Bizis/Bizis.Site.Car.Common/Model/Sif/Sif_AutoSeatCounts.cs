using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Manager;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoSeatCounts
    {
        private static Dictionary<string, Sif_AutoSeatCounts> _Current = new Dictionary<string, Sif_AutoSeatCounts>();
        private static object _Lock = new object();
        public static Sif_AutoSeatCounts Current(string lang)
        {
            Sif_AutoSeatCounts sif;
            lock (_Lock)
            {
                if (_Current.TryGetValue(lang, out sif))
                    return sif;
            }
            sif = new Sif_AutoSeatCounts(lang);
            lock (_Lock)
            {
                _Current[lang] = sif;
            }
            return sif;
        }

        public Sif_Base<short> All {get; private set;}
        public Sif_Base<short> Filter { get; private set; }
        public readonly short MaxCount = 60;
        public readonly short MinCount = 1;
        public Sif_AutoSeatCounts(string lang)
        {
            Translation t = TranslationMng.Current.Get(lang);
            List<short> counting = new List<short>(MaxCount);
            for (short i = MinCount; i <= MaxCount; i++)
                counting.Add(i);

            Dictionary<short, string> filter = new Dictionary<short, string>()
            {
                {2,"2"},
                {305,"3-5"},
                {600, t.Translate("seats6+", "6 or more", "Car attibutes")}
            };
            Dictionary<short, string> all = counting.ToDictionary(row => row, row => row.ToString());
            foreach (var pair in filter)
                all[pair.Key]= pair.Value;
            All = new Sif_Base<short>(all);
            Filter = new Sif_Base<short>(filter);


        }
    }
}
