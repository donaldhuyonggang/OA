using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 公司管理系统DAL;
using 公司管理系统Model;

namespace 公司管理系统BLL
{
  public  class ImageManager:BaseBLL<Image>
    {
        public ImageManager():
            base(new ImageService())
        {

        }
    }
}
