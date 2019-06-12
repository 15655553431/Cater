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
    public partial class OrderInfoList : Form
    {
        private OrderInfoList()
        {
            InitializeComponent();
        }

        private static OrderInfoList oil;
        public static OrderInfoList Create()
        {
            if(oil==null||oil.IsDisposed)
            {
                oil = new OrderInfoList();
            }
            return oil;
        }

        //这里我定义一个全局变量orderFlag,用来检测在点菜或加菜后，是否点击了下单。未点击则为false，点击了就为true
        private bool orderFlag = true;


        private OrderInfoBll oiBll = new OrderInfoBll();
        private int orderId;//订单编号
        private int tableId;//桌子编号

        private void OrderInfoList_Load(object sender, EventArgs e)
        {
            //获取从主窗体传递过来的餐桌编号
            tableId = Convert.ToInt32(Tag);
            //根据餐桌编号获取餐桌名称和餐桌所属厅包的名称,在窗体上面进行结账提示！
            TableInfoBll tiBll = new TableInfoBll();
            TableInfo ti = new TableInfo();
            ti.TId = tableId;
            List<TableInfo> list=new List<TableInfo>();
            list=tiBll.GetList(ti);
            string tableTitleById = list[0].TTitle;
            string hallTypeById = list[0].HallType;
            this.Text = "您正在为【"+hallTypeById+"】的【"+tableTitleById+"】号餐桌进行点菜操作！";

            //根据餐桌编号，查询订单编号！（去Dal层封装一个方法）
            orderId = oiBll.GetOidByTid(tableId);

            //在菜单容器里面加载数据,封装一个方法
            //加载所有菜品信息
            LoadDishInfo();
            LoadDishTypeInfo();
            //加载所有已点菜品信息
            LoadOrderList();

        }

        private void LoadDishInfo()
        {
            //加载菜品数据容器
            DishInfoBll diBll=new DishInfoBll();
            DishInfo di = new DishInfo();
            //根据Dal的情况分析，这里需要构造一个空的对象进行查询，不能直接用null查询
            di.DTypeId = Convert.ToInt32(cbxDishType.SelectedValue);
            di.DChar = txtPy.Text;
            gvDishInfo.AutoGenerateColumns = false;
            gvDishInfo.DataSource = diBll.GetList(di);
        }

        private void LoadDishTypeInfo()
        {
            //加载菜品分类下拉框
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            var list = dtiBll.GetList();
            list.Insert(0, new DishTypeInfo()
            {
                DId = 0,
                DTitle = "全部",
            });
            cbxDishType.DisplayMember = "DTitle";
            cbxDishType.ValueMember = "DId";
            cbxDishType.DataSource = list;
        }

        private void txtPy_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void cbxDishType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfo();
        }

        private void gvDishInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int dishId = Convert.ToInt32(gvDishInfo.Rows[e.RowIndex].Cells[0].Value);

            //点菜
            if(oiBll.DianCai(orderId,dishId))
            {
                //点菜成功后，重新刷新已点菜单
                LoadOrderList();
            }
            //一旦对已点菜单进行了加菜或删除菜品操作，就需要重新点击下单
            orderFlag = false;
        }
        //加载已点菜品
        private void LoadOrderList()
        {
            gvOrderInfo.AutoGenerateColumns = false;
            gvOrderInfo.DataSource = oiBll.GetOrderDetail(orderId);
            GetOrderMoney();
        }
        //修改数量
        private void gvOrderInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row=gvOrderInfo.Rows[e.RowIndex];
            int oid = Convert.ToInt32(row.Cells[0].Value);
            int count = Convert.ToInt32(row.Cells[e.ColumnIndex].Value);

            if (oiBll.AddDishCount(oid, count)) 
            {
                GetOrderMoney();
            }
            //一旦对已点菜单进行了加菜或删除菜品操作，就需要重新点击下单
            orderFlag = false;
            
        }

        //计算总价
        private void GetOrderMoney()
        {
            decimal total = 0;
            var rows = gvOrderInfo.Rows;
            for (int i = 0; i < rows.Count;i++ )
            {
                int count = Convert.ToInt32(rows[i].Cells[2].Value);
                decimal price = Convert.ToInt32(rows[i].Cells[3].Value);
                total += count * price;
            }
            lblMoney.Text = total.ToString();
        }

        private void btnRemoveDish_Click(object sender, EventArgs e)
        {
            var row = gvOrderInfo.SelectedRows[0];
            int oid = Convert.ToInt32(row.Cells[0].Value);
            if(oiBll.RemoveDish(oid))
            {
                LoadOrderList();
            }
            //一旦对已点菜单进行了加菜或删除菜品操作，就需要重新点击下单
            orderFlag = false;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            decimal totalMoney = Convert.ToDecimal(lblMoney.Text);
            if (totalMoney > 0)//只有订单金额大于0时，才去下单，否则这个按钮无效
            {
                if (oiBll.XiaDan(orderId, totalMoney))
                {
                    //将餐桌图标变为就餐状态
                    GetTableFreeEvent();
                    //下单标志变成true
                    orderFlag = true;
                    //点击下单之后关闭当前窗体
                    this.Close();
                }
            }
        }

        //下单事件，点击下单之后，把餐桌状态改变
        public event Action GetTableFreeEvent;

        private void OrderInfoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Convert.ToDecimal(lblMoney.Text) > 0)//订单金额大于0，才会提醒，
            {
                if (!orderFlag)
                {
                    DialogResult result = MessageBox.Show("请点击【确定】立刻下单！完成点菜或加菜！如不需要下单，请【取消】！\n（你刚刚对已点菜品进行了更改，但并没有下单！）", "未下单提示", MessageBoxButtons.OKCancel);
                    //点击确认就相当于点击下单，点击取消就撤单
                    if (result == DialogResult.OK)
                    {
                        btnOrder_Click(null, null);
                    }

                }
            }
     
        }

        private void OrderInfoList_FormClosed(object sender, FormClosedEventArgs e)
        {

            //撤单操作，如果没有点击下单，就进行撤单操作
           bool test= oiBll.CheDan();
            //如果订单金额等于0，那就删除这个订单,同时还要让桌子变得空闲
            //这里有个问题，就是虽然点了菜，但是不想下单，虽然订单金额显示是大于0，但在进行撤单操作之后，实际订单金额已经为0，应该删除订单
            //另外一种情况是加菜，又不想加了，这时候实际订单金额不是0，不应该删除订单
           if (Convert.ToDecimal(lblMoney.Text) == 0||oiBll.GetMoneyByTid(tableId).ToString()=="0")
           {
               //删除订单
               bool test2 = oiBll.DeleteOrderByOId(orderId,tableId);
               
           }

        }


        //这里有个问题是，大家常常会忽略下单，或者在加菜之后忽略点击下单，这样在结账的时候，会漏掉已经加的菜.
        //这里我增加了一个窗口提示，点击确定之后就会直接下单。
        //问题就是点击取消之后，应该把刚刚增加的菜取消掉
        //在数据库中增加了一个判断下单的标志IsOrder


    }
}
