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
    public class VmVehicleVendorType
    {
        public VmValue<byte?> VendorTypeId { get; private set; }
        public VmContext Context {get; private set;}

        private List<SelectListItem> _VendorTypes;
        public List<SelectListItem> VendorTypes
        {
            get
            {
                if (_VendorTypes == null)
                {
                    _VendorTypes = new List<SelectListItem>() { new SelectListItem() { Text = Context.Trans.Translate("filter_PrivateOrDealer", "Private Person or Dealer", "Car attibutes"), Value = string.Empty, Selected = !VendorTypeId.Val.HasValue } };
                    _VendorTypes.AddRange(Sif_VendorTypes.GetCurrent(Context.Lang).GetPairs().Select(row => new SelectListItem()
                    {
                        Text = row.Value,
                        Value = row.Key.ToString(),
                        Selected = (row.Key == VendorTypeId.Val)
                    }));
                }
                return _VendorTypes;
            }
        }
        public VmVehicleVendorType(VmContext context)
        {
            Context = context;
            VendorTypeId = new VmValue<byte?>("vendor");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (VendorTypeId.Val.HasValue)
                r.Add(VendorTypeId.Name, VendorTypeId.Val.Value);
        }
    }
}