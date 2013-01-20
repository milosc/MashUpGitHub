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
    public class VmVehicleSeatCount
    {

        public VmValue<short?> SeatCountId { get; private set; }
        public VmContext Context { get; private set; }

        private List<SelectListItem> _Seats;
        public List<SelectListItem> Seats
        {
            get
            {
                if (_Seats == null)
                {
                    _Seats = new List<SelectListItem>() { new SelectListItem() { Text = Context.Trans.Translate("filter_any", "Any", "Car attibutes"), Value = string.Empty, Selected = !SeatCountId.Val.HasValue } };
                    _Seats.AddRange(Sif_AutoSeatCounts.Current(Context.Lang).Filter.GetPairs().Select(row => new SelectListItem()
                    {
                        Text = row.Value,
                        Value = row.Key.ToString(),
                        Selected = (row.Key == SeatCountId.Val)
                    }));
                }
                return _Seats;
            }
        }
        public VmVehicleSeatCount(VmContext context)
        {
            Context = context;
            SeatCountId = new VmValue<short?>("seat_count");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (SeatCountId.Val.HasValue)
                r.Add(SeatCountId.Name, SeatCountId.Val.Value);
        }
    }
}