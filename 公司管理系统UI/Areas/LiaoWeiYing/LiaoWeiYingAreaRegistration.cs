using System.Web.Mvc;

namespace 公司管理系统UI.Areas.LiaoWeiYing
{
    public class LiaoWeiYingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LiaoWeiYing";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LiaoWeiYing_default",
                "LiaoWeiYing/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}