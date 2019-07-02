using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统Model;

namespace 公司管理系统DAL
{
    public class LeaveService : BaseDAL<Leave>
    {

        public virtual List<Leave> GetBySome(string tj)
        {
            Model1 db = new Model1();
            return db.Set<Leave>().Where(x => x.LeaveOver == tj).ToList();
        }
        public virtual List<Leave> GetByother(string tj)
        {
            Model1 db = new Model1();
            return db.Set<Leave>().Where(x => x.LeaveOver != tj).ToList();
        }
        public virtual List<Leave> GetByName(string tj)
        {
            Model1 db = new Model1();
            return db.Set<Leave>().Where(x => x.User.UserName == tj).ToList();
        }
        public virtual bool UpdateL(int id, string LeaveStatues) {
            Model1 db = new Model1();
            Leave le = db.Leave.Find(id);
            le.LeaveOver = LeaveStatues;
            return db.SaveChanges() > 0;
        }
        public virtual bool UpdateC(int id, string LeaveOline)
        {
            Model1 db = new Model1();
            Leave le = db.Leave.Find(id);
            le.Leave_Condition = LeaveOline;
            return db.SaveChanges() > 0;
        }
        public virtual bool UpdateG(int id, string LeaveOnline) {
            Model1 db = new Model1();
            Leave le = db.Leave.Find(id);
            le.Leave_Condition = LeaveOnline;
            return db.SaveChanges() > 0;
        }

        public virtual List<Leave> GetBySomeother(string tj,string tj2)
        {
            Model1 db = new Model1();
            return db.Set<Leave>().Where(x => x.LeaveOver == tj&&x.Leave_Condition==tj2).ToList();
        }
    }
}
