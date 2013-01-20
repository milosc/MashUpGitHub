using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Car.Classes
{
    public class CarSession
    {
        private const string _Session_Slot="CarSlot";
        public static CarSession Current
        {
            get 
            {
                HttpContext contex = HttpContext.Current;
                CarSession s = contex.Session[_Session_Slot] as CarSession;
                if(s==null)
                    contex.Session[_Session_Slot]  = s = new CarSession(contex);
                return s;
            }
        }


        public VmContext Vm {get; private set;}
        public CarSession(HttpContext contex)
        {
            Vm= new VmContext("en"); //TODO lang
        }
    }
}