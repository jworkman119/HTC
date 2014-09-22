namespace frmPinnacle
{
    partial class ConsumerList
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
            this.grdConsumers = new System.Windows.Forms.DataGridView();
            this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.View = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.menuReview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDates = new System.Windows.Forms.GroupBox();
            this.rdDay = new System.Windows.Forms.RadioButton();
            this.rdMonth = new System.Windows.Forms.RadioButton();
            this.dtTimeFrame = new System.Windows.Forms.DateTimePicker();
            this.lblHours = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdConsumers)).BeginInit();
            this.menuGrid.SuspendLayout();
            this.menuReview.SuspendLayout();
            this.grpDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdConsumers
            // 
            this.grdConsumers.AllowUserToAddRows = false;
            this.grdConsumers.AllowUserToDeleteRows = false;
            this.grdConsumers.AllowUserToOrderColumns = true;
            this.grdConsumers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConsumers.ContextMenuStrip = this.menuGrid;
            this.grdConsumers.Location = new System.Drawing.Point(3, 121);
            this.grdConsumers.Name = "grdConsumers";
            this.grdConsumers.ReadOnly = true;
            this.grdConsumers.RowHeadersVisible = false;
            this.grdConsumers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConsumers.Size = new System.Drawing.Size(747, 385);
            this.grdConsumers.TabIndex = 1;
            this.grdConsumers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdConsumers_CellMouseClick);
    
            // 
            // menuGrid
            // 
            this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View});
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.Size = new System.Drawing.Size(153, 48);
            this.menuGrid.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuGrid_ItemClicked);
            // 
            // View
            // 
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(152, 22);
            this.View.Text = "View";

            // 
            // cmbStaff
            // 
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(52, 6);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(186, 21);
            this.cmbStaff.TabIndex = 0;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(3, 6);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(29, 13);
            this.lblStaff.TabIndex = 2;
            this.lblStaff.Text = "Staff";
            // 
            // menuReview
            // 
            this.menuReview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editReviewToolStripMenuItem,
            this.deleteReviewToolStripMenuItem});
            this.menuReview.Name = "menuReview";
            this.menuReview.Size = new System.Drawing.Size(148, 48);
            this.menuReview.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuReview_ItemClicked);
            // 
            // editReviewToolStripMenuItem
            // 
            this.editReviewToolStripMenuItem.Name = "editReviewToolStripMenuItem";
            this.editReviewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editReviewToolStripMenuItem.Text = "Edit Review";
            // 
            // deleteReviewToolStripMenuItem
            // 
            this.deleteReviewToolStripMenuItem.Name = "deleteReviewToolStripMenuItem";
            this.deleteReviewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteReviewToolStripMenuItem.Text = "Delete Review";
            // 
            // grpDates
            // 
            this.grpDates.Controls.Add(this.rdDay);
            this.grpDates.Controls.Add(this.rdMonth);
            this.grpDates.Controls.Add(this.dtTimeFrame);
            this.grpDates.Location = new System.Drawing.Point(52, 43);
            this.grpDates.Name = "grpDates";
            this.grpDates.Size = new System.Drawing.Size(186, 75);
            this.grpDates.TabIndex = 4;
            this.grpDates.TabStop = false;
            this.grpDates.Text = "Time Frame";
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
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(684, 105);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(47, 13);
            this.lblHours.TabIndex = 7;
            this.lblHours.Text = "Hours: 0";
            // 
            // ConsumerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.grpDates);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.grdConsumers);
            this.Name = "ConsumerList";
            this.Size = new System.Drawing.Size(762, 525);
            ((System.ComponentModel.ISupportInitialize)(this.grdConsumers)).EndInit();
            this.menuGrid.ResumeLayout(false);
            this.menuReview.ResumeLayout(false);
            this.grpDates.ResumeLayout(false);
            this.grpDates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdConsumers;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ContextMenuStrip menuGrid;
        private System.Windows.Forms.ToolStripMenuItem View;
        private System.Windows.Forms.ContextMenuStrip menuReview;
        private System.Windows.Forms.ToolStripMenuItem editReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteReviewToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpDates;
        private System.Windows.Forms.RadioButton rdDay;
        private System.Windows.Forms.RadioButton rdMonth;
        private System.Windows.Forms.DateTimePicker dtTimeFrame;
        private System.Windows.Forms.Label lblHours;
    }
}
