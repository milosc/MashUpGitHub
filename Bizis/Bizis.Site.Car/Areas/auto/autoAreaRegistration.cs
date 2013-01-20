using System.Web.Mvc;

namespace Bizis.Site.Car.Areas.auto
{
    public class autoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "auto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "auto_default_home",
                "auto/{action}/{id}",
                new { action = "index", controller = "home", id = UrlParameter.Optional },
                new[] { "Bizis.Site.Car.Areas.auto.Controllers" }
            );
            context.MapRoute(
                "auto_default",
                "auto/{controller}/{action}/{id}",
                new { action = "index", controller = "home", id = UrlParameter.Optional },
                new[] { "Bizis.Site.Car.Areas.auto.Controllers" } 
            );

        }
    }
}
