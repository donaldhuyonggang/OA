using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.LiuYi.Controllers
{
    public class PointqianController : Controller
    {
        /// <summary>
        /// 前台分数总查询
        /// </summary>
        /// <returns></returns>
        // GET: LiuYi/Pointqian
        [HttpGet]
        public ActionResult Index()
        {
            ScoreManager bll = new ScoreManager();
            List<score> list = bll.Where(x=>x.score_Condition=="可见");
            return View(list);
        }
        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <param name="PointTime"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(DateTime PointTime)
        {
            ScoreManager bll = new ScoreManager();
            List<score> list = bll.Where(x=>x.PointTime==PointTime);
            return View("Index",list);
        }
        /// <summary>
        /// 按时间和名字查询总查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult select()
        {
            ScoreManager bll = new ScoreManager();
            List<score> list = bll.Where(x=>x.score_Condition=="可见");
            return View(list);
        }
        /// <summary>
        /// 按时间和名字查询
        /// </summary>
        /// <param name="PointTime"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult select(DateTime PointTime,string UserName)
        {
            ScoreManager bll = new ScoreManager();
            List<score> list = bll.Where(x => x.PointTime == PointTime && x.User.UserName == UserName);
            return View("select",list);
        }
    }
}