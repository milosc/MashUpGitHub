using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Model;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleKm
    {
        public VmValue<int?> From { get; private set; }
        public VmValue<int?> To { get; private set; }
        public string Unit { get; private set; } //Km, miles

        private int[] __Kms;
        private int[] _Kms
        {
            get
            {
                if (__Kms == null)
                    __Kms = new int[] { 5000, 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000, 90000, 100000, 125000, 150000 };
                return __Kms;
            }
        }

        private List<SelectListItem> _Froms;
        public List<SelectListItem> Froms
        {
            get
            {
                if (_Froms == null)
                {
                    _Froms = new List<SelectListItem>() { new SelectListItem() { Text = "0", Value = string.Empty, Selected = !From.Val.HasValue } };
                    _Froms.AddRange(_Kms.Select(row => new SelectListItem()
                    {
                        Text = _GetText(row),
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
                    _Tos.AddRange(_Kms.Select(row => new SelectListItem()
                    {
                        Text = _GetText(row),
                        Value = row.ToString(),
                        Selected = (row == To.Val)
                    }));
                    _Tos.Add(new SelectListItem() { Text = _GetText(200000), Value = "200000", Selected = (To.Val == 200000) });
                }
                return _Tos;
            }
        }

        public VmVehicleKm(string unit)
        {
            From = new VmValue<int?>("km_min");
            To = new VmValue<int?>("km_max");
            Unit = unit;
        }
        private string _GetText(int row)
        {
            return row.ToString("#,###") + " " + Unit;
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