using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class RmAutoSearchItem
    {
        //[CarAdId],[MakerId],[ModelId],[Variant],[Price],[Year1Reg],[VendorId],[Km],[Kw],[Ccm],[FuelId],[VendorTypeId],[IsDamaged],[JShortFeatures],[Published]
        public long CarAdOId;
        public int MakerId;
        public int ModelId;
        public string Variant;
        public int? Price;

        public short Year1Reg;
        public int Km;
        public int Kw;
        public int? Ccm;
        public byte FuelId;
        public byte VendorTypeId;
        public bool? IsDamaged;
        public string JShortFeatures;
        public DateTime Published;

        public long VendorId;
    }
}
