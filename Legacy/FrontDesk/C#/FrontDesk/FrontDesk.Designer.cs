namespace FrontDesk
{
    partial class frmFrontDesk
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
            this.cmbWorker = new System.Windows.Forms.ComboBox();
            this.grpTimes = new System.Windows.Forms.GroupBox();
            this.butSubmit = new System.Windows.Forms.Button();
            this.dtOut = new System.Windows.Forms.DateTimePicker();
            this.dtIn = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblOut = new System.Windows.Forms.Label();
            this.lblIn = new System.Windows.Forms.Label();
            this.lblWorker = new System.Windows.Forms.Label();
            this.butSignIn = new System.Windows.Forms.Button();
            this.grpTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbWorker
            // 
            this.cmbWorker.FormattingEnabled = true;
            this.cmbWorker.Location = new System.Drawing.Point(70, 41);
            this.cmbWorker.Name = "cmbWorker";
            this.cmbWorker.Size = new System.Drawing.Size(148, 21);
            this.cmbWorker.TabIndex = 0;
            // 
            // grpTimes
            // 
            this.grpTimes.Controls.Add(this.butSubmit);
            this.grpTimes.Controls.Add(this.dtOut);
            this.grpTimes.Controls.Add(this.dtIn);
            this.grpTimes.Controls.Add(this.label1);
            this.grpTimes.Controls.Add(this.dtDate);
            this.grpTimes.Controls.Add(this.lblOut);
            this.grpTimes.Controls.Add(this.lblIn);
            this.grpTimes.Enabled = false;
            this.grpTimes.Location = new System.Drawing.Point(27, 112);
            this.grpTimes.Name = "grpTimes";
            this.grpTimes.Size = new System.Drawing.Size(191, 171);
            this.grpTimes.TabIndex = 1;
            this.grpTimes.TabStop = false;
            this.grpTimes.Text = "Time Worked";
            // 
            // butSubmit
            // 
            this.butSubmit.Location = new System.Drawing.Point(46, 142);
            this.butSubmit.Name = "butSubmit";
            this.butSubmit.Size = new System.Drawing.Size(75, 23);
            this.butSubmit.TabIndex = 6;
            this.butSubmit.Text = "Submit";
            this.butSubmit.UseVisualStyleBackColor = true;
            this.butSubmit.Click += new System.EventHandler(this.butSubmit_Click);
            // 
            // dtOut
            // 
            this.dtOut.CustomFormat = "h:MM tt";
            this.dtOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtOut.Location = new System.Drawing.Point(46, 100);
            this.dtOut.Name = "dtOut";
            this.dtOut.ShowUpDown = true;
            this.dtOut.Size = new System.Drawing.Size(102, 20);
            this.dtOut.TabIndex = 5;
            // 
            // dtIn
            // 
            this.dtIn.CustomFormat = "h:MM tt";
            this.dtIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtIn.Location = new System.Drawing.Point(46, 64);
            this.dtIn.Name = "dtIn";
            this.dtIn.ShowUpDown = true;
            this.dtIn.Size = new System.Drawing.Size(102, 20);
            this.dtIn.TabIndex = 4;
            this.dtIn.ValueChanged += new System.EventHandler(this.dtIn_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date:";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "M";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(46, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(102, 20);
            this.dtDate.TabIndex = 2;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // lblOut
            // 
            this.lblOut.AutoSize = true;
            this.lblOut.Location = new System.Drawing.Point(7, 100);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(27, 13);
            this.lblOut.TabIndex = 1;
            this.lblOut.Text = "Out:";
            // 
            // lblIn
            // 
            this.lblIn.AutoSize = true;
            this.lblIn.Location = new System.Drawing.Point(7, 64);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(19, 13);
            this.lblIn.TabIndex = 0;
            this.lblIn.Text = "In:";
            // 
            // lblWorker
            // 
            this.lblWorker.AutoSize = true;
            this.lblWorker.Location = new System.Drawing.Point(16, 41);
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Size = new System.Drawing.Size(45, 13);
            this.lblWorker.TabIndex = 2;
            this.lblWorker.Text = "Worker:";
            // 
            // butSignIn
            // 
            this.butSignIn.Location = new System.Drawing.Point(19, 83);
            this.butSignIn.Name = "butSignIn";
            this.butSignIn.Size = new System.Drawing.Size(75, 23);
            this.butSignIn.TabIndex = 3;
            this.butSignIn.Text = "Sign In";
            this.butSignIn.UseVisualStyleBackColor = true;
            this.butSignIn.Click += new System.EventHandler(this.butSignIn_Click);
            // 
            // frmFrontDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 354);
            this.Controls.Add(this.butSignIn);
            this.Controls.Add(this.lblWorker);
            this.Controls.Add(this.grpTimes);
            this.Controls.Add(this.cmbWorker);
            this.Name = "frmFrontDesk";
            this.Text = "Front Desk";
            this.grpTimes.ResumeLayout(false);
            this.grpTimes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWorker;
        private System.Windows.Forms.GroupBox grpTimes;
        private System.Windows.Forms.Button butSubmit;
        private System.Windows.Forms.DateTimePicker dtOut;
        private System.Windows.Forms.DateTimePicker dtIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.Label lblWorker;
        private System.Windows.Forms.Button butSignIn;
    }
}

