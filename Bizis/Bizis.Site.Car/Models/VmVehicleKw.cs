using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Model;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    
    public class VmVehicleKw
    {
        private const double _kW2HP=1.34102209;

        public VmContext Context { get; private set; }
        public VmValue<int?> From { get; private set; }
        public VmValue<int?> To { get; private set; }

        private int[] __KWs;
        private int[] _KWs
        {
            get
            {
                if (__KWs == null)
                    __KWs = new int[] { 25, 37, 44, 55, 66, 74, 87, 96, 110, 147, 185, 223, 263, 296, 334 };
                return __KWs;
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
                    _Froms.AddRange(_KWs.Select(row => new SelectListItem()
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
                    _Tos.AddRange(_KWs.Select(row => new SelectListItem()
                    {
                        Text = _GetText(row),
                        Value = row.ToString(),
                        Selected = (row == To.Val)
                    }));
                }
                return _Tos;
            }
        }
        private string __PS_Local;
        private string _PS_Local
        {
            get 
            {
                if (__PS_Local == null)
                    __PS_Local = Context.Trans.Translate("car_HorsePow", "Hp", "Car attibutes");
                return __PS_Local;
            }
        }
        public VmVehicleKw(VmContext context)
        {
            Context = context;
            From = new VmValue<int?>("kw_min");
            To = new VmValue<int?>("kw_max");
        }
        private string _GetText(int row)
        {
            return row.ToString() + " Kw (" + Convert.ToInt32(row * _kW2HP) + " " + _PS_Local + ")"; //TODO translate
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