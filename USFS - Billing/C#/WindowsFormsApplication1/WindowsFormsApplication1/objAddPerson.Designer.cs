namespace WindowsFormsApplication1
{
    partial class objAddPerson
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
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.butEnter = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.picWorker = new System.Windows.Forms.PictureBox();
            this.butAddPic = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.objOpenFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLastName.Location = new System.Drawing.Point(216, 70);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(236, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFirstName.Location = new System.Drawing.Point(216, 34);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(236, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // butEnter
            // 
            this.butEnter.Location = new System.Drawing.Point(288, 200);
            this.butEnter.Name = "butEnter";
            this.butEnter.Size = new System.Drawing.Size(75, 23);
            this.butEnter.TabIndex = 4;
            this.butEnter.Text = "Enter";
            this.butEnter.UseVisualStyleBackColor = true;
            this.butEnter.Click += new System.EventHandler(this.butEnter_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(150, 112);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Role:";
            this.lblRole.Click += new System.EventHandler(this.lblRole_Click);
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(150, 73);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(61, 13);
            this.lblLast.TabIndex = 11;
            this.lblLast.Text = "Last Name:";
            this.lblLast.Click += new System.EventHandler(this.lblLast_Click);
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(150, 37);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(60, 13);
            this.lblFirst.TabIndex = 10;
            this.lblFirst.Text = "First Name:";
            this.lblFirst.Click += new System.EventHandler(this.lblFirst_Click);
            // 
            // picWorker
            // 
            this.picWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWorker.Location = new System.Drawing.Point(20, 12);
            this.picWorker.Name = "picWorker";
            this.picWorker.Size = new System.Drawing.Size(124, 129);
            this.picWorker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWorker.TabIndex = 9;
            this.picWorker.TabStop = false;
            this.picWorker.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // butAddPic
            // 
            this.butAddPic.Location = new System.Drawing.Point(44, 147);
            this.butAddPic.Name = "butAddPic";
            this.butAddPic.Size = new System.Drawing.Size(75, 23);
            this.butAddPic.TabIndex = 3;
            this.butAddPic.Text = "Add Picture";
            this.butAddPic.UseVisualStyleBackColor = true;
            this.butAddPic.Click += new System.EventHandler(this.butAddPic_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(216, 104);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(236, 21);
            this.cmbRole.TabIndex = 2;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // objOpenFile
            // 
            this.objOpenFile.FileName = "openFileDialog1";
            // 
            // objAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.butAddPic);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.butEnter);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.picWorker);
            this.Name = "objAddPerson";
            this.Size = new System.Drawing.Size(465, 303);
            this.Load += new System.EventHandler(this.objAddPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWorker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button butEnter;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.PictureBox picWorker;
        private System.Windows.Forms.Button butAddPic;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.OpenFileDialog objOpenFile;
    }
}
