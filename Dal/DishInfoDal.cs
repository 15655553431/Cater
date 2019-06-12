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
    public class DishInfoDal
    {
        public List<DishInfo> GetList(DishInfo di)
        {
            //构造sql语句
            //链接查询，需要查到MTypeId的会员名称
            string sql = "select di.*,dti.dTitle as typetitle from DishInfo di" +
                          " inner join dishtypeinfo dti" +
                          " on di.dtypeid=dti.did" +
                         " where di.dIsDelete=0";
            //拼接查询，得到结果
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (!string.IsNullOrEmpty(di.DTitle))
            {
                //模糊查询
                sql += " and di.dtitle like @title";
                listP.Add(new SQLiteParameter("@title", "%" + di.DTitle + "%"));

            }
            if (di.DTypeId>0)
            {
                sql += " and di.dtypeid like @typeid";
                listP.Add(new SQLiteParameter("@typeid", "%" + di.DTypeId + "%"));
            }
            //在点餐的时候根据拼音首字母查询
            if(!string.IsNullOrEmpty(di.DChar))
            {
                //模糊查询
                sql += " and di.dchar like @char";
                listP.Add(new SQLiteParameter("@char", "%" + di.DChar + "%"));
            }

            sql += " order by di.did desc";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql, listP.ToArray());

            //构造集合对象
            //定义一个集合用于转存数据
            List<DishInfo> list = new List<DishInfo>();

            //逐行遍历数据，将表中的数据存到集合中
            foreach (DataRow row in table.Rows)
            {
                //1.list.Add()
                //2.new Managerinfo()
                //3.对象的初始化
                list.Add(new DishInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DTypeId = Convert.ToInt32(row["dtypeid"]),
                    DTitle = row["dtitle"].ToString(),
                    DChar = row["dchar"].ToString(),
                    DPrice = Convert.ToDecimal(row["dprice"]),
                    TypeTitle=row["typetitle"].ToString(),

                });
            }
            //返回数据
            return list;
        }

        public int Update(DishInfo di)
        {
            string sql = "update  DishInfo set dtitle=@title,dtypeId=@typeId,dprice=@price,dchar=@char where did=@id";
            SQLiteParameter[] ps =
           {
               new SQLiteParameter("@id",di.DId),
               new SQLiteParameter("@title",di.DTitle),
               new SQLiteParameter("@typeId",di.DTypeId),
               new SQLiteParameter("@price",di.DPrice),
               new SQLiteParameter("@char",di.DChar),
           };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Insert(DishInfo di)
        {
            string sql = "insert into dishinfo(dtypeid,dtitle,dprice,dchar,disDelete) values(@tid,@title,@price,@char,0)";

            SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@tid",di.DTypeId),
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@char",di.DChar),
            };
            //执行
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int DeleteById(int id)
        {
            //逻辑删除，数据还在数据库中
            string sql = "update  DishInfo set dIsDelete=1 where did=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
