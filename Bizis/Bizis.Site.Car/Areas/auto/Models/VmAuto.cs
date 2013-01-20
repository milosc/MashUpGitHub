using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using Bizis.Site.Car.Classes;
using Bizis.Site.Car.Models;
using Bizis.Site.Common.Binder;
using Bizis.Site.Car.Areas.auto.Binder;
using System.Web.Routing;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Areas.auto.Models
{
    public class VmAuto
    {
        [PropertyBinder]
        public VmContext Context { get; private set; }
        [PropertyBinder]
        public VmAutoVehicleType VehicleType { get; private set; }
        
        [PropertyBinder]
        public VmAutoVariant Variant0 { get; private set; }
        [PropertyBinder]
        public VmAutoVariant Variant1 { get; private set; }
        [PropertyBinder]
        public VmAutoVariant Variant2 { get; private set; }

        [PropertyBinder]
        public VmVehiclePrice Price { get; private set; }

        [PropertyBinder]
        public VmVehicleYear Year1Reg { get; private set; }

        [PropertyBinder]
        public VmVehicleKm Km { get; private set; }

        [PropertyBinder]
        public VmVehicleKw Kw { get; private set; }

        
        [PropertyBinder]
        public VmVehicleDoors Doors { get; private set; }

        [PropertyBinder]
        public VmVehicleSeatCount SeatCounts { get; private set; }

        [PropertyBinder]
        public VmVehicleGearbox Gearbox { get; private set; }

        [PropertyBinder]
        public VmVehicleFuel Fuel { get; private set; }

        [PropertyBinder]
        public VmVehicleDamage Damage { get; private set; }

        [PropertyBinder]
        public VmVehicleAdPublished AdPublished { get; private set; }

        [PropertyBinder]
        public VmVehicleVendorType VendorType { get; private set; }
        
        [PropertyBinder]
        public VmVehicleColors ExteriorColor { get; private set; }
        
        [PropertyBinder]
        public VmVehicleSeatColors SeatColors { get; private set; }
        
        [PropertyBinder]
        public VmAutoFilterExtras Extras { get; private set; }

        [PropertyBinder]
        public VmVehicleOldTypes OldTypes { get; private set; }
        public VmAuto()
        {
            Context = CarSession.Current.Vm;
            
            Variant0 = new VmAutoVariant(null);
            Variant1 = new VmAutoVariant(1);
            Variant2 = new VmAutoVariant(2);
            VehicleType = new VmAutoVehicleType(Context);
            Price = new VmVehiclePrice("EUR");
            Km = new VmVehicleKm("km");
            Year1Reg = new VmVehicleYear("reg1");
            Kw = new VmVehicleKw(Context);
            Doors = new VmVehicleDoors(Context);
            SeatCounts = new VmVehicleSeatCount(Context);
            Gearbox = new VmVehicleGearbox(Context);
            Fuel = new VmVehicleFuel(Context);
            Damage = new VmVehicleDamage(Context);
            AdPublished = new VmVehicleAdPublished(Context);
            VendorType = new VmVehicleVendorType(Context);
            ExteriorColor = new VmVehicleColors(Context);
            SeatColors = new VmVehicleSeatColors(Context);
            Extras = new VmAutoFilterExtras(Context);
            OldTypes = new VmVehicleOldTypes(Context);
        }
        public void FillQueryString(RouteValueDictionary r)
        {
            Variant0.FillQueryString(r);
            Variant1.FillQueryString(r);
            Variant2.FillQueryString(r);
            VehicleType.FillQueryString(r);
            Price.FillQueryString(r);
            Km.FillQueryString(r);
            Year1Reg.FillQueryString(r);
            Kw.FillQueryString(r);
            Doors.FillQueryString(r);
            SeatCounts.FillQueryString(r);
            Gearbox.FillQueryString(r);
            Fuel.FillQueryString(r);
            Damage.FillQueryString(r);
            AdPublished.FillQueryString(r);
            VendorType.FillQueryString(r);
            ExteriorColor.FillQueryString(r);
            SeatColors.FillQueryString(r);
            Extras.FillQueryString(r);
            OldTypes.FillQueryString(r);

        }
        public RmAutoFilterSearch GetRequestModel()
        {
            RmAutoFilterSearch r= new RmAutoFilterSearch();
            r.PublishedFrom.Val = AdPublished.PublishedFromUtcDate;
            r.ColorIds.Val = ExteriorColor.GetFilter();
            r.DoorsId.Val = Doors.DoorsId.Val;
            r.Extras = Extras.GetRequestModel();
            r.FuelId.Val = Fuel.FuelId.Val;
            r.GearboxId.Val = Gearbox.GearboxId.Val;
            r.IsDamaged.Val = Damage.IsDamaged.Val;
            r.Km.From= Km.From.Val;
            r.Km.To = Km.To.Val;
            r.Kw.From = Kw.From.Val;
            r.Kw.To = Kw.To.Val;
            r.OldTypeIds.Val = OldTypes.GetFilter();
            r.Price.From = Price.From.Val;
            r.Price.To = Price.To.Val;
            r.Year1Reg.From = Year1Reg.From.Val;
            r.Year1Reg.To = Year1Reg.To.Val;
            r.SeatColorId.Val = SeatColors.ColorId.Val;
            r.SeatCountId .Val= SeatCounts.SeatCountId.Val;
            r.Variants = _GetVariantList();
            r.VehicleTypeIds.Val = VehicleType.GetFilter();
            r.VendorTypeId.Val = VendorType.VendorTypeId.Val;
            return r;
        }

        private List<RmAutoFilterVariant> _GetVariantList()
        {
            List<RmAutoFilterVariant> rms= new List<RmAutoFilterVariant>();
            RmAutoFilterVariant rm = Variant0.GetRequestModelVariant();
            if (rm.IsValidAndNotEmpty)
                rms.Add(rm);

            rm = Variant1.GetRequestModelVariant();
            if (rm.IsValidAndNotEmpty)
                rms.Add(rm);

            rm = Variant2.GetRequestModelVariant();
            if (rm.IsValidAndNotEmpty)
                rms.Add(rm);

            return rms;
        }
    }
}