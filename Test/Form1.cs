using Bll;
using Common;
using Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
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

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ManagerinfoBll miBll = new ManagerinfoBll();

        private void btnExport_Click(object sender, EventArgs e)
        {
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
            //创建单元格
            ICell cellId = row.CreateCell(0);
            cellId.SetCellValue("编号");

            ICell cellName = row.CreateCell(1);
            cellName.SetCellValue("用户名");

            ICell cellPwd = row.CreateCell(2);
            cellPwd.SetCellValue("密码");

            ICell cellType = row.CreateCell(3);
            cellType.SetCellValue("类型");


            FileStream file = new FileStream(@"C:\Users\Administrator\Desktop\b.xls",FileMode.CreateNew,FileAccess.Write);
            workbook.Write(file);
            file.Dispose();

        }

       
    }
}
