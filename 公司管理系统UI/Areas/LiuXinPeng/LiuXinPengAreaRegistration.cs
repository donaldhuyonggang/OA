using System.Web.Mvc;

namespace 公司管理系统UI.Areas.LiuXinPeng
{
    public class LiuXinPengAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LiuXinPeng";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LiuXinPeng_default",
                "LiuXinPeng/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}