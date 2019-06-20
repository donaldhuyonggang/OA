using System.Web.Mvc;

namespace 公司管理系统UI.Areas.LuoWei
{
    public class LuoWeiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LuoWei";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LuoWei_default",
                "LuoWei/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}