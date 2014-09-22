namespace WindowsFormsApplication1
{
    partial class objFindPerson
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
            this.butSearch = new System.Windows.Forms.Button();
            this.picWorker = new System.Windows.Forms.PictureBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.objGrid = new System.Windows.Forms.DataGridView();
            this.butClear = new System.Windows.Forms.Button();
            this.butRole = new System.Windows.Forms.Button();
            this.butChangeTime = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWorker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(266, 315);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(75, 23);
            this.butSearch.TabIndex = 3;
            this.butSearch.Text = "Search";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // picWorker
            // 
            this.picWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWorker.Location = new System.Drawing.Point(31, 23);
            this.picWorker.Name = "picWorker";
            this.picWorker.Size = new System.Drawing.Size(124, 129);
            this.picWorker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWorker.TabIndex = 21;
            this.picWorker.TabStop = false;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(235, 269);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(236, 21);
            this.cmbRole.TabIndex = 2;
            this.cmbRole.SelectedValueChanged += new System.EventHandler(this.cmbRole_SelectedValueChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLastName.Location = new System.Drawing.Point(235, 233);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(236, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFirstName.Location = new System.Drawing.Point(235, 197);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(236, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(169, 277);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 28;
            this.lblRole.Text = "Role:";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(169, 236);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(61, 13);
            this.lblLast.TabIndex = 27;
            this.lblLast.Text = "Last Name:";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(169, 200);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(60, 13);
            this.lblFirst.TabIndex = 26;
            this.lblFirst.Text = "First Name:";
            // 
            // objGrid
            // 
            this.objGrid.AllowUserToAddRows = false;
            this.objGrid.AllowUserToDeleteRows = false;
            this.objGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.objGrid.Location = new System.Drawing.Point(168, 23);
            this.objGrid.MultiSelect = false;
            this.objGrid.Name = "objGrid";
            this.objGrid.ReadOnly = true;
            this.objGrid.RowHeadersVisible = false;
            this.objGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.objGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.objGrid.ShowCellErrors = false;
            this.objGrid.ShowCellToolTips = false;
            this.objGrid.ShowEditingIcon = false;
            this.objGrid.Size = new System.Drawing.Size(303, 129);
            this.objGrid.TabIndex = 29;
            this.objGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.objGrid_CellDoubleClick);
            this.objGrid.DoubleClick += new System.EventHandler(this.objGrid_DoubleClick);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(374, 315);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 23);
            this.butClear.TabIndex = 30;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butRole
            // 
            this.butRole.Enabled = false;
            this.butRole.Location = new System.Drawing.Point(150, 315);
            this.butRole.Name = "butRole";
            this.butRole.Size = new System.Drawing.Size(80, 23);
            this.butRole.TabIndex = 31;
            this.butRole.Text = "Change Role";
            this.butRole.UseVisualStyleBackColor = true;
            this.butRole.Click += new System.EventHandler(this.butRole_Click);
            // 
            // butChangeTime
            // 
            this.butChangeTime.Enabled = false;
            this.butChangeTime.Location = new System.Drawing.Point(41, 315);
            this.butChangeTime.Name = "butChangeTime";
            this.butChangeTime.Size = new System.Drawing.Size(80, 23);
            this.butChangeTime.TabIndex = 32;
            this.butChangeTime.Text = "Change Time";
            this.butChangeTime.UseVisualStyleBackColor = true;
            this.butChangeTime.Click += new System.EventHandler(this.butChangeTime_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Menu;
            this.txtID.Location = new System.Drawing.Point(235, 166);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(236, 20);
            this.txtID.TabIndex = 33;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(169, 169);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 34;
            this.lblID.Text = "ID:";
            // 
            // objFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.butChangeTime);
            this.Controls.Add(this.butRole);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.objGrid);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.picWorker);
            this.Name = "objFindPerson";
            this.Size = new System.Drawing.Size(487, 348);
            ((System.ComponentModel.ISupportInitialize)(this.picWorker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.PictureBox picWorker;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.DataGridView objGrid;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butRole;
        private System.Windows.Forms.Button butChangeTime;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblID;
    }
}
