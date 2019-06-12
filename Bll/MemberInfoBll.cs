using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class MemberInfoBll
    {
        private MemberInfoDal meiDal = new MemberInfoDal();
        public List<MemberInfo> GetList(MemberInfo mei)
        {
            return meiDal.GetList(mei);
        }

        public bool Add(MemberInfo mei)
        {
            return meiDal.Insert(mei) > 0;
        }

        public bool Edit(MemberInfo mei)
        {
            return meiDal.UpDate(mei)>0;
        }

        public bool Remove(int id)
        {
            return meiDal.DeleteById(id) > 0;
        }

    }
}
