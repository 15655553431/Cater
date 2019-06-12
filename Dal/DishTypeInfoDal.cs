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
    public class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sql = "select * from DishTypeInfo where dIsDelete=0";
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            //这里必须要用集合，我也不明白为什么，这个集合可以存放一些查询条件，用于拼接查询。
            //这里并没有用到拼接查询，集合是空的，但也不能用null代替，否则后面运行会报错。
            DataTable table = SqliteHelper.GetList(sql,listP.ToArray());
          
            //构造集合对象
            //定义一个集合用于转存数据
            List<DishTypeInfo> list = new List<DishTypeInfo>();

            //逐行遍历数据，将表中的数据存到集合中
            foreach (DataRow row in table.Rows)
            {
                //1.list.Add()
                //2.new Managerinfo()
                //3.对象的初始化
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DTitle = row["dtitle"].ToString(),

                });
            }
            //返回数据
            return list;
        }

        public int Insert(DishTypeInfo dti)
        {
            #region 构造sql语句（这个里面的都是,有语句,还要有参数）
            //1.构造insert语句
            //sqlite要求插入的列必须指定
            string sql = "insert into DishTypeInfo(dtitle,disdelete) values(@title,0)";
            //数组初始化器

            SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@title",dti.DTitle),
                
            };
            #endregion

            //执行
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int DeleteById(int id)
        {
            //逻辑删除，数据还在数据库中
            string sql = "update  DishTypeInfo set dIsDelete=1 where did=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        public int Update(DishTypeInfo dti)
        {
            string sql = "update  DishTypeInfo set dtitle=@title where did=@id";
            SQLiteParameter[] ps =
           {
               new SQLiteParameter("@id",dti.DId),
               new SQLiteParameter("@title",dti.DTitle),
            
           };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
