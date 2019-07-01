using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统Model;

namespace 公司管理系统DAL
{

    public class BaseDAL<T> where T : class
    {
        Model1 db = new Model1();
        public virtual List<T> GetAll()
        {
           

            return db.Set<T>().ToList();
        }
        public virtual T GetByPK(object pk)
        {
       
            return db.Set<T>().Find(pk);
        }
        public virtual bool Add(T info)
        {
            
            db.Set<T>().Add(info);
            return db.SaveChanges() > 0;
        }
        public virtual bool Delete(object pk)
        {
           
            var info = db.Set<T>().Find(pk);
            if (info != null)
            {
                db.Set<T>().Remove(info);
                return db.SaveChanges() > 0;

            }
            else
            {
                return false;
            }

        }
        //条件查询
        public virtual List<T> Where(Expression<Func<T, bool>> tj) {
           
            return db.Set<T>().Where(tj).ToList();
        }
        //
        public virtual bool Update(T info)
        {
            
            db.Entry<T>(info).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
