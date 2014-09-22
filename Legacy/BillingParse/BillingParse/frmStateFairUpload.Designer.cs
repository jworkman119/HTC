namespace BillingParse
{
    partial class frmStateFairUpload
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblForder = new System.Windows.Forms.Label();
            this.butBrowse = new System.Windows.Forms.Button();
            this.butUpload = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.objBrowse = new System.Windows.Forms.OpenFileDialog();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.mnuCutCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblErrors = new System.Windows.Forms.Label();
            this.mnuCutCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(93, 76);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(306, 20);
            this.txtPath.TabIndex = 0;
            // 
            // lblForder
            // 
            this.lblForder.AutoSize = true;
            this.lblForder.Location = new System.Drawing.Point(12, 83);
            this.lblForder.Name = "lblForder";
            this.lblForder.Size = new System.Drawing.Size(75, 13);
            this.lblForder.TabIndex = 1;
            this.lblForder.Text = "File to Upload:";
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(436, 73);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 2;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // butUpload
            // 
            this.butUpload.Location = new System.Drawing.Point(93, 218);
            this.butUpload.Name = "butUpload";
            this.butUpload.Size = new System.Drawing.Size(122, 23);
            this.butUpload.TabIndex = 3;
            this.butUpload.Text = "Upload to Database";
            this.butUpload.UseVisualStyleBackColor = true;
            this.butUpload.Click += new System.EventHandler(this.butParse_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(277, 218);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(122, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // objBrowse
            // 
            this.objBrowse.DefaultExt = "xls";
            this.objBrowse.FileName = "openFileDialog1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(54, 47);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date:";
            // 
            // dtDate
            // 
            this.dtDate.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.dtDate.CalendarTrailingForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dtDate.CustomFormat = "\"m/d\"";
            this.dtDate.Location = new System.Drawing.Point(93, 41);
            this.dtDate.MaxDate = new System.DateTime(2012, 9, 7, 0, 0, 0, 0);
            this.dtDate.MinDate = new System.DateTime(2012, 8, 12, 0, 0, 0, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(200, 20);
            this.dtDate.TabIndex = 6;
            this.dtDate.Value = new System.DateTime(2012, 8, 12, 0, 0, 0, 0);
            // 
            // lstErrors
            // 
            this.lstErrors.ContextMenuStrip = this.mnuCutCopy;
            this.lstErrors.FormattingEnabled = true;
            this.lstErrors.Location = new System.Drawing.Point(93, 103);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstErrors.Size = new System.Drawing.Size(306, 95);
            this.lstErrors.TabIndex = 7;
            // 
            // mnuCutCopy
            // 
            this.mnuCutCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.mnuCutCopy.Name = "mnuCutCopy";
            this.mnuCutCopy.Size = new System.Drawing.Size(153, 48);
            this.mnuCutCopy.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuCutCopy_ItemClicked);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(-2, 103);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(89, 13);
            this.lblErrors.TabIndex = 8;
            this.lblErrors.Text = "Errors on Upload:";
            // 
            // frmStateFairUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 263);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butUpload);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.lblForder);
            this.Controls.Add(this.txtPath);
            this.Name = "frmStateFairUpload";
            this.Text = "Upload Schedule to Database";
            this.mnuCutCopy.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblForder;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Button butUpload;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.OpenFileDialog objBrowse;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ListBox lstErrors;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.ContextMenuStrip mnuCutCopy;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}

