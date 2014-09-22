namespace htcHealthCenter_TPDates
{
    partial class frmReports
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
            this.cmbRange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRange = new System.Windows.Forms.Panel();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlMonth = new System.Windows.Forms.Panel();
            this.dtMonth = new System.Windows.Forms.DateTimePicker();
            this.lblMonth = new System.Windows.Forms.Label();
            this.butRun = new System.Windows.Forms.Button();
            this.lblReport = new System.Windows.Forms.Label();
            this.rdTPDates = new System.Windows.Forms.RadioButton();
            this.rdWaitList = new System.Windows.Forms.RadioButton();
            this.pnlRange.SuspendLayout();
            this.pnlMonth.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRange
            // 
            this.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRange.FormattingEnabled = true;
            this.cmbRange.Location = new System.Drawing.Point(97, 33);
            this.cmbRange.Name = "cmbRange";
            this.cmbRange.Size = new System.Drawing.Size(139, 21);
            this.cmbRange.TabIndex = 0;
            this.cmbRange.SelectedIndexChanged += new System.EventHandler(this.cmbRange_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date Range:";
            // 
            // pnlRange
            // 
            this.pnlRange.Controls.Add(this.dtTo);
            this.pnlRange.Controls.Add(this.lblTo);
            this.pnlRange.Controls.Add(this.dtFrom);
            this.pnlRange.Controls.Add(this.lblFrom);
            this.pnlRange.Location = new System.Drawing.Point(26, 103);
            this.pnlRange.Name = "pnlRange";
            this.pnlRange.Size = new System.Drawing.Size(220, 64);
            this.pnlRange.TabIndex = 4;
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "MM/dd/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(71, 41);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(139, 20);
            this.dtTo.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(3, 41);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To:";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "MM/dd/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(71, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(139, 20);
            this.dtFrom.TabIndex = 7;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(3, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From:";
            // 
            // pnlMonth
            // 
            this.pnlMonth.Controls.Add(this.dtMonth);
            this.pnlMonth.Controls.Add(this.lblMonth);
            this.pnlMonth.Location = new System.Drawing.Point(26, 62);
            this.pnlMonth.Name = "pnlMonth";
            this.pnlMonth.Size = new System.Drawing.Size(220, 30);
            this.pnlMonth.TabIndex = 7;
            // 
            // dtMonth
            // 
            this.dtMonth.CustomFormat = "MMMM";
            this.dtMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMonth.Location = new System.Drawing.Point(70, 7);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.Size = new System.Drawing.Size(140, 20);
            this.dtMonth.TabIndex = 10;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(4, 8);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 13);
            this.lblMonth.TabIndex = 8;
            this.lblMonth.Text = "Month:";
            // 
            // butRun
            // 
            this.butRun.Location = new System.Drawing.Point(96, 177);
            this.butRun.Name = "butRun";
            this.butRun.Size = new System.Drawing.Size(75, 23);
            this.butRun.TabIndex = 8;
            this.butRun.Text = "Run Report";
            this.butRun.UseVisualStyleBackColor = true;
            this.butRun.Click += new System.EventHandler(this.butRun_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(23, 9);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(42, 13);
            this.lblReport.TabIndex = 9;
            this.lblReport.Text = "Report:";
            // 
            // rdTPDates
            // 
            this.rdTPDates.AutoSize = true;
            this.rdTPDates.Checked = true;
            this.rdTPDates.Location = new System.Drawing.Point(96, 7);
            this.rdTPDates.Name = "rdTPDates";
            this.rdTPDates.Size = new System.Drawing.Size(70, 17);
            this.rdTPDates.TabIndex = 10;
            this.rdTPDates.Text = "TP Dates";
            this.rdTPDates.UseVisualStyleBackColor = true;
            this.rdTPDates.Click += new System.EventHandler(this.rdTPDates_Click);
            // 
            // rdWaitList
            // 
            this.rdWaitList.AutoSize = true;
            this.rdWaitList.Location = new System.Drawing.Point(166, 7);
            this.rdWaitList.Name = "rdWaitList";
            this.rdWaitList.Size = new System.Drawing.Size(66, 17);
            this.rdWaitList.TabIndex = 11;
            this.rdWaitList.Text = "Wait List";
            this.rdWaitList.UseVisualStyleBackColor = true;
            this.rdWaitList.Click += new System.EventHandler(this.rdWaitList_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 307);
            this.Controls.Add(this.rdWaitList);
            this.Controls.Add(this.rdTPDates);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.butRun);
            this.Controls.Add(this.pnlMonth);
            this.Controls.Add(this.pnlRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRange);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.pnlRange.ResumeLayout(false);
            this.pnlRange.PerformLayout();
            this.pnlMonth.ResumeLayout(false);
            this.pnlMonth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlRange;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Panel pnlMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button butRun;
        private System.Windows.Forms.DateTimePicker dtMonth;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.RadioButton rdTPDates;
        private System.Windows.Forms.RadioButton rdWaitList;
    }
}