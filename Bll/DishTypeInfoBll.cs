using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public  class DishTypeInfoBll
    {
        private DishTypeInfoDal dtiDal = new DishTypeInfoDal();

        public List<DishTypeInfo> GetList()
        {
            return dtiDal.GetList();
        }

        public bool Add(DishTypeInfo mti)
        {
            return dtiDal.Insert(mti) > 0;
        }

        public bool Remove(int id)
        {
            return dtiDal.DeleteById(id) > 0;
        }

        public bool Edit(DishTypeInfo dti)
        {
            return dtiDal.Update(dti) > 0;
        }
    }
}
