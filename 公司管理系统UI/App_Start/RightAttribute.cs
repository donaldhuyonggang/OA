using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
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
            else
            {
                if (Users.AdminId == "True")
                {
                    return;
                }

                /*如果不是超级管理员，就获取判断是否有权限访问，*/
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                /*判断要访问的路径，时候跟权限路劲一样*/
                string Url = "/" + controller + "/" + action;
                Sys_UserRoleManager Sy = new Sys_UserRoleManager();
               
                foreach (var item in Users.Sys_Role)
                {
                    foreach (var i in item.Sys_Menu)
                    {
                        if (i.MenuPath== Url) {
                            return;

                        }

                          }
                    }
                }
            filterContext.HttpContext.Response.Redirect("~/Home/Index");
        }
        /*执行后*/
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}