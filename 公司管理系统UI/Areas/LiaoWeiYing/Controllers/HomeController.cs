using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
namespace 公司管理系统UI.Areas.LiaoWeiYing.Controllers
{
    public class HomeController : Controller
    {
        // GET: LiaoWeiYing/Home
        public ActionResult Index(int pageIndex = 1,int userID = 0 , int id=1)
        {
            //var idd=Session["name"] as User;
            userID = ((User)(Session["User"])).UserId;
            WebManager dal1 = new WebManager();
            List<web> list1 = dal1.Where(x => x.web_typeID == id && x.web_Condition=="可见").OrderByDescending(x => x.webtime).ToList();

            web_typeManager dal2 = new web_typeManager();
            List<web_type> list2 = dal2.GetAll();
            ViewBag.list2 = list2;


            UserManager dal3 = new UserManager();
            List<User> list3 = dal3.Where(x => x.UserId == userID);
            ViewBag.list3 = list3;

            

            ReplayTypeManager dal5 = new ReplayTypeManager();
            List<ReplayType> list6 = dal5.GetAll();
            ViewBag.ReplayTypeID = new SelectList(list6, "ReplayTypeID", "ReplayTypeName");


            int pageSize = 3;
            var list4= list1.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
            ViewBag.pageIndex = pageIndex;

            return View(list4);
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
                return Redirect("/LiaoWeiYing/Home/Index");
            }
            else
            {
                return Content("失败");
            }
        }
        public ActionResult As() {
            UserManager dal = new UserManager();
            List<User> list = dal.GetAll();
            ViewBag.UserId = new SelectList(list, "UserId", "UserName");

            web_typeManager list1 = new web_typeManager();
            List<web_type> dal1 = list1.GetAll();
            ViewBag.web_typeID = new SelectList(dal1, "web_typeID", "web_typeName");

            ReplayTypeManager dal2 = new ReplayTypeManager();
            List<ReplayType> list2 = dal2.GetAll();
            ViewBag.ReplayTypeID = new SelectList(list2, "ReplayTypeID", "ReplayTypeName");
            return PartialView();
        }
            

        public ActionResult AJ(int webId = 33) {
            ReplayManager dal4 = new ReplayManager();
            var list5 = dal4.Where(x => x.webId == webId).Select(x=>new {x.webId, x.ReplayTime,x.User.UserName,x.ReplayResult,x.ReplayId,x.User.Userimg }).ToList();
            return Json(list5, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(web info) {
            WebManager list1 = new WebManager();
            int userID = ((User)(Session["User"])).UserId;
            DateTime ss = System.DateTime.Now;
            //webId, UserId, web_typeID, webHead, webResult, webtime, like, ReplayTypeID, web_Condition
            web ds = new web() {
                UserId = userID,
                web_typeID=info.web_typeID,
                webHead=info.webHead,
                webResult=info.webResult,
                webtime=ss,
                like=0,
                ReplayTypeID=info.ReplayTypeID,
                web_Condition=info.web_Condition
            };
            bool list = list1.Add(ds);
            if (list)
            {
                return Redirect("/LiaoWeiYing/Home/Index");
            }
            else
            {
                return Content("发布失败");
            }
        }
        public ActionResult Delete(int webId,int UserId, int userID = 3)
        {
            if (UserId != userID)
            {
                return Content("对不起您不能删除别人的评论");
            }
            else
            {
                WebManager list1 = new WebManager();
                    web sdd = new web() {
                        webId =webId,
                        web_Condition="不可见"
                    };
                    bool list2 = list1.Update1(sdd);
                    if (list2)
                    {
                        return Redirect("/LiaoWeiYing/Home/Index");
                    }
                    else
                    {
                    return Content("失败");
                     }
            }
        }
        public ActionResult Plun(int webId) {
            int userID = ((User)(Session["User"])).UserId;
            ReplayManager dal2 = new ReplayManager();
            DateTime ss = System.DateTime.Now;
            Replay re = new Replay() {
                 UserId= userID,
                 ReplayResult=Request.Form["ReplayResult"],
                 ReplayTime=ss,
                 webId= webId,
                 Replay_Condition="可见"
            };
            bool restul = dal2.Add(re);
            if (restul)
            {
                return Redirect("/LiaoWeiYing/Home/Index");
            }
            else
            {
                return Content("失败");
            }
        }
        public ActionResult Zan(int webId,int like)
        {
            WebManager dal = new WebManager();
            WebManager dal1 = new WebManager();
            List<web> list = dal.Where(x => x.webId == webId);
            if (list!=null)
            {
                web lis = new web()
                {
                    webId=webId,
                    like = like + 1
                };
                bool list1 = dal1.Update(lis);
                if (list1)
                {
                    return Redirect("/LiaoWeiYing/Home/Index");
                }
                else
                {
                    return Content("ss");
                 }
            }
            return Content("ss");
        }
    }
}