using System.Web.Mvc;

namespace cythilya.Areas.EShopper
{
    public class EShopperAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EShopper";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EShopper_default",
                "EShopper/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
