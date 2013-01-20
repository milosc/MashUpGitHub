using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_VehicleType 
    {
        private static Dictionary<string, Sif_VehicleType> _Current = new Dictionary<string, Sif_VehicleType>();
        private static object _Lock = new object();
        public static Sif_VehicleType Current(string lang)
        {
            Sif_VehicleType sif;
            lock (_Lock)
            {
                if (_Current.TryGetValue(lang, out sif))
                    return sif;
            }
            sif = new Sif_VehicleType (lang);
            lock (_Lock)
            {
                _Current[lang] = sif;
            }
            return sif;
        }

        public Sif_Base<byte, BmVehicleType> All { get; private set; }
        public Sif_Base<byte, BmVehicleType> Auto { get; private set; }

        public Sif_VehicleType(string lang)
        {

            Dictionary<byte, BmVehicleType> auto = new Dictionary<byte, BmVehicleType>()
            {
                    {1, new BmVehicleType(1, "limo", "Limousine")},
                    {2, new BmVehicleType(2, "small_car", "Small Car")},
                    {3, new BmVehicleType(3, "estate", "Estate Car")},
                    {4, new BmVehicleType(4, "van", "Van / Minibus")},
                    {5, new BmVehicleType(5, "off_road", "Off-road Vehicle / Pickup Truck")},
                    {6, new BmVehicleType(6, "cabrio", "Cabrio")},
                    {7, new BmVehicleType(7, "coupe", "Coupe")}
            };

            Dictionary<byte, BmVehicleType> all = auto;

            All = new Sif_Base<byte, BmVehicleType>(auto, lang, "Vehicle type", (t) => "vehType_" + t, (v) => v.Name, (orig, translated) => new BmVehicleType(orig.Id, orig.Key, translated));
            Auto = new Sif_Base<byte, BmVehicleType>(auto, lang, "Vehicle type", (t) => "vehType_" + t, (v) => v.Name, (orig, translated) => new BmVehicleType(orig.Id, orig.Key, translated));
        }
    }
}
