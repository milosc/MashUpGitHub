using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Car.Common.Manager;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoMakers:Sif_Base<int>
    {
        private static Sif_AutoMakers _Current;
        public static Sif_AutoMakers Current
        {
            get 
            {
                if (_Current == null)
                    _Current = new Sif_AutoMakers();
                return _Current;
            }
        }
        public Sif_AutoMakers()
            : base(MakerModelBL.GetCarMakers(), 
                "en", 
                "Auto makers", 
                (t) => "car_Maker_" + t)
        {
        }
    }
}
