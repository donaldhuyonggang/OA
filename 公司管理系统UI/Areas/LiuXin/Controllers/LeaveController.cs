using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

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
            le.UserId = Convert.ToInt32(Request.Form["UserId"]);
            le.LeaveTime = Convert.ToDateTime(Request.Form["LeaveTime"]);
            le.LeaveOver = "未批准";
            le.Leave_Condition ="可见";
            bool b=lm.Add(le);
            if (b)
            {
                return Redirect("/LiuXin/Leave/Index"); ;
            }
            return Content("失败le");
        }
    
    }
}
