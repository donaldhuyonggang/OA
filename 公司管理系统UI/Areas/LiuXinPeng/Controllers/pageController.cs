﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统Model;
using 公司管理系统BLL;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.LiuXinPeng.Controllers
{
    [Right]
    public class pageController : Controller
    {
        // GET: LiuXinPeng/page
        public ActionResult Index()
        {
            CultureManager clm = new CultureManager();
            List<culture> list = clm.GetAll();
            return View(list);
        }
    }
}