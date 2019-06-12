using Bll;
using NPOI.HSSF.UserModel;
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
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        ManagerinfoBll miBll = new ManagerinfoBll();
        private void button1_Click(object sender, EventArgs e)
        {

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
            //如果用户选择了保存路径，则开始进行保存操作


            //导出：将数据库中的数据，存储到一个excel中
            //1、查询数据          
            var list = miBll.GetList();

            // dgvList.DataSource = miBll.GetList();
            //2、生成excel
            //生成workbook
            //生成sheet
            //遍历集合，生成行。（一个对象就是一行）
            //根据对象生成单元格，一个属性对应一个单元格

            //创建工作本
            HSSFWorkbook workbook = new HSSFWorkbook();
            //创建工作表
            //NPOI.SS.UserModel.ISheet sheet = workbook.CreateSheet("管理员");
            ISheet sheet = workbook.CreateSheet("管理员");
            //创建标题行
            IRow row = sheet.CreateRow(0);

            //合并单元格
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 3));
            ICell cellTitle = row.CreateCell(0);
            cellTitle.SetCellValue("管理员列表");

            //样式操作
            var style = workbook.CreateCellStyle();

            //style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;//左对齐  
            //style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;//右对齐  
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//居中  
            //竖直方向  
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;//垂直居中
            //应用样式
            cellTitle.CellStyle = style;

             IRow row1 = sheet.CreateRow(1);
            //创建单元格
            ICell cellId = row1.CreateCell(0);
            cellId.SetCellValue("编号");

            ICell cellName = row1.CreateCell(1);
            cellName.SetCellValue("用户名");

            ICell cellPwd = row1.CreateCell(2);
            cellPwd.SetCellValue("密码");

            ICell cellType = row1.CreateCell(3);
            cellType.SetCellValue("类型");


            //遍历集合，生成行
            int index = 2;//索引，0,1是表头。所以从2开始。
            foreach(var item in list)
            {
                var row2 = sheet.CreateRow(index++);

                var cell0 = row2.CreateCell(0);
                cell0.SetCellValue(item.MId);

                var cell1 = row2.CreateCell(1);
                cell1.SetCellValue(item.MName);

                var cell2 = row2.CreateCell(2);
                cell2.SetCellValue(item.MPwd);

                var cell3 = row2.CreateCell(3);
                cell3.SetCellValue(item.MType == 0 ? "店员" : "经理");

            }


           
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            workbook.Write(file);
            file.Dispose();//使用完要释放资源，或者使用using（）{}
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
