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
    public partial class DishTypeInfoList : Form
    {
        private DishTypeInfoList()
        {
            InitializeComponent();
        }

        //添加一个事件，用于窗体传值（发布订阅设计)前面必须是public
        public event Action UpdateTypeEvent;

        private static DishTypeInfoList dtil;

        public static DishTypeInfoList Create()
        {
            if(dtil==null||dtil.IsDisposed)
            {
                dtil=new DishTypeInfoList();
            }
            return dtil;
        }

        private DishTypeInfoBll dtiBll = new DishTypeInfoBll();

        private void DishTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadDishTypeList();
        }

        public void LoadDishTypeList()
        {
            gvDishTypeInfo.AutoGenerateColumns = false;
            gvDishTypeInfo.DataSource = dtiBll.GetList();
        }

        public void LoadCancel()
        {
            txtTitle.Text = "";
            txtDId.Text = "添加时无需填写！";
            btnSave.Text = "添加";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadCancel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo dti = new DishTypeInfo();
            dti.DTitle = txtTitle.Text;

            if(btnSave.Text=="添加")
            {
                if (dtiBll.Add(dti))
                {
                    LoadDishTypeList();
                    UpdateTypeEvent();
                }
                else
                {
                    MessageBox.Show("添加失败！请稍后重试！");
                }
            }
            else
            {
                dti.DId = Convert.ToInt32(txtDId.Text);
                if(dtiBll.Edit(dti))
                {
                    LoadDishTypeList();
                    UpdateTypeEvent();
                }
                else
                {
                   MessageBox.Show("修改失败！请稍后重试！");
                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var rows = gvDishTypeInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (dtiBll.Remove(id))
                    {
                        LoadDishTypeList();
                      
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

        private void gvDishTypeInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = gvDishTypeInfo.Rows[e.RowIndex];
                txtDId.Text = row.Cells[0].Value.ToString();
                txtTitle.Text = row.Cells[1].Value.ToString();
                btnSave.Text = "修改";
            }
            catch
            {
            }
        }


    }
}
