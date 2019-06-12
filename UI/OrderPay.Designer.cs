namespace UI
{
    partial class OrderPay
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
            this.btnStatement = new System.Windows.Forms.Button();
            this.btnShowOrderDish = new System.Windows.Forms.Button();
            this.ckbMember = new System.Windows.Forms.CheckBox();
            this.gbMember = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMemberInfo = new System.Windows.Forms.Button();
            this.lblTypeDiscount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ckbMoney = new System.Windows.Forms.CheckBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMphone = new System.Windows.Forms.TextBox();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRealIncome = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblConsumeMoney = new System.Windows.Forms.Label();
            this.lblShouldMoney = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.gbMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStatement
            // 
            this.btnStatement.Location = new System.Drawing.Point(119, 259);
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.Size = new System.Drawing.Size(75, 23);
            this.btnStatement.TabIndex = 1;
            this.btnStatement.Text = "确认结账";
            this.btnStatement.UseVisualStyleBackColor = true;
            this.btnStatement.Click += new System.EventHandler(this.btnStatement_Click);
            // 
            // btnShowOrderDish
            // 
            this.btnShowOrderDish.Location = new System.Drawing.Point(209, 259);
            this.btnShowOrderDish.Name = "btnShowOrderDish";
            this.btnShowOrderDish.Size = new System.Drawing.Size(75, 23);
            this.btnShowOrderDish.TabIndex = 2;
            this.btnShowOrderDish.Text = "查看菜品";
            this.btnShowOrderDish.UseVisualStyleBackColor = true;
            this.btnShowOrderDish.Click += new System.EventHandler(this.btnShowOrderDish_Click);
            // 
            // ckbMember
            // 
            this.ckbMember.AutoSize = true;
            this.ckbMember.Location = new System.Drawing.Point(12, 266);
            this.ckbMember.Name = "ckbMember";
            this.ckbMember.Size = new System.Drawing.Size(72, 16);
            this.ckbMember.TabIndex = 3;
            this.ckbMember.Text = "是否会员";
            this.ckbMember.UseVisualStyleBackColor = true;
            this.ckbMember.CheckedChanged += new System.EventHandler(this.ckbMember_CheckedChanged);
            // 
            // gbMember
            // 
            this.gbMember.Controls.Add(this.btnSearch);
            this.gbMember.Controls.Add(this.btnMemberInfo);
            this.gbMember.Controls.Add(this.lblTypeDiscount);
            this.gbMember.Controls.Add(this.label10);
            this.gbMember.Controls.Add(this.lblType);
            this.gbMember.Controls.Add(this.label8);
            this.gbMember.Controls.Add(this.ckbMoney);
            this.gbMember.Controls.Add(this.lblMoney);
            this.gbMember.Controls.Add(this.label6);
            this.gbMember.Controls.Add(this.label5);
            this.gbMember.Controls.Add(this.label4);
            this.gbMember.Controls.Add(this.txtMphone);
            this.gbMember.Controls.Add(this.txtMname);
            this.gbMember.Location = new System.Drawing.Point(12, 12);
            this.gbMember.Name = "gbMember";
            this.gbMember.Size = new System.Drawing.Size(272, 181);
            this.gbMember.TabIndex = 3;
            this.gbMember.TabStop = false;
            this.gbMember.Text = "会员信息";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(24, 149);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "重新查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMemberInfo
            // 
            this.btnMemberInfo.Location = new System.Drawing.Point(165, 149);
            this.btnMemberInfo.Name = "btnMemberInfo";
            this.btnMemberInfo.Size = new System.Drawing.Size(75, 23);
            this.btnMemberInfo.TabIndex = 11;
            this.btnMemberInfo.Text = "会员管理";
            this.btnMemberInfo.UseVisualStyleBackColor = true;
            this.btnMemberInfo.Click += new System.EventHandler(this.btnMemberInfo_Click);
            // 
            // lblTypeDiscount
            // 
            this.lblTypeDiscount.AutoSize = true;
            this.lblTypeDiscount.Location = new System.Drawing.Point(219, 125);
            this.lblTypeDiscount.Name = "lblTypeDiscount";
            this.lblTypeDiscount.Size = new System.Drawing.Size(23, 12);
            this.lblTypeDiscount.TabIndex = 10;
            this.lblTypeDiscount.Text = "9.8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "享受折扣：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(88, 125);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 12);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "普通会员";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "会员等级：";
            // 
            // ckbMoney
            // 
            this.ckbMoney.AutoSize = true;
            this.ckbMoney.Location = new System.Drawing.Point(165, 97);
            this.ckbMoney.Name = "ckbMoney";
            this.ckbMoney.Size = new System.Drawing.Size(72, 16);
            this.ckbMoney.TabIndex = 6;
            this.ckbMoney.Text = "使用余额";
            this.ckbMoney.UseVisualStyleBackColor = true;
            this.ckbMoney.CheckedChanged += new System.EventHandler(this.ckbMoney_CheckedChanged);
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoney.ForeColor = System.Drawing.Color.Red;
            this.lblMoney.Location = new System.Drawing.Point(88, 98);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(12, 12);
            this.lblMoney.TabIndex = 5;
            this.lblMoney.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "账户余额：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "手 机 号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "会员名称：";
            // 
            // txtMphone
            // 
            this.txtMphone.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtMphone.Location = new System.Drawing.Point(90, 61);
            this.txtMphone.Name = "txtMphone";
            this.txtMphone.Size = new System.Drawing.Size(164, 21);
            this.txtMphone.TabIndex = 1;
            this.txtMphone.TextChanged += new System.EventHandler(this.txtMphone_TextChanged);
            // 
            // txtMname
            // 
            this.txtMname.Location = new System.Drawing.Point(90, 29);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(164, 21);
            this.txtMname.TabIndex = 0;
            this.txtMname.TextChanged += new System.EventHandler(this.txtMname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "消费金额：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "应收金额：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "实收现金：";
            // 
            // txtRealIncome
            // 
            this.txtRealIncome.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRealIncome.ForeColor = System.Drawing.Color.Red;
            this.txtRealIncome.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtRealIncome.Location = new System.Drawing.Point(189, 203);
            this.txtRealIncome.Name = "txtRealIncome";
            this.txtRealIncome.Size = new System.Drawing.Size(95, 21);
            this.txtRealIncome.TabIndex = 0;
            this.txtRealIncome.Text = "0";
            this.txtRealIncome.Leave += new System.EventHandler(this.txtRealIncome_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(129, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "请 找 零：";
            // 
            // lblConsumeMoney
            // 
            this.lblConsumeMoney.AutoSize = true;
            this.lblConsumeMoney.Location = new System.Drawing.Point(65, 207);
            this.lblConsumeMoney.Name = "lblConsumeMoney";
            this.lblConsumeMoney.Size = new System.Drawing.Size(11, 12);
            this.lblConsumeMoney.TabIndex = 9;
            this.lblConsumeMoney.Text = "0";
            // 
            // lblShouldMoney
            // 
            this.lblShouldMoney.AutoSize = true;
            this.lblShouldMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShouldMoney.ForeColor = System.Drawing.Color.Red;
            this.lblShouldMoney.Location = new System.Drawing.Point(65, 231);
            this.lblShouldMoney.Name = "lblShouldMoney";
            this.lblShouldMoney.Size = new System.Drawing.Size(20, 19);
            this.lblShouldMoney.TabIndex = 10;
            this.lblShouldMoney.Text = "0";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChange.ForeColor = System.Drawing.Color.Red;
            this.lblChange.Location = new System.Drawing.Point(190, 231);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(20, 19);
            this.lblChange.TabIndex = 11;
            this.lblChange.Text = "0";
            // 
            // OrderPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 294);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblShouldMoney);
            this.Controls.Add(this.lblConsumeMoney);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRealIncome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbMember);
            this.Controls.Add(this.ckbMember);
            this.Controls.Add(this.btnShowOrderDish);
            this.Controls.Add(this.btnStatement);
            this.Name = "OrderPay";
            this.Text = "结账付款";
            this.Load += new System.EventHandler(this.OrderPay_Load);
            this.gbMember.ResumeLayout(false);
            this.gbMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStatement;
        private System.Windows.Forms.Button btnShowOrderDish;
        private System.Windows.Forms.CheckBox ckbMember;
        private System.Windows.Forms.GroupBox gbMember;
        private System.Windows.Forms.Button btnMemberInfo;
        private System.Windows.Forms.Label lblTypeDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckbMoney;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMphone;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRealIncome;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblConsumeMoney;
        private System.Windows.Forms.Label lblShouldMoney;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnSearch;
    }
}