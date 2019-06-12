namespace UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMember = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tabHall = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(55, 55);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMember,
            this.menuDish,
            this.menuTable,
            this.menuOrder,
            this.menuQuit,
            this.menuManager});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 80);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuMember
            // 
            this.menuMember.Image = global::UI.Properties.Resources.member;
            this.menuMember.Name = "menuMember";
            this.menuMember.Size = new System.Drawing.Size(68, 76);
            this.menuMember.Text = "会员管理";
            this.menuMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuMember.Click += new System.EventHandler(this.menuMember_Click);
            // 
            // menuDish
            // 
            this.menuDish.Image = global::UI.Properties.Resources.dish;
            this.menuDish.Name = "menuDish";
            this.menuDish.Size = new System.Drawing.Size(68, 76);
            this.menuDish.Text = "菜品管理";
            this.menuDish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuDish.Click += new System.EventHandler(this.menuDish_Click);
            // 
            // menuTable
            // 
            this.menuTable.Image = global::UI.Properties.Resources.table;
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(68, 76);
            this.menuTable.Text = "餐桌管理";
            this.menuTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuTable.Click += new System.EventHandler(this.menuTable_Click);
            // 
            // menuOrder
            // 
            this.menuOrder.Image = global::UI.Properties.Resources.order;
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(67, 76);
            this.menuOrder.Text = "结账";
            this.menuOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuOrder.Click += new System.EventHandler(this.menuOrder_Click);
            // 
            // menuQuit
            // 
            this.menuQuit.Image = global::UI.Properties.Resources.quit;
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(68, 76);
            this.menuQuit.Text = "退出系统";
            this.menuQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuQuit.Click += new System.EventHandler(this.menuQuit_Click);
            // 
            // menuManager
            // 
            this.menuManager.Image = global::UI.Properties.Resources.manager;
            this.menuManager.Name = "menuManager";
            this.menuManager.Size = new System.Drawing.Size(68, 76);
            this.menuManager.Text = "综合管理";
            this.menuManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuManager.Click += new System.EventHandler(this.menuManager_Click);
            // 
            // tabHall
            // 
            this.tabHall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHall.Location = new System.Drawing.Point(0, 80);
            this.tabHall.Name = "tabHall";
            this.tabHall.SelectedIndex = 0;
            this.tabHall.Size = new System.Drawing.Size(785, 284);
            this.tabHall.TabIndex = 1;
            this.tabHall.SelectedIndexChanged += new System.EventHandler(this.tabHall_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "TableN.png");
            this.imageList1.Images.SetKeyName(1, "TableY.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 364);
            this.Controls.Add(this.tabHall);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "餐饮管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripMenuItem menuMember;
        private System.Windows.Forms.ToolStripMenuItem menuDish;
        private System.Windows.Forms.ToolStripMenuItem menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
        private System.Windows.Forms.ToolStripMenuItem menuManager;
        private System.Windows.Forms.TabControl tabHall;
        private System.Windows.Forms.ImageList imageList1;
    }
}