using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Car.Areas.auto.Models;
using Bizis.Site.Car.Areas.auto.Binder;
using System.Web.Routing;
using Bizis.Site.Car.Common.Manager;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Areas.auto.Controllers
{
    public class homeController : Controller
    {

        private AutoBL __BL;
        private AutoBL _BL
        {
            get 
            {
                if (__BL == null)
                    __BL = new AutoBL();
                return __BL;
            }
        }

        public ActionResult index()
        { 
            return View(new VmAuto());
        }

        [HttpPost]
        public ActionResult index([ModelBinder(typeof(AutoBinder))] VmAuto s)
        {
            RouteValueDictionary r = new RouteValueDictionary() { { "area", "auto" } };
            s.FillQueryString(r);
            return RedirectToAction("search", "home", r);  
            
            //return View(s);
        }

        public ActionResult search([ModelBinder(typeof(AutoSearchBinder))] VmAuto s, int? page)
        {
            RmAutoFilterSearch req= s.GetRequestModel();
            RmAutoSearchList list = _BL.GetSearchList(page ?? 0, req);
            //_BL
            return View(s);
        }
       
    }
}
