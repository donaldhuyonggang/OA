using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 公司管理系统BLL;
using 公司管理系统Model;
using 公司管理系统UI.App_Start;

namespace 公司管理系统UI.Areas.LiuXin.Controllers
{
    
    public class MangerLeaveController : Controller
    {
        // GET: LiuXin/MangerLeave
        public ActionResult Index()
        {
            LeaveManager lm = new LeaveManager();
            List<Leave> listleave= lm.GetBySome("未批准");
            List<Leave> lists = listleave.OrderByDescending(x => x.LeaveTime).ToList();
            return View(lists);
        }
        [HouTai]
        public ActionResult JLagree(int id) {
            LeaveManager lm = new LeaveManager();
            string leaveover = "批准";
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            bool pd=lm.UpdateL(id,leaveover);
            if (pd)
            {
                return Redirect("~/LiuXin/MangerLeave/Index");
            }
            else
            {
                return Content("<script>alert('不允许批准');window.location.href='~/LiuXin/MangerLeave/Index';</script>");
            }
        }
        [HouTai]
        public ActionResult JLdisagree(int id) {
            LeaveManager lm = new LeaveManager();
            string leaveover = "不批准";
            bool pdd = lm.UpdateL(id, leaveover);
            if (pdd)
            {
                string leaveoline = "不可见";
                lm.UpdateC(id,leaveoline);
                return Redirect("~/LiuXin/MangerLeave/Index");
            }
            else
            {
                return Content("<script>alert('不允许批准');window.location.href='~/LiuXin/MangerLeave/Index';</script>");
            }
        }
        public ActionResult TcAgree()
        {
            LeaveManager lm = new LeaveManager();
            List<Leave> listleave = lm.GetBySomeother("批准","可见");
            return View(listleave);
        }
        [HouTai]
        public ActionResult RcAgree(int id) {
            LeaveManager lm = new LeaveManager();
            string leaveover = "批准";
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            bool pd = lm.UpdateG(id, leaveover);
            if (pd)
            {
                return Redirect("~/LiuXin/MangerLeave/TcAgree");
            }
            else
            {
                return Content("<script>alert('不允许批准');window.location.href='~/LiuXin/MangerLeave/TcAgree';</script>");
            }
        }
        [HouTai]
        public ActionResult RcDisAgree(int id)
        {
            LeaveManager lm = new LeaveManager();
            string leaveover = "不批准";
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            bool pd = lm.UpdateG(id, leaveover);
            if (pd)
            {
                return Redirect("~/LiuXin/MangerLeave/TcAgree");
            }
            else
            {
                return Content("<script>alert('不允许批准');window.location.href='~/LiuXin/MangerLeave/TcAgree';</script>");
            }
        }
        public ActionResult History() {
            LeaveManager lm = new LeaveManager();
            List<Leave> listhistory = lm.GetByother("未批准");
            List<Leave> lists = listhistory.OrderByDescending(x => x.LeaveTime).ToList(); ;
            return View(lists);
        }
    }
}