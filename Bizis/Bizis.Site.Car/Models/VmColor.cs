using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Models
{
    public class VmColor
    {
        public byte? ColorId {get; private set;}
        public BmColor Color { get; private set; }
        public bool Selected { get; set; }

        public VmColor(byte? colorId, BmColor color)
            : this(colorId, color, false)
        {
        }
        public VmColor(byte? colorId, BmColor color, bool selected)
        {
            ColorId = colorId;
            Color = color;
            Selected = selected;
        }
    }
}