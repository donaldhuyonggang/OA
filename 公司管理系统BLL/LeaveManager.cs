using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统DAL;
using 公司管理系统Model;

namespace 公司管理系统BLL
{
    public class LeaveManager : BaseBLL<Leave>
    {
        public LeaveManager() :
            base(new LeaveService())
        {

        }
        public List<Leave> GetBySome(string tj)
        {
            LeaveService ls = new LeaveService();
            return ls.GetBySome(tj);
        }
        public List<Leave> GetByother(string tj)
        {
            LeaveService ls = new LeaveService();
            return ls.GetByother(tj);
        }
        public bool UpdateL(int id, string LeaveStatues)
        {
            LeaveService ls = new LeaveService();
            return ls.UpdateL(id, LeaveStatues);
        }
        public List<Leave> GetByName(string tj)
        {
            LeaveService ls = new LeaveService();

            return ls.GetByName(tj);
        }
        public bool UpdateG(int id, string LeaveOnline)
        {
            LeaveService ls = new LeaveService();
            return ls.UpdateG(id, LeaveOnline);
        }
        public List<Leave> GetBySomeother(string tj, string tj2)
        {
            LeaveService ls = new LeaveService();
            return ls.GetBySomeother(tj, tj2);
        }
        public bool UpdateC(int id, string LeaveOline)
        {
            LeaveService ls = new LeaveService();
            return ls.UpdateC(id, LeaveOline);
        }
    }
}
