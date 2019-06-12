namespace UI
{
    partial class TableInfoList
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
            this.btnShowAll = new System.Windows.Forms.Button();
            this.cbxFreeSearch = new System.Windows.Forms.ComboBox();
            this.cbxHallSearch = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rb0 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.btnHallInfo = new System.Windows.Forms.Button();
            this.cbxHallInfo = new System.Windows.Forms.ComboBox();
            this.txtTTitle = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gvTableInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.free = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTableInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.cbxFreeSearch);
            this.groupBox1.Controls.Add(this.cbxHallSearch);
            this.groupBox1.Location = new System.Drawing.Point(440, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "餐桌查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "空  闲：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "厅  包：";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(23, 88);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(147, 23);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "显示全部餐桌";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // cbxFreeSearch
            // 
            this.cbxFreeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFreeSearch.FormattingEnabled = true;
            this.cbxFreeSearch.Location = new System.Drawing.Point(63, 57);
            this.cbxFreeSearch.Name = "cbxFreeSearch";
            this.cbxFreeSearch.Size = new System.Drawing.Size(121, 20);
            this.cbxFreeSearch.TabIndex = 1;
            this.cbxFreeSearch.SelectedIndexChanged += new System.EventHandler(this.cbxFreeSearch_SelectedIndexChanged);
            // 
            // cbxHallSearch
            // 
            this.cbxHallSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHallSearch.FormattingEnabled = true;
            this.cbxHallSearch.Location = new System.Drawing.Point(63, 23);
            this.cbxHallSearch.Name = "cbxHallSearch";
            this.cbxHallSearch.Size = new System.Drawing.Size(121, 20);
            this.cbxHallSearch.TabIndex = 0;
            this.cbxHallSearch.SelectedIndexChanged += new System.EventHandler(this.cbxHallSearch_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTId);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.rb0);
            this.groupBox2.Controls.Add(this.rb1);
            this.groupBox2.Controls.Add(this.btnHallInfo);
            this.groupBox2.Controls.Add(this.cbxHallInfo);
            this.groupBox2.Controls.Add(this.txtTTitle);
            this.groupBox2.Location = new System.Drawing.Point(440, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 255);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加\\修改";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "状  态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "厅  包：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "名  称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "编  号：";
            // 
            // txtTId
            // 
            this.txtTId.Location = new System.Drawing.Point(63, 20);
            this.txtTId.Name = "txtTId";
            this.txtTId.ReadOnly = true;
            this.txtTId.Size = new System.Drawing.Size(121, 21);
            this.txtTId.TabIndex = 9;
            this.txtTId.Text = "添加时无需填写！";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(21, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "提示：双击表项可以修改！";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(23, 226);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(147, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "删除选中的餐桌";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(109, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 176);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rb0
            // 
            this.rb0.AutoSize = true;
            this.rb0.Location = new System.Drawing.Point(125, 144);
            this.rb0.Name = "rb0";
            this.rb0.Size = new System.Drawing.Size(59, 16);
            this.rb0.TabIndex = 4;
            this.rb0.TabStop = true;
            this.rb0.Text = "使用中";
            this.rb0.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(63, 144);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(47, 16);
            this.rb1.TabIndex = 3;
            this.rb1.TabStop = true;
            this.rb1.Text = "空闲";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // btnHallInfo
            // 
            this.btnHallInfo.Location = new System.Drawing.Point(63, 106);
            this.btnHallInfo.Name = "btnHallInfo";
            this.btnHallInfo.Size = new System.Drawing.Size(121, 23);
            this.btnHallInfo.TabIndex = 2;
            this.btnHallInfo.Text = "厅包管理";
            this.btnHallInfo.UseVisualStyleBackColor = true;
            this.btnHallInfo.Click += new System.EventHandler(this.btnHallInfo_Click);
            // 
            // cbxHallInfo
            // 
            this.cbxHallInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHallInfo.FormattingEnabled = true;
            this.cbxHallInfo.Location = new System.Drawing.Point(63, 80);
            this.cbxHallInfo.Name = "cbxHallInfo";
            this.cbxHallInfo.Size = new System.Drawing.Size(121, 20);
            this.cbxHallInfo.TabIndex = 1;
            // 
            // txtTTitle
            // 
            this.txtTTitle.Location = new System.Drawing.Point(63, 50);
            this.txtTTitle.Name = "txtTTitle";
            this.txtTTitle.Size = new System.Drawing.Size(121, 21);
            this.txtTTitle.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvTableInfo);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 384);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "餐桌列表";
            // 
            // gvTableInfo
            // 
            this.gvTableInfo.AllowUserToAddRows = false;
            this.gvTableInfo.AllowUserToDeleteRows = false;
            this.gvTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTableInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.hall,
            this.free});
            this.gvTableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTableInfo.Location = new System.Drawing.Point(3, 17);
            this.gvTableInfo.MultiSelect = false;
            this.gvTableInfo.Name = "gvTableInfo";
            this.gvTableInfo.ReadOnly = true;
            this.gvTableInfo.RowTemplate.Height = 23;
            this.gvTableInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTableInfo.Size = new System.Drawing.Size(416, 364);
            this.gvTableInfo.TabIndex = 0;
            this.gvTableInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTableInfo_CellDoubleClick);
            this.gvTableInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvTableInfo_CellFormatting);
            // 
            // id
            // 
            this.id.DataPropertyName = "TId";
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // title
            // 
            this.title.DataPropertyName = "TTitle";
            this.title.HeaderText = "餐桌名称";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // hall
            // 
            this.hall.DataPropertyName = "HallType";
            this.hall.HeaderText = "所属厅包";
            this.hall.Name = "hall";
            this.hall.ReadOnly = true;
            // 
            // free
            // 
            this.free.DataPropertyName = "TIsFree";
            this.free.HeaderText = "是否空闲";
            this.free.Name = "free";
            this.free.ReadOnly = true;
            // 
            // TableInfoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 408);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TableInfoList";
            this.Text = "餐桌管理";
            this.Load += new System.EventHandler(this.TableInfoList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTableInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.ComboBox cbxFreeSearch;
        private System.Windows.Forms.ComboBox cbxHallSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rb0;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.Button btnHallInfo;
        private System.Windows.Forms.ComboBox cbxHallInfo;
        private System.Windows.Forms.TextBox txtTTitle;
        private System.Windows.Forms.DataGridView gvTableInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn hall;
        private System.Windows.Forms.DataGridViewTextBoxColumn free;
    }
}