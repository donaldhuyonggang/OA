using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.LiuXin.Controllers
{
    

    public class LeaveController : Controller
    {
        // GET: LiuXin/Leave
        [HttpGet]
        public ActionResult Index()
        {
            UserManager um = new UserManager();
            List<User> Userlist = um.GetAll();
            ViewData["Userlist"] = Userlist;
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Leave le) {
            LeaveManager lm = new LeaveManager();
            if (le.LeaveTime < DateTime.Now)
            {
                if (le.LeaveTime <le.LeaveResult)
                {
                    le.UserId = Convert.ToInt32(Request.Form["UserId"]);
                    le.LeaveTime = Convert.ToDateTime(Request.Form["LeaveTime"]);
                    le.LeaveOver = "未批准";
                    le.Leave_Condition = "可见";
                    bool b = lm.Add(le);
                    if (b)
                    {
                        return Redirect("/LiuXin/Leave/Query"); ;
                    }
                    return Content("<script>alert('批准失败');window.location.href='/LiuXin/Leave/Query';</script>");
                }
                else {
                    return Content("<script>alert('请输入合理的返校时间');window.location.href='/LiuXin/Leave/Query';</script>");
                }
            }
            else {
                return Content("<script>alert('请输入合理的请假时间');window.location.href='/LiuXin/Leave/Query';</script>");
            }
        }
        public ActionResult Query() {
            LeaveManager lm = new LeaveManager();
            string name = ((User)Session["User"]).UserName;//Session["User"]
            int UserId = ((User)Session["User"]).UserId;
            List<Leave> listcount = lm.Where(x=> x.UserId==UserId) ;
            ViewBag.UserCount=listcount.Count();
            UserManager um = new UserManager();
            List<User> Userlist = um.GetAll();
            ViewData["Userlist"] = Userlist;
            return View(listcount);
        }
    }
}
