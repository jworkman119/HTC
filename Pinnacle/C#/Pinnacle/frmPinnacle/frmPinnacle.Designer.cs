namespace frmPinnacle
{
    partial class frmPinnacle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPinnacle));
            this.butAllUsers = new System.Windows.Forms.Button();
            this.butAddUser = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.butAddReview = new System.Windows.Forms.Button();
            this.butMonthlyReport = new System.Windows.Forms.Button();
            this.butDailyReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butAllUsers
            // 
            this.butAllUsers.Image = ((System.Drawing.Image)(resources.GetObject("butAllUsers.Image")));
            this.butAllUsers.Location = new System.Drawing.Point(12, 26);
            this.butAllUsers.Name = "butAllUsers";
            this.butAllUsers.Size = new System.Drawing.Size(54, 56);
            this.butAllUsers.TabIndex = 0;
            this.butAllUsers.UseVisualStyleBackColor = true;
            this.butAllUsers.Click += new System.EventHandler(this.butAllUsers_Click);
            // 
            // butAddUser
            // 
            this.butAddUser.Image = ((System.Drawing.Image)(resources.GetObject("butAddUser.Image")));
            this.butAddUser.Location = new System.Drawing.Point(69, 26);
            this.butAddUser.Name = "butAddUser";
            this.butAddUser.Size = new System.Drawing.Size(54, 56);
            this.butAddUser.TabIndex = 1;
            this.butAddUser.UseVisualStyleBackColor = true;
            this.butAddUser.Click += new System.EventHandler(this.butAddUser_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(9, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 2;
            // 
            // butAddReview
            // 
            this.butAddReview.Enabled = false;
            this.butAddReview.Image = ((System.Drawing.Image)(resources.GetObject("butAddReview.Image")));
            this.butAddReview.Location = new System.Drawing.Point(129, 26);
            this.butAddReview.Name = "butAddReview";
            this.butAddReview.Size = new System.Drawing.Size(54, 56);
            this.butAddReview.TabIndex = 3;
            this.butAddReview.UseVisualStyleBackColor = true;
            this.butAddReview.Click += new System.EventHandler(this.butAddReview_Click);
            // 
            // butMonthlyReport
            // 
            this.butMonthlyReport.Enabled = false;
            this.butMonthlyReport.Image = ((System.Drawing.Image)(resources.GetObject("butMonthlyReport.Image")));
            this.butMonthlyReport.Location = new System.Drawing.Point(189, 26);
            this.butMonthlyReport.Name = "butMonthlyReport";
            this.butMonthlyReport.Size = new System.Drawing.Size(54, 56);
            this.butMonthlyReport.TabIndex = 4;
            this.butMonthlyReport.UseVisualStyleBackColor = true;
            this.butMonthlyReport.Click += new System.EventHandler(this.butMonthlyReport_Click);
            // 
            // butDailyReport
            // 
            this.butDailyReport.Enabled = false;
            this.butDailyReport.Image = ((System.Drawing.Image)(resources.GetObject("butDailyReport.Image")));
            this.butDailyReport.Location = new System.Drawing.Point(249, 26);
            this.butDailyReport.Name = "butDailyReport";
            this.butDailyReport.Size = new System.Drawing.Size(54, 56);
            this.butDailyReport.TabIndex = 5;
            this.butDailyReport.UseVisualStyleBackColor = true;
            this.butDailyReport.Click += new System.EventHandler(this.butDailyReport_Click);
            // 
            // frmPinnacle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 592);
            this.Controls.Add(this.butDailyReport);
            this.Controls.Add(this.butMonthlyReport);
            this.Controls.Add(this.butAddReview);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.butAddUser);
            this.Controls.Add(this.butAllUsers);
            this.Name = "frmPinnacle";
            this.Text = "Pinnacle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAllUsers;
        private System.Windows.Forms.Button butAddUser;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button butAddReview;
        private System.Windows.Forms.Button butMonthlyReport;
        private System.Windows.Forms.Button butDailyReport;
    }
}

