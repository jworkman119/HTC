namespace htcHealthCenter_TPDates
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
            this.butCustomer = new System.Windows.Forms.Button();
            this.mnuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.grpPatient = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtCounselor = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.Label();
            this.lblCounselor = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.butReport = new System.Windows.Forms.Button();
            this.tabApps = new System.Windows.Forms.TabControl();
            this.tabTPDates = new System.Windows.Forms.TabPage();
            this.lblTP = new System.Windows.Forms.Label();
            this.rbTPno = new System.Windows.Forms.RadioButton();
            this.rbTPyes = new System.Windows.Forms.RadioButton();
            this.pnlTreatmentPlan = new System.Windows.Forms.Panel();
            this.butDate = new System.Windows.Forms.Button();
            this.lblTPcounselor = new System.Windows.Forms.Label();
            this.cmbCounselor = new System.Windows.Forms.ComboBox();
            this.lblTPLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.tabWaitList = new System.Windows.Forms.TabPage();
            this.lblWaitList = new System.Windows.Forms.Label();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.pnlWaitList = new System.Windows.Forms.Panel();
            this.cmbResource = new System.Windows.Forms.ComboBox();
            this.lblResource = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.dtWaitEnd = new System.Windows.Forms.DateTimePicker();
            this.dtWaitStart = new System.Windows.Forms.DateTimePicker();
            this.butSearch = new System.Windows.Forms.Button();
            this.mnuDelete.SuspendLayout();
            this.grpPatient.SuspendLayout();
            this.tabApps.SuspendLayout();
            this.tabTPDates.SuspendLayout();
            this.pnlTreatmentPlan.SuspendLayout();
            this.tabWaitList.SuspendLayout();
            this.pnlWaitList.SuspendLayout();
            this.SuspendLayout();
            // 
            // butCustomer
            // 
            this.butCustomer.Image = ((System.Drawing.Image)(resources.GetObject("butCustomer.Image")));
            this.butCustomer.Location = new System.Drawing.Point(24, 12);
            this.butCustomer.Name = "butCustomer";
            this.butCustomer.Size = new System.Drawing.Size(44, 35);
            this.butCustomer.TabIndex = 2;
            this.butCustomer.UseVisualStyleBackColor = true;
            this.butCustomer.Click += new System.EventHandler(this.butCustomer_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(108, 26);
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // txtPatient
            // 
            this.txtPatient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPatient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPatient.Location = new System.Drawing.Point(112, 60);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(136, 20);
            this.txtPatient.TabIndex = 0;
            this.txtPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatient_KeyDown);
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(59, 63);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(40, 13);
            this.lblPatient.TabIndex = 4;
            this.lblPatient.Text = "Patient";
            // 
            // grpPatient
            // 
            this.grpPatient.Controls.Add(this.txtPhone);
            this.grpPatient.Controls.Add(this.lblPhone);
            this.grpPatient.Controls.Add(this.txtCounselor);
            this.grpPatient.Controls.Add(this.txtDOB);
            this.grpPatient.Controls.Add(this.txtAccount);
            this.grpPatient.Controls.Add(this.lblCounselor);
            this.grpPatient.Controls.Add(this.lblDOB);
            this.grpPatient.Controls.Add(this.lblAccount);
            this.grpPatient.Location = new System.Drawing.Point(57, 93);
            this.grpPatient.Name = "grpPatient";
            this.grpPatient.Size = new System.Drawing.Size(249, 116);
            this.grpPatient.TabIndex = 7;
            this.grpPatient.TabStop = false;
            this.grpPatient.Text = "Patient Info";
            // 
            // txtPhone
            // 
            this.txtPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(87, 65);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(0, 13);
            this.txtPhone.TabIndex = 14;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(19, 65);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 13;
            this.lblPhone.Text = "Phone:";
            // 
            // txtCounselor
            // 
            this.txtCounselor.AutoSize = true;
            this.txtCounselor.Location = new System.Drawing.Point(87, 90);
            this.txtCounselor.Name = "txtCounselor";
            this.txtCounselor.Size = new System.Drawing.Size(0, 13);
            this.txtCounselor.TabIndex = 12;
            // 
            // txtDOB
            // 
            this.txtDOB.AutoSize = true;
            this.txtDOB.Location = new System.Drawing.Point(87, 44);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(0, 13);
            this.txtDOB.TabIndex = 11;
            // 
            // txtAccount
            // 
            this.txtAccount.AutoSize = true;
            this.txtAccount.Location = new System.Drawing.Point(87, 21);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(0, 13);
            this.txtAccount.TabIndex = 9;
            // 
            // lblCounselor
            // 
            this.lblCounselor.AutoSize = true;
            this.lblCounselor.Location = new System.Drawing.Point(19, 90);
            this.lblCounselor.Name = "lblCounselor";
            this.lblCounselor.Size = new System.Drawing.Size(57, 13);
            this.lblCounselor.TabIndex = 8;
            this.lblCounselor.Text = "Counselor:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(19, 44);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(33, 13);
            this.lblDOB.TabIndex = 2;
            this.lblDOB.Text = "DOB:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(19, 21);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(60, 13);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Account #:";
            // 
            // butReport
            // 
            this.butReport.Image = global::htcHealthCenter_TPDates.Properties.Resources.printer_orange_small3;
            this.butReport.Location = new System.Drawing.Point(87, 12);
            this.butReport.Name = "butReport";
            this.butReport.Size = new System.Drawing.Size(44, 35);
            this.butReport.TabIndex = 3;
            this.butReport.UseVisualStyleBackColor = true;
            this.butReport.Click += new System.EventHandler(this.butReport_Click);
            // 
            // tabApps
            // 
            this.tabApps.Controls.Add(this.tabTPDates);
            this.tabApps.Controls.Add(this.tabWaitList);
            this.tabApps.Location = new System.Drawing.Point(57, 215);
            this.tabApps.Name = "tabApps";
            this.tabApps.SelectedIndex = 0;
            this.tabApps.Size = new System.Drawing.Size(249, 194);
            this.tabApps.TabIndex = 9;
            this.tabApps.SelectedIndexChanged += new System.EventHandler(this.tabApps_SelectedIndexChanged);
            // 
            // tabTPDates
            // 
            this.tabTPDates.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabTPDates.Controls.Add(this.lblTP);
            this.tabTPDates.Controls.Add(this.rbTPno);
            this.tabTPDates.Controls.Add(this.rbTPyes);
            this.tabTPDates.Controls.Add(this.pnlTreatmentPlan);
            this.tabTPDates.Location = new System.Drawing.Point(4, 22);
            this.tabTPDates.Name = "tabTPDates";
            this.tabTPDates.Padding = new System.Windows.Forms.Padding(3);
            this.tabTPDates.Size = new System.Drawing.Size(241, 168);
            this.tabTPDates.TabIndex = 0;
            this.tabTPDates.Text = "Treatment Plan Date";
            // 
            // lblTP
            // 
            this.lblTP.AutoSize = true;
            this.lblTP.Location = new System.Drawing.Point(15, 10);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(82, 13);
            this.lblTP.TabIndex = 17;
            this.lblTP.Text = "Treatment Plan:";
            // 
            // rbTPno
            // 
            this.rbTPno.AutoSize = true;
            this.rbTPno.Location = new System.Drawing.Point(158, 8);
            this.rbTPno.Name = "rbTPno";
            this.rbTPno.Size = new System.Drawing.Size(39, 17);
            this.rbTPno.TabIndex = 16;
            this.rbTPno.Text = "No";
            this.rbTPno.UseVisualStyleBackColor = true;
            this.rbTPno.CheckedChanged += new System.EventHandler(this.rbTPno_CheckedChanged);
            // 
            // rbTPyes
            // 
            this.rbTPyes.AutoSize = true;
            this.rbTPyes.Location = new System.Drawing.Point(109, 8);
            this.rbTPyes.Name = "rbTPyes";
            this.rbTPyes.Size = new System.Drawing.Size(43, 17);
            this.rbTPyes.TabIndex = 15;
            this.rbTPyes.Text = "Yes";
            this.rbTPyes.UseVisualStyleBackColor = true;
            this.rbTPyes.CheckedChanged += new System.EventHandler(this.rbTPyes_CheckedChanged);
            // 
            // pnlTreatmentPlan
            // 
            this.pnlTreatmentPlan.Controls.Add(this.butDate);
            this.pnlTreatmentPlan.Controls.Add(this.lblTPcounselor);
            this.pnlTreatmentPlan.Controls.Add(this.cmbCounselor);
            this.pnlTreatmentPlan.Controls.Add(this.lblTPLocation);
            this.pnlTreatmentPlan.Controls.Add(this.cmbLocation);
            this.pnlTreatmentPlan.Controls.Add(this.lblDate);
            this.pnlTreatmentPlan.Controls.Add(this.dtDate);
            this.pnlTreatmentPlan.Location = new System.Drawing.Point(18, 31);
            this.pnlTreatmentPlan.Name = "pnlTreatmentPlan";
            this.pnlTreatmentPlan.Size = new System.Drawing.Size(209, 131);
            this.pnlTreatmentPlan.TabIndex = 14;
            // 
            // butDate
            // 
            this.butDate.Location = new System.Drawing.Point(66, 108);
            this.butDate.Name = "butDate";
            this.butDate.Size = new System.Drawing.Size(64, 23);
            this.butDate.TabIndex = 18;
            this.butDate.Text = "Add Date";
            this.butDate.UseVisualStyleBackColor = true;
            this.butDate.Click += new System.EventHandler(this.butDate_Click);
            // 
            // lblTPcounselor
            // 
            this.lblTPcounselor.AutoSize = true;
            this.lblTPcounselor.Location = new System.Drawing.Point(5, 43);
            this.lblTPcounselor.Name = "lblTPcounselor";
            this.lblTPcounselor.Size = new System.Drawing.Size(56, 13);
            this.lblTPcounselor.TabIndex = 17;
            this.lblTPcounselor.Text = "Resource:";
            // 
            // cmbCounselor
            // 
            this.cmbCounselor.FormattingEnabled = true;
            this.cmbCounselor.Location = new System.Drawing.Point(67, 40);
            this.cmbCounselor.Name = "cmbCounselor";
            this.cmbCounselor.Size = new System.Drawing.Size(133, 21);
            this.cmbCounselor.TabIndex = 16;
            // 
            // lblTPLocation
            // 
            this.lblTPLocation.AutoSize = true;
            this.lblTPLocation.Location = new System.Drawing.Point(5, 77);
            this.lblTPLocation.Name = "lblTPLocation";
            this.lblTPLocation.Size = new System.Drawing.Size(51, 13);
            this.lblTPLocation.TabIndex = 15;
            this.lblTPLocation.Text = "Location:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "Utica",
            "Rome"});
            this.cmbLocation.Location = new System.Drawing.Point(66, 74);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(136, 21);
            this.cmbLocation.TabIndex = 14;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Date:";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(66, 9);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(136, 20);
            this.dtDate.TabIndex = 12;
            // 
            // tabWaitList
            // 
            this.tabWaitList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabWaitList.Controls.Add(this.lblWaitList);
            this.tabWaitList.Controls.Add(this.rdNo);
            this.tabWaitList.Controls.Add(this.rdYes);
            this.tabWaitList.Controls.Add(this.pnlWaitList);
            this.tabWaitList.Location = new System.Drawing.Point(4, 22);
            this.tabWaitList.Name = "tabWaitList";
            this.tabWaitList.Padding = new System.Windows.Forms.Padding(3);
            this.tabWaitList.Size = new System.Drawing.Size(241, 168);
            this.tabWaitList.TabIndex = 1;
            this.tabWaitList.Text = "Wait List";
            // 
            // lblWaitList
            // 
            this.lblWaitList.AutoSize = true;
            this.lblWaitList.Location = new System.Drawing.Point(18, 17);
            this.lblWaitList.Name = "lblWaitList";
            this.lblWaitList.Size = new System.Drawing.Size(51, 13);
            this.lblWaitList.TabIndex = 3;
            this.lblWaitList.Text = "Wait List:";
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Checked = true;
            this.rdNo.Location = new System.Drawing.Point(124, 15);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(39, 17);
            this.rdNo.TabIndex = 2;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "No";
            this.rdNo.UseVisualStyleBackColor = true;
            this.rdNo.CheckedChanged += new System.EventHandler(this.rdNo_CheckedChanged);
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Location = new System.Drawing.Point(75, 15);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(43, 17);
            this.rdYes.TabIndex = 1;
            this.rdYes.Text = "Yes";
            this.rdYes.UseVisualStyleBackColor = true;
            this.rdYes.CheckedChanged += new System.EventHandler(this.rdYes_CheckedChanged);
            // 
            // pnlWaitList
            // 
            this.pnlWaitList.Controls.Add(this.cmbResource);
            this.pnlWaitList.Controls.Add(this.lblResource);
            this.pnlWaitList.Controls.Add(this.lblEnd);
            this.pnlWaitList.Controls.Add(this.lblStart);
            this.pnlWaitList.Controls.Add(this.butAdd);
            this.pnlWaitList.Controls.Add(this.dtWaitEnd);
            this.pnlWaitList.Controls.Add(this.dtWaitStart);
            this.pnlWaitList.Location = new System.Drawing.Point(18, 38);
            this.pnlWaitList.Name = "pnlWaitList";
            this.pnlWaitList.Size = new System.Drawing.Size(211, 124);
            this.pnlWaitList.TabIndex = 0;
            this.pnlWaitList.Visible = false;
            // 
            // cmbResource
            // 
            this.cmbResource.FormattingEnabled = true;
            this.cmbResource.Location = new System.Drawing.Point(57, 72);
            this.cmbResource.Name = "cmbResource";
            this.cmbResource.Size = new System.Drawing.Size(122, 21);
            this.cmbResource.TabIndex = 15;
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(1, 75);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(53, 13);
            this.lblResource.TabIndex = 14;
            this.lblResource.Text = "Resource";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(26, 41);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(26, 13);
            this.lblEnd.TabIndex = 13;
            this.lblEnd.Text = "End";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(25, 6);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 12;
            this.lblStart.Text = "Start";
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(68, 101);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(55, 20);
            this.butAdd.TabIndex = 11;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // dtWaitEnd
            // 
            this.dtWaitEnd.CustomFormat = "MM/dd/yyyy";
            this.dtWaitEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWaitEnd.Location = new System.Drawing.Point(57, 38);
            this.dtWaitEnd.Name = "dtWaitEnd";
            this.dtWaitEnd.Size = new System.Drawing.Size(122, 20);
            this.dtWaitEnd.TabIndex = 10;
            // 
            // dtWaitStart
            // 
            this.dtWaitStart.CustomFormat = "MM/dd/yyyy";
            this.dtWaitStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWaitStart.Location = new System.Drawing.Point(57, 3);
            this.dtWaitStart.Name = "dtWaitStart";
            this.dtWaitStart.Size = new System.Drawing.Size(122, 20);
            this.dtWaitStart.TabIndex = 9;
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(251, 57);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(55, 23);
            this.butSearch.TabIndex = 1;
            this.butSearch.Text = "Search";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 418);
            this.Controls.Add(this.butReport);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.grpPatient);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.tabApps);
            this.Controls.Add(this.butCustomer);
            this.Name = "frmMain";
            this.Text = "MHC - Treatment Plan Dates";
            this.mnuDelete.ResumeLayout(false);
            this.grpPatient.ResumeLayout(false);
            this.grpPatient.PerformLayout();
            this.tabApps.ResumeLayout(false);
            this.tabTPDates.ResumeLayout(false);
            this.tabTPDates.PerformLayout();
            this.pnlTreatmentPlan.ResumeLayout(false);
            this.pnlTreatmentPlan.PerformLayout();
            this.tabWaitList.ResumeLayout(false);
            this.tabWaitList.PerformLayout();
            this.pnlWaitList.ResumeLayout(false);
            this.pnlWaitList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCustomer;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.GroupBox grpPatient;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ContextMenuStrip mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lblCounselor;
        private System.Windows.Forms.Label txtCounselor;
        private System.Windows.Forms.Label txtDOB;
        private System.Windows.Forms.Label txtAccount;
        private System.Windows.Forms.Button butReport;
        private System.Windows.Forms.Label txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TabControl tabApps;
        private System.Windows.Forms.TabPage tabTPDates;
        private System.Windows.Forms.TabPage tabWaitList;
        private System.Windows.Forms.Label lblWaitList;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdYes;
        private System.Windows.Forms.Panel pnlWaitList;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DateTimePicker dtWaitEnd;
        private System.Windows.Forms.DateTimePicker dtWaitStart;
        private System.Windows.Forms.ComboBox cmbResource;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.Label lblTP;
        private System.Windows.Forms.RadioButton rbTPno;
        private System.Windows.Forms.RadioButton rbTPyes;
        private System.Windows.Forms.Panel pnlTreatmentPlan;
        private System.Windows.Forms.Label lblTPcounselor;
        private System.Windows.Forms.ComboBox cmbCounselor;
        private System.Windows.Forms.Label lblTPLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button butDate;
    }
}

