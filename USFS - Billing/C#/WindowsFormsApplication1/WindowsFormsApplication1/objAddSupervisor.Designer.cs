namespace WindowsFormsApplication1
{
    partial class objAssignSupervisor
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
            this.dtDay = new System.Windows.Forms.DateTimePicker();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.lstWorkers = new System.Windows.Forms.ListBox();
            this.lstAssigned = new System.Windows.Forms.ListBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.butRemove = new System.Windows.Forms.Button();
            this.butEnter = new System.Windows.Forms.Button();
            this.lblUnassigned = new System.Windows.Forms.Label();
            this.lblAssigned = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtDay
            // 
            this.dtDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDay.Location = new System.Drawing.Point(194, 27);
            this.dtDay.MaxDate = new System.DateTime(2010, 9, 11, 0, 0, 0, 0);
            this.dtDay.MinDate = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtDay.Name = "dtDay";
            this.dtDay.Size = new System.Drawing.Size(117, 20);
            this.dtDay.TabIndex = 0;
            this.dtDay.Value = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtDay.ValueChanged += new System.EventHandler(this.dtDay_ValueChanged);
            // 
            // cmbShift
            // 
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(194, 58);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(117, 21);
            this.cmbShift.TabIndex = 1;
            this.cmbShift.SelectedValueChanged += new System.EventHandler(this.cmbShift_SelectedValueChanged);
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisor.FormattingEnabled = true;
            this.cmbSupervisor.Location = new System.Drawing.Point(194, 91);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(117, 21);
            this.cmbSupervisor.TabIndex = 2;
            this.cmbSupervisor.SelectedValueChanged += new System.EventHandler(this.cmbSupervisor_SelectedValueChanged);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(123, 32);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(29, 13);
            this.lblDay.TabIndex = 3;
            this.lblDay.Text = "Day:";
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(123, 64);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(31, 13);
            this.lblShift.TabIndex = 4;
            this.lblShift.Text = "Shift:";
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(123, 97);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(60, 13);
            this.lblSupervisor.TabIndex = 5;
            this.lblSupervisor.Text = "Supervisor:";
            // 
            // lstWorkers
            // 
            this.lstWorkers.FormattingEnabled = true;
            this.lstWorkers.Location = new System.Drawing.Point(41, 145);
            this.lstWorkers.Name = "lstWorkers";
            this.lstWorkers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstWorkers.Size = new System.Drawing.Size(131, 199);
            this.lstWorkers.TabIndex = 3;
            // 
            // lstAssigned
            // 
            this.lstAssigned.FormattingEnabled = true;
            this.lstAssigned.Location = new System.Drawing.Point(328, 145);
            this.lstAssigned.Name = "lstAssigned";
            this.lstAssigned.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAssigned.Size = new System.Drawing.Size(131, 199);
            this.lstAssigned.TabIndex = 5;
            this.lstAssigned.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstAssigned_DrawItem);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(211, 195);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 4;
            this.butAdd.Text = "------------->";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butRemove
            // 
            this.butRemove.Location = new System.Drawing.Point(211, 257);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(75, 23);
            this.butRemove.TabIndex = 6;
            this.butRemove.Text = "<-------------";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // butEnter
            // 
            this.butEnter.Location = new System.Drawing.Point(194, 321);
            this.butEnter.Name = "butEnter";
            this.butEnter.Size = new System.Drawing.Size(117, 23);
            this.butEnter.TabIndex = 7;
            this.butEnter.Text = "Update";
            this.butEnter.UseVisualStyleBackColor = true;
            this.butEnter.Click += new System.EventHandler(this.butEnter_Click);
            // 
            // lblUnassigned
            // 
            this.lblUnassigned.AutoSize = true;
            this.lblUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnassigned.Location = new System.Drawing.Point(57, 129);
            this.lblUnassigned.Name = "lblUnassigned";
            this.lblUnassigned.Size = new System.Drawing.Size(106, 13);
            this.lblUnassigned.TabIndex = 11;
            this.lblUnassigned.Text = "Unassigned Workers";
            // 
            // lblAssigned
            // 
            this.lblAssigned.AutoSize = true;
            this.lblAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssigned.Location = new System.Drawing.Point(350, 129);
            this.lblAssigned.Name = "lblAssigned";
            this.lblAssigned.Size = new System.Drawing.Size(93, 13);
            this.lblAssigned.TabIndex = 12;
            this.lblAssigned.Text = "Assigned Workers";
            // 
            // objAssignSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAssigned);
            this.Controls.Add(this.lblUnassigned);
            this.Controls.Add(this.butEnter);
            this.Controls.Add(this.butRemove);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.lstAssigned);
            this.Controls.Add(this.lstWorkers);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.cmbSupervisor);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.dtDay);
            this.Name = "objAssignSupervisor";
            this.Size = new System.Drawing.Size(531, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDay;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.ListBox lstWorkers;
        private System.Windows.Forms.ListBox lstAssigned;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.Button butEnter;
        private System.Windows.Forms.Label lblUnassigned;
        private System.Windows.Forms.Label lblAssigned;
    }
}
