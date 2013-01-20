using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Model;
using Bizis.Site.Car.Common.Model.Sif;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleDoors
    {
        public VmValue<short?> DoorsId { get; private set; }
        public VmContext Context { get; private set; }

        private List<SelectListItem> _Doors;
        public List<SelectListItem> Doors
        {
            get
            {
                if (_Doors == null)
                {
                    _Doors = new List<SelectListItem>() { new SelectListItem() { Text = Context.Trans.Translate("filter_any", "Any", "Car attibutes"), Value = string.Empty, Selected = !DoorsId.Val.HasValue } };
                    _Doors.AddRange(Sif_AutoDoors.Current.Filter.GetPairs().Select(row => new SelectListItem()
                    {
                        Text = row.Value,
                        Value = row.Key.ToString(),
                        Selected = (row.Key == DoorsId.Val)
                    }));
                }
                return _Doors;
            }
        }
        public VmVehicleDoors(VmContext context)
        {
            DoorsId = new VmValue<short?>("doors");
            Context = context;
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (DoorsId.Val.HasValue)
                r.Add(DoorsId.Name, DoorsId.Val.Value);
        }
    }
}