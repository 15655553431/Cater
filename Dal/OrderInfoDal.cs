using Model;
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
    public class OrderInfoDal
    {
        //获得所有订单数据，以便存储到xls表格，导出数据
        public List<OrderInfo> GetOrderInfo()
        {
            //连接查询，根据订单编号查到会员名称，会员手机号
            //这样查询，只能查到会员点菜记录，非会员查询不到
            string sql = "select oi.*,mei.MName,mei.MPhone" +
                          " from orderInfo oi" +
                          " inner join MemberInfo mei" +
                          " on oi.memberid=mei.mid" +
                          " where oi.ispay=1 and omoney is NOT NULL";
           // inner join MemberInfo mei
            DataTable dt = SqliteHelper.GetList(sql);

            //查询一般客户订餐记录
            sql = "select * from orderInfo where memberId is NULL and ispay=1 and omoney is NOT NULL";
            //这里NULL必须用大写，这里之所以让订单金额不能为空，担心有意外导致的金额为空
          DataTable dt2 = SqliteHelper.GetList(sql);

            List<OrderInfo> list = new List<OrderInfo>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new OrderInfo()
                {
                    OId = Convert.ToInt32(row["oid"]),
                    ODate = Convert.ToDateTime(row["odate"]),
                    MemberName = row["mname"].ToString(),
                    MemberPhone = row["mphone"].ToString(),
                    OMoney = Convert.ToDecimal(row["omoney"]),
                });

            }
            foreach (DataRow row in dt2.Rows)
            {
                list.Add(new OrderInfo()
                {
                    OId = Convert.ToInt32(row["oid"]),
                    ODate = Convert.ToDateTime(row["odate"]),
                    MemberName = "普通客户",
                    MemberPhone = "10000000000",
                    OMoney = Convert.ToDecimal(row["omoney"]),
                });

            }
            return list;

        }

        public int DeleteOrder()
        {
            //要先删除OrderDetailInfo表中的信息，
            //再删除OrderInfo表中的信息
            string sql = "delete odi from OrderDetailInfo odi inner join OrderInfo oi" +
                            "on odi.orderId=oi.oid"+
                           " where oi.ispay=1";
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        //开单操作，实际 就是插入数据。只需要接受一个tableid数据,这里一旦开单，我就把订单金额设为0
        public int Insert(int tableId)
        {
            string sql = "insert into orderinfo(odate,ispay,tableId,omoney) values(datetime('now','localtime'),0,@tid,0);"+
                "update tableinfo set tIsFree=0 where tid=@tid";
            SQLiteParameter p = new SQLiteParameter("@tid",tableId);
            return SqliteHelper.ExecuteNonQuery(sql, p);
        }

        //根据餐桌编号，获得订单编号
        public int GetOidByTid(int tid)
        {
            string sql = "select oid from orderinfo where tableid=@tid and ispay=0";
            SQLiteParameter p = new SQLiteParameter("@tid",tid);

            //然后去SqliteHelper类中加一个获得首行首列的方法
            return Convert.ToInt32(SqliteHelper.ExecuteScalar(sql,p));
        }

        //点菜操作
        public int DianCai(int orderId,int dishId)
        {
            //点菜的优化，如果已经点过了，就数量加1，
            string sql = "select count(*) from orderDetailInfo where orderid=@oid and dishid=@did";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid",orderId),
                new SQLiteParameter("@did",dishId),
            };
            int count = Convert.ToInt32(SqliteHelper.ExecuteScalar(sql,ps));
            if(count==0)
            {
                //当前订单中没有此菜品,则进行添加
                sql = "insert into orderDetailInfo(orderid,dishid,count,isorder) values(@oid,@did,1,0)";
            }
            else
            {
                //当前订单中已经存在此菜品，进行数量更新
                sql = "update orderDetailInfo set count=count+1 where orderid=@oid and dishid=@did";
            }
     
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }

        //获得订单详细信息
        public List<OrderDetailInfo> GetOrderDetail(int orderId)
        {
            //连接查询，根据订单的编号查到所有已点菜的名称和价格
            string sql = "select odi.*,di.DTitle,di.DPrice"+
                          " from orderDetailInfo odi"+
                          " inner join dishInfo di"+
                          " on odi.dishid=di.did"+
                          " where odi.orderid=@oid";

            SQLiteParameter p = new SQLiteParameter("@oid",orderId);

            DataTable dt = SqliteHelper.GetList(sql, p);

            List<OrderDetailInfo> list = new List<OrderDetailInfo>();
            foreach(DataRow row in dt.Rows)
            {
                list.Add(new OrderDetailInfo()
                    {
                        OId=Convert.ToInt32(row["oid"]),
                        OrderId=orderId,
                        DishId=Convert.ToInt32(row["dishid"]),
                        Count=Convert.ToInt32(row["count"]),
                        DishTitle=row["dtitle"].ToString(),
                        DishPrice=Convert.ToInt32(row["dprice"]),
                    });
            }


            return list;
        }

        //修改已点菜品数量
        public int UpdateDishCount(int oid,int count)
        {
            string sql = "update orderDetailInfo set count=@count where oid=@oid";

            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@count",count),
                new SQLiteParameter("@oid",oid),
            };

            return SqliteHelper.ExecuteNonQuery(sql,ps);

        }

        //删除已点菜品
        public int DeleteDish(int oid)
        {
            string sql = "delete from orderDetailInfo where oid=@oid";
            SQLiteParameter p=new SQLiteParameter("@oid",oid);

            return SqliteHelper.ExecuteNonQuery(sql,p);
        }

        //确定下单方法,实际就是根据orderid和计算的Money的值，来更新Omoney数据。
        public int XiaDan(int orderId,decimal totalMoney)
        {
            string sql = "update orderinfo set omoney=@totalMoney where oid=@oid";
            string sql2 = "update OrderDetailInfo set isorder=1 where OrderId=@oid";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@oid",orderId),
                new SQLiteParameter("@totalMoney",totalMoney),
            };
            SqliteHelper.ExecuteNonQuery(sql2, ps[0]); 
            return SqliteHelper.ExecuteNonQuery(sql,ps);
        }

        //当服务员点过菜，但是并没有下单时，需要撤单操作，把之前点的菜都从菜单上删除
        //这里只需要一个订单编号，用来查询撤销的菜，消费金额保持原来的不变
        public int CheDan()
        {
            //实际就是直接删除，不管你的订单编号多少，只要没下单的，都删除
            //这里只是删除没有下单的菜品，但订单编号还是保留的。
            string sql = "delete from orderDetailInfo where isorder=0";  
            return SqliteHelper.ExecuteNonQuery(sql);
        }

        //删除订单，当双击桌子进行开单之后，如果总金额为0，就关闭点菜窗口了，就删除订单，同时还要改变桌子的空闲状态
        public int DeleteOrderById(int orderId,int tableId)
        {
            string sql = "delete from orderInfo where oid="+orderId;
            int test = SqliteHelper.ExecuteNonQuery(sql);
            string sql2 = "update tableinfo set tIsFree=1 where tid="+tableId;
            return SqliteHelper.ExecuteNonQuery(sql2);
        }


        //根据餐桌编号，查询出当前餐桌的消费金额，在结账界面调用
        public decimal GetOMoneyByTid(int tid)
        {
            string sql = "select oMoney from orderinfo where tableid=@tid and ispay=0";
            SQLiteParameter p = new SQLiteParameter("@tid", tid);

            //然后去SqliteHelper类中加一个获得首行首列的方法
            return Convert.ToDecimal(SqliteHelper.ExecuteScalar(sql, p));
        }

        //根据餐桌编号、会员编号、会员折扣、应付金额进行结账操作,开事务
        public int JieZhang(int tableId,int memberId,decimal discount,decimal payMoney)
        {
            //这里和开事务有关，然而我并不懂，需要查资料去详细了解一下，再回来做注释。时间：20170512
            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["cater"].ConnectionString))
            {
                conn.Open();
                //开启事务
                SQLiteTransaction tran = conn.BeginTransaction();
                int counter = 0;
                try
                {
                    //创建command对象，并与事务相关联。执行语句,用上事务.
                    //让cmd和事务连起来，事务由连接对象创建，那么cmd就和连接对象连起来了，这里如果不懂就暂时记住
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Transaction = tran;

                    //1.更改订单状态  ispay=1
                    string sql = "update orderinfo set ispay=1";
                    //如果是会员，就记录下来
                    if(memberId>0)
                    {
                        sql += ",memberId="+memberId+",discount="+discount;
                    }
                    
                    //根据餐桌编号和未支付订单查询结果
                    sql += " where tableId="+tableId+" and ispay=0";
                    //指定命令
                    cmd.CommandText = sql;
                    //执行命令，把受影响的行数给counter
                    counter += cmd.ExecuteNonQuery();


                    //2.将餐桌状态更改为1，即空闲
                    sql = "update tableInfo set tisFree=1 where tid="+tableId;
                    //指定命令
                    cmd.CommandText = sql;
                    //执行命令，把受影响的行数给counter
                    counter += cmd.ExecuteNonQuery();


                    //3.如果使用余额付款结账，则更新会员余额
                    //这里如果我们传过来的付款金额是有的，那我就认为是用余额结账的，如果传来的付款金额是0，就没有用余额
                    if(payMoney>=0)
                    {
                        //这里要注意一点，余额减去实际消费金额，得出结果不能是负值，也就是保证余额不能是负值，
                        //后期导出数据时发现这里必须要等于0，因为如果选择了会员但是没有使用会员付款，会导致数据库结账出现空值
                        //这里我们选择的解决方法是，在Ui层进行判断，
                        //如果余额小于付款金额，那么pagmoney的值，我只传余额的最大值，余额不够的，再付现金
                        sql = "update memberinfo set mMoney=mMoney-"+payMoney+" where mid="+memberId;
                        //指定命令
                        cmd.CommandText = sql;
                        //执行命令，把受影响的行数给counter
                        counter += cmd.ExecuteNonQuery();
                    }
                    //4.更改结账的餐桌状态图片
                    //这件事在Dal是无法完成，在UI层去实现


                    //操作成功，则提交确定之前所有操作 
                    tran.Commit();
                }
                catch
                {
                    counter = 0;
                    //一旦出错，则回滚，放弃之前所有的操作
                    tran.Rollback();
                }
                return counter;
            }

        }
    }
}
