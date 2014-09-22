namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.objTabs = new System.Windows.Forms.TabControl();
            this.objTab1 = new System.Windows.Forms.TabPage();
            this.objPanel = new System.Windows.Forms.Panel();
            this.radFindWorker = new System.Windows.Forms.RadioButton();
            this.radAddWorker = new System.Windows.Forms.RadioButton();
            this.objTab2 = new System.Windows.Forms.TabPage();
            this.radSupervisor = new System.Windows.Forms.RadioButton();
            this.objPanel2 = new System.Windows.Forms.Panel();
            this.radSchedule = new System.Windows.Forms.RadioButton();
            this.radShifts = new System.Windows.Forms.RadioButton();
            this.objTab3 = new System.Windows.Forms.TabPage();
            this.butGetReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.dtDay = new System.Windows.Forms.DateTimePicker();
            this.butClose = new System.Windows.Forms.Button();
            this.objTabs.SuspendLayout();
            this.objTab1.SuspendLayout();
            this.objTab2.SuspendLayout();
            this.objTab3.SuspendLayout();
            this.SuspendLayout();
            // 
            // objTabs
            // 
            this.objTabs.Controls.Add(this.objTab1);
            this.objTabs.Controls.Add(this.objTab2);
            this.objTabs.Controls.Add(this.objTab3);
            this.objTabs.Location = new System.Drawing.Point(3, 12);
            this.objTabs.Name = "objTabs";
            this.objTabs.SelectedIndex = 0;
            this.objTabs.Size = new System.Drawing.Size(708, 446);
            this.objTabs.TabIndex = 0;
            this.objTabs.SelectedIndexChanged += new System.EventHandler(this.objTabs_SelectedIndexChanged);
            // 
            // objTab1
            // 
            this.objTab1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.objTab1.Controls.Add(this.objPanel);
            this.objTab1.Controls.Add(this.radFindWorker);
            this.objTab1.Controls.Add(this.radAddWorker);
            this.objTab1.Location = new System.Drawing.Point(4, 22);
            this.objTab1.Name = "objTab1";
            this.objTab1.Padding = new System.Windows.Forms.Padding(3);
            this.objTab1.Size = new System.Drawing.Size(700, 420);
            this.objTab1.TabIndex = 0;
            this.objTab1.Text = "Manage Workers";
            // 
            // objPanel
            // 
            this.objPanel.Location = new System.Drawing.Point(7, 30);
            this.objPanel.Name = "objPanel";
            this.objPanel.Size = new System.Drawing.Size(686, 382);
            this.objPanel.TabIndex = 2;
            // 
            // radFindWorker
            // 
            this.radFindWorker.AutoSize = true;
            this.radFindWorker.Location = new System.Drawing.Point(6, 6);
            this.radFindWorker.Name = "radFindWorker";
            this.radFindWorker.Size = new System.Drawing.Size(83, 17);
            this.radFindWorker.TabIndex = 1;
            this.radFindWorker.Text = "Find Worker";
            this.radFindWorker.UseVisualStyleBackColor = true;
            this.radFindWorker.CheckedChanged += new System.EventHandler(this.radFindWorker_CheckedChanged);
            // 
            // radAddWorker
            // 
            this.radAddWorker.AutoSize = true;
            this.radAddWorker.Checked = true;
            this.radAddWorker.Location = new System.Drawing.Point(127, 6);
            this.radAddWorker.Name = "radAddWorker";
            this.radAddWorker.Size = new System.Drawing.Size(82, 17);
            this.radAddWorker.TabIndex = 0;
            this.radAddWorker.TabStop = true;
            this.radAddWorker.Text = "Add Worker";
            this.radAddWorker.UseVisualStyleBackColor = true;
            this.radAddWorker.CheckedChanged += new System.EventHandler(this.radAddWorker_CheckedChanged);
            // 
            // objTab2
            // 
            this.objTab2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.objTab2.Controls.Add(this.radSupervisor);
            this.objTab2.Controls.Add(this.objPanel2);
            this.objTab2.Controls.Add(this.radSchedule);
            this.objTab2.Controls.Add(this.radShifts);
            this.objTab2.Location = new System.Drawing.Point(4, 22);
            this.objTab2.Name = "objTab2";
            this.objTab2.Padding = new System.Windows.Forms.Padding(3);
            this.objTab2.Size = new System.Drawing.Size(700, 420);
            this.objTab2.TabIndex = 1;
            this.objTab2.Text = "Manage Schedule";
            // 
            // radSupervisor
            // 
            this.radSupervisor.AutoSize = true;
            this.radSupervisor.Location = new System.Drawing.Point(135, 3);
            this.radSupervisor.Name = "radSupervisor";
            this.radSupervisor.Size = new System.Drawing.Size(109, 17);
            this.radSupervisor.TabIndex = 3;
            this.radSupervisor.TabStop = true;
            this.radSupervisor.Text = "Assign Supervisor";
            this.radSupervisor.UseVisualStyleBackColor = true;
            this.radSupervisor.CheckedChanged += new System.EventHandler(this.radSupervisor_CheckedChanged);
            // 
            // objPanel2
            // 
            this.objPanel2.Location = new System.Drawing.Point(6, 26);
            this.objPanel2.Name = "objPanel2";
            this.objPanel2.Size = new System.Drawing.Size(691, 391);
            this.objPanel2.TabIndex = 2;
            // 
            // radSchedule
            // 
            this.radSchedule.AutoSize = true;
            this.radSchedule.Location = new System.Drawing.Point(6, 3);
            this.radSchedule.Name = "radSchedule";
            this.radSchedule.Size = new System.Drawing.Size(112, 17);
            this.radSchedule.TabIndex = 1;
            this.radSchedule.TabStop = true;
            this.radSchedule.Text = "Manage Schedule";
            this.radSchedule.UseVisualStyleBackColor = true;
            this.radSchedule.CheckedChanged += new System.EventHandler(this.radSchedule_CheckedChanged);
            // 
            // radShifts
            // 
            this.radShifts.AutoSize = true;
            this.radShifts.Location = new System.Drawing.Point(261, 3);
            this.radShifts.Name = "radShifts";
            this.radShifts.Size = new System.Drawing.Size(85, 17);
            this.radShifts.TabIndex = 0;
            this.radShifts.TabStop = true;
            this.radShifts.Text = "Create Shifts";
            this.radShifts.UseVisualStyleBackColor = true;
            this.radShifts.CheckedChanged += new System.EventHandler(this.radShifts_CheckedChanged);
            // 
            // objTab3
            // 
            this.objTab3.Controls.Add(this.butGetReport);
            this.objTab3.Controls.Add(this.label1);
            this.objTab3.Controls.Add(this.lblDate);
            this.objTab3.Controls.Add(this.lblReport);
            this.objTab3.Controls.Add(this.cmbShift);
            this.objTab3.Controls.Add(this.cmbReports);
            this.objTab3.Controls.Add(this.dtDay);
            this.objTab3.Location = new System.Drawing.Point(4, 22);
            this.objTab3.Name = "objTab3";
            this.objTab3.Padding = new System.Windows.Forms.Padding(3);
            this.objTab3.Size = new System.Drawing.Size(700, 420);
            this.objTab3.TabIndex = 2;
            this.objTab3.Text = "Reports";
            this.objTab3.UseVisualStyleBackColor = true;
            // 
            // butGetReport
            // 
            this.butGetReport.Location = new System.Drawing.Point(183, 167);
            this.butGetReport.Name = "butGetReport";
            this.butGetReport.Size = new System.Drawing.Size(75, 23);
            this.butGetReport.TabIndex = 8;
            this.butGetReport.Text = "Get Report";
            this.butGetReport.UseVisualStyleBackColor = true;
            this.butGetReport.Visible = false;
            this.butGetReport.Click += new System.EventHandler(this.butGetReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Shift:";
            this.label1.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(64, 77);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date:";
            this.lblDate.Visible = false;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(64, 34);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(42, 13);
            this.lblReport.TabIndex = 5;
            this.lblReport.Text = "Report:";
            // 
            // cmbShift
            // 
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(136, 118);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(200, 21);
            this.cmbShift.TabIndex = 4;
            this.cmbShift.Visible = false;
            // 
            // cmbReports
            // 
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(136, 34);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(200, 21);
            this.cmbReports.TabIndex = 3;
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // dtDay
            // 
            this.dtDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDay.Location = new System.Drawing.Point(136, 77);
            this.dtDay.MaxDate = new System.DateTime(2010, 9, 11, 0, 0, 0, 0);
            this.dtDay.MinDate = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtDay.Name = "dtDay";
            this.dtDay.Size = new System.Drawing.Size(200, 20);
            this.dtDay.TabIndex = 2;
            this.dtDay.Value = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtDay.Visible = false;
            // 
            // butClose
            // 
            this.butClose.BackColor = System.Drawing.Color.Red;
            this.butClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.butClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butClose.Location = new System.Drawing.Point(620, 2);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(79, 28);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "Close ";
            this.butClose.UseVisualStyleBackColor = false;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 458);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.objTabs);
            this.Name = "Form1";
            this.Text = "HTC - Time Clock";
            this.objTabs.ResumeLayout(false);
            this.objTab1.ResumeLayout(false);
            this.objTab1.PerformLayout();
            this.objTab2.ResumeLayout(false);
            this.objTab2.PerformLayout();
            this.objTab3.ResumeLayout(false);
            this.objTab3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl objTabs;
        private System.Windows.Forms.TabPage objTab1;
        private System.Windows.Forms.TabPage objTab2;
        private System.Windows.Forms.RadioButton radFindWorker;
        private System.Windows.Forms.RadioButton radAddWorker;
        private System.Windows.Forms.Panel objPanel;
        private System.Windows.Forms.Panel objPanel2;
        private System.Windows.Forms.RadioButton radSchedule;
        private System.Windows.Forms.RadioButton radShifts;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.RadioButton radSupervisor;
        private System.Windows.Forms.TabPage objTab3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.DateTimePicker dtDay;
        private System.Windows.Forms.Button butGetReport;
    }
}

