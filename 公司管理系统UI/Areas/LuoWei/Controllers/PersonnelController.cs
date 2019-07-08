using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统Model;
using 公司管理系统BLL;
using System.Threading.Tasks;
using System.Data.Entity;
using 公司管理系统UI.App_Start;

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
            //每页的条数
            var pageSize = 4;
            //判断点击上一页，当前页大于1的时候，当前页-1，否则等于1
            if (pageIndex > 1)
            {
                ViewBag.page = pageIndex - 1;
            }
            else
            {
                ViewBag.page = 1;
            }

            var list = user.GetAll();
            var list1 = list.OrderByDescending(x => x.Userscore).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //数据总条数
            var SumCount = list.Count();
            //数据总条数/每页条数=总页数
            var sum = list.Count / pageSize;
            //尾页
            var TrailerPage = SumCount % pageSize == 0 ? sum : sum + 1;
            //判断点击下一页，当前页小于尾页的时候，当前页+1，否则当前页等于尾页
            if (pageIndex < TrailerPage)
            {

                ViewBag.row = pageIndex + 1;
            }
            else
            {
                ViewBag.row = TrailerPage;
            }
            //当前页传到页面
            ViewBag.pageIndex = pageIndex;
            //尾页传到页面
            ViewBag.TrailerPage = TrailerPage;
            return View(list1);
        }


        [HttpPost]
        public ActionResult Person(string UserName)
        {
            List<User> list = user.Where(s => s.UserName.Contains(UserName));
            return View(list);
        }
        [HouTai]
        [HttpGet]
        public ActionResult PersonAdd()
        {
            List<Sys_Department> list = bll.GetAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult PersonAdd(User info,HttpPostedFileBase Userimg)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(Userimg.FileName);
            string ext = fi.Extension;
            string path = Server.MapPath("~/Content/images/");
            string name = DateTime.Now.ToString("YYYY-MM-dd-hh-ss-ms") + ext;
            Userimg.SaveAs(path + name);//另存为
            info.Userimg = name;
            info.AdminId = "false";
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
        [HouTai]
        [HttpGet]
        public ActionResult PersonUpdate(int id)
        {
            var info = user.GetByPK(id);
            List<Sys_Department> list = bll.GetAll();
            ViewBag.FileName = info.Userimg;
            ViewData["Sys_Department"] = list;
            return View(info);
        }
        [HttpPost]
        public ActionResult PersonUpdate(User info, HttpPostedFileBase Userimg)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(Userimg.FileName);
            string ext = fi.Extension;
            string path = Server.MapPath("/Content/images/");
            string name = DateTime.Now.ToString("YYYY-MM-dd-hh-ss-ms") + ext;
            Userimg.SaveAs(path + name);//另存为
            info.Userimg = name;
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
            //每页的条数
            var pageSize = 4;
            //判断点击上一页，当前页大于1的时候，当前页-1，否则等于1
            if (pageIndex > 1)
            {
                ViewBag.page = pageIndex - 1;
            }
            else
            {
                ViewBag.page = 1;
            }

            var list = user.Where(x=>x.User_Condition=="在职");
            var list1 = list.OrderByDescending(x => x.Userscore).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //数据总条数
            var SumCount = list.Count();
            //数据总条数/每页条数=总页数
            var sum = list.Count / pageSize;
            //尾页
            var TrailerPage = SumCount % pageSize == 0 ? sum : sum + 1;
            //判断点击下一页，当前页小于尾页的时候，当前页+1，否则当前页等于尾页
            if (pageIndex < TrailerPage)
            {

                ViewBag.row = pageIndex + 1;
            }
            else
            {
                ViewBag.row = TrailerPage;
            }
            //当前页传到页面
            ViewBag.pageIndex = pageIndex;
            //尾页传到页面
            ViewBag.TrailerPage = TrailerPage;
            return View(list1);
        }
    }

}