using Bll;
using Model;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormManagerList : Form
    {
        
        //单例模式开启方案之一（另外一个方法是单独做一个类出来）
        //将构造方法变为私有（隐藏），不许new出对象了
        private FormManagerList()
        {
            InitializeComponent();
        }
        //定义静态变量，用于存储单例对象
        private static FormManagerList fml;
        //创建对象的方法，按照类点Create创建对象，按照指定的方法创建对象
        public static FormManagerList Create()
        {
            //判断对象是否存在，或是否已经被释放
            if(fml==null||fml.IsDisposed)
            {
                //新建对象
                fml = new FormManagerList();
            }
            //直接返回对象
            return fml;
        }
        //全局对象，Bll业务逻辑层
        ManagerinfoBll miBll = new ManagerinfoBll();
        
        private void FormManagerList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            gvList.AutoGenerateColumns = false;
            gvList.DataSource = miBll.GetList();
            txtName.TabIndex = 0;
            txtPwd.TabIndex = 1;
            rb0.TabIndex = 2;
            rb1.TabIndex = 3;
            btnSave.TabIndex = 4;
            gvList.TabIndex = 5;
        }

        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "经理";
                        break;
                    case "0":
                        e.Value = "店员";
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //根据接收控件的值，用于构造对象。
            Managerinfo mi = new Managerinfo()
            {
                MName = txtName.Text,
                MPwd = txtPwd.Text,
                MType = rb1.Checked ? 1 : 0,
            };
            //判断当前是应该执行添加操作，还是执行修改操作
            if (btnSave.Text == "添加")
            {

                if (miBll.Add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试！");
                }
            }
            else
            {
                mi.MId = Convert.ToInt32(txtId.Text);
                if (miBll.Edit(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("修改失败！请稍后重试！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无须填写！";
            txtName.Text = "";
            txtPwd.Text = "";
            rb0.Checked = true;
            btnSave.Text = "添加";


            
     
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvList.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result= MessageBox.Show("确定删除吗？","提示",MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    int id = Convert.ToInt32(rows[0].Cells[0].Value);
                    if(miBll.Remove(id))
                    {
                        LoadList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败，请稍后重试！");
                    }
                }
            }
            else
            {
                MessageBox.Show("二货，你还没选要删除的行呢！");
            }
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = gvList.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtPwd.Text = "******";
                if (row.Cells[2].Value.ToString() == "1")
                {
                    rb1.Checked = true;
                }
                else
                {
                    rb0.Checked = true;
                }
                btnSave.Text = "修改";
            }
            catch
            {
            }
        }

        private void FormManagerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            //当窗体对象关闭后，被资源回收的时候，配合前面指定的对象创建方法Create，重新创建窗体对象
            fml = null;
        }

        private void btnXls_Click(object sender, EventArgs e)
        {

            ////因为这个数据导出可能出现意外，并且导出时间可能比较长，所以决定开一个线程去做
            //开了线程之后发现无法弹出保存路径对话框，无奈，于是放弃
            //Control.CheckForIllegalCrossThreadCalls = false;
            //Thread thOutputXls = new Thread(OutputXls);
            //thOutputXls.IsBackground = false;
            //thOutputXls.Start();

            DialogResult result = MessageBox.Show("点击【确定】将把会员数据，菜品数据导出为xls表格！", "数据导出提示！", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                #region 弹出保存窗口对话框，选择保存路径，创建工作本
                /*******************************************************/
                /*******************************************************/
                /*******************************************************/
                //弹出保存对话框
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "请选择要保存的路径，默认为桌面";
                sfd.InitialDirectory = @"C:\Users\Administrator\Desktop";
                sfd.Filter = "xls表格文件|*.xls|所有文件|*.*";
                sfd.ShowDialog();
                //获得保存文件的路径
                string path = sfd.FileName;
                if (path == "")//打开了对话框，但是没有选择地址
                {
                    return;
                }
                //创建工作本
                HSSFWorkbook workbook = new HSSFWorkbook();
                //如果用户选择了保存路径，则开始进行保存操作
                #endregion

                #region 表格样式操作

                //导出：将数据库中的数据，存储到一个excel中
                //2、生成excel
                //生成workbook
                //生成sheet
                //遍历集合，生成行。（一个对象就是一行）
                //根据对象生成单元格，一个属性对应一个单元格

            
                //样式表
                /*****************************************************************************/
                /******************表格样式操作*********************************************/
                /*****************************************************************************/
                /************/
                //表头标题样式操作（水平垂直居中，黄色背景，字体颜色黑色，微软雅黑加粗，字体大小18）
                /*************/
                var styleTitle = workbook.CreateCellStyle();
                //style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;//左对齐  
                //style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;//右对齐  
                styleTitle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//居中  
                //垂直居中
                styleTitle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                //
                //字体样式设置
                HSSFFont fontTitle = (HSSFFont)workbook.CreateFont();
                fontTitle.FontName = "微软雅黑";//字体  
                fontTitle.FontHeightInPoints = 18;//字号  
                fontTitle.Color = HSSFColor.Red.Index; //颜色 红色
                fontTitle.IsBold = true;//加粗  
                // font.Underline = NPOI.SS.UserModel.FontUnderlineType.Double;//下划线  
                // font.IsStrikeout = true;//删除线  
                // font.IsItalic = true;//斜体  

                //将字体样式加入表头样式中
                styleTitle.SetFont(fontTitle);

                //背景色设置
                //styleTitle.FillBackgroundColor = HSSFColor.Yellow.Index;//背景色  
                styleTitle.FillForegroundColor = HSSFColor.Yellow.Index;//前景色  
                styleTitle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;//填充方式 AltBars


                /****************/
                //表格列头样式操作
                /****************/
                //表格列头样式操作（水平垂直居中，蓝色背景，字体颜色白色，黑体，字体大小16）
                var styleHeader = workbook.CreateCellStyle();
                styleHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平居中  
                styleHeader.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直居中  
                styleHeader.FillForegroundColor = HSSFColor.Blue.Index;//前景色  
                styleHeader.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;//填充方式 AltBars
                HSSFFont fontHeader = (HSSFFont)workbook.CreateFont();
                fontHeader.FontName = "黑体";//字体  
                fontHeader.FontHeightInPoints = 12;//字号  
                fontHeader.Color = HSSFColor.White.Index; //颜色 
                fontHeader.IsBold = true;//加粗  
                styleHeader.SetFont(fontHeader);
                /*****************/
                /****************/


                /*****************/
                //*表脚样式*//
                /*****************/
                var styleFoot = workbook.CreateCellStyle();
                styleFoot.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平居中  
                styleFoot.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直居中  
                styleFoot.FillForegroundColor = HSSFColor.Blue.Index;//前景色  
                styleFoot.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;//填充方式 AltBars
                HSSFFont fontFoot = (HSSFFont)workbook.CreateFont();
                fontFoot.FontName = "黑体";//字体  
                fontFoot.FontHeightInPoints = 10;//字号  
                fontFoot.Color = HSSFColor.White.Index; //颜色 
                fontFoot.IsBold = true;//加粗  
                styleFoot.SetFont(fontFoot);
                /*****************/
                /****************/

                /*****************/
                //*表格正文样式*//
                /*****************/
                var styleBody = workbook.CreateCellStyle();
                styleBody.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平居中  
                styleBody.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直居中                      
                HSSFFont fontBody = (HSSFFont)workbook.CreateFont();
                fontBody.FontName = "宋体";//字体  
                fontBody.FontHeightInPoints = 12;//字号  
                fontBody.Color = HSSFColor.Black.Index; //颜色 
                fontBody.IsBold = true;//加粗  
                styleBody.SetFont(fontBody);
                /*****************/
                /****************/

                /******************************************************************************/
                /***************************表格样式操作***************************************/
                /*****************************************************************************/
                #endregion

                #region 会员信息表存储
                /***********************创建工作表，在一个工作本里面可以有多张表*************************/
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/

                /*********************************************/
                /**************会员信息表*********************/
                /*********************************************/

                //1、查询数据
                //保存会员信息表
                MemberInfoBll meiBll = new MemberInfoBll();
                MemberInfo mei = new MemberInfo();
                var listMemberInfo = meiBll.GetList(mei);

                //创建工作表
                //NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("管理员");
                ISheet sheet = workbook.CreateSheet("会员信息表");


                //创建标题行
                IRow row = sheet.CreateRow(0);
                //合并单元格
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));
                ICell cellTitle = row.CreateCell(0);
                cellTitle.SetCellValue("会员信息记录表");
                row.HeightInPoints = 22;//表头标题行高
                //应用样式
                cellTitle.CellStyle = styleTitle;



                //创建列名称
                IRow row1 = sheet.CreateRow(1);
                row1.HeightInPoints = 20;//表列头行高
                //创建单元格
                //设置名称
                //应用样式
                //设置列的宽度
                //SetColumnWidth（）方法有两个参数，第一个是列的索引，从0开始。注意第二个参数，是以1/256为单位。
                ICell cellId = row1.CreateCell(0);
                cellId.SetCellValue("编号");
                cellId.CellStyle = styleHeader;
                sheet.SetColumnWidth(0, 10 * 256);

                ICell cellName = row1.CreateCell(1);
                cellName.SetCellValue("会员名称");
                cellName.CellStyle = styleHeader;
                sheet.SetColumnWidth(1, 20 * 256);

                ICell cellPhone = row1.CreateCell(2);
                cellPhone.SetCellValue("会员手机号");
                cellPhone.CellStyle = styleHeader;
                sheet.SetColumnWidth(2, 25 * 256);

                ICell cellMoney = row1.CreateCell(3);
                cellMoney.SetCellValue("会员余额");
                cellMoney.CellStyle = styleHeader;
                sheet.SetColumnWidth(3, 18 * 256);

                ICell cellType = row1.CreateCell(4);
                cellType.SetCellValue("会员类型");
                cellType.CellStyle = styleHeader;
                sheet.SetColumnWidth(4, 20 * 256);

                ICell cellDiscount = row1.CreateCell(5);
                cellDiscount.SetCellValue("享受折扣");
                cellDiscount.CellStyle = styleHeader;
                sheet.SetColumnWidth(5, 18 * 256);


                //遍历集合，生成行
                int index = 2;//索引，0,1是表头。所以从2开始。
                foreach (var item in listMemberInfo)
                {
                    //创建下面每行单元格的值
                    var row2 = sheet.CreateRow(index++);

                    var cell0 = row2.CreateCell(0);
                    cell0.SetCellValue(item.MId);
                    cell0.CellStyle = styleBody;

                    var cell1 = row2.CreateCell(1);
                    cell1.SetCellValue(item.MName);

                    var cell2 = row2.CreateCell(2);
                    cell2.SetCellValue(item.MPhone);

                    var cell3 = row2.CreateCell(3);
                    cell3.SetCellValue(item.MMoney.ToString());

                    var cell4 = row2.CreateCell(4);
                    cell4.SetCellValue(item.TypeTitle);

                    var cell5 = row2.CreateCell(5);
                    cell5.SetCellValue((item.TypeDiscount * 10).ToString() + "折");


                }

                /**表页脚**/
                //创建标题行
                IRow row3 = sheet.CreateRow(index);
                //合并单元格
                sheet.AddMergedRegion(new CellRangeAddress(index, index, 0, 5));
                ICell cellFoot = row3.CreateCell(0);
                cellFoot.SetCellValue("欢迎使用！如有建议或需求反馈可以联系梦雨客服QQ:1517680389");
                row3.HeightInPoints = 22;//表头标题行高
                //应用样式
                cellFoot.CellStyle = styleFoot;
                /**********/

                /*********************************************/
                /**************会员信息表*********************/
                /*********************************************/
                #endregion

                #region 菜品信息表储存
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/

                /*********************************************/
                /**************菜品信息表*********************/
                /*********************************************/

                //关于菜品信息表，需要显示基本的菜品信息，这里我是想加入每个菜品在一段时间内的点菜频率的
                //感觉有了点菜频率统计，还是蛮使用
                //只是一直没想出来更好的统计方案，暂时也就没有做，现在就只是单纯的输出吧

                //1.查询数据
                DishInfoBll diBll = new DishInfoBll();
                DishInfo di = new DishInfo();
                var listDishInfo = diBll.GetList(di);

                //2.创建工作表
                ISheet sheetDish = workbook.CreateSheet("菜品信息表");


                //3.创建标题行
                IRow rowDish0 = sheetDish.CreateRow(0);
                  //合并单元格
                sheetDish.AddMergedRegion(new CellRangeAddress(0, 0, 0, 3));
                ICell cellDishTitle = rowDish0.CreateCell(0);
                cellDishTitle.SetCellValue("菜品信息记录表");
                rowDish0.HeightInPoints = 22;//表头标题行高
                   //应用样式
                cellDishTitle.CellStyle = styleTitle;



                //4.创建列名称
                IRow rowDish1 = sheetDish.CreateRow(1);
                rowDish1.HeightInPoints = 20;//表列头行高
                //创建单元格
                //设置名称
                //应用样式
                //设置列的宽度
                //SetColumnWidth（）方法有两个参数，第一个是列的索引，从0开始。注意第二个参数，是以1/256为单位。
                ICell cellDishId = rowDish1.CreateCell(0);
                cellDishId.SetCellValue("编号");
                cellDishId.CellStyle = styleHeader;
                sheetDish.SetColumnWidth(0, 10 * 256);

                ICell cellNameDishTitle = rowDish1.CreateCell(1);
                cellNameDishTitle.SetCellValue("菜品名称");
                cellNameDishTitle.CellStyle = styleHeader;
                sheetDish.SetColumnWidth(1, 30 * 256);

                ICell cellDishType = rowDish1.CreateCell(2);
                cellDishType.SetCellValue("所属菜系");
                cellDishType.CellStyle = styleHeader;
                sheetDish.SetColumnWidth(2, 25 * 256);

                ICell cellDishPrice = rowDish1.CreateCell(3);
                cellDishPrice.SetCellValue("菜品单价");
                cellDishPrice.CellStyle = styleHeader;
                sheetDish.SetColumnWidth(3, 18 * 256);


                //遍历集合，生成行
                int indexDish = 2;//索引，0,1是表头。所以从2开始。
                foreach (var item in listDishInfo)
                {
                    //创建下面每行单元格的值
                    var rowDish2 = sheetDish.CreateRow(indexDish++);

                    var cell0 = rowDish2.CreateCell(0);
                    cell0.SetCellValue(item.DId);
                    cell0.CellStyle = styleBody;

                    var cell1 = rowDish2.CreateCell(1);
                    cell1.SetCellValue(item.DTitle);

                    var cell2 = rowDish2.CreateCell(2);
                    cell2.SetCellValue(item.TypeTitle);

                    var cell3 = rowDish2.CreateCell(3);
                    cell3.SetCellValue(item.DPrice.ToString()+"元");

                }

                /**表页脚**/
                //创建标题行
                IRow rowDish3 = sheetDish.CreateRow(indexDish);
                //合并单元格
                sheetDish.AddMergedRegion(new CellRangeAddress(indexDish, indexDish, 0, 3));
                ICell cellDishFoot = rowDish3.CreateCell(0);
                cellDishFoot.SetCellValue("欢迎使用！如有建议或需求反馈可以联系梦雨客服QQ:1517680389");
                rowDish3.HeightInPoints = 22;//表头标题行高
                //应用样式
                cellDishFoot.CellStyle = styleFoot;

                /*********************************************/
                /**************菜品信息表*********************/
                /*********************************************/
                #endregion

                #region 点菜记录表存储
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/

                /*********************************************/
                /**************点菜记录表*********************/
                /*********************************************/
                //这个主要是用来存储点菜记录的，我觉得每个酒店都应该记录一下，加入发生食品中毒等意外事件，可以查一查，做个参考啥的
                //然后也能看出每天生意的大概情况，因为我自己的交接班功能，还没有一个整体方案，所以这个表还是可以参考的
                //另外需要注意的是，如果客户先点击了缓存清理，那么只能可能就没有数据了。缓存清理会把所有已经付钱的订单全部删除。
                //所以需要在缓存清理按钮上增加窗口弹出提示！

                //1.查询数据
                OrderInfoBll oiBll = new OrderInfoBll();
                var listOrderInfo = oiBll.GetOrderInfo();

                //2.创建工作表
                ISheet sheetOrder = workbook.CreateSheet("下单信息表");


                //3.创建标题行
                IRow rowOrder0 = sheetOrder.CreateRow(0);
                //合并单元格
                sheetOrder.AddMergedRegion(new CellRangeAddress(0, 0, 0, 4));
                ICell cellOrderTitle = rowOrder0.CreateCell(0);
                cellOrderTitle.SetCellValue("点菜下单信息记录表");
                rowOrder0.HeightInPoints = 22;//表头标题行高
                //应用样式
                cellOrderTitle.CellStyle = styleTitle;

                //4.创建列名称
                IRow rowOrder1 = sheetOrder.CreateRow(1);
                rowOrder1.HeightInPoints = 20;//表列头行高
                //创建单元格
                //设置名称
                //应用样式
                //设置列的宽度
                //SetColumnWidth（）方法有两个参数，第一个是列的索引，从0开始。注意第二个参数，是以1/256为单位。
                ICell cellOrderId = rowOrder1.CreateCell(0);
                cellOrderId.SetCellValue("编号");
                cellOrderId.CellStyle = styleHeader;
                sheetOrder.SetColumnWidth(0, 10 * 256);

                ICell cellOrderDate = rowOrder1.CreateCell(1);
                cellOrderDate.SetCellValue("下单时间");
                cellOrderDate.CellStyle = styleHeader;
                sheetOrder.SetColumnWidth(1, 30 * 256);

                ICell cellOrderMember = rowOrder1.CreateCell(2);
                cellOrderMember.SetCellValue("会员姓名");
                cellOrderMember.CellStyle = styleHeader;
                sheetOrder.SetColumnWidth(2, 15 * 256);

                ICell cellOrderPhone = rowOrder1.CreateCell(3);
                cellOrderPhone.SetCellValue("会员手机号");
                cellOrderPhone.CellStyle = styleHeader;
                sheetOrder.SetColumnWidth(3, 25 * 256);

                ICell cellOrderMoney = rowOrder1.CreateCell(4);
                cellOrderMoney.SetCellValue("菜单总金额");
                cellOrderMoney.CellStyle = styleHeader;
                sheetOrder.SetColumnWidth(4, 15 * 256);

                //遍历集合，生成行
                int indexOrder = 2;//索引，0,1是表头。所以从2开始。
                foreach (var item in listOrderInfo)
                {
                    //创建下面每行单元格的值
                    var rowOrder2 = sheetOrder.CreateRow(indexOrder++);

                    var cell0 = rowOrder2.CreateCell(0);
                    cell0.SetCellValue(item.OId);
                    cell0.CellStyle = styleBody;

                    var cell1 = rowOrder2.CreateCell(1);
                    cell1.SetCellValue(item.ODate.ToString());

                    var cell2 = rowOrder2.CreateCell(2);
                    cell2.SetCellValue(item.MemberName);

                    var cell3 = rowOrder2.CreateCell(3);
                    cell3.SetCellValue(item.MemberPhone);

                    var cell4 = rowOrder2.CreateCell(4);
                    cell4.SetCellValue(item.OMoney.ToString() + "元");

                }

                /**表页脚**/
                //创建标题行
                IRow rowOrder3 = sheetOrder.CreateRow(indexOrder);
                //合并单元格
                sheetOrder.AddMergedRegion(new CellRangeAddress(indexOrder, indexOrder, 0, 4));
                ICell cellOrderFoot = rowOrder3.CreateCell(0);
                cellOrderFoot.SetCellValue("欢迎使用！如有建议或需求反馈可以联系梦雨客服QQ:1517680389");
                rowOrder3.HeightInPoints = 22;//表头标题行高
                //应用样式
                cellOrderFoot.CellStyle = styleFoot;

                /*********************************************/
                /**************点菜记录表*********************/
                /*********************************************/

                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/
                /******************************************************************************************************************************************/
                #endregion

                #region 写入文件保存
                //是否成功标志
                bool flag = false;
                try
                {
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                    workbook.Write(file);
                    file.Dispose();//使用完要释放资源，或者使用using（）{}
                    flag = true;
                }
                catch
                {
                    MessageBox.Show("保存出错！\n请关闭其他xls文件，再重试！");
                    flag = false;
                }
                /*******************************************************/
                if (flag)
                {
                    //操作完成，导出成功提示
                    MessageBox.Show("数据导出成功！导出路径如下：\n" + path + "\n敬请及时查收！");
                }
                #endregion
            }
              
        }

        

        private void btnClean_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("点击【确定】将把过期的点菜信息进行清理，以加快软件运行速度！\n强烈建议：先点击【导出数据】做备份，再继续清理缓存。清理之后不可恢复！", "清除缓存！", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {

            }
        }
    }
}
