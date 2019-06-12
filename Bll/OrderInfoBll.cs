using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class OrderInfoBll
    {
        private OrderInfoDal oiDal = new OrderInfoDal();
        public bool Kaidan(int tableId)
        {
            return oiDal.Insert(tableId) > 0;
        }

        public int GetOidByTid(int tid)
        {
            return oiDal.GetOidByTid(tid);
        }

        //点菜
        public bool DianCai(int orderId, int dishId)
        {
            return oiDal.DianCai(orderId,dishId) > 0;
        }

         //获得所有订单数据，以便存储到xls表格，导出数据
        public List<OrderInfo> GetOrderInfo()
        {
            return oiDal.GetOrderInfo();
        }
        //清理缓存，这里需要删除所有已付过钱的菜品和订单
       
        //获得订单详细情况
        public List<OrderDetailInfo> GetOrderDetail(int orderId)
        {
            return oiDal.GetOrderDetail(orderId);
        }


        //修改已点菜品数量
        public bool AddDishCount(int oid, int count)
        {
            return oiDal.UpdateDishCount(oid,count) > 0;
        }

        //删除已点的菜品数量
        public bool RemoveDish(int oid)
        {
            return oiDal.DeleteDish(oid) > 0;
        }
        //下单操作
        public bool XiaDan(int orderId, decimal totalMoney)
        {
            return oiDal.XiaDan(orderId,totalMoney) > 0;
        }

        //通过TableID获得订单消费金额，主要在结账界面使用，这里查询的是实际下单的金额，
        public decimal GetMoneyByTid(int tid)
        {
            return oiDal.GetOMoneyByTid(tid);
        }

        //结账操作
        public bool JieZhang(int tableId, int memberId, decimal discount, decimal payMoney)
        {
            return oiDal.JieZhang(tableId,memberId,discount,payMoney) > 0;
        }

        //撤单操作
        public bool CheDan()
        {
            return oiDal.CheDan() > 0;
        }

        //删除订单
        public bool DeleteOrderByOId(int orderId,int tableId)
        {
            return oiDal.DeleteOrderById(orderId,tableId) > 0;
        }
    }
}
