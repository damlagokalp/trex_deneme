using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trex_deneme.UI
{
    public partial class ButtonNotifications : UserControl
    {
        private Color OriginalButtonColor ;
        private bool IsMouseEntered = false;
        public ButtonNotifications()
        {
            InitializeComponent();
            foreach(Control control in panel1.Controls)
            {
                control.Click += ButtonNotifications_Click;
            }
        }
        private string _labelText;
        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {                
                _labelText = value;
                UpdateComponent();

            }
        }
        private void UpdateComponent()
        {
            txtIssueName.Text = _labelText;
        }

        private Image _image;
        public Image ButtonImage {
            get {
                return _image;
            }
            set { 
                _image = value;
                UpdateIcon();
            }
        
        }
        private Color _color;
        public Color ButtonBackgroundColor
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                UpdateBackground();
            }

        }
        private Color _labelcolor;
        public Color ButtonLabelColor
        {
            get
            {
                return _labelcolor;
            }
            set
            {
                _labelcolor = value;
                UpdateBackground();
            }

        }
        private Color _circleBackgroundColor;
        public Color CircleBackgroundColor
        {
            get
            {
                return _circleBackgroundColor;
            }
            set
            {
                _circleBackgroundColor = value;
                UpdateBackground();
            }

        }
        private Color _circleLabelColor;
        public Color CircleLabelColor
        {
            get
            {
                return _circleLabelColor;
            }
            set
            {
                _circleLabelColor = value;
                UpdateBackground();
            }

        }
        private void UpdateBackground()
        {
            this.BackColor = ButtonBackgroundColor;
            txtIssueCount.CirlceBackgroundColor = CircleBackgroundColor; 
            txtIssueName.ForeColor = ButtonLabelColor;
            txtIssueCount.CircleLabelColor = CircleLabelColor;
        }
        private void UpdateIcon()
        {
            pictureBoxIcon.Image = ButtonImage;
            pictureBoxIcon.Size = new Size(pictureBoxIcon.Size.Height, pictureBoxIcon.Size.Height);

        }
        private string _labelCount;
        public string LabelCount
        {
            get
            {
                return _labelCount;
            }
            set
            {
             txtIssueCount.LabelCount = value;//labelcircle compentinin içindeki değeri çeker
            }
        }

       

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
        }

        private void ButtonNotifications_Paint(object sender, PaintEventArgs e)
        {
            pictureBoxIcon.Size = new Size(pictureBoxIcon.Size.Height, pictureBoxIcon.Size.Height);

            // Graphics v = e.Graphics;
            // DrawRoundRect(v, Pens.White, e.ClipRectangle.Left, e.ClipRectangle.Top , e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 5);
            //Without rounded corners
            e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
        }


        private void ButtonNotifications_Resize(object sender, EventArgs e)
        {
                // this.Width = this.Height;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.White, 0,0, this.Width-1, this.Height-1);

        }
        
        ////////////////////////////
        //buton işlemleri
        public  event EventHandler Clicked;

        private void ButtonNotifications_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }              


        private void ButtonNotifications_MouseEnter(object sender, EventArgs e)
        {
            if (!IsMouseEntered)
            {
                
                OriginalButtonColor = ButtonBackgroundColor;
                Color color = ControlPaint.Light(ButtonBackgroundColor);
                ButtonBackgroundColor = color;
                IsMouseEntered = true;
            }
        }

        private void ButtonNotifications_MouseLeave(object sender, EventArgs e)
        {
            if (IsMouseEntered)
            {
                ButtonBackgroundColor = OriginalButtonColor;
                IsMouseEntered = false;
            }
        }
    }
}
