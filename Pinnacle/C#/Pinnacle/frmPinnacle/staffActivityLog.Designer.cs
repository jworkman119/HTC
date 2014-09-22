namespace frmPinnacle
{
    partial class staffActivityLog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabctlStaff = new System.Windows.Forms.TabControl();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.grdAllActivity = new System.Windows.Forms.DataGridView();
            this.tabConsumer = new System.Windows.Forms.TabPage();
            this.butSearch = new System.Windows.Forms.Button();
            this.txtConsumer = new System.Windows.Forms.TextBox();
            this.lblConsumer = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtDisability = new System.Windows.Forms.TextBox();
            this.lblDisability = new System.Windows.Forms.Label();
            this.txtFunding = new System.Windows.Forms.TextBox();
            this.lblFunding = new System.Windows.Forms.Label();
            this.grdActivity = new System.Windows.Forms.DataGridView();
            this.tabAdministrative = new System.Windows.Forms.TabPage();
            this.butAddAdmin = new System.Windows.Forms.Button();
            this.panelAdministrative = new System.Windows.Forms.Panel();
            this.dtTimeOut = new System.Windows.Forms.DateTimePicker();
            this.dtTimeIn = new System.Windows.Forms.DateTimePicker();
            this.butCancelAdmin = new System.Windows.Forms.Button();
            this.butEnterAdmin = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.lblStarted = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDateAdmin = new System.Windows.Forms.DateTimePicker();
            this.grdAdministrative = new System.Windows.Forms.DataGridView();
            this.mnuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDates = new System.Windows.Forms.GroupBox();
            this.dtTimeFrame = new System.Windows.Forms.DateTimePicker();
            this.rdMonth = new System.Windows.Forms.RadioButton();
            this.rdDay = new System.Windows.Forms.RadioButton();
            this.lblHours = new System.Windows.Forms.Label();
            this.mnuEdit.SuspendLayout();
            this.tabctlStaff.SuspendLayout();
            this.tabActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllActivity)).BeginInit();
            this.tabConsumer.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActivity)).BeginInit();
            this.tabAdministrative.SuspendLayout();
            this.panelAdministrative.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdministrative)).BeginInit();
            this.mnuDelete.SuspendLayout();
            this.grpDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuEdit
            // 
            this.mnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createReportToolStripMenuItem,
            this.toolStripSeparator2,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.mnuEdit.Name = "contextMenuStrip1";
            this.mnuEdit.Size = new System.Drawing.Size(176, 76);
            this.mnuEdit.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuEdit_ItemClicked);
            // 
            // createReportToolStripMenuItem
            // 
            this.createReportToolStripMenuItem.Name = "createReportToolStripMenuItem";
            this.createReportToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createReportToolStripMenuItem.Text = "Create Daily Report";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // tabctlStaff
            // 
            this.tabctlStaff.Controls.Add(this.tabActivity);
            this.tabctlStaff.Controls.Add(this.tabConsumer);
            this.tabctlStaff.Controls.Add(this.tabAdministrative);
            this.tabctlStaff.Location = new System.Drawing.Point(3, 3);
            this.tabctlStaff.Name = "tabctlStaff";
            this.tabctlStaff.SelectedIndex = 0;
            this.tabctlStaff.Size = new System.Drawing.Size(875, 460);
            this.tabctlStaff.TabIndex = 15;
            this.tabctlStaff.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabctlStaff_Selected);
            // 
            // tabActivity
            // 
            this.tabActivity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabActivity.Controls.Add(this.lblHours);
            this.tabActivity.Controls.Add(this.grdAllActivity);
            this.tabActivity.Controls.Add(this.grpDates);
            this.tabActivity.Location = new System.Drawing.Point(4, 22);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Size = new System.Drawing.Size(867, 434);
            this.tabActivity.TabIndex = 3;
            this.tabActivity.Text = "All Activity";
            // 
            // grdAllActivity
            // 
            this.grdAllActivity.AllowUserToAddRows = false;
            this.grdAllActivity.AllowUserToDeleteRows = false;
            this.grdAllActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAllActivity.ContextMenuStrip = this.mnuEdit;
            this.grdAllActivity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdAllActivity.Location = new System.Drawing.Point(21, 94);
            this.grdAllActivity.Name = "grdAllActivity";
            this.grdAllActivity.ReadOnly = true;
            this.grdAllActivity.RowHeadersVisible = false;
            this.grdAllActivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdAllActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAllActivity.Size = new System.Drawing.Size(832, 319);
            this.grdAllActivity.TabIndex = 5;
            this.grdAllActivity.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllActivity_CellDoubleClick);
            // 
            // tabConsumer
            // 
            this.tabConsumer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabConsumer.Controls.Add(this.butSearch);
            this.tabConsumer.Controls.Add(this.txtConsumer);
            this.tabConsumer.Controls.Add(this.lblConsumer);
            this.tabConsumer.Controls.Add(this.grpDetails);
            this.tabConsumer.Controls.Add(this.grdActivity);
            this.tabConsumer.Location = new System.Drawing.Point(4, 22);
            this.tabConsumer.Name = "tabConsumer";
            this.tabConsumer.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsumer.Size = new System.Drawing.Size(867, 434);
            this.tabConsumer.TabIndex = 0;
            this.tabConsumer.Text = "Consumer";
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(272, 24);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(75, 23);
            this.butSearch.TabIndex = 19;
            this.butSearch.Text = "Search";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // txtConsumer
            // 
            this.txtConsumer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsumer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsumer.Location = new System.Drawing.Point(96, 24);
            this.txtConsumer.Name = "txtConsumer";
            this.txtConsumer.Size = new System.Drawing.Size(160, 20);
            this.txtConsumer.TabIndex = 18;
            this.txtConsumer.Click += new System.EventHandler(this.txtConsumer_Click);
            // 
            // lblConsumer
            // 
            this.lblConsumer.AutoSize = true;
            this.lblConsumer.Location = new System.Drawing.Point(25, 24);
            this.lblConsumer.Name = "lblConsumer";
            this.lblConsumer.Size = new System.Drawing.Size(54, 13);
            this.lblConsumer.TabIndex = 17;
            this.lblConsumer.Text = "Consumer";
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.txtDisability);
            this.grpDetails.Controls.Add(this.lblDisability);
            this.grpDetails.Controls.Add(this.txtFunding);
            this.grpDetails.Controls.Add(this.lblFunding);
            this.grpDetails.Location = new System.Drawing.Point(388, 15);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(473, 45);
            this.grpDetails.TabIndex = 15;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Consumer Details";
            this.grpDetails.Visible = false;
            this.grpDetails.VisibleChanged += new System.EventHandler(this.grpDetails_VisibleChanged);
            // 
            // txtDisability
            // 
            this.txtDisability.BackColor = System.Drawing.SystemColors.Info;
            this.txtDisability.Location = new System.Drawing.Point(69, 16);
            this.txtDisability.Name = "txtDisability";
            this.txtDisability.ReadOnly = true;
            this.txtDisability.Size = new System.Drawing.Size(256, 20);
            this.txtDisability.TabIndex = 11;
            // 
            // lblDisability
            // 
            this.lblDisability.AutoSize = true;
            this.lblDisability.Location = new System.Drawing.Point(6, 19);
            this.lblDisability.Name = "lblDisability";
            this.lblDisability.Size = new System.Drawing.Size(48, 13);
            this.lblDisability.TabIndex = 10;
            this.lblDisability.Text = "Disability";
            // 
            // txtFunding
            // 
            this.txtFunding.BackColor = System.Drawing.SystemColors.Info;
            this.txtFunding.Location = new System.Drawing.Point(382, 16);
            this.txtFunding.Name = "txtFunding";
            this.txtFunding.ReadOnly = true;
            this.txtFunding.Size = new System.Drawing.Size(77, 20);
            this.txtFunding.TabIndex = 8;
            // 
            // lblFunding
            // 
            this.lblFunding.AutoSize = true;
            this.lblFunding.Location = new System.Drawing.Point(331, 19);
            this.lblFunding.Name = "lblFunding";
            this.lblFunding.Size = new System.Drawing.Size(45, 13);
            this.lblFunding.TabIndex = 5;
            this.lblFunding.Text = "Funding";
            // 
            // grdActivity
            // 
            this.grdActivity.AllowUserToAddRows = false;
            this.grdActivity.AllowUserToDeleteRows = false;
            this.grdActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdActivity.ContextMenuStrip = this.mnuEdit;
            this.grdActivity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdActivity.Location = new System.Drawing.Point(8, 66);
            this.grdActivity.Name = "grdActivity";
            this.grdActivity.ReadOnly = true;
            this.grdActivity.RowHeadersVisible = false;
            this.grdActivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdActivity.Size = new System.Drawing.Size(853, 344);
            this.grdActivity.TabIndex = 4;
            this.grdActivity.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdActivity_CellMouseDoubleClick);
            this.grdActivity.SelectionChanged += new System.EventHandler(this.grdActivity_SelectionChanged);
            // 
            // tabAdministrative
            // 
            this.tabAdministrative.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabAdministrative.Controls.Add(this.butAddAdmin);
            this.tabAdministrative.Controls.Add(this.panelAdministrative);
            this.tabAdministrative.Controls.Add(this.grdAdministrative);
            this.tabAdministrative.Location = new System.Drawing.Point(4, 22);
            this.tabAdministrative.Name = "tabAdministrative";
            this.tabAdministrative.Size = new System.Drawing.Size(867, 434);
            this.tabAdministrative.TabIndex = 2;
            this.tabAdministrative.Text = "Administrative";
            // 
            // butAddAdmin
            // 
            this.butAddAdmin.Location = new System.Drawing.Point(78, 248);
            this.butAddAdmin.Name = "butAddAdmin";
            this.butAddAdmin.Size = new System.Drawing.Size(75, 23);
            this.butAddAdmin.TabIndex = 0;
            this.butAddAdmin.Text = "Add";
            this.butAddAdmin.UseVisualStyleBackColor = true;
            this.butAddAdmin.Click += new System.EventHandler(this.butAddAdmin_Click);
            // 
            // panelAdministrative
            // 
            this.panelAdministrative.Controls.Add(this.dtTimeOut);
            this.panelAdministrative.Controls.Add(this.dtTimeIn);
            this.panelAdministrative.Controls.Add(this.butCancelAdmin);
            this.panelAdministrative.Controls.Add(this.butEnterAdmin);
            this.panelAdministrative.Controls.Add(this.txtDescription);
            this.panelAdministrative.Controls.Add(this.lblDescription);
            this.panelAdministrative.Controls.Add(this.lblFinished);
            this.panelAdministrative.Controls.Add(this.lblStarted);
            this.panelAdministrative.Controls.Add(this.lblDate);
            this.panelAdministrative.Controls.Add(this.dtDateAdmin);
            this.panelAdministrative.Location = new System.Drawing.Point(166, 278);
            this.panelAdministrative.Name = "panelAdministrative";
            this.panelAdministrative.Size = new System.Drawing.Size(460, 135);
            this.panelAdministrative.TabIndex = 1;
            this.panelAdministrative.Visible = false;
            // 
            // dtTimeOut
            // 
            this.dtTimeOut.CustomFormat = "h:mm tt";
            this.dtTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeOut.Location = new System.Drawing.Point(380, 16);
            this.dtTimeOut.Name = "dtTimeOut";
            this.dtTimeOut.ShowUpDown = true;
            this.dtTimeOut.Size = new System.Drawing.Size(69, 20);
            this.dtTimeOut.TabIndex = 2;
            this.dtTimeOut.Value = new System.DateTime(2012, 12, 7, 13, 58, 44, 0);
            this.dtTimeOut.ValueChanged += new System.EventHandler(this.dtTimeOut_ValueChanged);
            // 
            // dtTimeIn
            // 
            this.dtTimeIn.CustomFormat = "h:mm tt";
            this.dtTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeIn.Location = new System.Drawing.Point(243, 16);
            this.dtTimeIn.Name = "dtTimeIn";
            this.dtTimeIn.ShowUpDown = true;
            this.dtTimeIn.Size = new System.Drawing.Size(69, 20);
            this.dtTimeIn.TabIndex = 1;
            this.dtTimeIn.ValueChanged += new System.EventHandler(this.dtTimeIn_ValueChanged);
            // 
            // butCancelAdmin
            // 
            this.butCancelAdmin.Location = new System.Drawing.Point(270, 105);
            this.butCancelAdmin.Name = "butCancelAdmin";
            this.butCancelAdmin.Size = new System.Drawing.Size(75, 23);
            this.butCancelAdmin.TabIndex = 5;
            this.butCancelAdmin.Text = "Cancel";
            this.butCancelAdmin.UseVisualStyleBackColor = true;
            this.butCancelAdmin.Click += new System.EventHandler(this.butCancelAdmin_Click);
            // 
            // butEnterAdmin
            // 
            this.butEnterAdmin.Location = new System.Drawing.Point(142, 105);
            this.butEnterAdmin.Name = "butEnterAdmin";
            this.butEnterAdmin.Size = new System.Drawing.Size(75, 23);
            this.butEnterAdmin.TabIndex = 4;
            this.butEnterAdmin.Text = "Enter";
            this.butEnterAdmin.UseVisualStyleBackColor = true;
            this.butEnterAdmin.Click += new System.EventHandler(this.butEnterAdmin_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(87, 58);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(362, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description:";
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.Location = new System.Drawing.Point(325, 16);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(49, 13);
            this.lblFinished.TabIndex = 5;
            this.lblFinished.Text = "Finished:";
            // 
            // lblStarted
            // 
            this.lblStarted.AutoSize = true;
            this.lblStarted.Location = new System.Drawing.Point(196, 16);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(44, 13);
            this.lblStarted.TabIndex = 4;
            this.lblStarted.Text = "Started:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(42, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // dtDateAdmin
            // 
            this.dtDateAdmin.CustomFormat = "MM/dd/yyyy";
            this.dtDateAdmin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateAdmin.Location = new System.Drawing.Point(87, 16);
            this.dtDateAdmin.Name = "dtDateAdmin";
            this.dtDateAdmin.Size = new System.Drawing.Size(97, 20);
            this.dtDateAdmin.TabIndex = 0;
            // 
            // grdAdministrative
            // 
            this.grdAdministrative.AllowUserToAddRows = false;
            this.grdAdministrative.AllowUserToDeleteRows = false;
            this.grdAdministrative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAdministrative.ContextMenuStrip = this.mnuDelete;
            this.grdAdministrative.Location = new System.Drawing.Point(78, 13);
            this.grdAdministrative.Name = "grdAdministrative";
            this.grdAdministrative.ReadOnly = true;
            this.grdAdministrative.RowHeadersVisible = false;
            this.grdAdministrative.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAdministrative.Size = new System.Drawing.Size(597, 230);
            this.grdAdministrative.TabIndex = 0;
            this.grdAdministrative.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAdministrative_CellDoubleClick);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(108, 26);
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // grpDates
            // 
            this.grpDates.Controls.Add(this.rdDay);
            this.grpDates.Controls.Add(this.rdMonth);
            this.grpDates.Controls.Add(this.dtTimeFrame);
            this.grpDates.Location = new System.Drawing.Point(21, 13);
            this.grpDates.Name = "grpDates";
            this.grpDates.Size = new System.Drawing.Size(194, 75);
            this.grpDates.TabIndex = 3;
            this.grpDates.TabStop = false;
            this.grpDates.Text = "Time Frame";
            // 
            // dtTimeFrame
            // 
            this.dtTimeFrame.CustomFormat = "MMMM";
            this.dtTimeFrame.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeFrame.Location = new System.Drawing.Point(76, 29);
            this.dtTimeFrame.Name = "dtTimeFrame";
            this.dtTimeFrame.Size = new System.Drawing.Size(97, 20);
            this.dtTimeFrame.TabIndex = 2;
            this.dtTimeFrame.ValueChanged += new System.EventHandler(this.dtTimeFrame_ValueChanged);
            // 
            // rdMonth
            // 
            this.rdMonth.AutoSize = true;
            this.rdMonth.Checked = true;
            this.rdMonth.Location = new System.Drawing.Point(15, 19);
            this.rdMonth.Name = "rdMonth";
            this.rdMonth.Size = new System.Drawing.Size(55, 17);
            this.rdMonth.TabIndex = 3;
            this.rdMonth.TabStop = true;
            this.rdMonth.Text = "Month";
            this.rdMonth.UseVisualStyleBackColor = true;
            this.rdMonth.Click += new System.EventHandler(this.rdMonth_Click);
            // 
            // rdDay
            // 
            this.rdDay.AutoSize = true;
            this.rdDay.Location = new System.Drawing.Point(15, 42);
            this.rdDay.Name = "rdDay";
            this.rdDay.Size = new System.Drawing.Size(44, 17);
            this.rdDay.TabIndex = 4;
            this.rdDay.Text = "Day";
            this.rdDay.UseVisualStyleBackColor = true;
            this.rdDay.Click += new System.EventHandler(this.rdDay_Click);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(781, 75);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(47, 13);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Hours: 0";
            // 
            // staffActivityLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabctlStaff);
            this.Name = "staffActivityLog";
            this.Size = new System.Drawing.Size(881, 471);
            this.mnuEdit.ResumeLayout(false);
            this.tabctlStaff.ResumeLayout(false);
            this.tabActivity.ResumeLayout(false);
            this.tabActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllActivity)).EndInit();
            this.tabConsumer.ResumeLayout(false);
            this.tabConsumer.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActivity)).EndInit();
            this.tabAdministrative.ResumeLayout(false);
            this.panelAdministrative.ResumeLayout(false);
            this.panelAdministrative.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdministrative)).EndInit();
            this.mnuDelete.ResumeLayout(false);
            this.grpDates.ResumeLayout(false);
            this.grpDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabctlStaff;
        private System.Windows.Forms.TabPage tabConsumer;
        private System.Windows.Forms.Label lblConsumer;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.TextBox txtDisability;
        private System.Windows.Forms.Label lblDisability;
        private System.Windows.Forms.TextBox txtFunding;
        private System.Windows.Forms.Label lblFunding;
        private System.Windows.Forms.DataGridView grdActivity;
        private System.Windows.Forms.TabPage tabAdministrative;
        private System.Windows.Forms.Panel panelAdministrative;
        private System.Windows.Forms.Button butCancelAdmin;
        private System.Windows.Forms.Button butEnterAdmin;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFinished;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView grdAdministrative;
        private System.Windows.Forms.Button butAddAdmin;
        private System.Windows.Forms.DateTimePicker dtTimeOut;
        private System.Windows.Forms.DateTimePicker dtTimeIn;
        private System.Windows.Forms.DateTimePicker dtDateAdmin;
        private System.Windows.Forms.ContextMenuStrip mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtConsumer;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.DataGridView grdAllActivity;
        private System.Windows.Forms.GroupBox grpDates;
        private System.Windows.Forms.RadioButton rdDay;
        private System.Windows.Forms.RadioButton rdMonth;
        private System.Windows.Forms.DateTimePicker dtTimeFrame;
        private System.Windows.Forms.Label lblHours;
    }
}
