using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.TangKai.Controllers
{
    public class LoginController : Controller
    {
        // GET: TangKai/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string name , string pwd)
        {
            UserManager bll = new UserManager();
            User info = bll.Where(x => x.UserName == name && x.UserPwd == pwd).FirstOrDefault();
            if (info!=null)
            {
                Session["Users"] = info.UserName;
                Session["User"] = info;
                return Redirect("/TangKai/Homes/Index");
            }
            else
            {
                return Content("登陆失败！");
            }
        }
        
        public ActionResult Bck()
        {
            return View();
        }
        
        public ActionResult Back(string name , string pwd)
        {
            UserManager bll = new UserManager();
            User info = bll.Where(x => x.UserName == name && x.UserPwd == pwd).FirstOrDefault();
            if (info != null)
            {
                Session["UsHt"] = info;
                return Redirect("/LuoWei/Personnel/Person");
            }
            else
            {
                return Content("登陆失败！");
            }
        }
    }
}