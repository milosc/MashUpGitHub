using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class BmVehicleType
    {
        public string Name {get; private set; }
        public string Key { get; private set; }
        public byte Id { get; private set; }
        public BmVehicleType(byte id, string key, string name)
        {
            Id = id;
            Key = key;
            Name = name;
        }
    }
}
