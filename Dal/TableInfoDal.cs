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
    public class TableInfoDal
    {
        public List<TableInfo> GetList(TableInfo ti)
        {
            //构造sql语句
            //链接查询，需要查到MTypeId的会员名称
            string sql = "select ti.*,hi.hTitle from TableInfo ti" +
                          " inner join hallinfo hi" +
                          " on ti.thallid=hi.hid" +
                         " where ti.tIsDelete=0";
            //拼接查询，得到结果
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if(ti.THallId>0)
            {
                sql += " and ti.THallId=@hid";
                listP.Add(new SQLiteParameter("@hid",ti.THallId));
            }
            if(ti.IsFreeSearch>-1)
            {
                sql += " and ti.TIsFree=@isFree";
                listP.Add(new SQLiteParameter("@isFree",ti.IsFreeSearch));
            }
            if(ti.TId!=0)//这里用来拼接查询，根据餐桌ID查询餐桌名称和所属包厅，在点菜时使用。
            {
                sql += " and ti.TId=@id";
                listP.Add(new SQLiteParameter("@id",ti.TId));
            }
            //if (!string.IsNullOrEmpty(mei.MName))
            //{
            //    //模糊查询
            //    sql += " and mei.mname like @name";
            //    listP.Add(new SQLiteParameter("@name", "%" + mei.MName + "%"));

            //}
            //if (!string.IsNullOrEmpty(mei.MPhone))
            //{
            //    sql += " and mei.mphone like @phone";
            //    listP.Add(new SQLiteParameter("@phone", "%" + mei.MPhone + "%"));
            //}

            sql += " order by ti.tid desc";
            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql,listP.ToArray());

            //构造集合对象
            //定义一个集合用于转存数据
            List<TableInfo> list = new List<TableInfo>();

            //逐行遍历数据，将表中的数据存到集合中
            foreach (DataRow row in table.Rows)
            {
                //1.list.Add()
                //2.new Managerinfo()
                //3.对象的初始化
                list.Add(new TableInfo()
                {
                    TId = Convert.ToInt32(row["tid"]),
                    THallId = Convert.ToInt32(row["thallid"]),
                    TTitle = row["ttitle"].ToString(),
                    TIsFree = Convert.ToBoolean(row["tisfree"]),
                    HallType = row["htitle"].ToString(),
                });
            }
            //返回数据
            return list;
        }

        public int DeleteById(int id)
        {
            //逻辑删除，数据还在数据库中
            string sql = "update  TableInfo set tIsDelete=1 where tid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        public int Insert(TableInfo ti)
        {
            string sql = "insert into Tableinfo(thallid,ttitle,tisfree,tisDelete) values(@hallid,@title,@isfree,0)";

            SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@hallid",ti.THallId),
                new SQLiteParameter("@title",ti.TTitle),
                new SQLiteParameter("@isfree",ti.TIsFree),
                
            };
            //执行
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int Update(TableInfo ti)
        {
            string sql = "update  TableInfo set ttitle=@title,thallId=@hallId,tisfree=@isfree where tid=@id";
            SQLiteParameter[] ps =
           {
               new SQLiteParameter("@id",ti.TId),
               new SQLiteParameter("@title",ti.TTitle),
               new SQLiteParameter("@hallId",ti.THallId),
               new SQLiteParameter("@isfree",ti.TIsFree),
           
           };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
