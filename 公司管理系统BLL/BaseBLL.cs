using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统DAL;

namespace 公司管理系统BLL
{

        public class BaseBLL<T> where T : class
        {
            BaseDAL<T> dal = null;
            public BaseBLL(BaseDAL<T> _dal)
            {
                dal = _dal;
            }
            public List<T> GetAll()
            {
                return dal.GetAll();
            }
            public T GetByPK(object pk)
            {
                return dal.GetByPK(pk);
            }
            public bool Add(T info)
            {
                return dal.Add(info);
            }
            public bool Delete(object pk)
            {

                return dal.Delete(pk);
            }
            public bool Update(T info)
            {
                return dal.Update(info);
            }
            public virtual List<T> Where(Expression<Func<T, bool>> tj)
            {
                return dal.Where(tj);
            }
    }
    }
