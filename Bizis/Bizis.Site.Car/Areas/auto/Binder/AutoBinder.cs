using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Binder;
using Bizis.Site.Car.Areas.auto.Models;

namespace Bizis.Site.Car.Areas.auto.Binder
{
    public class AutoBinder : AttribBaseBinder
    {
        public override object BindModel(ControllerContext cc, ModelBindingContext bc)
        {
            VmAuto m= base.BindModel(cc, bc) as VmAuto;

            Fill(bc, m.AdPublished.DaysFromNow);
            Fill(bc, m.Damage.IsDamaged);
            Fill(bc, m.Doors.DoorsId);

            foreach (byte id in m.ExteriorColor.Options)
                if (GetValue<bool>(bc, m.ExteriorColor.GetHtmlName(id)))
                    m.ExteriorColor.Selection.Add(id);
            Fill(bc, m.ExteriorColor.IsAll);


            Fill(bc, m.Fuel.FuelId);
            Fill(bc, m.Gearbox.GearboxId);


            foreach (byte id in m.OldTypes.Options)
                if (GetValue<bool>(bc, m.OldTypes.GetHtmlName(id)))
                    m.OldTypes.Selection.Add(id);
            Fill(bc, m.OldTypes.IsAll);

            Fill(bc, m.SeatColors.ColorId);
            Fill(bc, m.SeatCounts.SeatCountId);
            Fill(bc, m.VendorType.VendorTypeId);


            Fill(bc, m.Km.From);
            Fill(bc, m.Km.To);

            Fill(bc, m.Kw.From);
            Fill(bc, m.Kw.To);

            Fill(bc, m.Price.From);
            Fill(bc, m.Price.To);
            Fill(bc, m.Price.ShowWithNoPrice);

            Fill(bc, m.Year1Reg.From);
            Fill(bc, m.Year1Reg.To);

            _BindExtras(bc, m.Extras);

            _BindVariant(bc, m.Variant0);
            _BindVariant(bc, m.Variant1);
            _BindVariant(bc, m.Variant2);

            _BindVehicleType(bc, m.VehicleType);
            return m;

        }

        private void _BindVehicleType(ModelBindingContext bc, VmAutoVehicleType m)
        {
            foreach (byte id in m.Options)
                if (GetValue<bool>(bc, m.GetHtmlName(id)))
                    m.Selection.Add(id);
            Fill(bc, m.IsAll);
        }

        private void _BindVariant(ModelBindingContext bc, VmAutoVariant m)
        {
            Fill(bc, m.MakerId);
            Fill(bc, m.ModelId);
            Fill(bc, m.Variant);
        }

        private void _BindExtras(ModelBindingContext bc, VmAutoFilterExtras m)
        {
            Fill(bc, m.CanExchange);
            Fill(bc, m.Has4x4);
            Fill(bc, m.HasABS);
            Fill(bc, m.HasAirbag);
            Fill(bc, m.HasAluFelt);
            Fill(bc, m.HasAutoKlima);
            Fill(bc, m.HasCentrLock);
            Fill(bc, m.HasElWin);
            Fill(bc, m.HasESP);
            Fill(bc, m.HasGarage);
            Fill(bc, m.HasKlima);
            Fill(bc, m.HasLeather);
            Fill(bc, m.HasNavig);
            Fill(bc, m.HasSeatHeating);
            Fill(bc, m.HasServisBook);
            Fill(bc, m.HasServo);
            Fill(bc, m.HasSunRoof);
            Fill(bc, m.HasTempomat);
            Fill(bc, m.HasTowbar);
            Fill(bc, m.HasXenonL);
            Fill(bc, m.Is1Owner);
        }
    }
}