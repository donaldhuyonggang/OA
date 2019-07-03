using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.LiuXinPeng.Controllers
{
    [Right]
    public class CultureController : Controller
    {
        // GET: LiuXinPeng/Culture
        public ActionResult Culture()
        {
            CultureManager clm = new CultureManager();
            List<culture> list = clm.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            UserManager um = new UserManager();
            List<User> list = um.GetAll();
            ViewData["User"] = list;

            ImageManager im = new ImageManager();
            List<Image> lists = im.GetAll();
            ViewData["Image"] = lists;
            return View();
        }
        [HttpPost]
        public ActionResult Add(culture info)
        {
            CultureManager clm = new CultureManager();
            bool result = clm.Add(info);
            if (result)
            {
                return Redirect("/LiuXinPeng/Culture/Culture");
            }
            else
            {
                return Content("新增失败");
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            UserManager um = new UserManager();
            List<User> list = um.GetAll();
            ViewData["User"] = list;

            ImageManager im = new ImageManager();
            List<Image> lists = im.GetAll();
            ViewData["Image"] = lists;

            CultureManager cm = new CultureManager();
            culture info = cm.GetByPK(id);
            return View(info);
        }
        [HttpPost]
        public ActionResult Update(culture info)
        {
            CultureManager cm = new CultureManager();
            bool result = cm.Update(info);
            if (result)
            {
                return Redirect("/LiuXinPeng/Culture/Culture");
            }
            else
            {
                return Content("修改失败");
            }
            
        }
        public ActionResult Delete(int id)
        {
            CultureManager cm = new CultureManager();
            bool result = cm.Delete(id);
            if (result)
            {
                return Redirect("/LiuXinPeng/Culture/Culture");
            }
            else
            {
                return Content("删除失败！");
            }
        }
    }
}