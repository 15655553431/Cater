using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class MemberInfo
    {
        public int MId
        {
            get;
            set;
        }

        public int MTypeId
        {
            get;
            set;
        }

        public string MName
        {
            get;
            set;
        }

        public string MPhone
        {
            get;
            set;
        }

        public decimal MMoney
        {
            get;
            set;
        }

        public Boolean MIsDelete
        {
            get;
            set;
        }
        
        //这不是表中有的列，目的是做链接查询的时候，存放结果的
        public string TypeTitle
        {
            get;
            set;
        }
        public decimal TypeDiscount
        {
            get;
            set;
        }
    }
}
