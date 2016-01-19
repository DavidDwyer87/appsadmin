using System.Web.Mvc;

namespace AppService.Areas.cafeBlue
{
    public class cafeBlueAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "cafeBlue";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "cafeBlue_default",
                "cafeBlue/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
