using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoGearbox
    {
        private static Dictionary<string, Sif_AutoGearbox> _Current = new Dictionary<string, Sif_AutoGearbox>();
        private static object _Lock = new object();
        public static Sif_AutoGearbox Current(string lang)
        {
            Sif_AutoGearbox sif;
            lock (_Lock)
            {
                if (_Current.TryGetValue(lang, out sif))
                    return sif;
            }
            sif = new Sif_AutoGearbox(lang);
            lock (_Lock)
            {
                _Current[lang] = sif;
            }
            return sif;
        }

        public Sif_Base<byte> All { get; private set; }
        public Sif_Base<byte> Filter { get; private set; }
        public Sif_Base<byte> Insert { get; private set; }
        public Sif_AutoGearbox(string lang)
        {
            Dictionary<byte, string> filter = new Dictionary<byte, string>()
                {
                    {1,"Manual gearbox"},
                    {10,"Automatic transmission"},
                    {11,"Semi-automatic"}
                };
            Dictionary<byte, string> insert = new Dictionary<byte, string>()
                {
                    {3,"Manual 3-speed"},
                    {4,"Manual 4-speed"},
                    {5,"Manual 5-speed"},
                    {6,"Manual 6-speed"},
                    {10,"Automatic transmission"},
                    {11,"Semi-automatic"}
                };
            Dictionary<byte, string> all = filter.ToDictionary(row => row.Key, row => row.Value);
            foreach (var pair in insert)
                all[pair.Key] = pair.Value;

            Filter = new Sif_Base<byte>(filter, 
                lang,
                "Auto Gearbox",
                (t) => "car_Gearbox_" + t);
            
            Insert = new Sif_Base<byte>(insert,
                lang,
                "Auto Gearbox",
                (t) => "car_Gearbox_" + t);
            
            All = new Sif_Base<byte>(all,
                lang,
                "Auto Gearbox",
                (t) => "car_Gearbox_" + t);
        }
    }
}
