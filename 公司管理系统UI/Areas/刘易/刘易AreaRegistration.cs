using System.Web.Mvc;

namespace 公司管理系统.Areas.刘易
{
    public class 刘易AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "刘易";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "刘易_default",
                "刘易/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}