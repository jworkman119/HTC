namespace WindowsFormsApplication1
{
    partial class frmReportViewer
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
            this.objReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
   //         this.Schedule1 = new WindowsFormsApplication1.Schedule();
            this.SuspendLayout();
            // 
            // objReportViewer
            // 
            this.objReportViewer.ActiveViewIndex = -1;
            this.objReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.objReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objReportViewer.Location = new System.Drawing.Point(0, 0);
            this.objReportViewer.Name = "objReportViewer";
            this.objReportViewer.Size = new System.Drawing.Size(999, 772);
            this.objReportViewer.TabIndex = 0;
            // 
            // Schedule1
            // 
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 772);
            this.Controls.Add(this.objReportViewer);
            this.Name = "frmReportViewer";
            this.Text = "Report Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer objReportViewer;
   //     private Schedule Schedule1;

    }
}