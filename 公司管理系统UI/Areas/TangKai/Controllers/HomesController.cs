using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.TangKai.Controllers
{
    public class HomesController : Controller
    {
        [Right]
        // GET: TangKai/Homes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Back()
        {
            UserManager bll = new UserManager();
            DateTime now = DateTime.Now;
            DateTime dt = Convert.ToDateTime(now.ToShortDateString());
            List<User> info = bll.GetAll();
            ViewBag.Use = info.Count();
            List<User> info1 = bll.Where(x => x.User_Condition == "在职");
            ViewBag.Use1 = info1.Count();
            List<User> info2 = bll.Where(x => x.User_Condition == "离职");
            ViewBag.Use2 = info2.Count();
            ClassManager blll = new ClassManager();
            List<_class> cla = blll.Where(x => x.DataTime == dt);
            ViewBag.Use3 = cla;
            ActionManager a = new ActionManager();
            List<action> detail = a.GetAll();
            var list = detail.OrderByDescending(x => x.actiontime).Take(5).ToList();
            ViewBag.Use5 = list;
            WebManager web = new WebManager();
            List<web> detail1 = web.GetAll();
            var list1 = detail1.OrderByDescending(x => x.like).Take(5).ToList();
            ViewBag.Use4 = list1;
            return View();
        }
        public ActionResult Ajax()
        {
            UserManager bll = new UserManager();
            var list = bll.GetAll();
            var list1 = list.Select(x => new
            {
                x.UserName,
                x.Sex,
                x.Phone,
                x.Email
            }).ToList();
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
    }
}