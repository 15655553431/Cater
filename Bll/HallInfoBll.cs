using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public  class HallInfoBll
    {
        private HallInfoDal hiDal = new HallInfoDal();
        public List<HallInfo> GetList()
        {
            return hiDal.GetList();
        }

        public bool Add(HallInfo hi)
        {
            return hiDal.Insert(hi) > 0;
        }

        public bool Edit(HallInfo hi)
        {
            return hiDal.Update(hi) > 0;
        }

        public bool Remove(int id)
        {
            return hiDal.DeleteById(id) > 0;
        }
        
    }
}
