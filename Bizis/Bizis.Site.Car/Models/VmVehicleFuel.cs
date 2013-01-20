using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using Bizis.Site.Car.Common.Model.Sif;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleFuel
    {
        public VmValue<byte?> FuelId { get; private set; }
        public VmContext Context {get; private set;}

        private List<SelectListItem> _Fuel;
        public List<SelectListItem> Fuel
        {
            get
            {
                if (_Fuel == null)
                {
                    _Fuel = new List<SelectListItem>() { new SelectListItem() { Text = Context.Trans.Translate("filter_any", "Any", "Car attibutes"), Value = string.Empty, Selected = !FuelId.Val.HasValue } };
                    _Fuel.AddRange(Sif_AutoFuel.GetCurrent(Context.Lang).GetPairs().Select(row => new SelectListItem()
                    {
                        Text = row.Value,
                        Value = row.Key.ToString(),
                        Selected = (row.Key == FuelId.Val)
                    }));
                }
                return _Fuel;
            }
        }
        public VmVehicleFuel(VmContext context)
        {
            Context = context;
            FuelId = new VmValue<byte?>("fuel");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (FuelId.Val.HasValue)
                r.Add(FuelId.Name, FuelId.Val.Value);
        }
    }
}