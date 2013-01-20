using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleDamage
    {
        public VmValue<bool?> IsDamaged { get; private set; }
        public VmContext Context { get; private set; }

        private List<SelectListItem> _Damages;
        public List<SelectListItem> Damages
        {
            get
            {
                if (_Damages == null)
                    _Damages = new List<SelectListItem>() 
                    { 
                        new SelectListItem() { Text = Context.Trans.Translate("filter_show", "show", "Car attibutes"), Value = string.Empty, Selected = !IsDamaged.Val.HasValue },
                        new SelectListItem() { Text = Context.Trans.Translate("filter_dontshow", "don't show", "Car attibutes"), Value = "false", Selected = IsDamaged.Val==false},
                        new SelectListItem() { Text = Context.Trans.Translate("filter_showonly", "show only", "Car attibutes"), Value = "true", Selected = IsDamaged.Val == true},
                    };
                return _Damages;
            }
        }
        public VmVehicleDamage(VmContext context)
        {
            Context = context;
            IsDamaged = new VmValue<bool?>("isdamage");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (IsDamaged.Val.HasValue)
                r.Add(IsDamaged.Name, IsDamaged.Val.Value);
        }
    }
}