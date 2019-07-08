using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
namespace 公司管理系统UI.Areas.LiaoWeiYing.Controllers
{
    public class BackController : Controller
    {
        // GET: LiaoWeiYing/Back
        //public ActionResult Back(int pageIndex = 1) {
        //    int pageHang = 5;
        //    WebManager dal = new WebManager();
        //    List<web> list = dal.GetAll();
        //    var list1 = list.OrderBy(x => x.webtime).Skip((pageIndex - 1) * pageHang).Take(pageHang).ToList();
        //    ViewBag.pageIndex = pageIndex;
        //    return View(list1);
        //}
        public ActionResult Bacck(int pageIndex = 1)
        {
            int pageHang = 1;
            WebManager dal = new WebManager();
            List<web> list = dal.Where(x=> x.web_Condition == "可见");
            var list1 = list.OrderByDescending(x => x.webtime).Skip((pageIndex - 1) * pageHang).Take(pageHang).ToList();
            ViewBag.pageIndex = pageIndex;
            return View(list1);
        }
        public ActionResult AJ(int webId = 33)
        {
            ReplayManager dal4 = new ReplayManager();
            var list5 = dal4.Where(x => x.webId == webId && x.Replay_Condition == "可见").Select(x => new { x.webId, x.ReplayTime, x.User.UserName, x.ReplayResult, x.ReplayId }).ToList();
            return Json(list5, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int webId=0, int UserId=0)
        {
            WebManager list1 = new WebManager();
                web sdd = new web()
                {
                    webId = webId,
                    web_Condition = "不可见"
                };
                bool list2 = list1.Update1(sdd);
                if (list2)
                {
                    return Redirect("/LiaoWeiYing/Back/Bacck");
                }
                else
                {
                    return Content("失败");
                }
        }
        public ActionResult Delete1(int ReplayId = 0)
        {
            ReplayManager list1 = new ReplayManager();
            Replay sdd = new Replay()
            {
                ReplayId = ReplayId,
                Replay_Condition = "不可见"
            };
            bool list2 = list1.Update(sdd);
            if (list2)
            {
                return Redirect("/LiaoWeiYing/Back/Bacck");
            }
            else
            {
                return Content("失败");
            }
        }
    }
}