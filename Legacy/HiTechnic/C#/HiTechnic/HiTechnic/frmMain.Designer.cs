namespace HiTechnic
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.butImport = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.butUSPS = new System.Windows.Forms.Button();
            this.tabOrders = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdOrders = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mnuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdb200 = new System.Windows.Forms.RadioButton();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.chkSearch = new System.Windows.Forms.CheckBox();
            this.grpEmail = new System.Windows.Forms.GroupBox();
            this.tabOrders.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            this.mnuRightClick.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(12, 29);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(100, 23);
            this.butImport.TabIndex = 0;
            this.butImport.Text = "Import Data";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(19, 20);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(100, 20);
            this.dtDate.TabIndex = 10;
            // 
            // butUSPS
            // 
            this.butUSPS.Location = new System.Drawing.Point(19, 52);
            this.butUSPS.Name = "butUSPS";
            this.butUSPS.Size = new System.Drawing.Size(100, 23);
            this.butUSPS.TabIndex = 4;
            this.butUSPS.Text = "End of Day";
            this.butUSPS.UseVisualStyleBackColor = true;
            this.butUSPS.Click += new System.EventHandler(this.butUSPS_Click);
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.tabPage1);
            this.tabOrders.Controls.Add(this.tabPage2);
            this.tabOrders.Location = new System.Drawing.Point(2, 167);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.SelectedIndex = 0;
            this.tabOrders.Size = new System.Drawing.Size(993, 425);
            this.tabOrders.TabIndex = 4;
            this.tabOrders.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabOrders_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdOrders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Incomplete Orders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdOrders
            // 
            this.grdOrders.AllowUserToAddRows = false;
            this.grdOrders.AllowUserToDeleteRows = false;
            this.grdOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrders.Location = new System.Drawing.Point(6, 6);
            this.grdOrders.MultiSelect = false;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.ReadOnly = true;
            this.grdOrders.RowHeadersVisible = false;
            this.grdOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrders.Size = new System.Drawing.Size(976, 387);
            this.grdOrders.TabIndex = 0;
            this.grdOrders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdIncomplete_MouseClick);
            this.grdOrders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdIncomplete_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Completed Orders";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mnuRightClick
            // 
            this.mnuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem});
            this.mnuRightClick.Name = "contextMenuStrip1";
            this.mnuRightClick.Size = new System.Drawing.Size(100, 26);
            this.mnuRightClick.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuRightClick_ItemClicked);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(121, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 8;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(126, 20);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // rdb200
            // 
            this.rdb200.AutoSize = true;
            this.rdb200.Checked = true;
            this.rdb200.Location = new System.Drawing.Point(12, 18);
            this.rdb200.Name = "rdb200";
            this.rdb200.Size = new System.Drawing.Size(100, 17);
            this.rdb200.TabIndex = 11;
            this.rdb200.TabStop = true;
            this.rdb200.Text = "Last 200 Orders";
            this.rdb200.UseVisualStyleBackColor = true;
            this.rdb200.CheckedChanged += new System.EventHandler(this.rdb200_CheckedChanged);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.rdbAll);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.rdb200);
            this.grpSearch.Location = new System.Drawing.Point(12, 90);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(262, 68);
            this.grpSearch.TabIndex = 12;
            this.grpSearch.TabStop = false;
            this.grpSearch.Visible = false;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(130, 18);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(70, 17);
            this.rdbAll.TabIndex = 13;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All Orders";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // chkSearch
            // 
            this.chkSearch.AutoSize = true;
            this.chkSearch.Location = new System.Drawing.Point(12, 64);
            this.chkSearch.Name = "chkSearch";
            this.chkSearch.Size = new System.Drawing.Size(114, 17);
            this.chkSearch.TabIndex = 13;
            this.chkSearch.Text = "Search By Order#:";
            this.chkSearch.UseVisualStyleBackColor = true;
            this.chkSearch.Visible = false;
            this.chkSearch.CheckedChanged += new System.EventHandler(this.chkSearch_CheckedChanged_1);
            // 
            // grpEmail
            // 
            this.grpEmail.Controls.Add(this.dtDate);
            this.grpEmail.Controls.Add(this.butUSPS);
            this.grpEmail.Location = new System.Drawing.Point(863, 9);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(125, 89);
            this.grpEmail.TabIndex = 3;
            this.grpEmail.TabStop = false;
            this.grpEmail.Text = "Email";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1007, 604);
            this.Controls.Add(this.chkSearch);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabOrders);
            this.Controls.Add(this.butImport);
            this.Controls.Add(this.grpEmail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "HiTechnic";
            this.tabOrders.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            this.mnuRightClick.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpEmail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butUSPS;
        private System.Windows.Forms.TabControl tabOrders;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grdOrders;
        private System.Windows.Forms.ContextMenuStrip mnuRightClick;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdb200;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.CheckBox chkSearch;
        private System.Windows.Forms.GroupBox grpEmail;
    }
}