﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.TangKai.Controllers
{
    [Right]
    public class UpController : Controller
    {
        // GET: TangKai/Up
        public ActionResult Index()
        {
          
            return View();
        }
    }
}