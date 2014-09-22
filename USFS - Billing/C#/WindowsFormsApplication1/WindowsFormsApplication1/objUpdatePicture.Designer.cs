namespace WindowsFormsApplication1
{
    partial class objUpdatePicture
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
            this.picWorker = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // picWorker
            // 
            this.picWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWorker.Location = new System.Drawing.Point(21, 20);
            this.picWorker.Name = "picWorker";
            this.picWorker.Size = new System.Drawing.Size(124, 129);
            this.picWorker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWorker.TabIndex = 10;
            this.picWorker.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 20);
            this.textBox1.TabIndex = 11;
            // 
            // objUpdatePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picWorker);
            this.Name = "objUpdatePicture";
            this.Size = new System.Drawing.Size(488, 362);
            ((System.ComponentModel.ISupportInitialize)(this.picWorker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWorker;
        private System.Windows.Forms.TextBox textBox1;

    }
}
