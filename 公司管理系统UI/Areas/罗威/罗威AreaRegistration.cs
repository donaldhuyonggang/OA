using System.Web.Mvc;

namespace 公司管理系统.Areas.罗威
{
    public class 罗威AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "罗威";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "罗威_default",
                "罗威/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}