using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.LiuYi.Controllers
{
    public class systemhouController : Controller
    {
        /// <summary>
        /// 后台规章制度批阅
        /// </summary>
        /// <returns></returns>
        // GET: LiuYi/systemhou
        public ActionResult systemhou()
        {
            SystemManager bll = new SystemManager();
            List<system> list = bll.Where(x=>x.status=="未通");
            return View(list);
        }
        /// <summary>
        /// 点击修改为通过状态，只有老胡可以看
        /// </summary>
        /// <param name="id"></param>
        /// <param name="systemPoint"></param>
        /// <param name="systemName"></param>
        /// <param name="audat"></param>
        /// <param name="sys_Condition"></param>
        /// <returns></returns>
        public ActionResult systemupdate(int id,int systemPoint,string systemName,string audat,string sys_Condition)
        {
            SystemManager bll = new SystemManager();
            system tem = new system()
            {
                systemId = id,
                status = "通过",
                audat=audat,
                systemName=systemName,
                systemPoint=systemPoint,
                sys_Condition=sys_Condition
            };
            var info = bll.Update(tem);
            if (info)
            {
                return Redirect("/LiuYi/systemhou/systemhou");
            }
            else
            {
                return Redirect("/LiuYi/systemhou/systemhou");
            }
        }
        /// <summary>
        /// 发布公司规章制度
        /// </summary>
        /// <returns></returns>
        public ActionResult systemfabu()
        {
            SystemManager bll = new SystemManager();
            List<system> list = bll.Where(x => x.audat== "批准" && x.sys_Condition=="未发布");
            return View(list);
        }
        /// <summary>
        /// 经理发布
        /// </summary>
        /// <returns></returns>
        public ActionResult systemfabuupdate(int id, int systemPoint, string systemName, string audat,string status)
        {
            SystemManager bll = new SystemManager();
            system tem = new system()
            {
                systemId = id,
                status = status,
                audat = audat,
                systemName = systemName,
                systemPoint = systemPoint,
                sys_Condition = "发布"
            };
            var info = bll.Update(tem);
            if (info)
            {
                return Redirect("/LiuYi/systemhou/systemfabu");
            }
            else
            {
                return Redirect("/LiuYi/systemhou/systemfabu");
            }
        }
        /// <summary>
        /// 冉波批准并且将批准后的规定去掉
        /// </summary>
        /// <returns></returns>
        public ActionResult systemzongjian()
        {
            SystemManager bll = new SystemManager();
            List<system> list = bll.Where(x => x.status == "通过" && x.audat=="没批准");
            return View(list);
        }
        /// <summary>
        /// 批准过后修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="systemPoint"></param>
        /// <param name="systemName"></param>
        /// <param name="sys_Condition"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ActionResult systemzongjianpi(int id, int systemPoint, string systemName, string sys_Condition, string status)
        {
            SystemManager bll = new SystemManager();
            system tem = new system()
            {
                systemId = id,
                status = status,
                audat = "批准",
                systemName = systemName,
                systemPoint = systemPoint,
                sys_Condition = sys_Condition
            };
            var info = bll.Update(tem);
            if (info)
            {
                return Redirect("/LiuYi/systemhou/systemzongjian");
            }
            else
            {
                return Redirect("/LiuYi/systemhou/systemzongjian");
            }
        }
    }
}