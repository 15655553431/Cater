using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class TableState
        //餐桌空闲状态
    {
        public int State
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        //构造方法
        public TableState(int state,string title)
        {
            State = state;
            Title = title;
        }
    }
}
