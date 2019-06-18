using System.Web.Mvc;

namespace 公司管理系统.Areas.郑亮
{
    public class 郑亮AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "郑亮";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "郑亮_default",
                "郑亮/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}