using System.Web.Mvc;

namespace 公司管理系统.Areas.刘欣
{
    public class 刘欣AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "刘欣";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "刘欣_default",
                "刘欣/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}