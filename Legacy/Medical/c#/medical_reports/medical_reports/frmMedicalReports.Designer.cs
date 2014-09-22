namespace medical_reports
{
    partial class frmMedicalReports
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
            this.butUpdate = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.objFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.objFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // butUpdate
            // 
            this.butUpdate.Location = new System.Drawing.Point(53, 128);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(112, 23);
            this.butUpdate.TabIndex = 0;
            this.butUpdate.Text = "Update Database";
            this.butUpdate.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(226, 128);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(112, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(25, 55);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(313, 20);
            this.txtPath.TabIndex = 2;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(353, 53);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 3;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // objFileDialog
            // 
            this.objFileDialog.FileName = "openFileDialog1";
            // 
            // frmMedicalReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 190);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butUpdate);
            this.Name = "frmMedicalReports";
            this.Text = "HTC Medical Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.FolderBrowserDialog objFolderBrowser;
        private System.Windows.Forms.OpenFileDialog objFileDialog;
    }
}

