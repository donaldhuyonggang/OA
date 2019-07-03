using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
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