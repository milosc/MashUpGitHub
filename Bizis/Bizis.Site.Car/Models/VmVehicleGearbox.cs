using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using System.Web.Mvc;
using Bizis.Site.Car.Common.Model.Sif;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleGearbox
    {
        public VmValue<byte?> GearboxId { get; private set; }

        public VmContext Context { get; private set; }

        private List<SelectListItem> _Gearboxes;
        public List<SelectListItem> Gearboxes
        {
            get
            {
                if (_Gearboxes == null)
                {
                    _Gearboxes = new List<SelectListItem>() { new SelectListItem() { Text = Context.Trans.Translate("filter_any", "Any", "Car attibutes"), Value = string.Empty, Selected = !GearboxId.Val.HasValue } };
                    _Gearboxes.AddRange(Sif_AutoGearbox.Current(Context.Lang).Filter.GetPairs().Select(row => new SelectListItem()
                    {
                        Text = row.Value,
                        Value = row.Key.ToString(),
                        Selected = (row.Key == GearboxId.Val)
                    }));
                }
                return _Gearboxes;
            }
        }
        public VmVehicleGearbox(VmContext context)
        {
            Context = context;
            GearboxId = new VmValue<byte?>("gearbox");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (GearboxId.Val.HasValue)
                r.Add(GearboxId.Name, GearboxId.Val.Value);
        }
    }
}