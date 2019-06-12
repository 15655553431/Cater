namespace UI
{
    partial class MemberList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvMemberInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.手机号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.余额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMemberTypeInfo = new System.Windows.Forms.Button();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPhoneSeek = new System.Windows.Forms.TextBox();
            this.txtNameSeek = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMemberInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvMemberInfo);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 420);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会员列表";
            // 
            // gvMemberInfo
            // 
            this.gvMemberInfo.AllowUserToAddRows = false;
            this.gvMemberInfo.AllowUserToDeleteRows = false;
            this.gvMemberInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMemberInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.类型,
            this.手机号,
            this.余额});
            this.gvMemberInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMemberInfo.Location = new System.Drawing.Point(3, 17);
            this.gvMemberInfo.MultiSelect = false;
            this.gvMemberInfo.Name = "gvMemberInfo";
            this.gvMemberInfo.ReadOnly = true;
            this.gvMemberInfo.RowTemplate.Height = 23;
            this.gvMemberInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMemberInfo.Size = new System.Drawing.Size(508, 400);
            this.gvMemberInfo.TabIndex = 4;
            this.gvMemberInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMemberInfo_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "MId";
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // name
            // 
            this.name.DataPropertyName = "MName";
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 80;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "TypeTitle";
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.ReadOnly = true;
            // 
            // 手机号
            // 
            this.手机号.DataPropertyName = "MPhone";
            this.手机号.HeaderText = "手机号";
            this.手机号.Name = "手机号";
            this.手机号.ReadOnly = true;
            this.手机号.Width = 150;
            // 
            // 余额
            // 
            this.余额.DataPropertyName = "MMoney";
            this.余额.HeaderText = "余额";
            this.余额.Name = "余额";
            this.余额.ReadOnly = true;
            this.余额.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtMoney);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnMemberTypeInfo);
            this.groupBox2.Controls.Add(this.cbxType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(523, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 292);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加\\修改";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(23, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "提示：双击表格项进行修改！";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(17, 259);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(171, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "删除所选中的会员";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(119, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(69, 176);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(125, 21);
            this.txtMoney.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "余  额：";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(69, 143);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(125, 21);
            this.txtPhone.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "手机号：";
            // 
            // btnMemberTypeInfo
            // 
            this.btnMemberTypeInfo.Location = new System.Drawing.Point(68, 108);
            this.btnMemberTypeInfo.Name = "btnMemberTypeInfo";
            this.btnMemberTypeInfo.Size = new System.Drawing.Size(126, 23);
            this.btnMemberTypeInfo.TabIndex = 6;
            this.btnMemberTypeInfo.Text = "会员类型管理";
            this.btnMemberTypeInfo.UseVisualStyleBackColor = true;
            this.btnMemberTypeInfo.Click += new System.EventHandler(this.btnMemberTypeInfo_Click);
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(68, 81);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(126, 20);
            this.cbxType.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "类  型：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(68, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 21);
            this.txtName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "姓  名：";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(68, 19);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(126, 21);
            this.txtId.TabIndex = 1;
            this.txtId.Text = "添加时无需填写";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "编  号：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPhoneSeek);
            this.groupBox3.Controls.Add(this.txtNameSeek);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnShowResult);
            this.groupBox3.Location = new System.Drawing.Point(523, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 122);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "会员查询";
            // 
            // txtPhoneSeek
            // 
            this.txtPhoneSeek.Location = new System.Drawing.Point(68, 54);
            this.txtPhoneSeek.Name = "txtPhoneSeek";
            this.txtPhoneSeek.Size = new System.Drawing.Size(126, 21);
            this.txtPhoneSeek.TabIndex = 1;
            this.txtPhoneSeek.TextChanged += new System.EventHandler(this.txtPhoneSeek_TextChanged);
            this.txtPhoneSeek.Leave += new System.EventHandler(this.txtPhoneSeek_Leave);
            // 
            // txtNameSeek
            // 
            this.txtNameSeek.Location = new System.Drawing.Point(68, 23);
            this.txtNameSeek.Name = "txtNameSeek";
            this.txtNameSeek.Size = new System.Drawing.Size(126, 21);
            this.txtNameSeek.TabIndex = 0;
            this.txtNameSeek.TextChanged += new System.EventHandler(this.txtNameSeek_TextChanged);
            this.txtNameSeek.Leave += new System.EventHandler(this.txtNameSeek_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "手机号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓  名：";
            // 
            // btnShowResult
            // 
            this.btnShowResult.Location = new System.Drawing.Point(32, 85);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(137, 27);
            this.btnShowResult.TabIndex = 2;
            this.btnShowResult.Text = "显示所有会员信息";
            this.btnShowResult.UseVisualStyleBackColor = true;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
            // 
            // MemberList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 425);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MemberList";
            this.Text = "会员管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberList_FormClosing);
            this.Load += new System.EventHandler(this.MemberList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMemberInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gvMemberInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnMemberTypeInfo;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhoneSeek;
        private System.Windows.Forms.TextBox txtNameSeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 手机号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 余额;
    }
}