using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleType
    {
        public bool Selected { get; set; }
        public BmVehicleType VehicleType { get; private set; }

        public VmVehicleType(BmVehicleType vehicleType, bool selected)
            : this(vehicleType)
        {
            Selected = selected;
        }
        public VmVehicleType(BmVehicleType vehicleType)
        {
            VehicleType = vehicleType;
        }
    }
}