using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public  class HallInfoDal
    {
        public List<HallInfo> GetList()
        {
            //构造sql语句
            string sql = "select * from HallInfo where hIsDelete=0";
            //拼接查询，得到结果
           // List<SQLiteParameter> listP = new List<SQLiteParameter>();

            //执行查询，获取数据
            //这里突然发现，在传递参数的时候，可以只传一个spl语句，可以正常运行出正确结果
            DataTable table = SqliteHelper.GetList(sql);

            //构造集合对象
            //定义一个集合用于转存数据
            List<HallInfo> list = new List<HallInfo>();

            //逐行遍历数据，将表中的数据存到集合中
            foreach (DataRow row in table.Rows)
            {
                //1.list.Add()
                //2.new Managerinfo()
                //3.对象的初始化
                list.Add(new HallInfo()
                {
                    HId = Convert.ToInt32(row["hid"]),
                    HTitle = row["htitle"].ToString(),
                });
            }
            //返回数据
            return list;
        }

        public int Insert(HallInfo hi)
        {
            #region 构造sql语句（这个里面的都是,有语句,还要有参数）
            //1.构造insert语句
            //sqlite要求插入的列必须指定
            string sql = "insert into HallInfo(htitle,hisdelete) values(@title,0)";
            //数组初始化器

            SQLiteParameter p =new SQLiteParameter("@title", hi.HTitle);
            #endregion

            //执行
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        public int Update(HallInfo hi)
        {
            string sql = "update  HallInfo set htitle=@title where hid=@id";
            SQLiteParameter[] ps =
           {
               new SQLiteParameter("@id",hi.HId),
               new SQLiteParameter("@title",hi.HTitle),
              
           };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int DeleteById(int id)
        {
            //逻辑删除，数据还在数据库中
            string sql = "update  HallInfo set hIsDelete=1 where hid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);

            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
