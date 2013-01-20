using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Common.Model
{
    public class RmBase
    {
        public int? No { get; private set; }
        public RmBase()
        {
        }
        public RmBase(int? no)
        {
            No = no;
        }
    }
}
