using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class OrderDishList : Form
    {
        private  OrderDishList()
        {
            InitializeComponent();
        }

        private static OrderDishList odl;
        public static OrderDishList Create()
        {
            if(odl==null||odl.IsDisposed)
            {
                odl = new OrderDishList();
            }
            return odl;
        }

        private void OrderDishList_Load(object sender, EventArgs e)
        {
            //根据餐桌编号获取餐桌名称和餐桌所属厅包的名称,在窗体上面进行提示！
            TableInfoBll tiBll = new TableInfoBll();
            TableInfo ti = new TableInfo();
            ti.TId = Convert.ToInt32(this.Tag);
            List<TableInfo> list = new List<TableInfo>();
            list = tiBll.GetList(ti);
            string tableTitleById = list[0].TTitle;
            string hallTypeById = list[0].HallType;
            lblOrderDish.Text = "正在查看【" + hallTypeById + "】【" + tableTitleById + "】号的点菜详情！";
            this.Text = "【" + hallTypeById + "】【" + tableTitleById + "】";

            //加载所有已点菜品，包含未下单的
            OrderInfoBll oiBll = new OrderInfoBll();
            //根据餐桌id获取订单id
            int orderId = oiBll.GetOidByTid(Convert.ToInt32(this.Tag));
            gvOrderDishInfo.AutoGenerateColumns = false;
            gvOrderDishInfo.DataSource = oiBll.GetOrderDetail(orderId);
            //计算点菜总金额
            GetOrderMoney();
        }
        private void GetOrderMoney()
        {
            decimal total = 0;
            var rows = gvOrderDishInfo.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                int count = Convert.ToInt32(rows[i].Cells[2].Value);
                decimal price = Convert.ToInt32(rows[i].Cells[3].Value);
                total += count * price;
            }
            lblMoney.Text = total.ToString()+"元";
        }
    }
}
