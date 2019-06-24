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
        public ActionResult Index()
        {
            WebManager w = new WebManager();
            web_typeManager t = new web_typeManager();
            List<web_type> listt = t.GetAll();
            List<web> listw = w.GetAll();
            ViewData["t"] = listt;
            return View(listw);
        }
    }
}