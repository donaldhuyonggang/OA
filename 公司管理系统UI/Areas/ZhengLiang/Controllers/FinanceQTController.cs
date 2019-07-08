using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;

namespace 公司管理系统UI.Areas.ZhengLiang.Controllers
{
    public class FinanceQTController : Controller
    {
        // GET: ZhengLiang/FinanceQT
        public ActionResult Show(int index=1,int indexs=1)
        {
            if (index>1)
            {
                ViewBag.index1 = index - 1;
            }
            else {
                ViewBag.index1 = 1;
            }
            if (indexs>1)
            {
                ViewBag.indexss = indexs-1;
            }
            else {
                ViewBag.indexss = 1;
            }
            int count = 3;
            ActionManager a = new ActionManager();
            List<action> action = a.Where(x => x.actiontype == "通过").ToList();
            var list = action.OrderBy(x => x.actiontime).Skip((index - 1) * count).Take(count).ToList();

            
            int zongshu= action.Count();
            int zongye = zongshu / count;
             zongye = zongshu % count==0 ? zongye : zongye+1;
            if (index<zongye)
            {
                ViewBag.zongyeqq = index + 1; ;
            }
            else {
                ViewBag.zongyeqq = zongye;
            }
                    ViewBag.zongshu = zongshu;
                    ViewBag.index = index;
                    ViewBag.list = list;

            ConsumeManager aa = new ConsumeManager();
            List<consume> consume = aa.GetAll();
            var lists = consume.OrderBy(x => x.consume_Time).Skip((indexs - 1) * count).Take(count).ToList();
            int zongshus = consume.Count();
            int zongyes = zongshus/ count;
            zongyes = zongshus % count == 0 ? zongyes : zongyes + 1;
            if (indexs<zongyes)
            {
                ViewBag.zongyeaa = indexs+1;
            }
            else
            {
                ViewBag.zongyeaa = zongye;
            }
            ViewBag.zongyes = zongyes;
                  ViewBag.indexs = indexs;
                  ViewBag.lists = lists;
                
            
            return View();
        }

    }
}