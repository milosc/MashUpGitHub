using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using Bizis.Site.Car.Common.Model.Sif;
using System.Web.Routing;

namespace Bizis.Site.Car.Models
{
    public class VmVehicleSeatColors
    {
        public VmValue<byte?> ColorId { get; private set; }
        public VmContext Context {get; private set;}

        private List<VmColor> _Colors;
        public List<VmColor> Colors
        {
            get
            {
                if (_Colors == null)
                {
                    Sif_Color sif = Sif_Color.Current(Context.Lang);
 
                    _Colors = new List<VmColor>() { new VmColor(null, sif.AnyColor, !ColorId.Val.HasValue) };
                    _Colors.AddRange(Sif_Color.Current(Context.Lang).Seats.GetPairs()
                        .Select(row => new VmColor(row.Key, row.Value, row.Key == ColorId.Val))
                        );
                }
                return _Colors;
            }
        }
        public VmVehicleSeatColors(VmContext context)
        {
            Context = context;
            ColorId = new VmValue<byte?>("seat_col");
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (ColorId.Val.HasValue)
                r.Add(ColorId.Name, ColorId.Val.Value);
        }
    }
}