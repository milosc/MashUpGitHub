using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Model;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleYear
    {
        public VmValue<short?> From { get; private set; }
        public VmValue<short?> To { get; private set; }

        private List<short> __Years;
        private List<short> _Years
        {
            get 
            {
                if (__Years == null)
                {
                    short yearNow = (short)DateTime.Now.Year;
                    __Years = new List<short>(yearNow - 1990 + 10);
                    for (short year = yearNow; year >= 1960; year -= (year > 1990 ? (short)1 : (short)5))
                        __Years.Add(year);
                }
                return __Years;
            }
        }

        private List<SelectListItem> _Froms;
        public List<SelectListItem> Froms
        {
            get
            {
                if (_Froms == null)
                {
                    _Froms = new List<SelectListItem>() { new SelectListItem() { Text = "- min -", Value = string.Empty, Selected = !From.Val.HasValue } };
                    _Froms.AddRange(_Years.Select(row => new SelectListItem()
                    {
                        Text = row.ToString(),
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
                    _Tos.AddRange(_Years.Select(row => new SelectListItem()
                    {
                        Text = row.ToString(),
                        Value = row.ToString(),
                        Selected = (row == To.Val)
                    }));
                }
                return _Tos;
            }
        }

        public VmVehicleYear(string htmlNamePrefix)
        {
            From = new VmValue<short?>(htmlNamePrefix+"_min");
            To = new VmValue<short?>(htmlNamePrefix +"_max");
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