using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.LiuYi.Controllers
{
    public class systemqianController : Controller
    {
        /// <summary>
        /// 前台公司规章制度显示
        /// </summary>
        /// <returns></returns>
        // GET: LiuYi/systemqian
        public ActionResult systemIndex()
        {
            SystemManager bll = new SystemManager();
            List<system> list = bll.Where(x => x.sys_Condition == "发布");
            return View(list);
        }
    }
}