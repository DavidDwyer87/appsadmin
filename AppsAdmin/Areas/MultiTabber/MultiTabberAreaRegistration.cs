using System.Web.Mvc;

namespace AppService.Areas.MultiTabber
{
    public class MultiTabberAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MultiTabber";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MultiTabber_default",
                "MultiTabber/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
