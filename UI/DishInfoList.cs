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
    public partial class DishInfoList : Form
    {
        private DishInfoList()
        {
            InitializeComponent();
        }

        private static DishInfoList dil;
        public static DishInfoList Create()
        {
            if (dil == null || dil.IsDisposed)
            {
                dil = new DishInfoList();
            }
            return dil;
        }

        private DishInfoBll diBll = new DishInfoBll();

        private void DishInfoList_Load(object sender, EventArgs e)
        {
            LoadDishInfoList();
            LoadTypeList();
        }

        private void LoadDishInfoList()
        {
            DishInfo di = new DishInfo();
            
            if(!string.IsNullOrEmpty(txtTitleSearch.Text))
            {
                di.DTitle = txtTitleSearch.Text;
            }
            di.DTypeId = Convert.ToInt32(cbxTypeSearch.SelectedValue);

            gvDishInfo.AutoGenerateColumns = false;
            gvDishInfo.DataSource = diBll.GetList(di);   
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();

            //绑定添加修改的分类
            cbxType.DisplayMember = "DTitle";
            cbxType.ValueMember = "DId";
            cbxType.DataSource =dtiBll.GetList();;

            //绑定查询的分类
            var list = dtiBll.GetList();
            list.Insert(0,new DishTypeInfo()
            {
                DId=0,
                DTitle="全部",
             });
            
            cbxTypeSearch.DisplayMember = "DTitle";
            cbxTypeSearch.ValueMember = "DId";
            cbxTypeSearch.DataSource = list;

            
        }

        private void UpdateType()
        {
           // LoadTypeList();
            LoadDishInfoList();
        }

        #region 菜品查询
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            cbxTypeSearch.SelectedIndex = 0;
            LoadDishInfoList();
        }

        private void txtTitleSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDishInfoList();
        }

        private void cbxTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDishInfoList();
        }
        #endregion

        private void btnDishType_Click(object sender, EventArgs e)
        {
            DishTypeInfoList dtil = DishTypeInfoList.Create();
            dtil.UpdateTypeEvent += UpdateType;
            dtil.Show();
            dtil.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo();
            try
            {
                di.DTitle = txtTitle.Text;
                di.DTypeId = Convert.ToInt32(cbxType.SelectedValue);
                di.DPrice = Convert.ToDecimal(txtPrice.Text);
                di.DChar = txtPy.Text;
            }
            catch
            {
                return;
            }
            if(btnSave.Text=="添加")
            {
                if(diBll.Add(di))
                {
                    LoadDishInfoList();
                }
                else
                {
                    MessageBox.Show("添加失败！请稍后重试！");
                }
            }
            else
            {
                //修改
                di.DId = Convert.ToInt32(txtId.Text);
                if (diBll.Edit(di))
                {
                    LoadDishInfoList();
                }
                else
                {
                    MessageBox.Show("修改失败！请稍后重试！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDishInfoList();
            btnSave.Text = "添加";
            txtId.Text = "添加时无需填写！";
            txtTitle.Text = "";
            txtPrice.Text = "";
            txtPy.Text = "";
         
        }

        private void gvDishInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Text = "修改";
            var row = gvDishInfo.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            cbxType.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            txtPy.Text = row.Cells[4].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvDishInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (diBll.Remove(id))
                    {
                        LoadDishInfoList();
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
