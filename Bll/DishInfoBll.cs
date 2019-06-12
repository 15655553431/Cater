using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public  class DishInfoBll
    {
        private DishInfoDal diDal = new DishInfoDal();

        public List<DishInfo> GetList(DishInfo di)
        {
            return diDal.GetList(di);
        }

        public bool Add(DishInfo di)
        {
            return diDal.Insert(di) > 0;
        }

        public bool Edit(DishInfo di)
        {
            return diDal.Update(di) > 0;
        }

        public bool Remove(int id)
        {
            return diDal.DeleteById(id) > 0;
        }
    }
}
