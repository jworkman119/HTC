namespace frmTimeClock
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
            this.lblError = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblTimeIn = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.Label();
            this.txtTimeIn = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(21, 206);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(250, 56);
            this.lblError.TabIndex = 20;
            this.lblError.Visible = false;
            // 
            // lblInstructions
            // 
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(76, 55);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(121, 16);
            this.lblInstructions.TabIndex = 19;
            this.lblInstructions.Text = "Slide Time Card.";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(22, 9);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(249, 31);
            this.txtTime.TabIndex = 18;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(79, 174);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(120, 20);
            this.txtData.TabIndex = 17;
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(22, 140);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(53, 13);
            this.lblTimeOut.TabIndex = 16;
            this.lblTimeOut.Text = "Time Out:";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.AutoSize = true;
            this.lblTimeIn.Location = new System.Drawing.Point(30, 113);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(45, 13);
            this.lblTimeIn.TabIndex = 15;
            this.lblTimeIn.Text = "Time In:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(37, 84);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Name:";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeOut.Location = new System.Drawing.Point(85, 134);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(124, 19);
            this.txtTimeOut.TabIndex = 21;
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeIn.Location = new System.Drawing.Point(85, 111);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Size = new System.Drawing.Size(124, 19);
            this.txtTimeIn.TabIndex = 22;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(85, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(124, 19);
            this.txtName.TabIndex = 23;
            // 
            // frmTimeClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 296);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.lblName);
            this.Name = "frmTimeClock";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label txtTime;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.Label lblTimeIn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label txtTimeOut;
        private System.Windows.Forms.Label txtTimeIn;
        private System.Windows.Forms.Label txtName;

    }
}

