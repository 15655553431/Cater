using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public  class TableInfoBll
    {
        private TableInfoDal tiDal = new TableInfoDal();

        public List<TableInfo> GetList(TableInfo ti)
        {
            return tiDal.GetList(ti);
        }

        public bool Remove(int id)
        {
            return tiDal.DeleteById(id) > 0;
        }

        public bool Add(TableInfo ti)
        {
            return tiDal.Insert(ti) > 0;
        }

        public bool Edit(TableInfo ti)
        {
            return tiDal.Update(ti) > 0;
        }
    }
}
