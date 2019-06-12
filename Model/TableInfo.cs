using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TableInfo
    {
        public int TId
        {
            get;
            set;
        }

        public string TTitle
        {
            get;
            set;
        }

        public int THallId
        {
            get;
            set;
        }

        public bool TIsFree
        {
            get;
            set;
        }

        public bool TIsDelete
        {
            get;
            set;
        }
        //实际数据库中不存在，这里只是为了存储连接查询出的结果
        public string HallType
        {
            get;
            set;
        }

        public int IsFreeSearch
        {
            get;
            set;
        }
    }

}
