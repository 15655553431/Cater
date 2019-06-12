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
    public partial class MemberTypeInfoList : Form
    {
        private MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();

        private MemberTypeInfoList()
        {
            InitializeComponent();
        }

        private static MemberTypeInfoList metil;
        public static MemberTypeInfoList Create()
        {
            if(metil==null)
            {
                metil = new MemberTypeInfoList();
            }
            return metil;
        }

        private void MemberTypeInfoList_Load(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void LoadMemberList()
        {
            gvMemberTypeInfo.AutoGenerateColumns = false;
            gvMemberTypeInfo.DataSource = mtiBll.GetList();
            txtTitle.TabIndex = 0;
            txtDiscount.TabIndex = 1;
            btnSave.TabIndex = 2;
        }

        private void gvMemberTypeinfo_CellFormattig(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = ((Convert.ToDouble(e.Value)) * 10.0).ToString() + "折"; 
                
            }
        }

        private void gvMemberTypeInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = gvMemberTypeInfo.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtTitle.Text = row.Cells[1].Value.ToString();
                txtDiscount.Text =(Convert.ToDouble(row.Cells[2].Value)*10.0).ToString();             
                btnSave.Text = "修改";
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberTypeInfo mti = new MemberTypeInfo();
            try
            {              
                mti.MTitle = txtTitle.Text;
                mti.MDiscount = Convert.ToDecimal(Convert.ToDouble(txtDiscount.Text) / 10.0);

            }
            catch
            {
                MessageBox.Show("输入格式有误！请核查后重新输入！");
            }
            if(btnSave.Text=="修改")
            {
                mti.MId = Convert.ToInt32(txtId.Text);
                if (mtiBll.Edit(mti))
                {
                    LoadMemberList();
                    UpdateTypeEvent();
                }
                else
                {
                    MessageBox.Show("修改失败！请稍后重试！");
                }
            }
            else
            {
            if (mtiBll.Add(mti))
            {
                LoadMemberList();
                UpdateTypeEvent();
            }
            else
            {
                MessageBox.Show("添加失败！请稍后重试！");
            }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvMemberTypeInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                  int id=int.Parse(rows[0].Cells[0].Value.ToString());
                    if (mtiBll.Remove(id))
                    {
                        LoadMemberList();
                        UpdateTypeEvent();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Text = "添加时无需填写";
            txtTitle.Text = "";
            txtDiscount.Text = "";
            //LoadMemberList();
            btnSave.Text = "添加";
        }

        private void MemberTypeInfoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            metil = null;
        }

        //添加一个事件，用于窗体传值（发布订阅设计)前面必须是public
        public event Action UpdateTypeEvent;

    }
}
