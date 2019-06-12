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
    public partial class TableInfoList : Form
    {
        private TableInfoList()
        {
            InitializeComponent();
        }
        private static TableInfoList til;
        public static TableInfoList Create()
        {
            if(til==null||til.IsDisposed)
            {
                til = new TableInfoList();
            }
            return til;
        }


        private TableInfoBll tiBll = new TableInfoBll();

        private void btnHallInfo_Click(object sender, EventArgs e)
        {
            HallInfoList hil = HallInfoList.Create();
            hil.UpdateHallInfoEvent += UpdateHallInfo;
            hil.Show();
            hil.Focus();
        }

        private void UpdateHallInfo()
        {
            LoadTableInfoList();
            LoadHallInfo();
        }

        private void TableInfoList_Load(object sender, EventArgs e)
        {
            LoadTableInfoList();
            LoadHallInfo();
        }
        private void LoadTableInfoList()
        {
            TableInfo ti = new TableInfo();
            ti.THallId = Convert.ToInt32(cbxHallSearch.SelectedValue);
            ti.IsFreeSearch = Convert.ToInt32(cbxFreeSearch.SelectedValue);
            
            gvTableInfo.AutoGenerateColumns = false;
            gvTableInfo.DataSource = tiBll.GetList(ti);
        }
        private void LoadHallInfo()
        {
            HallInfoBll hiBll = new HallInfoBll();
            //绑定修改窗口的分类下拉框
            cbxHallInfo.DisplayMember = "HTitle";
            cbxHallInfo.ValueMember = "HId";
            cbxHallInfo.DataSource = hiBll.GetList();

            //绑定查询窗口分类下拉框
            var list = hiBll.GetList();
            list.Insert(0, new HallInfo()
                {
                    HId=0,
                    HTitle="全部",
                });
            cbxHallSearch.DisplayMember = "HTitle";
            cbxHallSearch.ValueMember = "HId";
            cbxHallSearch.DataSource = list;


            List<TableState> listState = new List<TableState>();
            listState.Add(new TableState(-1, "全部"));
            listState.Add(new TableState(0, "使用中"));
            listState.Add(new TableState(1, "空闲中"));
            cbxFreeSearch.DisplayMember = "Title";
            cbxFreeSearch.ValueMember = "State";
            cbxFreeSearch.DataSource = listState;
        }

        private void gvTableInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Convert.ToBoolean(e.Value) == false)
                {
                    e.Value = "使用中！";
                }
                else
                {
                    e.Value = "空闲中 ！";
                }

            }
        }

        private void cbxHallSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTableInfoList();
        }

        private void cbxFreeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTableInfoList();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
       
            cbxFreeSearch.SelectedIndex = 0;
            cbxHallSearch.SelectedIndex = 0;
            LoadTableInfoList();
          
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvTableInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (tiBll.Remove(id))
                    {
                        LoadTableInfoList();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            TableInfo ti = new TableInfo();
            ti.TTitle = txtTTitle.Text;
            ti.THallId =Convert.ToInt32(cbxHallInfo.SelectedValue);
            ti.TIsFree =Convert.ToBoolean(rb1.Checked ? 1 : 0);

            if(btnSave.Text=="添加")
            {
                if (tiBll.Add(ti))
                {
                    LoadTableInfoList();
                }
                else
                {
                    MessageBox.Show("添加失败！请稍后重试！");
                }

            }
            else
            {
                //修改
                ti.TId = Convert .ToInt32(txtTId.Text);
                if(tiBll.Edit(ti))
                {
                    LoadTableInfoList();
                }
                else
                {
                    MessageBox.Show("修改失败！请稍后重试！");
                }
            }
        }

        private void gvTableInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Text = "修改";
            var row = gvTableInfo.Rows[e.RowIndex];
            txtTId.Text = row.Cells[0].Value.ToString();
            txtTTitle.Text = row.Cells[1].Value.ToString();
            cbxHallInfo.Text = row.Cells[2].Value.ToString();
            if (Convert.ToBoolean(row.Cells[3].Value) == true)
            {
                rb1.Checked = true;
            }
            else
            {
                rb0.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTId.Text = "添加时无需填写！";
            txtTTitle.Text = "";
            cbxHallInfo.SelectedIndex = 0;
            rb1.Checked = true;
            btnSave.Text = "添加";
        }

    }
}
