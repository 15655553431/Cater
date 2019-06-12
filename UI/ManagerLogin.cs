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
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Managerinfo mi = new Managerinfo();
            mi.MName = txtName.Text;
            mi.MPwd = txtPwd.Text;

            ManagerinfoBll miBll = new ManagerinfoBll();
            if (miBll.Login(mi))
            {
                //登录成功，打开主窗体
                MainForm mainForm = new MainForm();
                mainForm .Tag=mi.MType;
                mainForm.Show();
                this.Visible=false;
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
           

        }

        private void ManagerLogin_Load(object sender, EventArgs e)
        {
            //获取用户名输入框焦点
            this.txtName.TabIndex=0;
            this.txtPwd.TabIndex = 1;
            this.btnLogin.TabIndex = 2;
           
        }
    }
}
