using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统Model;

namespace 公司管理系统UI.App_Start
{
    public class RightAttribute : FilterAttribute, IActionFilter
    {
        /*执行前*/
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            User Users= filterContext.HttpContext.Session["User"] as User;
            if (Users==null) {


            }
        }
        /*执行后*/
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}