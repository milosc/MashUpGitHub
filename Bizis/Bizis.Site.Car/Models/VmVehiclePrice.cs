using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Model;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehiclePrice
    {
        public VmValue<bool> ShowWithNoPrice { get; private set; }
        public VmValue<int?> From { get; private set; }
        public VmValue<int?> To { get; private set; }
        public string Currency { get; private set; }

        private List<SelectListItem> _Froms;
        public List<SelectListItem> Froms
        {
            get 
            {
                if (_Froms == null)
                {
                    _Froms = new List<SelectListItem>() { new SelectListItem() { Text = "- min -", Value = string.Empty, Selected = !From.Val.HasValue } };
                   var froms= new int[] { 500, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000,
                        10000, 11000,12000,13000,14000,15000,17500, 20000, 22500, 25000, 27500, 30000, 35000, 40000, 50000, 55000 };
                   _Froms.AddRange(froms.Select(row => new SelectListItem()
                   {
                       Text = _GetPriceText(row),
                       Value = row.ToString(),
                       Selected = (row == From.Val)
                   }));
                }
                return _Froms;
            }
        }
        private List<SelectListItem> _Tos;
        public List<SelectListItem> Tos
        {
            get
            {
                if (_Tos == null)
                {
                    _Tos = new List<SelectListItem>() { new SelectListItem() { Text = "- max -", Value = string.Empty, Selected = !To.Val.HasValue } };
                    var tos = new int[] { 501, 1001, 2001, 3001, 4001, 5001, 6001, 7001, 8001, 9001,
                        10001, 11001,12001,13001,14001,15001,17501, 20001, 22501, 25001, 27501, 30001, 35001, 40001, 50001, 55001, 60001};
                    _Tos.AddRange(tos.Select(row => new SelectListItem()
                    {
                        Text = _GetPriceText(row),
                        Value = row.ToString(),
                        Selected = (row == To.Val)
                    }));
                }
                return _Tos;
            }
        }


        public VmVehiclePrice(string currency)
        {
            Currency = currency;
            From = new VmValue<int?>("p_min");
            To = new VmValue<int?>("p_max");
            ShowWithNoPrice = new VmValue<bool>("p_no");
            ShowWithNoPrice.Val = true;

        }
        private string _GetPriceText(int row)
        {
            return row.ToString("#,###") + " " + Currency;
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (From.Val.HasValue)
                r.Add(From.Name, From.Val.Value);
            if (To.Val.HasValue)
                r.Add(To.Name, To.Val.Value);
        }
    }
}