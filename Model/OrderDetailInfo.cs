using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetailInfo
    {
        public int OId
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        public int DishId
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }

        public Boolean IsOrder
        {
            get;
            set;
        }

        //以下是数据库中没有的，只是用来存储连接查询的结果的
        public string DishTitle
        {
            get;
            set;
        }
        public decimal DishPrice
        {
            get;
            set;
        }
    }
}
