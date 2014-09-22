namespace htcTimeClock
{
    partial class frmTimeClock
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.Label();
            this.tmrDigitalClock = new System.Windows.Forms.Timer(this.components);
            this.lblInstructions = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtTimeIn = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(28, 84);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Location = new System.Drawing.Point(21, 113);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(45, 13);
            this.lblTimeIn.TabIndex = 4;
            this.lblTimeIn.Text = "Time In:";
            this.lblTimeIn.Click += new System.EventHandler(this.lblTimeIn_Click);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(13, 140);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(53, 13);
            this.lblTimeOut.TabIndex = 5;
            this.lblTimeOut.Text = "Time Out:";
            this.lblTimeOut.Click += new System.EventHandler(this.lblTimeOut_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(70, 174);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(120, 20);
            this.txtData.TabIndex = 6;
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(13, 9);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(249, 31);
            this.txtTime.TabIndex = 7;
            this.txtTime.Click += new System.EventHandler(this.txtTime_Click);
            // 
            // tmrDigitalClock
            // 
            this.tmrDigitalClock.Enabled = true;
            this.tmrDigitalClock.Interval = 1000;
            this.tmrDigitalClock.Tick += new System.EventHandler(this.tmrDigitalClock_Tick);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(67, 55);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(121, 16);
            this.lblInstructions.TabIndex = 8;
            this.lblInstructions.Text = "Slide Time Card.";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblInstructions.Click += new System.EventHandler(this.lblInstructions_Click);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(83, 84);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 13);
            this.txtName.TabIndex = 10;
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.AutoSize = true;
            this.txtTimeIn.Location = new System.Drawing.Point(83, 113);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(0, 13);
            this.txtTimeIn.TabIndex = 11;
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.AutoSize = true;
            this.txtTimeOut.Location = new System.Drawing.Point(83, 140);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(0, 13);
            this.txtTimeOut.TabIndex = 12;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 206);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(328, 56);
            this.lblError.TabIndex = 13;
            this.lblError.Visible = false;
            // 
            // frmTimeClock
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 284);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.lblName);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "frmTimeClock";
            this.Text = "HTC - Time Clock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmTimeClock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label txtTime;
        private System.Windows.Forms.Timer tmrDigitalClock;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtTimeIn;
        private System.Windows.Forms.Label txtTimeOut;
        private System.Windows.Forms.Label lblError;
    }
}

