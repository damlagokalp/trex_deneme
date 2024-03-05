namespace trex_deneme
{
    partial class ButtonOperations
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOperations = new System.Windows.Forms.Label();
            this.txtOpCount = new trex_deneme.UI.labelCrcle();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtOperations);
            this.panel1.Controls.Add(this.txtOpCount);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 45);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtOperations
            // 
            this.txtOperations.AutoSize = true;
            this.txtOperations.BackColor = System.Drawing.Color.Transparent;
            this.txtOperations.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtOperations.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperations.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtOperations.Location = new System.Drawing.Point(85, 0);
            this.txtOperations.Name = "txtOperations";
            this.txtOperations.Size = new System.Drawing.Size(60, 20);
            this.txtOperations.TabIndex = 5;
            this.txtOperations.Text = "label1";
            this.txtOperations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOpCount
            // 
            this.txtOpCount.BackColor = System.Drawing.Color.Transparent;
            this.txtOpCount.CircleLabelColor = System.Drawing.Color.Empty;
            this.txtOpCount.CirlceBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtOpCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtOpCount.LabelCount = null;
            this.txtOpCount.Location = new System.Drawing.Point(145, 0);
            this.txtOpCount.Name = "txtOpCount";
            this.txtOpCount.Size = new System.Drawing.Size(36, 45);
            this.txtOpCount.TabIndex = 4;
            // 
            // ButtonOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.Controls.Add(this.panel1);
            this.Name = "ButtonOperations";
            this.Size = new System.Drawing.Size(181, 45);
            this.Click += new System.EventHandler(this.ButtonOperations_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonOperations_Paint);
            this.MouseEnter += new System.EventHandler(this.ButtonOperations_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ButtonOperations_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtOperations;
        private UI.labelCrcle txtOpCount;
    }
}
