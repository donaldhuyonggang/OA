using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统Model;


namespace 公司管理系统DAL
{
    public class ClassService : BaseDAL<_class>
    {
        public int DelCommons(List<string> IDs)
        {
            using (Model1 db=new Model1())//实例化上下文对象
            {
                var vm = db._class.Where(m => IDs.Contains(m.class_Condition));//获取所要操作的行
                vm.ToList().ForEach(t => db.Entry(t).State = EntityState.Deleted);//利用 Foreach() 方法 循环遍历删除选中行
                db._class.RemoveRange(vm);//完成操作
                return db.SaveChanges();//返回数据
            }
        }
    }
}

