using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public  class ManagerinfoBll
    {
        //设为全局对象，Dal数据访问层的对象
        ManagerinfoDal miDal = new ManagerinfoDal();

        public List<Managerinfo> GetList()
        {
            
            return miDal.GetList(null);
        }
        //接受一个对象，层与层之间通过Model层的对象传递
        public bool Add(Managerinfo mi)
        {
            return miDal.Insert(mi) > 0;
        }

        public bool Remove(int id)
        {
           return miDal.DeleteById(id) > 0;
        }

        public bool Edit(Managerinfo mi)
        {
            return miDal.Update(mi) > 0;
        }

        public bool Login(Managerinfo mi)
        {
            var list = miDal.GetList(mi);
            if (list.Count > 0)
            {
                mi.MType = list[0].MType;
                //获得登录对象的类型。              
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
