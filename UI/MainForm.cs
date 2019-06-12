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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //申明一个全局的私有变量，当我选中一个餐桌的时候，就把点击的项赋值给itemtable，
        //ListViewItem类表示你当前选中的选项卡里面的一个餐桌信息
        private ListViewItem itemTable;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(this.Tag.ToString()=="0")
            {
                menuManager.Visible=false;
            }

            LoadHallInfo();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuManager_Click(object sender, EventArgs e)
        {
            FormManagerList miList = FormManagerList.Create();
            miList.Show();
            miList.Focus();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuMember_Click(object sender, EventArgs e)
        {
            MemberList memberinfo = MemberList.Create();
            memberinfo.Show();
            memberinfo.Focus();

        }

        private void menuDish_Click(object sender, EventArgs e)
        {
            DishInfoList Dil = DishInfoList.Create();
            Dil.Show();
            Dil.Focus();
        }

        private void menuTable_Click(object sender, EventArgs e)
        {
            TableInfoList til = TableInfoList.Create();
            til.Show();
            til.Focus();
        }

        //加载所有所有厅包信息
        private void LoadHallInfo()
        {
            HallInfoBll hiBll = new HallInfoBll();
            var list = hiBll.GetList();


            foreach(var hallInfo in list)
            {
                TabPage page = new TabPage(hallInfo.HTitle);
                page.Tag = hallInfo.HId;//给当前选项卡页tag属性存储餐桌所属的包房编号，给下面根据包房编号查询包房下面的所有餐桌
                tabHall.TabPages.Add(page);
            }
            tabHall_SelectedIndexChanged(null,null);//调用一下这个事件方法，直接触发事件
            
        }

        //厅包选择改变之后，加载当前厅包下的所有餐桌
        private void tabHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            //操作过程：选择一个Tabpage，然后根据当前选中的tabpage存储的厅包编号，查找里面的餐桌，然后创建ListView，
            //加入所有的餐桌，再将ListView加到当前选中的TagPage
            //1、获取选中的tabpage
            var tabpage = tabHall.SelectedTab;//获取当前选定的选项卡页，tabHall就是一个控件，tabpage表示当前选定的选项卡
            int hallId = Convert.ToInt32(tabpage.Tag);//这里不懂看上面，这通过tag把厅包编号传过来

            //2、查询餐桌
            TableInfoBll tiBll = new TableInfoBll();//构造业务逻辑层对象，根据条件查询
            //构造搜索条件
            int hid = hallId;           
            TableInfo tiSearch = new TableInfo();
            tiSearch.THallId = hid;//厅包的条件
            tiSearch.IsFreeSearch = -1;//显示所有餐桌
            //根据上面的查询条件，这里获得的是当前厅包下面的所有餐桌信息的集合
            var listTableInfo = tiBll.GetList(tiSearch);

            //3、创建ListView，加入项
            ListView listview = new ListView();
            listview.LargeImageList = imageList1;//设置大图标
            listview.Dock = DockStyle.Fill;//图标自己自动整齐排列，大概就是这个意思，图片停靠
            //
            //为ListView绑定双击事件，以获得被双击的项，从而完成点菜。
            listview.DoubleClick += listview_DoubleClick;//写完+=之后，直接按两下tab键

            //为ListView绑定单击事件，用来获得被选中的餐桌编号，用于结账
            listview.Click += listview_Click;
            //给查询到的当前厅包下面的所有餐桌信息，进行遍历
            foreach(var tableInfo in listTableInfo)
            {
                //这里把餐桌的名称，空闲状态，和餐桌编号给item，进行遍历
                ListViewItem item = new ListViewItem(tableInfo.TTitle,tableInfo.TIsFree?0:1);//第一个参数是显示名称，第二个参数是根据空闲状态选择图片
                //得到tableid，得到餐桌的编号，方便后面的开单操作
                item.Tag = tableInfo.TId;//这里把餐桌编号给了tag，所以在下面可以使用tag传递餐桌编号结账，也使用tag进行开单点菜加菜
                listview.Items.Add(item);//加入到显示前面定义的选项卡中
            }

            //4、将ListView加入当前选中的tabPag
            tabpage.Controls.Add(listview);
           
        }

        void listview_Click(object sender, EventArgs e)
        {
           //得到单击的listview
            ListView listview = sender as ListView;
            itemTable = listview.SelectedItems[0];
        }

        void listview_DoubleClick(object sender, EventArgs e)
        {
            //得到双击的listview
            ListView listview = sender as ListView;
            //然后去设计窗口，给listview控件设置属性，MUltiSelect=false，（multiline）只允许选择一个，不许多选
            ListViewItem item = listview.SelectedItems[0];//拿到双击的项了，当项被双击后，被选择，这里注意：我们定义的item就可以拿到上面item存储的tag信息
            int tableId = Convert.ToInt32(item.Tag);//获得餐桌编号，给业务逻辑层开单使用

            //如果当前餐桌是空闲状态，就进行开单操作
            if (item.ImageIndex == 0)
            {
                OrderInfoBll oiBll = new OrderInfoBll();
                if (oiBll.Kaidan(tableId))
                {
                    //打开开单界面
                    //当前餐桌的状态改为占用
                    //这里注意，点开了开单界面，并不代表下单了，可能并没有下单，
                    //使用委托事件，必须在开单界面点击了下单，才可以更换图片
                    
                    //继续往下执行打开点菜窗体
                }
            }
            else
            {
                //如果不是空闲状态，就进行加菜操作，一样也是打开点菜窗体
            }
            OrderInfoList orderInfoList =OrderInfoList.Create();
            orderInfoList.Tag=tableId;//将餐桌编号传递过去，用于进行订单编号的查找，这样才能加菜点菜
            orderInfoList.GetTableFreeEvent += GetTableFree;
            orderInfoList.Show();
            orderInfoList.Focus();

        }



        private void menuOrder_Click(object sender, EventArgs e)
        {
            //判断当前选中的餐桌是否为空闲，如果是空闲则不需要结账
            if(itemTable==null)
            {
                MessageBox.Show("请先选择需要结账的餐桌！再点击结账。");
                return;
            }
            if (itemTable.ImageIndex == 0)
            {
                MessageBox.Show("当前餐桌并没有开单，无需结账！");
            }
            else
            {
                OrderPay op = OrderPay.Create();
                op.Tag = itemTable.Tag;//itemtable里面记录的是餐桌的编号，传递给结账窗口
                op.SetTableFreeEvent += SetTableFree;
                op.Show();
                op.Focus();
            }
        }

        //这个方法作为事件，当结账窗体完成结账之后，执行，用来改变餐桌状态
        private void SetTableFree()
        {
            itemTable.ImageIndex = 0;
        }

        //这个方法，在打开,开单窗体之后，并点击下单时，执行
        private void GetTableFree()
        {
            itemTable.ImageIndex = 1;
        }

    }
}
