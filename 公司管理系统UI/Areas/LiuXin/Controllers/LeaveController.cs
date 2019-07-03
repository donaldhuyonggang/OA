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
        [HouTai]
        [HttpPost]
        public ActionResult Index(Leave le) {
            LeaveManager lm = new LeaveManager();
            le.UserId = Convert.ToInt32(Request.Form["UserId"]);
            le.LeaveTime = Convert.ToDateTime(Request.Form["LeaveTime"]);
            le.LeaveOver = "未批准";
            le.Leave_Condition ="可见";
            bool b=lm.Add(le);
            if (b)
            {
                return Redirect("/LiuXin/Leave/Query"); ;
            }
            return Content("失败1");
        }
        public ActionResult Query() {
            LeaveManager lm = new LeaveManager();
            string name = ((User)Session["User"]).UserName;//Session["User"]
            List<Leave> listcount = lm.GetByName(((User)Session["User"]).UserId) ;
            ViewBag.UserCount=listcount.Count();
            UserManager um = new UserManager();
            List<User> Userlist = um.GetAll();
            ViewData["Userlist"] = Userlist;
            return View(listcount);
        }
    }
}
