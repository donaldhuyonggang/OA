using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.LiuYi.Controllers
{
    public class workController : Controller
    {
        /// <summary>
        /// 前台课表查询
        /// </summary>
        /// <returns></returns>
        // GET: LiuYi/work
        public ActionResult Index()
        {
            ClassManager bll = new ClassManager();
            List<_class> list = bll.Where(x=>x.class_Condition=="可见");
            return View(list);
        }
    }
}