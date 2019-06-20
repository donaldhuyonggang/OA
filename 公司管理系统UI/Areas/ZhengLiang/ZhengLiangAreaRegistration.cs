using System.Web.Mvc;

namespace 公司管理系统UI.Areas.ZhengLiang
{
    public class ZhengLiangAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ZhengLiang";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ZhengLiang_default",
                "ZhengLiang/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}