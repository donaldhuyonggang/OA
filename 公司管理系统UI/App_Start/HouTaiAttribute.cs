using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.App_Start
{
    public class HouTaiAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UserManager user = new UserManager();
            User Users = filterContext.HttpContext.Session["UsHt"] as User;
            /*User Users= */
            ;
            if (Users == null)
            {
                filterContext.HttpContext.Response.Redirect("~/TangKai/Login/Bck");
            }
            else
            {
                if (Users.AdminId == "true")
                {
                    return;
                }
                else
                {
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
                            if (i.MenuPath == Url)
                            {
                                return;
                            }
                        }
                    }
                     filterContext.HttpContext.Response.Redirect("~/LuoWei/Personnel/Person");
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            return;
        }
    }
}