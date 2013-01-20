using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class BmEngine
    {
        public byte FuelId { get; set; }
        public int Kw { get; set; }
        public int? Ccm { get; set; }
        public byte GearboxId { get; set; }
    }
}
