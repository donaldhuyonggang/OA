using System.Web.Mvc;

namespace 公司管理系统UI.Areas.LiuYi
{
    public class LiuYiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LiuYi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LiuYi_default",
                "LiuYi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}