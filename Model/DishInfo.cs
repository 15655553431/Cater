using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DishInfo
    {
        public int DId
        {
            get;
            set;
        }

        public string DTitle
        {
            get;
            set;
        }

        public int DTypeId
        {
            get;
            set;
        }

        public decimal DPrice
        {
            get;
            set;
        }

        public string DChar
        {
            get;
            set;
        }

        public bool DIsDelete
        {
            get;
            set;
        }
        //实际数据库中并不存在，这里只是为了存储值
        public string TypeTitle
        {
            get;
            set;
        }
    }
}
