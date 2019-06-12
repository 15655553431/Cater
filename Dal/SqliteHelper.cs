using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class SqliteHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["cater"].ConnectionString;

        //查询数据
        public static DataTable GetList(string sql,params SQLiteParameter[] ps)
        {
            //构造连接对象
            using(SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                //SQLiteCommand cmd=new SQLiteCommand(sql,conn);
                //conn.Open();
                //SQLiteDataReader reader= cmd.ExecuteReader();

                //构造桥接器（adapter）对象
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql,conn);

                //添加参数
                   adapter.SelectCommand.Parameters.AddRange(ps);
               
                //数据表对象
                DataTable table = new DataTable();
                //将数据存到table中，返回
                adapter.Fill(table);
                //返回数据表
                return table;
            }
        }

        //添加数据
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using(SQLiteConnection conn=new SQLiteConnection(connStr) )
            {
                SQLiteCommand cmd = new SQLiteCommand(sql,conn);
                cmd.Parameters.AddRange(ps);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //查询首行首列
        public static object ExecuteScalar(string sql,params SQLiteParameter[] ps)
        {
            using(SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql,conn);
                cmd.Parameters.AddRange(ps);
                conn.Open();

                return cmd.ExecuteScalar();
            }
        }

    }
}
