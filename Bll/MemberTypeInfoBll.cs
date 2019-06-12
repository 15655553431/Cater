using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public  class MemberTypeInfoBll
    {
       MemberTypeInfoDal mtiDal = new MemberTypeInfoDal();

       public List<MemberTypeInfo> GetList()
       {
           return mtiDal.GetList();
       }

       public bool Add(MemberTypeInfo mti)
       {
           return mtiDal.Insert(mti) > 0;
       }

       public bool Remove(int id)
       {
           return mtiDal.DeleteById(id) > 0;
       }

       public bool Edit(MemberTypeInfo mti)
       {
           return mtiDal.Update(mti)>0;
       }
    }
}
