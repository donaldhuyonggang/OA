using System.Web.Mvc;

namespace 公司管理系统.Areas.廖蔚莹
{
    public class 廖蔚莹AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "廖蔚莹";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "廖蔚莹_default",
                "廖蔚莹/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}