using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统DAL;
using 公司管理系统Model;

namespace 公司管理系统BLL
{
   public class ClassManager:BaseBLL<_class>
    {
        public ClassManager():base(new ClassService())
        {

        }
        public int DelCommons(List<string> IDs)
        {
            ClassService dal = new ClassService();
            return dal.DelCommons(IDs);
        }
    }
}
