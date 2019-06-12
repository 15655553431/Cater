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
    public class MemberInfoDal
    {
        public List<MemberInfo> GetList(MemberInfo mei)
        {
            //构造sql语句
            //链接查询，需要查到MTypeId的会员名称
            string sql = "select mei.*,mti.mTitle,mti.mDiscount from MemberInfo mei"+
                          " inner join membertypeinfo mti"+
                          " on mei.mtypeid=mti.mid"+
                         " where mei.mIsDelete=0";
            //拼接查询，得到结果
            List<SQLiteParameter> listP = new List<SQLiteParameter>();
            if (!string.IsNullOrEmpty(mei.MName))
            {
                //模糊查询
                sql += " and mei.mname like @name";
                listP.Add(new SQLiteParameter("@name","%"+mei.MName+"%"));
                
            }
            if(!string.IsNullOrEmpty(mei.MPhone))
            {
                sql += " and mei.mphone like @phone";
                listP.Add(new SQLiteParameter("@phone","%"+mei.MPhone+"%"));
            }

            //执行查询，获取数据
            DataTable table = SqliteHelper.GetList(sql,listP.ToArray());

            //构造集合对象
            //定义一个集合用于转存数据
            List<MemberInfo> list = new List<MemberInfo>();

            //逐行遍历数据，将表中的数据存到集合中
            foreach (DataRow row in table.Rows)
            {
                //1.list.Add()
                //2.new Managerinfo()
                //3.对象的初始化
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MTypeId = Convert.ToInt32(row["mtypeid"]),
                    MName = row["mname"].ToString(),
                    MPhone=row["mphone"].ToString(),
                    MMoney=Convert.ToDecimal(row["mmoney"]),
                    TypeTitle=row["mtitle"].ToString(),
                    TypeDiscount=Convert.ToDecimal(row["mDiscount"]),

                });
            }
            //返回数据
            return list;
        }
        
        public int Insert(MemberInfo mei)
        {
            string sql = "insert into memberinfo(mtypeid,mname,mphone,mmoney,misDelete) values(@tid,@name,@phone,@money,0)";

            SQLiteParameter[] ps = 
            {
                new SQLiteParameter("@tid",mei.MTypeId),
                new SQLiteParameter("@name",mei.MName),
                new SQLiteParameter("@phone",mei.MPhone),
                new SQLiteParameter("@money",mei.MMoney),
            };
            

           //执行
           return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int UpDate(MemberInfo mei)
        {
            string sql = "update  MemberInfo set mname=@name,mtypeId=@typeId,mphone=@phone,mmoney=@money where mid=@id";
            SQLiteParameter[] ps =
           {
               new SQLiteParameter("@id",mei.MId),
               new SQLiteParameter("@name",mei.MName),
               new SQLiteParameter("@typeId",mei.MTypeId),
               new SQLiteParameter("@phone",mei.MPhone),
               new SQLiteParameter("@money",mei.MMoney),
           };
            return SqliteHelper.ExecuteNonQuery(sql, ps);
        }

        public int DeleteById(int id)
        {
            //逻辑删除，数据还在数据库中
            string sql = "update  MemberInfo set mIsDelete=1 where mid=@id";
            SQLiteParameter p = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }
    }
}
