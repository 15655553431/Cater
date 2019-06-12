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
    public partial class MemberList : Form
    {
        private MemberList()
        {
            InitializeComponent();
        }

        private static MemberList meil;

        public static MemberList Create()
        {
            if (meil == null)
            {
                meil = new MemberList();
            }
            return meil;
        }

        private MemberInfoBll meiBll = new MemberInfoBll();

        private void btnMemberTypeInfo_Click(object sender, EventArgs e)
        {
            MemberTypeInfoList mtil =MemberTypeInfoList.Create();
            mtil.UpdateTypeEvent += UpdateType;
            mtil.Show();
            mtil.Focus();
        }

        //为了要让会员类型管理的窗体更改后的设置同步到会员管理窗体，需要使用窗体传值。无参数无返回值
        private void UpdateType()
        {
           // LoadTypeList();
            LoadMemberList();
        }

        private void MemberList_Load(object sender, EventArgs e)
        {
            LoadMemberList();

        }

        private void LoadMemberList()
        {
            MemberInfo mei = new MemberInfo();
            mei.MName = txtNameSeek.Text;
            mei.MPhone = txtPhoneSeek.Text;

            gvMemberInfo.AutoGenerateColumns = false;
            gvMemberInfo.DataSource=meiBll.GetList(mei);
            //加载会员分类下拉框选项
            LoadTypeList();
            //这里注意把输入焦点改到会员搜索输入框
            txtNameSeek.TabIndex = 0;
            txtPhoneSeek.TabIndex = 1;
            btnShowResult.TabIndex = 2;
          
        }
        //加载会员分类下拉框选项
        private void LoadTypeList()
        {
            //查询会员分类情况
            MemberTypeInfoBll mtiBll = new MemberTypeInfoBll();
            List<MemberTypeInfo> list = mtiBll.GetList();

            cbxType.DisplayMember = "MTitle";
            cbxType.ValueMember = "MId";
            cbxType.DataSource = list;
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadMemberList();
            txtId.Text = "添加时无需填写";
            txtName.Text = "";
            txtPhone.Text = "";
            txtMoney.Text = "";
            btnSave.Text = "添加";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberInfo mei=new MemberInfo();
            mei.MName = txtName.Text;
            mei.MTypeId = Convert.ToInt32(cbxType.SelectedValue);
            mei.MPhone = txtPhone.Text;
            mei.MMoney = Convert.ToDecimal(txtMoney.Text);
            if (txtPhone.Text.Length != 11)
            {
                MessageBox.Show("手机号输入有误！请核查后重新输入哦！");
            }
            else
            {
                //添加或者修改
                if (btnSave.Text == "修改")
                {
                    //修改
                    mei.MId = Convert.ToInt32(txtId.Text);
                    if (meiBll.Edit(mei))
                    {
                        LoadMemberList();
                    }
                    else
                    {
                        MessageBox.Show("修改失败！请稍后重试！");
                    }

                }
                else
                {
                    //添加
                    
                    if (meiBll.Add(mei))
                    {
                        LoadMemberList();
                    }
                    else
                    {
                        MessageBox.Show("添加失败，请稍后重试！");
                    }

                }
            }
        }

        private void gvMemberInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
                btnSave.Text = "修改";
                var row = gvMemberInfo.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                cbxType.Text = row.Cells[2].Value.ToString();
                txtPhone.Text = row.Cells[3].Value.ToString();
                txtMoney.Text = row.Cells[4].Value.ToString();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //获取选中的行
            var rows = gvMemberInfo.SelectedRows;
            if (rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    int id = int.Parse(rows[0].Cells[0].Value.ToString());
                    if (meiBll.Remove(id))
                    {
                        LoadMemberList();
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

        private void MemberList_FormClosing(object sender, FormClosingEventArgs e)
        {
            meil = null;
        }

        #region 会员查询方法

        private void txtNameSeek_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void txtPhoneSeek_TextChanged(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void txtNameSeek_Leave(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void txtPhoneSeek_Leave(object sender, EventArgs e)
        {
            LoadMemberList();
        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            txtNameSeek.Text = "";
            txtPhoneSeek.Text = "";

            LoadMemberList();
        }

        #endregion

    }
}
