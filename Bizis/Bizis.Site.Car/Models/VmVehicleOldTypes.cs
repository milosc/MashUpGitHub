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
    public class VmVehicleOldType
    {
        public byte Id {get; private set;}
        public string Name {get; private set;}
        public bool IsSelected { get; private set; }

        public VmVehicleOldType(byte id, string name, bool isSelected)
        {
            Id = id;
            Name = name;
            IsSelected = isSelected;
        }
    }
    public class VmVehicleOldTypes : VmSelections<byte>
    {

        public VmContext Context { get; private set; }

        private List<VmVehicleOldType> _OldTypes;
        public List<VmVehicleOldType> OldTypes
        {
            get
            {
                if (_OldTypes == null)
                {
                    _OldTypes = Sif_AutoOldType.Current(Context.Lang).Filter.GetPairs()
                        .Select(row => new VmVehicleOldType(row.Key, row.Value, Selection.Contains(row.Key)))
                        .ToList();
                }
                return _OldTypes;
            }
        }
        protected override byte[] GetOptions()
        {
            return Sif_AutoOldType.Current(Context.Lang).Filter.GetPairs()
                .Select(row => row.Key)
                .ToArray();
        }
        public VmVehicleOldTypes(VmContext context)
            :base("ot")
        {
            Context = context;
        }

        internal void FillQueryString(RouteValueDictionary r)
        {
            if (IsAll.Val)
                return;
            r.Add("ot", string.Join(",", Selection.Select(row => row.ToString()).ToArray()));
        }
    }
}