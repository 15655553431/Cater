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
   public class MemberTypeInfoDal
    {
       public List<MemberTypeInfo> GetList()
       {
           //构造sql语句
           string sql = "select * from MemberTypeInfo where mIsDelete=0";
           //拼接查询，得到结果
           List<SQLiteParameter> listP = new List<SQLiteParameter>();
           //if (mti != null)
           //{
           //    sql += "and mtitle=@title and mdiscount=@discount";
           //    listP.Add(new SQLiteParameter("@title", mti.MTitle));
           //    listP.Add(new SQLiteParameter("@discount", mti.MDiscount));
           //}

           //执行查询，获取数据
           DataTable table = SqliteHelper.GetList(sql,listP.ToArray());

           //构造集合对象
           //定义一个集合用于转存数据
           List<MemberTypeInfo> list = new List<MemberTypeInfo>();

           //逐行遍历数据，将表中的数据存到集合中
           foreach (DataRow row in table.Rows)
           {
               //1.list.Add()
               //2.new Managerinfo()
               //3.对象的初始化
               list.Add(new MemberTypeInfo()
               {
                   MId = Convert.ToInt32(row["mid"]),
                   MTitle = row["mtitle"].ToString(),
                   MDiscount =Convert.ToDecimal( row["mdiscount"]),
                 
               });
           }
           //返回数据
           return list;
       }

       public int Insert(MemberTypeInfo mti)
       {

           #region 构造sql语句（这个里面的都是,有语句,还要有参数）
           //1.构造insert语句
           //sqlite要求插入的列必须指定
           string sql = "insert into MemberTypeInfo(mtitle,mdiscount,misdelete) values(@title,@discount,0)";
           //数组初始化器

           SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@title",mti.MTitle),
                new SQLiteParameter("@discount",mti.MDiscount),
            };
           #endregion

           //执行
           return SqliteHelper.ExecuteNonQuery(sql, ps);


       }

       public int DeleteById(int id)
       {
           //逻辑删除，数据还在数据库中
           string sql = "update  MemberTypeInfo set mIsDelete=1 where mid=@id";
           SQLiteParameter p = new SQLiteParameter("@id", id);
            
           return SqliteHelper.ExecuteNonQuery(sql, p);
       }

       public int Update(MemberTypeInfo mti)
       {
           string sql = "update  MemberTypeInfo set mtitle=@title,mdiscount=@discount where mid=@id";
           SQLiteParameter[] ps =
           {
               new SQLiteParameter("@id",mti.MId),
               new SQLiteParameter("@title",mti.MTitle),
               new SQLiteParameter("@discount",mti.MDiscount),
           };
           return SqliteHelper.ExecuteNonQuery(sql, ps);
       }

    }
}
