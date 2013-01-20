using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class BmCarAd
    {
        public long CarAdId { get; set; }
        public BmJPrice Price { get; set; }

        public int MakerId { get; set; }
        public int ModelId { get; set; }
        public string Variant { get; set; }
        public byte? VehicleTypeId { get; set; } //OBLIKA

        public short DoorsId { get; set; }
        public short SeatCountId { get; set; }
        public byte? SeatColorId { get; set; }
        public byte? SeatMaterialId { get; set; }
        public byte? RoofId { get; set; }

        public string VIN { get; set; }
        public byte VendorType { get; set; } 
        public BmCarCondition Condition { get; set; }
        public BmEngine Engine { get; set; }

        public BmJCarSecurity Security { get; set; }
        public BmJComfort Comfort { get; set; }
        public BmJExtras Extras { get; set; }
        public BmJMultimedia Multimedia { get; set; }
        public BmJUnderCarriage UnderCarriage { get; set; }

        public string Comment { get; set; }
    }
}
