namespace frmPinnacle
{
    partial class assignJob
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
            this.lblJob = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.MaskedTextBox();
            this.grpDates = new System.Windows.Forms.GroupBox();
            this.lblExtended = new System.Windows.Forms.Label();
            this.txtExtended = new System.Windows.Forms.MaskedTextBox();
            this.txtPlacement = new System.Windows.Forms.MaskedTextBox();
            this.lblPlacementDate = new System.Windows.Forms.Label();
            this.butJob = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.txtEmployer = new System.Windows.Forms.TextBox();
            this.lblEmployer = new System.Windows.Forms.Label();
            this.grpDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsumer
            // 
            this.txtConsumer.Location = new System.Drawing.Point(112, 27);
            this.txtConsumer.Name = "txtConsumer";
            this.txtConsumer.ReadOnly = true;
            this.txtConsumer.Size = new System.Drawing.Size(194, 20);
            this.txtConsumer.TabIndex = 10;
            // 
            // lblConsumer
            // 
            this.lblConsumer.AutoSize = true;
            this.lblConsumer.Location = new System.Drawing.Point(40, 30);
            this.lblConsumer.Name = "lblConsumer";
            this.lblConsumer.Size = new System.Drawing.Size(54, 13);
            this.lblConsumer.TabIndex = 1;
            this.lblConsumer.Text = "Consumer";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(47, 77);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(47, 13);
            this.lblJob.TabIndex = 2;
            this.lblJob.Text = "Job Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Job Description";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(49, 216);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Address";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(70, 261);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "City";
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(248, 261);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(22, 13);
            this.lblZip.TabIndex = 6;
            this.lblZip.Text = "Zip";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(112, 74);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(233, 20);
            this.txtJob.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(112, 113);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(233, 42);
            this.txtDescription.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(112, 213);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(233, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(112, 258);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(112, 20);
            this.txtCity.TabIndex = 4;
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(276, 258);
            this.txtZip.Mask = "00000-9999";
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(69, 20);
            this.txtZip.TabIndex = 5;
            // 
            // grpDates
            // 
            this.grpDates.Controls.Add(this.lblExtended);
            this.grpDates.Controls.Add(this.txtExtended);
            this.grpDates.Controls.Add(this.txtPlacement);
            this.grpDates.Controls.Add(this.lblPlacementDate);
            this.grpDates.Location = new System.Drawing.Point(50, 299);
            this.grpDates.Name = "grpDates";
            this.grpDates.Size = new System.Drawing.Size(318, 72);
            this.grpDates.TabIndex = 6;
            this.grpDates.TabStop = false;
            this.grpDates.Text = "Dates";
            // 
            // lblExtended
            // 
            this.lblExtended.AutoSize = true;
            this.lblExtended.Location = new System.Drawing.Point(175, 36);
            this.lblExtended.Name = "lblExtended";
            this.lblExtended.Size = new System.Drawing.Size(52, 13);
            this.lblExtended.TabIndex = 19;
            this.lblExtended.Text = "Extended";
            // 
            // txtExtended
            // 
            this.txtExtended.Location = new System.Drawing.Point(233, 33);
            this.txtExtended.Mask = "00/00/0000";
            this.txtExtended.Name = "txtExtended";
            this.txtExtended.Size = new System.Drawing.Size(69, 20);
            this.txtExtended.TabIndex = 1;
            this.txtExtended.ValidatingType = typeof(System.DateTime);
            // 
            // txtPlacement
            // 
            this.txtPlacement.Location = new System.Drawing.Point(70, 29);
            this.txtPlacement.Mask = "00/00/0000";
            this.txtPlacement.Name = "txtPlacement";
            this.txtPlacement.Size = new System.Drawing.Size(69, 20);
            this.txtPlacement.TabIndex = 0;
            this.txtPlacement.ValidatingType = typeof(System.DateTime);
            // 
            // lblPlacementDate
            // 
            this.lblPlacementDate.AutoSize = true;
            this.lblPlacementDate.Location = new System.Drawing.Point(1, 36);
            this.lblPlacementDate.Name = "lblPlacementDate";
            this.lblPlacementDate.Size = new System.Drawing.Size(57, 13);
            this.lblPlacementDate.TabIndex = 16;
            this.lblPlacementDate.Text = "Placement";
            // 
            // butJob
            // 
            this.butJob.Location = new System.Drawing.Point(113, 397);
            this.butJob.Name = "butJob";
            this.butJob.Size = new System.Drawing.Size(75, 23);
            this.butJob.TabIndex = 7;
            this.butJob.Text = "Assign Job";
            this.butJob.UseVisualStyleBackColor = true;
            this.butJob.Click += new System.EventHandler(this.butJob_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(270, 397);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // txtEmployer
            // 
            this.txtEmployer.Location = new System.Drawing.Point(114, 174);
            this.txtEmployer.Name = "txtEmployer";
            this.txtEmployer.Size = new System.Drawing.Size(233, 20);
            this.txtEmployer.TabIndex = 2;
            // 
            // lblEmployer
            // 
            this.lblEmployer.AutoSize = true;
            this.lblEmployer.Location = new System.Drawing.Point(51, 177);
            this.lblEmployer.Name = "lblEmployer";
            this.lblEmployer.Size = new System.Drawing.Size(50, 13);
            this.lblEmployer.TabIndex = 9;
            this.lblEmployer.Text = "Employer";
            // 
            // assignJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEmployer);
            this.Controls.Add(this.lblEmployer);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butJob);
            this.Controls.Add(this.grpDates);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.lblZip);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblConsumer);
            this.Controls.Add(this.txtConsumer);
            this.Name = "assignJob";
            this.Size = new System.Drawing.Size(408, 470);
            this.grpDates.ResumeLayout(false);
            this.grpDates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsumer;
        private System.Windows.Forms.Label lblConsumer;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.MaskedTextBox txtZip;
        private System.Windows.Forms.GroupBox grpDates;
        private System.Windows.Forms.MaskedTextBox txtPlacement;
        private System.Windows.Forms.Label lblPlacementDate;
        private System.Windows.Forms.Label lblExtended;
        private System.Windows.Forms.MaskedTextBox txtExtended;
        private System.Windows.Forms.Button butJob;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.TextBox txtEmployer;
        private System.Windows.Forms.Label lblEmployer;
    }
}
