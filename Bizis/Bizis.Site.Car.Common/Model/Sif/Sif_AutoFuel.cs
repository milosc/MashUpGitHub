using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoFuel:Sif_Base<byte>
    {
        private static SifLangStore<Sif_AutoFuel> _Store = new SifLangStore<Sif_AutoFuel>();
        public static Sif_AutoFuel GetCurrent(string lang)
        {
            return _Store.Get(lang, () => new Sif_AutoFuel(lang));
        }

        public Sif_AutoFuel(string lang)
            :base(new Dictionary<byte,string>()
            {
                {1,"Petrol"},
                {2,"Diesel"},
                {3,"Electric"},
                {4,"Ethanol"},
                {5,"Gas"},
                {6,"Petrol + Gas"},
                {7,"Diesl + Gas"},
                {8,"Hydrogen"},
            }, 
            lang, 
            "Auto fuel",
            (t) => "car_Fuel_" + t)
        {
        }
    }
}
