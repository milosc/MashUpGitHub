using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using System.Web.Routing;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Areas.auto.Models
{
    public class VmAutoVariant:VmAutoModel
    {
        public VmValue<string> Variant { get; private set; }

        public VmAutoVariant(int? no)
            :base(no)
        {
            Variant = new VmValue<string>("var" + NoPostFix);
        }

        internal override void FillQueryString(RouteValueDictionary r)
        {
            if (!string.IsNullOrEmpty(Variant.Val))
                r.Add(Variant.Name, Variant.Val);
            base.FillQueryString(r);
        }

        internal RmAutoFilterVariant GetRequestModelVariant()
        {
            RmAutoFilterVariant r = new RmAutoFilterVariant(this.No);
            
            r.MakerId.Val = MakerId.Val;
            r.ModelId.Val = ModelId.Val;
            r.Variant.Val = Variant.Val;
            return r;
        }
    }
}