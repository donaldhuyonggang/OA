using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统Model;
using 公司管理系统BLL;
using System.Threading.Tasks;
using System.Data.Entity;

namespace 公司管理系统UI.Areas.LuoWei.Controllers
{
    public class PersonnelController : Controller
    {
        UserManager user = new UserManager();
        Sys_DepartmentManager bll = new Sys_DepartmentManager();
        // GET: LuoWei/Personnel
        [HttpGet]
        public ActionResult Person(int pageIndex = 1)
        {
            int pageSize = 2;   
            var list = user.GetAll();
            var list1 = list.OrderByDescending(x => x.Userscore).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.pageIndex = pageIndex;
            ViewBag.pageCount = list.Count;
            ViewBag.pageSize = pageSize;
            return View(list1);
        }
        [HttpPost]
        public ActionResult Person(string UserName)
        {
            List<User> list = user.Where(s => s.UserName.Contains(UserName));
            return View(list);
        }

        [HttpGet]
        public ActionResult PersonAdd()
        {
            List<Sys_Department> list = bll.GetAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult PersonAdd(User info)
        {
            var result = user.Add(info);
            if (result)
            {
                return Content("<script>alert('添加成功');window.location.href='/LuoWei/Personnel/Person';</script>");

            }
            else
            {
                return Content("<script>alert('添加失败');</script>");
            }

        }
        [HttpGet]
        public ActionResult PersonUpdate(int id)
        {
            var info = user.GetByPK(id);
            List<Sys_Department> list = bll.GetAll();
            ViewData["Sys_Department"] = list;
            return View(info);
        }
        [HttpPost]
        public ActionResult PersonUpdate(User info)
        {
            var result = user.Update(info);
            if (result)
            {
                return Content("<script>alert('修改成功');window.location.href='/LuoWei/Personnel/Person';</script>");

            }
            else
            {
                return Content("<script>alert('修改失败');</script>");
            }
            
        }
        //前台查询
        public ActionResult PersonReception(int pageIndex = 1)
        {
            int pageSize = 2;
            var list = user.GetAll();
            var list1 = list.OrderByDescending(x => x.Userscore).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.pageIndex = pageIndex;
            ViewBag.pageCount = list.Count;
            ViewBag.pageSize = pageSize;
            return View(list1);
        }


    }

}