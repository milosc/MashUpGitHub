using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class BmColor
    {
        public string Name {get; private set; }
        public string Key { get; private set; }
        public BmColor(string key, string name)
        {
            Key = key;
            Name = name;
        }
    }
}
