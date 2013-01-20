using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using Bizis.Site.Car.Classes;

namespace Bizis.Site.Car.Models
{
    public class VmHome
    {
        public VmContext Context { get; private set; }
        public VmHome()
        {
            Context = CarSession.Current.Vm;
        }
    }
}