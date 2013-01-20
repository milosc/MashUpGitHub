using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Common.Model
{
    public class VmValue<T>
    {
        public T Val { get; set; }
        public string Name { get; private set; }
        public VmValue(string name)
        {
            Name = name;
        }
    }
}
