namespace BillParse
{
    partial class frmParse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParse));
            this.txtPath = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.butParse = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.objBrowseDir = new System.Windows.Forms.FolderBrowserDialog();
            this.butExcel = new System.Windows.Forms.Button();
            this.objMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSource = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSource_Zip = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSource_txt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete_zip = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete_txt = new System.Windows.Forms.ToolStripMenuItem();
            this.objBrowseFile = new System.Windows.Forms.OpenFileDialog();
            this.objMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 111);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(290, 20);
            this.txtPath.TabIndex = 0;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(308, 111);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 1;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // butParse
            // 
            this.butParse.Location = new System.Drawing.Point(62, 153);
            this.butParse.Name = "butParse";
            this.butParse.Size = new System.Drawing.Size(75, 23);
            this.butParse.TabIndex = 2;
            this.butParse.Text = "Parse File";
            this.butParse.UseVisualStyleBackColor = true;
            this.butParse.Click += new System.EventHandler(this.butParse_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(193, 153);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 47);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 4;
            // 
            // objBrowseDir
            // 
            this.objBrowseDir.RootFolder = System.Environment.SpecialFolder.Personal;
            // 
            // butExcel
            // 
            this.butExcel.Enabled = false;
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.Location = new System.Drawing.Point(344, 0);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(39, 41);
            this.butExcel.TabIndex = 5;
            this.butExcel.UseVisualStyleBackColor = true;
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // objMenu
            // 
            this.objMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.objMenu.Location = new System.Drawing.Point(0, 0);
            this.objMenu.Name = "objMenu";
            this.objMenu.Size = new System.Drawing.Size(387, 24);
            this.objMenu.TabIndex = 6;
            this.objMenu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSource,
            this.mnuDelete});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mnuSource
            // 
            this.mnuSource.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSource_Zip,
            this.mnuSource_txt});
            this.mnuSource.Name = "mnuSource";
            this.mnuSource.Size = new System.Drawing.Size(152, 22);
            this.mnuSource.Text = "Source";
            // 
            // mnuSource_Zip
            // 
            this.mnuSource_Zip.CheckOnClick = true;
            this.mnuSource_Zip.Name = "mnuSource_Zip";
            this.mnuSource_Zip.Size = new System.Drawing.Size(152, 22);
            this.mnuSource_Zip.Text = ".zip";
            this.mnuSource_Zip.Click += new System.EventHandler(this.mnuSource_Zip_Click);
            // 
            // mnuSource_txt
            // 
            this.mnuSource_txt.CheckOnClick = true;
            this.mnuSource_txt.Name = "mnuSource_txt";
            this.mnuSource_txt.Size = new System.Drawing.Size(152, 22);
            this.mnuSource_txt.Text = ".txt";
            this.mnuSource_txt.Click += new System.EventHandler(this.mnuSource_txt_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete_zip,
            this.mnuDelete_txt});
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete.Text = "Delete";
            // 
            // mnuDelete_zip
            // 
            this.mnuDelete_zip.CheckOnClick = true;
            this.mnuDelete_zip.Name = "mnuDelete_zip";
            this.mnuDelete_zip.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete_zip.Text = ".zip";
            this.mnuDelete_zip.Click += new System.EventHandler(this.mnuDelete_zip_Click);
            // 
            // mnuDelete_txt
            // 
            this.mnuDelete_txt.CheckOnClick = true;
            this.mnuDelete_txt.Name = "mnuDelete_txt";
            this.mnuDelete_txt.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete_txt.Text = ".txt";
            this.mnuDelete_txt.Click += new System.EventHandler(this.mnuDelete_txt_Click);
            // 
            // objBrowseFile
            // 
            this.objBrowseFile.Filter = "Text files|*.txt";
            // 
            // frmParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 213);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butParse);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.objMenu);
            this.MainMenuStrip = this.objMenu;
            this.Name = "frmParse";
            this.Text = "HTC - Parse USFS Bill";
            this.objMenu.ResumeLayout(false);
            this.objMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Button butParse;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FolderBrowserDialog objBrowseDir;
        private System.Windows.Forms.Button butExcel;
        private System.Windows.Forms.MenuStrip objMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSource;
        private System.Windows.Forms.ToolStripMenuItem mnuSource_Zip;
        private System.Windows.Forms.ToolStripMenuItem mnuSource_txt;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete_zip;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete_txt;
        private System.Windows.Forms.OpenFileDialog objBrowseFile;
    }
}

