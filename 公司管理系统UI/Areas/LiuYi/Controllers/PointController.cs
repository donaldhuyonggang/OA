using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.LiuYi.Controllers
{
    //[Right]
    public class PointController : Controller
    {
        /// <summary>
        /// 后台分数主页面
        /// </summary>
        /// <returns></returns>
        // GET: LiuYi/Point
        public ActionResult Index(int pageIndex=1)
        {
            int pageSize = 2;
            ScoreManager bll = new ScoreManager();
            List<score> list = bll.Where(x=>x.score_Condition=="可见");
            var list1 = list.OrderBy(x=>x.PointId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.pageIndex = pageIndex;
            return View(list1);
        }
        /// <summary>
        /// 修改扣分记录为不可见
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult update(int id,DateTime PointTime,int UserId,int systemId)
        {
            ScoreManager bll = new ScoreManager();
            score se = new score()
            {
                PointId=id,
                PointTime=PointTime,
                UserId=UserId,
                systemId=systemId,
                score_Condition="不可见"
            };
            var info = bll.Update(se);
            if (info)
            {
                return Redirect("/LiuYi/Point/Index");
            }
            else
            {
                return Redirect("/LiuYi/Point/Index");
            }
        }
        /// <summary>
        /// 扣分记录查询
        /// </summary>
        /// <returns></returns>
        public ActionResult select()
        {
            ScoreManager bll = new ScoreManager();
            List<score> list = bll.GetAll();
            return View(list);
        }
        /// <summary>
        /// 新增扣分记录
        /// </summary>
        /// <returns></returns>
        public ActionResult add()
        {
            UserManager bll = new UserManager();
            List<User> list = bll.GetAll();
            SystemManager blls = new SystemManager();
            List<system> lis = blls.GetAll();
            ViewData["syslis"] = lis;
            return View(list);
        }
        /// <summary>
        /// 就是新增
        /// </summary>
        /// <returns></returns>
        public ActionResult adds()
        {
            ScoreManager bll = new ScoreManager();
            score se = new score()
            {
                PointTime=Convert.ToDateTime(Request.Form["PointTime"]),
                UserId=Convert.ToInt32(Request.Form["UserId"]),
                systemId=Convert.ToInt32(Request.Form["systemId"]),
                score_Condition="可见"
            };
            var info = bll.Add(se);
            if (info)
            {
                return Redirect("/LiuYi/Point/Index");
            }
            else
            {
                return Redirect("/LiuYi/Point/Index");
            }
        }
    }
}