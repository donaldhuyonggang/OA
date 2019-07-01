using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.LiuYi.Controllers
{
    public class workhouController : Controller
    {
        /// <summary>
        /// 后台课表
        /// </summary>
        /// <returns></returns>
        // GET: LiuYi/workhou
        public ActionResult deleteIndex()
        {
            ClassManager bll = new ClassManager();
            List<_class> list = bll.Where(x => x.class_Condition == "可见");
            return View(list);
        }
        /// <summary>
        /// 删除表内原本的上周课表
        /// </summary>
        /// <param name="class_Condition"></param>
        /// <returns></returns>
        public ActionResult deleteAll(string class_Condition)
        {
            ClassManager bll = new ClassManager();
            List<string> IDS = new List<string>();//创建list<int> 保存选中信息的Id 简化操作
            var Ls = class_Condition.Split(',');//根据(',') 完成对数据的分组
            foreach (var item in Ls)
            {
                IDS.Add(Convert.ToString(item));//foreach 循环遍历添加选中信息的Id
            }
            int n = bll.DelCommons(IDS);
            if (n>0)
            {
                return Redirect("/LiuYi/workhou/deleteIndex");
            }
            else
            {
                return Content("删除失败");
            }
        }
        [HttpGet]
        public ActionResult addAll()
        {
            UserManager blll = new UserManager();
            List<User> lis = blll.GetAll();
            ViewData["lis"] = lis;
            return View();
        }
        [HttpPost]
        public ActionResult addAll(_class info)
        {
            ClassManager bll = new ClassManager();
            _class cla = new _class()
            {
                 Morning=Request.Form["Morning"],
                 Afertnoon=Request.Form["Afertnoon"],
                 UserIde=Convert.ToInt32(Request.Form["UserIde"]),
                 UserId=Convert.ToInt32(Request.Form["UserId"]),
                 DataTime=Convert.ToDateTime(Request.Form["DataTime"]),
                 require=Request.Form["require"],
                 class_Condition="可见"
            };
            var add = bll.Add(cla);
            if (add)
            {
                return Redirect("/LiuYi/workhou/addAll");
            }
            else
            {
                return Redirect("/LiuYi/workhou/deleteIndex");
            }
        }
    }
}