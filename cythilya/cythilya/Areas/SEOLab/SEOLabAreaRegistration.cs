using System.Web.Mvc;

namespace cythilya.Areas.SEOLab
{
    public class SEOLabAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SEOLab";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SEOLab_default",
                "SEOLab/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
