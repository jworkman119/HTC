namespace WindowsFormsApplication1
{
    partial class objCreateSchedule
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
            this.lblDirections = new System.Windows.Forms.Label();
            this.dtDay = new System.Windows.Forms.DateTimePicker();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblWorkers = new System.Windows.Forms.Label();
            this.lblScheduled = new System.Windows.Forms.Label();
            this.lstWorkers = new System.Windows.Forms.ListBox();
            this.lstScheduled = new System.Windows.Forms.ListBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.butRemove = new System.Windows.Forms.Button();
            this.butEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDirections
            // 
            this.lblDirections.AutoSize = true;
            this.lblDirections.Location = new System.Drawing.Point(86, 17);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(122, 13);
            this.lblDirections.TabIndex = 1;
            this.lblDirections.Text = "Select Day to Schedule:";
            // 
            // dtDay
            // 
            this.dtDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDay.Location = new System.Drawing.Point(214, 17);
            this.dtDay.MaxDate = new System.DateTime(2010, 9, 11, 0, 0, 0, 0);
            this.dtDay.MinDate = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtDay.Name = "dtDay";
            this.dtDay.Size = new System.Drawing.Size(117, 20);
            this.dtDay.TabIndex = 2;
            this.dtDay.Value = new System.DateTime(2010, 8, 23, 0, 0, 0, 0);
            this.dtDay.ValueChanged += new System.EventHandler(this.dtDay_ValueChanged);
            // 
            // cmbShift
            // 
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(214, 59);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(117, 21);
            this.cmbShift.TabIndex = 3;
            this.cmbShift.SelectedIndexChanged += new System.EventHandler(this.cmbShift_SelectedIndexChanged);
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(177, 59);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(31, 13);
            this.lblShift.TabIndex = 4;
            this.lblShift.Text = "Shift:";
            // 
            // lblWorkers
            // 
            this.lblWorkers.AutoSize = true;
            this.lblWorkers.Location = new System.Drawing.Point(6, 104);
            this.lblWorkers.Name = "lblWorkers";
            this.lblWorkers.Size = new System.Drawing.Size(50, 13);
            this.lblWorkers.TabIndex = 5;
            this.lblWorkers.Text = "Workers:";
            // 
            // lblScheduled
            // 
            this.lblScheduled.AutoSize = true;
            this.lblScheduled.Location = new System.Drawing.Point(236, 104);
            this.lblScheduled.Name = "lblScheduled";
            this.lblScheduled.Size = new System.Drawing.Size(104, 13);
            this.lblScheduled.TabIndex = 6;
            this.lblScheduled.Text = "Workers Scheduled:";
            // 
            // lstWorkers
            // 
            this.lstWorkers.FormattingEnabled = true;
            this.lstWorkers.Location = new System.Drawing.Point(62, 104);
            this.lstWorkers.Name = "lstWorkers";
            this.lstWorkers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstWorkers.Size = new System.Drawing.Size(146, 199);
            this.lstWorkers.TabIndex = 7;
            this.lstWorkers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstWorkers_DrawItem);
            // 
            // lstScheduled
            // 
            this.lstScheduled.FormattingEnabled = true;
            this.lstScheduled.Location = new System.Drawing.Point(346, 104);
            this.lstScheduled.Name = "lstScheduled";
            this.lstScheduled.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstScheduled.Size = new System.Drawing.Size(146, 199);
            this.lstScheduled.TabIndex = 8;
            this.lstScheduled.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstScheduled_DrawItem);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(254, 155);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(59, 23);
            this.butAdd.TabIndex = 9;
            this.butAdd.Text = "-------->";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butRemove
            // 
            this.butRemove.Location = new System.Drawing.Point(254, 222);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(59, 23);
            this.butRemove.TabIndex = 10;
            this.butRemove.Text = "<--------";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // butEnter
            // 
            this.butEnter.Location = new System.Drawing.Point(239, 323);
            this.butEnter.Name = "butEnter";
            this.butEnter.Size = new System.Drawing.Size(75, 23);
            this.butEnter.TabIndex = 11;
            this.butEnter.Text = "Update Shift";
            this.butEnter.UseVisualStyleBackColor = true;
            this.butEnter.Click += new System.EventHandler(this.butEnter_Click);
            // 
            // objCreateSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butEnter);
            this.Controls.Add(this.butRemove);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.lstScheduled);
            this.Controls.Add(this.lstWorkers);
            this.Controls.Add(this.lblScheduled);
            this.Controls.Add(this.lblWorkers);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.dtDay);
            this.Controls.Add(this.lblDirections);
            this.Name = "objCreateSchedule";
            this.Size = new System.Drawing.Size(531, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.DateTimePicker dtDay;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblWorkers;
        private System.Windows.Forms.Label lblScheduled;
        private System.Windows.Forms.ListBox lstWorkers;
        private System.Windows.Forms.ListBox lstScheduled;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.Button butEnter;


    }
}
