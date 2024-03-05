namespace trex_deneme.UI
{
    partial class ButtonNotifications
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
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.txtIssueName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIssueCount = new trex_deneme.UI.labelCrcle();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxIcon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Padding = new System.Windows.Forms.Padding(4);
            this.pictureBoxIcon.Size = new System.Drawing.Size(43, 45);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.MouseEnter += new System.EventHandler(this.ButtonNotifications_MouseEnter);
            this.pictureBoxIcon.MouseLeave += new System.EventHandler(this.ButtonNotifications_MouseLeave);
            // 
            // txtIssueName
            // 
            this.txtIssueName.BackColor = System.Drawing.Color.Transparent;
            this.txtIssueName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIssueName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueName.Location = new System.Drawing.Point(43, 0);
            this.txtIssueName.Name = "txtIssueName";
            this.txtIssueName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.txtIssueName.Size = new System.Drawing.Size(102, 45);
            this.txtIssueName.TabIndex = 2;
            this.txtIssueName.Text = "label1";
            this.txtIssueName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtIssueName.MouseEnter += new System.EventHandler(this.ButtonNotifications_MouseEnter);
            this.txtIssueName.MouseLeave += new System.EventHandler(this.ButtonNotifications_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIssueName);
            this.panel1.Controls.Add(this.pictureBoxIcon);
            this.panel1.Controls.Add(this.txtIssueCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 45);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseEnter += new System.EventHandler(this.ButtonNotifications_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.ButtonNotifications_MouseLeave);
            // 
            // txtIssueCount
            // 
            this.txtIssueCount.BackColor = System.Drawing.Color.Transparent;
            this.txtIssueCount.CircleLabelColor = System.Drawing.Color.Empty;
            this.txtIssueCount.CirlceBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(252)))), ((int)(((byte)(207)))));
            this.txtIssueCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtIssueCount.LabelCount = null;
            this.txtIssueCount.Location = new System.Drawing.Point(145, 0);
            this.txtIssueCount.Name = "txtIssueCount";
            this.txtIssueCount.Size = new System.Drawing.Size(36, 45);
            this.txtIssueCount.TabIndex = 3;
            this.txtIssueCount.MouseEnter += new System.EventHandler(this.ButtonNotifications_MouseEnter);
            this.txtIssueCount.MouseLeave += new System.EventHandler(this.ButtonNotifications_MouseLeave);
            // 
            // ButtonNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "ButtonNotifications";
            this.Size = new System.Drawing.Size(181, 45);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonNotifications_Paint);
            this.MouseEnter += new System.EventHandler(this.ButtonNotifications_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ButtonNotifications_MouseLeave);
            this.Resize += new System.EventHandler(this.ButtonNotifications_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label txtIssueName;
        private labelCrcle txtIssueCount;
        private System.Windows.Forms.Panel panel1;
    }
}
