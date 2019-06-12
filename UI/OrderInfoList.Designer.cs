namespace UI
{
    partial class OrderInfoList
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gvDishInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.py = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxDishType = new System.Windows.Forms.ComboBox();
            this.txtPy = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gvOrderInfo = new System.Windows.Forms.DataGridView();
            this.oid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnRemoveDish = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDishInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.gvDishInfo);
            this.groupBox1.Controls.Add(this.cbxDishType);
            this.groupBox1.Controls.Add(this.txtPy);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "菜品分类查找：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "菜名首字母：";
            // 
            // gvDishInfo
            // 
            this.gvDishInfo.AllowUserToAddRows = false;
            this.gvDishInfo.AllowUserToDeleteRows = false;
            this.gvDishInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDishInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.price,
            this.type,
            this.py});
            this.gvDishInfo.Location = new System.Drawing.Point(6, 47);
            this.gvDishInfo.Name = "gvDishInfo";
            this.gvDishInfo.ReadOnly = true;
            this.gvDishInfo.RowTemplate.Height = 23;
            this.gvDishInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDishInfo.Size = new System.Drawing.Size(509, 364);
            this.gvDishInfo.TabIndex = 2;
            this.gvDishInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDishInfo_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "DId";
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // title
            // 
            this.title.DataPropertyName = "DTitle";
            this.title.HeaderText = "名称";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 120;
            // 
            // price
            // 
            this.price.DataPropertyName = "DPrice";
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 80;
            // 
            // type
            // 
            this.type.DataPropertyName = "TypeTitle";
            this.type.HeaderText = "菜系";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // py
            // 
            this.py.DataPropertyName = "DChar";
            this.py.HeaderText = "首字母";
            this.py.Name = "py";
            this.py.ReadOnly = true;
            this.py.Width = 80;
            // 
            // cbxDishType
            // 
            this.cbxDishType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDishType.FormattingEnabled = true;
            this.cbxDishType.Location = new System.Drawing.Point(344, 20);
            this.cbxDishType.Name = "cbxDishType";
            this.cbxDishType.Size = new System.Drawing.Size(121, 20);
            this.cbxDishType.TabIndex = 1;
            this.cbxDishType.SelectedIndexChanged += new System.EventHandler(this.cbxDishType_SelectedIndexChanged);
            // 
            // txtPy
            // 
            this.txtPy.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPy.Location = new System.Drawing.Point(89, 20);
            this.txtPy.Name = "txtPy";
            this.txtPy.Size = new System.Drawing.Size(112, 21);
            this.txtPy.TabIndex = 0;
            this.txtPy.TextChanged += new System.EventHandler(this.txtPy_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMoney);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.gvOrderInfo);
            this.groupBox2.Controls.Add(this.btnOrder);
            this.groupBox2.Controls.Add(this.btnRemoveDish);
            this.groupBox2.Location = new System.Drawing.Point(539, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 417);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已点菜品";
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.BackColor = System.Drawing.SystemColors.Control;
            this.lblMoney.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoney.ForeColor = System.Drawing.Color.Red;
            this.lblMoney.Location = new System.Drawing.Point(84, 15);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(22, 21);
            this.lblMoney.TabIndex = 4;
            this.lblMoney.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "消费总计：￥";
            // 
            // gvOrderInfo
            // 
            this.gvOrderInfo.AllowUserToAddRows = false;
            this.gvOrderInfo.AllowUserToDeleteRows = false;
            this.gvOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrderInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oid,
            this.Column1,
            this.Column2,
            this.Column3});
            this.gvOrderInfo.Location = new System.Drawing.Point(6, 47);
            this.gvOrderInfo.Name = "gvOrderInfo";
            this.gvOrderInfo.RowTemplate.Height = 23;
            this.gvOrderInfo.Size = new System.Drawing.Size(362, 364);
            this.gvOrderInfo.TabIndex = 2;
            this.gvOrderInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvOrderInfo_CellEndEdit);
            // 
            // oid
            // 
            this.oid.DataPropertyName = "OId";
            this.oid.HeaderText = "编号";
            this.oid.Name = "oid";
            this.oid.ReadOnly = true;
            this.oid.Width = 60;
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
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DishPrice";
            this.Column3.HeaderText = "价格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(180, 17);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "下单";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnRemoveDish
            // 
            this.btnRemoveDish.Location = new System.Drawing.Point(261, 17);
            this.btnRemoveDish.Name = "btnRemoveDish";
            this.btnRemoveDish.Size = new System.Drawing.Size(107, 23);
            this.btnRemoveDish.TabIndex = 0;
            this.btnRemoveDish.Text = "删除选中菜品";
            this.btnRemoveDish.UseVisualStyleBackColor = true;
            this.btnRemoveDish.Click += new System.EventHandler(this.btnRemoveDish_Click);
            // 
            // OrderInfoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrderInfoList";
            this.Text = "点菜界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderInfoList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderInfoList_FormClosed);
            this.Load += new System.EventHandler(this.OrderInfoList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDishInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvDishInfo;
        private System.Windows.Forms.ComboBox cbxDishType;
        private System.Windows.Forms.TextBox txtPy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvOrderInfo;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnRemoveDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn py;
        private System.Windows.Forms.DataGridViewTextBoxColumn oid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}