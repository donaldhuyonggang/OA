using System.Web.Mvc;

namespace 公司管理系统.Areas.唐凯
{
    public class 唐凯AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "唐凯";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "唐凯_default",
                "唐凯/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}