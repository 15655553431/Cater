using Common;
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
    public  class ManagerinfoDal
    {
        public List<Managerinfo> GetList(Managerinfo mi)
        {
            //构造sql语句
            string sql = "select * from Managerinfo";
            //拼接查询，得到结果
            List<SQLiteParameter> listP=new List<SQLiteParameter>();
            if(mi!=null)
            {
                sql += " where mname=@name and mpwd=@pwd";
                listP.Add( new SQLiteParameter("@name",mi.MName));
                listP.Add(new SQLiteParameter("@pwd", MD5Helper.GetMd5(mi.MPwd)));
            }
            
        
                //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql,listP.ToArray());
       

            //构造集合对象
            //定义一个集合用于转存数据
            List<Managerinfo>  list=new List<Managerinfo>();

            //逐行遍历数据，将表中的数据存到集合中
            foreach(DataRow row in table.Rows)
            {
                //1.list.Add()
                //2.new Managerinfo()
                //3.对象的初始化
                list.Add(new Managerinfo()
                {
                    MId=Convert.ToInt32(row["mid"]),
                    MName=row["mname"].ToString(),
                    MPwd=row["mpwd"].ToString(),
                    MType=Convert.ToInt32(row["mtype"])
                });
            }
            //返回数据
            return list;
        }

        public int Insert(Managerinfo mi)
        {
            
            #region 构造sql语句（这个里面的都是,有语句,还要有参数）
            //1.构造insert语句
            //sqlite要求插入的列必须指定
            string sql = "insert into Managerinfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            //数组初始化器
            
            SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@pwd",MD5Helper.GetMd5(mi.MPwd)),
                new SQLiteParameter("@type",mi.MType),
            };
            #endregion

            //执行
            return SqliteHelper.ExecuteNonQuery(sql, ps);


        }

        public int DeleteById(int id)
        {
            string sql = "delete from Managerinfo where mid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        public int Update(Managerinfo mi)
        {
            //这里要注意，密码是否修改必须判断后，进行不同的处理！
            string sql = "update Managerinfo set mid=@id,mname=@name,";
            List<SQLiteParameter> list=new List<SQLiteParameter>();
            list.Add(new SQLiteParameter("@id", mi.MId));
            list.Add(new SQLiteParameter("@name",mi.MName));
            if(!mi.MPwd.Equals("******"))
            {
                sql += "mpwd=@pwd,";
                list.Add(new SQLiteParameter("@pwd", MD5Helper.GetMd5(mi.MPwd)));
            }
            sql += "mtype=@type where mid=@id";
            list.Add(new SQLiteParameter("@type", mi.MType));
           
            return SqliteHelper.ExecuteNonQuery(sql, list.ToArray());
            //int b = -1;
            //if (mi.MPwd.Equals("******"))
            //{
            //    sql += "mtype=@type where mid=@id";
            //    SQLiteParameter[] ps = 
            //   {
            //    new SQLiteParameter("@id",mi.MId),
            //    new SQLiteParameter("@name",mi.MName),
            //    new SQLiteParameter("@type",mi.MType),
            //    };
            //    b = SqliteHelper.ExecuteNonQuery(sql, ps);
            //}
            //else
            //{
            //    sql += "mpwd=@pwd,mtype=@type where mid=@id";
            //    SQLiteParameter[] ps = 
            //   {
            //    new SQLiteParameter("@id",mi.MId),
            //    new SQLiteParameter("@name",mi.MName),
            //    new SQLiteParameter("@pwd",MD5Helper.GetMd5(mi.MPwd)),
            //    new SQLiteParameter("@type",mi.MType),
            //   };
            //    b = SqliteHelper.ExecuteNonQuery(sql, ps);
            //}
            
            //return b;
        }
    }
}
