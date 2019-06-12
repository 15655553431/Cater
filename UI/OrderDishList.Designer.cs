namespace UI
{
    partial class OrderDishList
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderDish = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.gvOrderDishInfo = new System.Windows.Forms.DataGridView();
            this.oid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderDishInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "餐桌信息：";
            // 
            // lblOrderDish
            // 
            this.lblOrderDish.AutoSize = true;
            this.lblOrderDish.Location = new System.Drawing.Point(69, 10);
            this.lblOrderDish.Name = "lblOrderDish";
            this.lblOrderDish.Size = new System.Drawing.Size(53, 12);
            this.lblOrderDish.TabIndex = 1;
            this.lblOrderDish.Text = "普通用户";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvOrderDishInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 381);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已点菜品列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "点菜总计金额（包含未下单）：";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoney.ForeColor = System.Drawing.Color.Red;
            this.lblMoney.Location = new System.Drawing.Point(180, 27);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(20, 19);
            this.lblMoney.TabIndex = 4;
            this.lblMoney.Text = "0";
            // 
            // gvOrderDishInfo
            // 
            this.gvOrderDishInfo.AllowUserToAddRows = false;
            this.gvOrderDishInfo.AllowUserToDeleteRows = false;
            this.gvOrderDishInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrderDishInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oid,
            this.Column1,
            this.Column2,
            this.Column3});
            this.gvOrderDishInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvOrderDishInfo.Location = new System.Drawing.Point(3, 17);
            this.gvOrderDishInfo.Name = "gvOrderDishInfo";
            this.gvOrderDishInfo.ReadOnly = true;
            this.gvOrderDishInfo.RowTemplate.Height = 23;
            this.gvOrderDishInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvOrderDishInfo.Size = new System.Drawing.Size(338, 361);
            this.gvOrderDishInfo.TabIndex = 3;
            // 
            // oid
            // 
            this.oid.DataPropertyName = "OId";
            this.oid.HeaderText = "编号";
            this.oid.Name = "oid";
            this.oid.ReadOnly = true;
            this.oid.Width = 55;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DishTitle";
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Count";
            this.Column2.HeaderText = "数量";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DishPrice";
            this.Column3.HeaderText = "价格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // OrderDishList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 440);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblOrderDish);
            this.Controls.Add(this.label1);
            this.Name = "OrderDishList";
            this.Text = "用户已点菜品";
            this.Load += new System.EventHandler(this.OrderDishList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderDishInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrderDish;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.DataGridView gvOrderDishInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn oid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}