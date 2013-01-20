using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Common.Model;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleAdPublished
    {
        public DateTime? PublishedFromUtcDate 
        {
            get
            {
                if (!DaysFromNow.Val.HasValue)
                    return null;
                return DateTime.UtcNow.AddDays(-DaysFromNow.Val.Value);
            }
        }
        public VmValue<int?> DaysFromNow {get; private set;}
        public VmContext Context { get; private set; }

        private List<SelectListItem> _When;
        public List<SelectListItem> When
        {
            get
            {
                if (_When == null)
                    _When = new List<SelectListItem>() 
                    { 
                        new SelectListItem() { Text = Context.Trans.Translate("filter_anytime", "any time", "Car attibutes"), Value = string.Empty, Selected = !DaysFromNow.Val.HasValue },
                        new SelectListItem() { Text = Context.Trans.Translate("filter_since1day", "1 day", "Car attibutes"), Value = "1", Selected = (DaysFromNow.Val==1) },
                        new SelectListItem() { Text = Context.Trans.Translate("filter_since2days", "2 days", "Car attibutes"), Value = "2", Selected = (DaysFromNow.Val==2)},
                        new SelectListItem() { Text = Context.Trans.Translate("filter_since3days", "3 days", "Car attibutes"), Value = "3", Selected = (DaysFromNow.Val==3)},
                        new SelectListItem() { Text = Context.Trans.Translate("filter_sinceLastWeak", "last week", "Car attibutes"), Value = "7", Selected = (DaysFromNow.Val==7)},
                    };
                return _When;
            }
        }
        public VmVehicleAdPublished(VmContext context)
        {
            Context = context;
            DaysFromNow = new VmValue<int?>("pub_days");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (DaysFromNow.Val.HasValue)
                r.Add(DaysFromNow.Name, DaysFromNow.Val.Value);
        }

        
    }
}