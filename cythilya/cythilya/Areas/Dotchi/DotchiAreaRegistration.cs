using System.Web.Mvc;

namespace cythilya.Areas.Dotchi
{
    public class DotchiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dotchi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dotchi_default",
                "{controller}/{action}/{id}",
                new {  action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
