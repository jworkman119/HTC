namespace frmPinnacle
{
    partial class staffAddReview
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
            this.txtConsumer = new System.Windows.Forms.TextBox();
            this.lblConsumer = new System.Windows.Forms.Label();
            this.chkWaiver = new System.Windows.Forms.CheckBox();
            this.chkEmployed = new System.Windows.Forms.CheckBox();
            this.tbMeeting = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpMeeting = new System.Windows.Forms.GroupBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtTimeOut = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtTimeIn = new System.Windows.Forms.DateTimePicker();
            this.lblDetails = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtBarriers = new System.Windows.Forms.TextBox();
            this.lblBarriers = new System.Windows.Forms.Label();
            this.txtOutcome = new System.Windows.Forms.TextBox();
            this.lblOutcome = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMeeting = new System.Windows.Forms.ComboBox();
            this.lblMeeting = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpJob = new System.Windows.Forms.GroupBox();
            this.lblPlacement = new System.Windows.Forms.Label();
            this.txtPlacement = new System.Windows.Forms.MaskedTextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.MaskedTextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmployer = new System.Windows.Forms.TextBox();
            this.lblEmployer = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.lblJob = new System.Windows.Forms.Label();
            this.butEnter = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butEmpEnter = new System.Windows.Forms.Button();
            this.butEmpCancel = new System.Windows.Forms.Button();
            this.tbMeeting.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpMeeting.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpJob.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsumer
            // 
            this.txtConsumer.Location = new System.Drawing.Point(92, 12);
            this.txtConsumer.Name = "txtConsumer";
            this.txtConsumer.ReadOnly = true;
            this.txtConsumer.Size = new System.Drawing.Size(146, 20);
            this.txtConsumer.TabIndex = 3;
            // 
            // lblConsumer
            // 
            this.lblConsumer.AutoSize = true;
            this.lblConsumer.Location = new System.Drawing.Point(25, 15);
            this.lblConsumer.Name = "lblConsumer";
            this.lblConsumer.Size = new System.Drawing.Size(54, 13);
            this.lblConsumer.TabIndex = 3;
            this.lblConsumer.Text = "Consumer";
            // 
            // chkWaiver
            // 
            this.chkWaiver.AutoSize = true;
            this.chkWaiver.Location = new System.Drawing.Point(309, 42);
            this.chkWaiver.Name = "chkWaiver";
            this.chkWaiver.Size = new System.Drawing.Size(101, 17);
            this.chkWaiver.TabIndex = 5;
            this.chkWaiver.Text = "Waiver Enrolled";
            this.chkWaiver.UseVisualStyleBackColor = true;
            // 
            // chkEmployed
            // 
            this.chkEmployed.AutoSize = true;
            this.chkEmployed.Location = new System.Drawing.Point(92, 42);
            this.chkEmployed.Name = "chkEmployed";
            this.chkEmployed.Size = new System.Drawing.Size(72, 17);
            this.chkEmployed.TabIndex = 4;
            this.chkEmployed.Text = "Employed";
            this.chkEmployed.UseVisualStyleBackColor = true;
            this.chkEmployed.CheckedChanged += new System.EventHandler(this.chkEmployed_CheckedChanged);
            // 
            // tbMeeting
            // 
            this.tbMeeting.Controls.Add(this.tabPage1);
            this.tbMeeting.Controls.Add(this.tabPage2);
            this.tbMeeting.Location = new System.Drawing.Point(3, 65);
            this.tbMeeting.Name = "tbMeeting";
            this.tbMeeting.SelectedIndex = 0;
            this.tbMeeting.Size = new System.Drawing.Size(533, 428);
            this.tbMeeting.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.butCancel);
            this.tabPage1.Controls.Add(this.butEnter);
            this.tabPage1.Controls.Add(this.grpMeeting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(525, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Meeting Details";
            // 
            // grpMeeting
            // 
            this.grpMeeting.Controls.Add(this.lblEnd);
            this.grpMeeting.Controls.Add(this.dtTimeOut);
            this.grpMeeting.Controls.Add(this.lblStart);
            this.grpMeeting.Controls.Add(this.dtTimeIn);
            this.grpMeeting.Controls.Add(this.lblDetails);
            this.grpMeeting.Controls.Add(this.txtDetails);
            this.grpMeeting.Controls.Add(this.txtBarriers);
            this.grpMeeting.Controls.Add(this.lblBarriers);
            this.grpMeeting.Controls.Add(this.txtOutcome);
            this.grpMeeting.Controls.Add(this.lblOutcome);
            this.grpMeeting.Controls.Add(this.lblDate);
            this.grpMeeting.Controls.Add(this.dtDate);
            this.grpMeeting.Controls.Add(this.cmbMeeting);
            this.grpMeeting.Controls.Add(this.lblMeeting);
            this.grpMeeting.Location = new System.Drawing.Point(21, 28);
            this.grpMeeting.Name = "grpMeeting";
            this.grpMeeting.Size = new System.Drawing.Size(485, 302);
            this.grpMeeting.TabIndex = 5;
            this.grpMeeting.TabStop = false;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(308, 87);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(26, 13);
            this.lblEnd.TabIndex = 27;
            this.lblEnd.Text = "End";
            // 
            // dtTimeOut
            // 
            this.dtTimeOut.CustomFormat = "hh:mm tt";
            this.dtTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeOut.Location = new System.Drawing.Point(350, 82);
            this.dtTimeOut.Name = "dtTimeOut";
            this.dtTimeOut.ShowUpDown = true;
            this.dtTimeOut.Size = new System.Drawing.Size(102, 20);
            this.dtTimeOut.TabIndex = 3;
            this.dtTimeOut.ValueChanged += new System.EventHandler(this.dtTimeOut_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(57, 87);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 25;
            this.lblStart.Text = "Start";
            // 
            // dtTimeIn
            // 
            this.dtTimeIn.CustomFormat = "hh:mm tt";
            this.dtTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTimeIn.Location = new System.Drawing.Point(101, 81);
            this.dtTimeIn.Name = "dtTimeIn";
            this.dtTimeIn.ShowUpDown = true;
            this.dtTimeIn.Size = new System.Drawing.Size(102, 20);
            this.dtTimeIn.TabIndex = 2;
            this.dtTimeIn.ValueChanged += new System.EventHandler(this.dtTimeIn_ValueChanged);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(43, 199);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(50, 13);
            this.lblDetails.TabIndex = 23;
            this.lblDetails.Text = "Summary";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(101, 196);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(370, 89);
            this.txtDetails.TabIndex = 6;
            // 
            // txtBarriers
            // 
            this.txtBarriers.Location = new System.Drawing.Point(101, 156);
            this.txtBarriers.Name = "txtBarriers";
            this.txtBarriers.Size = new System.Drawing.Size(370, 20);
            this.txtBarriers.TabIndex = 5;
            // 
            // lblBarriers
            // 
            this.lblBarriers.AutoSize = true;
            this.lblBarriers.Location = new System.Drawing.Point(46, 159);
            this.lblBarriers.Name = "lblBarriers";
            this.lblBarriers.Size = new System.Drawing.Size(42, 13);
            this.lblBarriers.TabIndex = 20;
            this.lblBarriers.Text = "Barriers";
            // 
            // txtOutcome
            // 
            this.txtOutcome.Location = new System.Drawing.Point(101, 115);
            this.txtOutcome.Name = "txtOutcome";
            this.txtOutcome.Size = new System.Drawing.Size(370, 20);
            this.txtOutcome.TabIndex = 4;
            // 
            // lblOutcome
            // 
            this.lblOutcome.AutoSize = true;
            this.lblOutcome.Location = new System.Drawing.Point(6, 118);
            this.lblOutcome.Name = "lblOutcome";
            this.lblOutcome.Size = new System.Drawing.Size(86, 13);
            this.lblOutcome.TabIndex = 18;
            this.lblOutcome.Text = "Valued Outcome";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(308, 44);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(350, 41);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(102, 20);
            this.dtDate.TabIndex = 1;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // cmbMeeting
            // 
            this.cmbMeeting.FormattingEnabled = true;
            this.cmbMeeting.Location = new System.Drawing.Point(101, 41);
            this.cmbMeeting.Name = "cmbMeeting";
            this.cmbMeeting.Size = new System.Drawing.Size(131, 21);
            this.cmbMeeting.TabIndex = 0;
            this.cmbMeeting.SelectedValueChanged += new System.EventHandler(this.cmbMeeting_SelectedValueChanged);
            // 
            // lblMeeting
            // 
            this.lblMeeting.AutoSize = true;
            this.lblMeeting.Location = new System.Drawing.Point(14, 44);
            this.lblMeeting.Name = "lblMeeting";
            this.lblMeeting.Size = new System.Drawing.Size(72, 13);
            this.lblMeeting.TabIndex = 6;
            this.lblMeeting.Text = "Meeting Type";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.butEmpCancel);
            this.tabPage2.Controls.Add(this.butEmpEnter);
            this.tabPage2.Controls.Add(this.grpJob);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Current Employer";
            // 
            // grpJob
            // 
            this.grpJob.Controls.Add(this.lblPlacement);
            this.grpJob.Controls.Add(this.txtPlacement);
            this.grpJob.Controls.Add(this.lblZip);
            this.grpJob.Controls.Add(this.txtZip);
            this.grpJob.Controls.Add(this.lblCity);
            this.grpJob.Controls.Add(this.txtCity);
            this.grpJob.Controls.Add(this.lblAddress);
            this.grpJob.Controls.Add(this.txtAddress);
            this.grpJob.Controls.Add(this.txtEmployer);
            this.grpJob.Controls.Add(this.lblEmployer);
            this.grpJob.Controls.Add(this.txtDescription);
            this.grpJob.Controls.Add(this.lblDescription);
            this.grpJob.Controls.Add(this.txtJob);
            this.grpJob.Controls.Add(this.lblJob);
            this.grpJob.Location = new System.Drawing.Point(21, 21);
            this.grpJob.Name = "grpJob";
            this.grpJob.Size = new System.Drawing.Size(495, 242);
            this.grpJob.TabIndex = 4;
            this.grpJob.TabStop = false;
            // 
            // lblPlacement
            // 
            this.lblPlacement.AutoSize = true;
            this.lblPlacement.Location = new System.Drawing.Point(6, 216);
            this.lblPlacement.Name = "lblPlacement";
            this.lblPlacement.Size = new System.Drawing.Size(83, 13);
            this.lblPlacement.TabIndex = 39;
            this.lblPlacement.Text = "Placement Date";
            // 
            // txtPlacement
            // 
            this.txtPlacement.Location = new System.Drawing.Point(104, 213);
            this.txtPlacement.Mask = "00/00/0000";
            this.txtPlacement.Name = "txtPlacement";
            this.txtPlacement.Size = new System.Drawing.Size(68, 20);
            this.txtPlacement.TabIndex = 6;
            this.txtPlacement.ValidatingType = typeof(System.DateTime);
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(318, 179);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(22, 13);
            this.lblZip.TabIndex = 37;
            this.lblZip.Text = "Zip";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(350, 176);
            this.txtZip.Mask = "00000-9999";
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(70, 20);
            this.txtZip.TabIndex = 5;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(62, 179);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 35;
            this.lblCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(101, 176);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(167, 20);
            this.txtCity.TabIndex = 4;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(41, 145);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 33;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(101, 142);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(372, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtEmployer
            // 
            this.txtEmployer.Location = new System.Drawing.Point(101, 106);
            this.txtEmployer.Name = "txtEmployer";
            this.txtEmployer.Size = new System.Drawing.Size(374, 20);
            this.txtEmployer.TabIndex = 2;
            // 
            // lblEmployer
            // 
            this.lblEmployer.AutoSize = true;
            this.lblEmployer.Location = new System.Drawing.Point(38, 109);
            this.lblEmployer.Name = "lblEmployer";
            this.lblEmployer.Size = new System.Drawing.Size(50, 13);
            this.lblEmployer.TabIndex = 30;
            this.lblEmployer.Text = "Employer";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(101, 77);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(374, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 13);
            this.lblDescription.TabIndex = 28;
            this.lblDescription.Text = "Job Description";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(101, 44);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(374, 20);
            this.txtJob.TabIndex = 0;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(62, 47);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(24, 13);
            this.lblJob.TabIndex = 26;
            this.lblJob.Text = "Job";
            // 
            // butEnter
            // 
            this.butEnter.Location = new System.Drawing.Point(149, 358);
            this.butEnter.Name = "butEnter";
            this.butEnter.Size = new System.Drawing.Size(75, 23);
            this.butEnter.TabIndex = 6;
            this.butEnter.Text = "Enter";
            this.butEnter.UseVisualStyleBackColor = true;
            this.butEnter.Click += new System.EventHandler(this.butEnter_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(280, 358);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 7;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butEmpEnter
            // 
            this.butEmpEnter.Enabled = false;
            this.butEmpEnter.Location = new System.Drawing.Point(138, 316);
            this.butEmpEnter.Name = "butEmpEnter";
            this.butEmpEnter.Size = new System.Drawing.Size(75, 23);
            this.butEmpEnter.TabIndex = 7;
            this.butEmpEnter.Text = "Enter";
            this.butEmpEnter.UseVisualStyleBackColor = true;
            this.butEmpEnter.Click += new System.EventHandler(this.butEmpEnter_Click);
            // 
            // butEmpCancel
            // 
            this.butEmpCancel.Enabled = false;
            this.butEmpCancel.Location = new System.Drawing.Point(286, 316);
            this.butEmpCancel.Name = "butEmpCancel";
            this.butEmpCancel.Size = new System.Drawing.Size(75, 23);
            this.butEmpCancel.TabIndex = 8;
            this.butEmpCancel.Text = "Cancel";
            this.butEmpCancel.UseVisualStyleBackColor = true;
            this.butEmpCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // staffAddReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMeeting);
            this.Controls.Add(this.chkEmployed);
            this.Controls.Add(this.chkWaiver);
            this.Controls.Add(this.lblConsumer);
            this.Controls.Add(this.txtConsumer);
            this.Name = "staffAddReview";
            this.Size = new System.Drawing.Size(546, 496);
            this.tbMeeting.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpMeeting.ResumeLayout(false);
            this.grpMeeting.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpJob.ResumeLayout(false);
            this.grpJob.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsumer;
        private System.Windows.Forms.Label lblConsumer;
        private System.Windows.Forms.CheckBox chkWaiver;
        private System.Windows.Forms.CheckBox chkEmployed;
        private System.Windows.Forms.TabControl tbMeeting;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpMeeting;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtTimeOut;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtTimeIn;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.TextBox txtBarriers;
        private System.Windows.Forms.Label lblBarriers;
        private System.Windows.Forms.TextBox txtOutcome;
        private System.Windows.Forms.Label lblOutcome;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ComboBox cmbMeeting;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpJob;
        private System.Windows.Forms.Label lblPlacement;
        private System.Windows.Forms.MaskedTextBox txtPlacement;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.MaskedTextBox txtZip;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmployer;
        private System.Windows.Forms.Label lblEmployer;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butEnter;
        private System.Windows.Forms.Button butEmpCancel;
        private System.Windows.Forms.Button butEmpEnter;
    }
}
