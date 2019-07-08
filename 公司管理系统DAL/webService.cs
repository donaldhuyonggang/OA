using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统Model;

namespace 公司管理系统DAL
{
   public class WebService:BaseDAL<web>
    {
        public bool Update(web info)
        {
            Model1 db = new Model1();
            web infoTable = db.web.Find(info.webId);
            //把UI传过来的实体类赋值给根据主键查询出来的实体类
            infoTable.like = info.like;
            return db.SaveChanges() > 0;
        }
        public bool Update1(web info)
        {
            Model1 db = new Model1();
            web infoTable = db.web.Find(info.webId);
            //把UI传过来的实体类赋值给根据主键查询出来的实体类
            infoTable.web_Condition = info.web_Condition;
            return db.SaveChanges() > 0;
        }
    }
}
