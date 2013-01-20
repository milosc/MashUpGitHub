using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using Bizis.Site.Car.Common.Model.Sif;
using Bizis.Site.Car.Models;
using System.Web.Routing;

namespace Bizis.Site.Car.Areas.auto.Models
{
    public class VmAutoVehicleType: VmSelections<byte>
    {
        public const string HtmlName ="t"; 
        public VmContext Context {get; private set;}

        private List<VmVehicleType> _Types;
        public List<VmVehicleType> Types
        {
            get
            {
                if (_Types == null)
                {
                    _Types = Sif_VehicleType.Current(Context.Lang).Auto.GetPairs()
                        .Select(row => new VmVehicleType(row.Value, Selection.Contains(row.Key)))
                        .ToList();
                }
                return _Types;
            }
        }
        protected override byte[] GetOptions()
        {
            return Sif_VehicleType.Current(Context.Lang).Auto.GetPairs()
                .Select(row => row.Key)
                .ToArray();
        }

        public VmAutoVehicleType(VmContext context)
            : base(HtmlName)
        {
            Context = context;
            IsAll.Val = true;
        }




        internal void FillQueryString(RouteValueDictionary r)
        {
            if (IsAll.Val)
                return;
            r.Add(HtmlName, string.Join(",", Selection.Select(row => row.ToString()).ToArray()));

        }
    }
}