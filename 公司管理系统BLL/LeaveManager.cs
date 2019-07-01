using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统DAL;
using 公司管理系统Model;

namespace 公司管理系统BLL
{
   public class LeaveManager:BaseBLL<Leave>
    {
        public LeaveManager():
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
    }
}
