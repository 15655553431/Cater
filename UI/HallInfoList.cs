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
    public partial class HallInfoList : Form
    {
        private HallInfoList()
        {
            InitializeComponent();
        }

        private static HallInfoList hil;

        public static HallInfoList Create()
        {
            if(hil==null||hil.IsDisposed)
            {
                hil = new HallInfoList();
            }
            return hil;
        }

        public event Action UpdateHallInfoEvent;


        private HallInfoBll hiBll = new HallInfoBll();
        private void HallInfoList_Load(object sender, EventArgs e)
        {
            LoadHallInfoList();
        }

        private void LoadHallInfoList()
        {
            gvHallInfo.AutoGenerateColumns = false;
            gvHallInfo.DataSource = hiBll.GetList();
        }

        private void gvHallInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = gvHallInfo.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtTitle.Text = row.Cells[1].Value.ToString();
                btnSave.Text = "修改";
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HallInfo hi = new HallInfo();
            hi.HTitle = txtTitle.Text;
            if(btnSave.Text=="添加")
            {
                if (hiBll.Add(hi))
                {
                    LoadHallInfoList();
                    UpdateHallInfoEvent();
                }
                else
                {
                    MessageBox.Show("添加失败！请稍后重试！");
                }
            }
            else
            {
                hi.HId = Convert.ToInt32(txtId.Text);
                //修改操作
                if(hiBll.Edit(hi))
                {
                    LoadHallInfoList();
                    UpdateHallInfoEvent();
                }
                else
                {
                    MessageBox.Show("修改失败！请稍后重试！");
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无需填写！";
            txtTitle.Text = "";
            btnSave.Text = "添加";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvHallInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (hiBll.Remove(id))
                    {
                        LoadHallInfoList();
                        UpdateHallInfoEvent();
                        
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
    }
}
