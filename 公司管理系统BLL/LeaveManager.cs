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
            base(new 公司管理系统DAL.ImageBLL())
        {

        }
    }
}
