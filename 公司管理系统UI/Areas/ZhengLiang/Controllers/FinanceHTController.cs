using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.ZhengLiang.Controllers
{
    public class FinanceHTController : Controller
    {
        //添加活动记录
        [HttpGet]
        public ActionResult HuoDong()
        {
            //员工
            UserManager a = new UserManager();
            List<User> User =  a.GetAll();
            ViewBag.User = User;
            //类型
            ActionTypeManager aa = new ActionTypeManager();
            List<actionType> actionType = aa.GetAll();
            ViewBag.actionType = actionType;
            return View();
        }
        [HouTai]
        //添加活动记录
        [HttpPost]
        public ActionResult HuoDong(action info)
        {
            //查询出总经费
            MoneyManager aa = new MoneyManager();
            money mys = aa.GetByPK(1);
            if (info.actionneedmoney <= mys.overmoney)
            {
                ActionManager a = new ActionManager();
                var qq = a.Add(info);

                if (qq)
                {
                    //判断是否以批准，
                    if (info.actiontype.Equals("通过"))
                    {
                        if (mys.overmoney == null)
                        {
                            mys.overmoney = 0;
                        }
                        if (mys.openmoney == null)
                        {
                            mys.openmoney = 0;
                        }
                        //修改总经费
                        money my = new money();
                        if (my.overmoney == null)
                        {
                            my.overmoney = 0;
                        }
                        if (my.openmoney == null)
                        {
                            my.openmoney = 0;
                        }
                        my.sunId = 1;
                        my.overmoney = (mys.overmoney - info.actionneedmoney);
                        my.openmoney = (mys.openmoney + info.actionneedmoney);
                        MoneyManager aq = new MoneyManager();
                        var boo = aq.Update(my);
                        if (boo)
                        {
                            return Redirect("~/ZhengLiang/FinanceHT/HuoDong");
                        }
                        else {
                            return Content("<script>alert('异常')</script>;window.location = '/ZhengLiang/FinanceHT/HuoDongJiLu');</script>");
                        }
                       
                    }
                    else
                    {
                        return Redirect("~/ZhengLiang/FinanceHT/HuoDong");
                    }
                }
                else
                {
                    return Content("<script>alert('添加失败';window.location = '/ZhengLiang/FinanceHT/HuoDong');</script>");
                }
            }
            else {
                return Content("<script>alert('余额不足');window.location = '/ZhengLiang/FinanceHT/HuoDong';</script>");
            }
        }

        //公司活动记录
        [HttpGet]
        public ActionResult HuoDongJiLu(int current = 1)
        {
            if (current> 1)
            {
                ViewBag.currents = current - 1;
            }
            else {
                ViewBag.currents = 1;
            }
            int count = 5;
            ActionManager a = new ActionManager();
            List<action> detail = a.GetAll();
            var list = detail.OrderByDescending(x => x.actiontime).Skip((current - 1) * count).Take(count).ToList();

            int zongshu = detail.Count();
            int zongye = zongshu / count;
            zongye = zongshu % count == 0 ? zongye : zongye + 1;
            if (current < zongye)
            {
                ViewBag.currentc = current+1;
            }
            else {
                ViewBag.currentc = zongye;
            }
            ViewBag.zongye = zongye;
            ViewBag.current = current;
            ViewBag.list = list;
            return View();
        }
        //公司活动记录
        [HttpPost]
        public ActionResult HuoDongJiLu(action info)
        {
            if (info.action_Condition.Equals("全部")) {
                int current = 1;
                if (current > 1)
                {
                    ViewBag.currents = current - 1;
                }
                else
                {
                    ViewBag.currents = 1;
                }
                int count = 5;
                ActionManager a = new ActionManager();
                
                if (info.actionhead==null) {
                    List<action> detail = a.GetAll();
                    var list = detail.OrderByDescending(x => x.actiontime).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    ViewBag.list = list;
                    return View();
                }
                else
                {
                    List<action> detail = a.Where(x => x.actionhead.Contains(info.actionhead)).ToList();
                    var list = detail.OrderByDescending(x => x.actiontime).Skip((current - 1) * count).Take(count).ToList();

                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    ViewBag.list = list;
                    return View();
                }
               
            }
            else {
                int current = 1;
                if (current > 1)
                {
                    ViewBag.currents = current - 1;
                }
                else
                {
                    ViewBag.currents = 1;
                }
                int count = 5;
                ActionManager a = new ActionManager();
                //List<action> detail = a.GetAll();
                if (info.actionhead == null)
                {
                    List<action> detail = a.Where(x => x.action_Condition == info.action_Condition).ToList();
                    var list = detail.OrderByDescending(x => x.actiontime).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    ViewBag.list = list;
                    return View();
                }
                else
                {
                    List<action> detail = a.Where(x => x.actionhead.Contains(info.actionhead) && x.action_Condition ==info.action_Condition).ToList();
                    //List<action> detail = a.Where(x => x.actionhead.Contains(info.actionhead)).ToList();
                    var list = detail.OrderByDescending(x => x.actiontime).Skip((current - 1) * count).Take(count).ToList();

                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    ViewBag.list = list;
                    return View();
                }
                
            }
        }
        [HouTai]
        //改变活动可见状态
        public ActionResult HuoDongDelete(int id)
        {
            //根据id,找到这个对象
            ActionManager aa = new ActionManager();
            var info = aa.GetByPK(id);
            if (info.action_Condition == "可见")
            {
                info.action_Condition = "不可见";
                var qq = aa.Update(info);
                if (qq)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/HuoDongJiLu");
                }
                else
                {
                    return Content("<script>alert('异常');window.location = '/ZhengLiang/FinanceHT/HuoDongJiLu';</script>");
                }
            }
            else {
                info.action_Condition = "可见";
                var qq = aa.Update(info);
                if (qq)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/HuoDongJiLu");
                }
                else
                {
                    return Content("<script>alert('异常');window.location = '/ZhengLiang/FinanceHT/HuoDongJiLu';</script>");
                }
            }
            
        }
        [HouTai]
        //修改活动是否批准
        public ActionResult HuoDongUpdate(int id)
        {
            //查询出总经费
            MoneyManager a = new MoneyManager();
            money mys = a.GetByPK(1);
            //根据id,找到这个对象
            ActionManager ss = new ActionManager();
            action an= ss.GetByPK(id);

            if (an.actiontype == "通过")
            {
                return Content("<script>alert('该活动以通过!');window.location = '/ZhengLiang/FinanceHT/HuoDongJiLu';</script>");
            }
            else
            {
                if (mys.overmoney >= an.actionneedmoney) {
                    ActionManager aa = new ActionManager();
                    var info = aa.GetByPK(id);
                    info.actiontype = "通过";
                    var qq = aa.Update(info);
                    if (qq)
                    {
                        //通过后，财务就支出费用
                        mys.overmoney = mys.overmoney - an.actionneedmoney;
                        mys.openmoney = mys.openmoney + an.actionneedmoney;

                       MoneyManager z = new MoneyManager();
                        var my = a.Update(mys);
                        if (my)
                        {
                            return Redirect("~/ZhengLiang/FinanceHT/HuoDongJiLu");
                        }
                        else {
                            return Content("<script>alert('异常');window.location = '/ZhengLiang/ FinanceHT /HuoDongJiLu';</script>");
                        }   
                    }
                    else
                    {
                        return Content("<script>alert('失败');window.location = '/ZhengLiang/ FinanceHT /HuoDongJiLu';</script>");
                    }

                }
                else
                {
                    return Content("<script>alert('余额不足，不能通过');window.location = '/ZhengLiang/ FinanceHT /HuoDongJiLu';</script>");
                }

            }
        }
        [HouTai]
        //搞完活动后，修改活动的实际金额
        [HttpGet]
        public ActionResult XiuGaiHuoDong(int id)
        {
            ActionManager a = new ActionManager();
            var action= a.GetByPK(id);
            return PartialView (action);
        }
        //搞完活动后，修改活动的实际金额
        [HttpPost]
        public ActionResult XiuGaiHuoDong(action info)
        {
            ActionManager a = new ActionManager();
            action an= a.GetByPK(info.actionId);
            an.actionhead = info.actionhead;
            an.actionresult = info.actionresult;
            an.actiontime = info.actiontime;
            an.actionfactmoney = info.actionfactmoney;


            if (info.actionfactmoney > info.actionneedmoney)
                {
                    return Content("<script>alert('实际金额，不能大于所需经费！');window.location = '/ZhengLiang/ FinanceHT /XiuGaiHuoDong';</script>");
                } else {
                        if (info.actionfactmoney == info.actionneedmoney) {  
                             var qq = a.Update(an);
                              if (qq){
                                return Redirect("~/ZhengLiang/FinanceHT/HuoDongJiLu");

                                 } else{
                                     return Content("<script>alert('修改失败');window.location = '/ZhengLiang/ FinanceHT /HuoDongJiLu';</script>");
                                }
                         } else {  
                           
                             var qq = a.Update(an);
                             if (qq) {
                                 //查询出总经费
                                   MoneyManager am = new MoneyManager();
                                   money mys = am.GetByPK(1);
                                   mys.overmoney = mys.overmoney + (info.actionneedmoney - info.actionfactmoney);
                                   mys.openmoney = mys.openmoney - (info.actionneedmoney - info.actionfactmoney);

                                 //修改总经费
                                   bool pp = am.Update(mys);
                                  if (pp){
                                       return Redirect("~/ZhengLiang/FinanceHT/HuoDongJiLu");
                                  } else
                                 {
                                    return Content("<script>alert('异常！');window.location = '/ZhengLiang/ FinanceHT /HuoDongJiLu';</script>");
                                  }
                        
                             } else {
                                     return Content("<script>alert('修改失败');window.location = '/ZhengLiang/ FinanceHT /HuoDongJiLu';</script>");
                               }

                          }
                    
                }  
            
        }


        [HouTai]
        //添加员工缴费
        [HttpGet]
        public ActionResult YuanGongJiaoFei()
        {
            //员工
            UserManager a = new UserManager();
            List<User> User = a.GetAll();
            ViewBag.User = User;
            return View();
        }
        [HouTai]
        //添加员工缴费
        [HttpPost]
        public ActionResult YuanGongJiaoFei(detail info)
        {
          
            ////添加缴费记录
            DetailManager a = new DetailManager();
            var qq = a.Add(info);
            if (qq)
            {

                //查询出总经费
                MoneyManager aa = new MoneyManager();
                money mys = aa.GetByPK(1);
                if (mys.overmoney == null)
                {
                    mys.overmoney = 0;
                }
                //修改总经费
                money my = new money();
                if (my.overmoney == null)
                {
                    my.overmoney = 0;
                }
                my.sunId = 1;
                my.overmoney = (mys.overmoney + info.sum);
                my.openmoney =mys.openmoney+ 0;
                MoneyManager aq = new MoneyManager();
                var boo = aq.Update(my);
                if (boo)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/YuanGongJiaoFei");
                }

                else
                {
                    return Redirect("~/ZhengLiang/FinanceHT/YuanGongJiaoFei");
                }
            }
            else
            {

                return Content("<script>alert('添加失败');window.location = '/ZhengLiang/FinanceHT/YuanGongJiaoFei';</script>");
            }


        }

        //员工缴费记录
        [HttpGet]
        public ActionResult JiaoFeiJiLu(int current=1)
        {
            if (current > 1)
            {
                ViewBag.currents = current - 1;
            }
            else
            {
                ViewBag.currents = 1;
            }
            int count = 5;
                 DetailManager a = new DetailManager();
                List<detail> detail = a.GetAll();
                var list = detail.OrderByDescending(x => x.MoneyTime).Skip((current - 1) * count).Take(count).ToList();
                int zongshu = detail.Count();
                int zongye = zongshu / count;
                zongye = zongshu % count == 0 ? zongye : zongye + 1;
            if (current < zongye)
            {
                ViewBag.currentc = current + 1;
            }
            else
            {
                ViewBag.currentc = zongye;
            }
            ViewBag.zongye = zongye;
                ViewBag.current = current;
                return View(list);
            
        }
        //员工缴费记录
        [HttpPost]
        public ActionResult JiaoFeiJiLu(detail info)
        {
           
            if (info.detail_Condition.Equals("全部"))
            {
                int current = 1;
                if (current > 1)
                {
                    ViewBag.currents = current - 1;
                }
                else
                {
                    ViewBag.currents = 1;
                }
                int count = 5;
                DetailManager a = new DetailManager();

                if (info.MonryResult == null)
                {
                    List<detail> detail= a.GetAll();
                    var list = detail.OrderByDescending(x => x.MoneyTime).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }
                else
                {
                    List<detail> detail = a.Where(x => x.MonryResult.Contains(info.MonryResult)).ToList();
                    var list = detail.OrderByDescending(x => x.MoneyTime).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }

            }
            else {
                int current = 1;
                if (current > 1)
                {
                    ViewBag.currents = current - 1;
                }
                else
                {
                    ViewBag.currents = 1;
                }
                int count = 5;
                DetailManager a = new DetailManager();
                if (info.MonryResult == null)
                {
                    List<detail> detail = a.Where(x => x.detail_Condition == info.detail_Condition).ToList();
                    var list = detail.OrderByDescending(x => x.MoneyTime).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }
                else
                {
                    List<detail> detail = a.Where(x => x.MonryResult.Contains(info.MonryResult) && x.detail_Condition == info.detail_Condition).ToList();
                    var list = detail.OrderByDescending(x => x.MoneyTime).Skip((current - 1) * count).Take(count).ToList();

                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }

            }
        }
        [HouTai]
        //员工缴费状态
        public ActionResult JiaoFeiDelete( int id)
        {
            //根据id,找到这个对象
            DetailManager aa = new DetailManager();
            var info = aa.GetByPK(id);
            if (info.detail_Condition == "可见")
            {
                info.detail_Condition = "不可见";
                var qq = aa.Update(info);
                if (qq)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/JiaoFeiJiLu");
                }
                else
                {
                    return Content("<script>alert('异常');window.location = '/ZhengLiang/FinanceHT/JiaoFeiJiLu';</script>");
                }
            }
            else
            {
                info.detail_Condition = "可见";
                var qq = aa.Update(info);
                if (qq)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/JiaoFeiJiLu");
                }
                else
                {
                    return Content("<script>alert('异常');window.location = '/ZhengLiang/FinanceHT/JiaoFeiJiLu';</script>");
                }
            }
        }



        //添加公司消费
        [HttpGet]
        public ActionResult XiaoFeiAdd()
        {
            //员工
            UserManager a = new UserManager();
            List<User> User = a.GetAll();
            ViewBag.User = User;
            return View();
        }

        //添加公司消费
        [HttpPost]
        public ActionResult XiaoFeiAdd(consume info)
        {
            //查询出总经费
            MoneyManager aa = new MoneyManager();
            money mys = aa.GetByPK(1);
            if (info.consume_money<=mys.overmoney) {
                ConsumeManager a = new ConsumeManager();
                var qq = a.Add(info);
                if (qq)
                {
                    
                        if (mys.overmoney == null)
                        {
                            mys.overmoney = 0;
                        }
                        if (mys.openmoney == null)
                        {
                            mys.openmoney = 0;
                        }
                        //修改总经费
                        money my = new money();
                        if (my.overmoney == null)
                        {
                            my.overmoney = 0;
                        }
                        if (my.openmoney == null)
                        {
                            my.openmoney = 0;
                        }
                        my.sunId = 1;
                        my.overmoney = (mys.overmoney - info.consume_money);
                        my.openmoney = (mys.openmoney + info.consume_money);
                        MoneyManager aq = new MoneyManager();
                        var boo = aq.Update(my);
                        if (boo)
                        {
                            return Redirect("~/ZhengLiang/FinanceHT/XiaoFeiAdd");
                        }
                      
                    else
                    {
                        return Redirect("~/ZhengLiang/FinanceHT/XiaoFeiAdd");
                    }
                }
                else
                {

                    return Content("<script>alert('添加失败')</script>");
                }
            }
            else {
                return Content("<script>alert('余额不足');window.location = '/ZhengLiang/FinanceHT/XiaoFeiAdd';</script>");
            }
        }

        //公司消费记录
        [HttpGet]
        public ActionResult XiaoFeiJiLu(int current=1)
        {
            if (current > 1)
            {
                ViewBag.currents = current - 1;
            }
            else
            {
                ViewBag.currents = 1;
            }
            ConsumeManager a = new ConsumeManager();
            int count = 5;
            List<consume> consume = a.GetAll();
            //List<consume> consume = a.Where(x => x.consume_Condition == "可见").ToList();
            var list = consume.OrderByDescending(x => x.consume_Time).Skip((current - 1) * 5).Take(count).ToList();

            int zongshu = consume.Count();
            int zongye = zongshu / count;
            zongye = zongshu % count == 0 ? zongye : zongye + 1;
            if (current < zongye)
            {
                ViewBag.currentc = current + 1;
            }
            else
            {
                ViewBag.currentc = zongye;
            }
            ViewBag.zongye = zongye;
            ViewBag.current = current;
            return View(list);
        }

        //公司消费记录
        [HttpPost]
        public ActionResult XiaoFeiJiLu(consume info)
        {
            if (info.consume_Condition.Equals("全部"))
            {
                int current = 1;
                if (current > 1)
                {
                    ViewBag.currents = current - 1;
                }
                else
                {
                    ViewBag.currents = 1;
                }
                int count = 5;
                ConsumeManager a = new ConsumeManager();

                if (info.consume_cause == null)
                {
                    List<consume> detail = a.GetAll();
                    var list = detail.OrderByDescending(x => x.consume_Time).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }
                else
                {
                    List<consume> detail = a.Where(x => x.consume_cause.Contains(info.consume_cause)).ToList();
                    var list = detail.OrderByDescending(x => x.consume_Time).Skip((current - 1) * count).Take(count).ToList();

                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }

            }
            else
            {
                int current = 1;
                if (current > 1)
                {
                    ViewBag.currents = current - 1;
                }
                else
                {
                    ViewBag.currents = 1;
                }
                int count = 5;
                ConsumeManager a = new ConsumeManager();
                //List<action> detail = a.GetAll();
                if (info.consume_cause == null)
                {
                    List<consume> detail = a.Where(x => x.consume_Condition == info.consume_Condition).ToList();
                    var list = detail.OrderByDescending(x => x.consume_Time).Skip((current - 1) * count).Take(count).ToList();
                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }
                else
                {
                    List<consume> detail = a.Where(x => x.consume_cause.Contains(info.consume_cause) && x.consume_Condition == info.consume_Condition).ToList();
                    //List<action> detail = a.Where(x => x.actionhead.Contains(info.actionhead)).ToList();
                    var list = detail.OrderByDescending(x => x.consume_Time).Skip((current - 1) * count).Take(count).ToList();

                    int zongshu = detail.Count();
                    int zongye = zongshu / count;
                    zongye = zongshu % count == 0 ? zongye : zongye + 1;
                    if (current < zongye)
                    {
                        ViewBag.currentc = current + 1;
                    }
                    else
                    {
                        ViewBag.currentc = zongye;
                    }
                    ViewBag.zongye = zongye;
                    ViewBag.current = current;
                    return View(list);
                }

            }
           
        }

        //员工缴费状态
        public ActionResult XiaoFeiDelete(int id)
        {
            //根据id,找到这个对象
            ConsumeManager aa = new ConsumeManager();
            var info = aa.GetByPK(id);
            if (info.consume_Condition == "可见")
            {
                info.consume_Condition = "不可见";
                var qq = aa.Update(info);
                if (qq)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/XiaoFeiJiLu");
                }
                else
                {
                    return Content("<script>alert('异常');window.location = '/ZhengLiang/FinanceHT/XiaoFeiJiLu';</script>");
                }
            }
            else
            {
                info.consume_Condition = "可见";
                var qq = aa.Update(info);
                if (qq)
                {
                    return Redirect("~/ZhengLiang/FinanceHT/XiaoFeiJiLu");
                }
                else
                {
                    return Content("<script>alert('异常');window.location = '/ZhengLiang/FinanceHT/XiaoFeiJiLu';</script>");
                }
            }
        }


    }
}