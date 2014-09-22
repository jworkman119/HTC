namespace WindowsFormsApplication1
{
    partial class frmChangeTime
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.butDelete = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.butAdd = new System.Windows.Forms.Button();
            this.butAdjust = new System.Windows.Forms.Button();
            this.grdTimes = new System.Windows.Forms.DataGridView();
            this.lblID = new System.Windows.Forms.Label();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.chkAddEndTime = new System.Windows.Forms.CheckBox();
            this.chkAddStartTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.Location = new System.Drawing.Point(88, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(304, 23);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "label1";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(352, 313);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(98, 23);
            this.butDelete.TabIndex = 2;
            this.butDelete.Text = "Remove Time";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(121, 210);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(58, 13);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Start Time:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(121, 258);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(55, 13);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "End Time:";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "M/dd/yyyy h:mm:ss tt";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(205, 204);
            this.dtStart.MaxDate = new System.DateTime(2010, 9, 11, 0, 0, 0, 0);
            this.dtStart.MinDate = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(172, 20);
            this.dtStart.TabIndex = 7;
            this.dtStart.Value = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "M/dd/yyyy h:mm:ss tt";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(205, 258);
            this.dtEnd.MaxDate = new System.DateTime(2010, 9, 11, 0, 0, 0, 0);
            this.dtEnd.MinDate = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(172, 20);
            this.dtEnd.TabIndex = 8;
            this.dtEnd.Value = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(81, 313);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(98, 23);
            this.butAdd.TabIndex = 9;
            this.butAdd.Text = "Add Time";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butAdjust
            // 
            this.butAdjust.Enabled = false;
            this.butAdjust.Location = new System.Drawing.Point(218, 313);
            this.butAdjust.Name = "butAdjust";
            this.butAdjust.Size = new System.Drawing.Size(98, 23);
            this.butAdjust.TabIndex = 10;
            this.butAdjust.Text = "Adjust Time";
            this.butAdjust.UseVisualStyleBackColor = true;
            this.butAdjust.Click += new System.EventHandler(this.butAdjust_Click);
            // 
            // grdTimes
            // 
            this.grdTimes.AllowUserToAddRows = false;
            this.grdTimes.AllowUserToDeleteRows = false;
            this.grdTimes.AllowUserToResizeColumns = false;
            this.grdTimes.AllowUserToResizeRows = false;
            this.grdTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTimes.Location = new System.Drawing.Point(56, 47);
            this.grdTimes.MultiSelect = false;
            this.grdTimes.Name = "grdTimes";
            this.grdTimes.ReadOnly = true;
            this.grdTimes.RowHeadersVisible = false;
            this.grdTimes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdTimes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTimes.ShowCellErrors = false;
            this.grdTimes.ShowCellToolTips = false;
            this.grdTimes.ShowEditingIcon = false;
            this.grdTimes.Size = new System.Drawing.Size(383, 129);
            this.grdTimes.TabIndex = 30;
            this.grdTimes.DoubleClick += new System.EventHandler(this.grdTimes_DoubleClick);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(21, 18);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 31;
            // 
            // butUpdate
            // 
            this.butUpdate.Enabled = false;
            this.butUpdate.Location = new System.Drawing.Point(329, 18);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(110, 23);
            this.butUpdate.TabIndex = 32;
            this.butUpdate.Text = "Update Database";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(389, 220);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(61, 21);
            this.butClear.TabIndex = 33;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // chkAddEndTime
            // 
            this.chkAddEndTime.AutoSize = true;
            this.chkAddEndTime.Location = new System.Drawing.Point(124, 235);
            this.chkAddEndTime.Name = "chkAddEndTime";
            this.chkAddEndTime.Size = new System.Drawing.Size(93, 17);
            this.chkAddEndTime.TabIndex = 34;
            this.chkAddEndTime.Text = "Add End Time";
            this.chkAddEndTime.UseVisualStyleBackColor = true;
            this.chkAddEndTime.Visible = false;
            this.chkAddEndTime.CheckedChanged += new System.EventHandler(this.chkAddEndTime_CheckedChanged);
            // 
            // chkAddStartTime
            // 
            this.chkAddStartTime.AutoSize = true;
            this.chkAddStartTime.Location = new System.Drawing.Point(124, 182);
            this.chkAddStartTime.Name = "chkAddStartTime";
            this.chkAddStartTime.Size = new System.Drawing.Size(96, 17);
            this.chkAddStartTime.TabIndex = 35;
            this.chkAddStartTime.Text = "Add Start Time";
            this.chkAddStartTime.UseVisualStyleBackColor = true;
            this.chkAddStartTime.Visible = false;
            this.chkAddStartTime.CheckedChanged += new System.EventHandler(this.chkAddStartTime_CheckedChanged);
            // 
            // frmChangeTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 348);
            this.Controls.Add(this.chkAddStartTime);
            this.Controls.Add(this.chkAddEndTime);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.grdTimes);
            this.Controls.Add(this.butAdjust);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.lblHeading);
            this.Name = "frmChangeTime";
            this.Text = "Adjust Time";
            ((System.ComponentModel.ISupportInitialize)(this.grdTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butAdjust;
        private System.Windows.Forms.DataGridView grdTimes;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.CheckBox chkAddEndTime;
        private System.Windows.Forms.CheckBox chkAddStartTime;
    }
}