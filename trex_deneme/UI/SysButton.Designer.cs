namespace trex_deneme.UI
{
    partial class SysButton
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
            this.IconBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconBox.Location = new System.Drawing.Point(0, 0);
            this.IconBox.Name = "IconBox";
            this.IconBox.Padding = new System.Windows.Forms.Padding(5);
            this.IconBox.Size = new System.Drawing.Size(150, 113);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.IconBox_Click);
            this.IconBox.MouseEnter += new System.EventHandler(this.SysButton_MouseEnter);
            this.IconBox.MouseLeave += new System.EventHandler(this.SysButton_MouseLeave);
            // 
            // SysButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.IconBox);
            this.Name = "SysButton";
            this.Size = new System.Drawing.Size(150, 113);
            this.Click += new System.EventHandler(this.IconBox_Click);
            this.MouseEnter += new System.EventHandler(this.SysButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SysButton_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
    }
}
