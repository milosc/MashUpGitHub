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
    public class VmVehicleColors : VmSelections<byte>
    {

        public VmContext Context {get; private set;}

        private VmColor _AnyColor;
        public VmColor AnyColor 
        {
            get 
            {
                if (_AnyColor == null)
                    _AnyColor = new VmColor(null, Sif_Color.Current(Context.Lang).AnyColor, IsAll.Val);
                return _AnyColor;
            }
        }
        private List<VmColor> _Colors;
        public List<VmColor> Colors
        {
            get
            {
                if (_Colors == null)
                {
                    _Colors = Sif_Color.Current(Context.Lang).Exterior.GetPairs()
                        .Select(row => new VmColor(row.Key, row.Value, Selection.Contains(row.Key)))
                        .ToList();

                }
                return _Colors;
            }
        }
        protected override byte[] GetOptions()
        {
            return Sif_Color.Current(Context.Lang).Exterior.GetPairs()
                .Select(row => row.Key)
                .ToArray();
        }
        public VmVehicleColors(VmContext context)
            : base("c")
        {
            Context = context;

        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (IsAll.Val)
                return;
            r.Add("c", string.Join(",", Selection.Select(row => row.ToString()).ToArray()));
        }

    }
}