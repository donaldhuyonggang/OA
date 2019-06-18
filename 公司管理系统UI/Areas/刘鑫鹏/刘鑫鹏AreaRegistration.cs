using System.Web.Mvc;

namespace 公司管理系统.Areas.刘鑫鹏
{
    public class 刘鑫鹏AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "刘鑫鹏";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "刘鑫鹏_default",
                "刘鑫鹏/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}