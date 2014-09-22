namespace BillingParse
{
    partial class frmBillingParse
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.objBrowse = new System.Windows.Forms.OpenFileDialog();
            this.butParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(55, 85);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(365, 20);
            this.txtPath.TabIndex = 0;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(449, 85);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 1;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // objBrowse
            // 
            this.objBrowse.FileName = "openFileDialog1";
            // 
            // butParse
            // 
            this.butParse.Location = new System.Drawing.Point(219, 161);
            this.butParse.Name = "butParse";
            this.butParse.Size = new System.Drawing.Size(75, 23);
            this.butParse.TabIndex = 2;
            this.butParse.Text = "Parse File";
            this.butParse.UseVisualStyleBackColor = true;
            this.butParse.Click += new System.EventHandler(this.butParse_Click);
            // 
            // frmBillingParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 233);
            this.Controls.Add(this.butParse);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.txtPath);
            this.Name = "frmBillingParse";
            this.Text = "frmBillingParse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.OpenFileDialog objBrowse;
        private System.Windows.Forms.Button butParse;
    }
}