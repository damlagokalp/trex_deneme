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

namespace trex_deneme
{
    public partial class ButtonOperations : UserControl
    {
        private Color OriginalButtonColor;
        private bool IsMouseEntered = false;
        public ButtonOperations()
        {
            InitializeComponent();
            foreach (Control control in panel1.Controls)
            {
                control.Click += ButtonOperations_Click;
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
            txtOperations.Text = _labelText;
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
            txtOpCount.CirlceBackgroundColor = CircleBackgroundColor;
            txtOperations.ForeColor = ButtonLabelColor;
            txtOpCount.CircleLabelColor = CircleLabelColor;
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
                txtOpCount.LabelCount = value;//labelcircle compentinin içindeki değeri çeker
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
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.White, 0, 0, this.Width - 1, this.Height - 1);

        }

        private void ButtonOperations_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);

        }
        //buton işlemleri
        public event EventHandler Clicked;

        private void ButtonOperations_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }
        private void ButtonOperations_MouseEnter(object sender, EventArgs e)
        {
            if (!IsMouseEntered)
            {

                OriginalButtonColor = ButtonBackgroundColor;
                Color color = ControlPaint.Light(ButtonBackgroundColor);
                ButtonBackgroundColor = color;
                IsMouseEntered = true;
            }
        }

        private void ButtonOperations_MouseLeave(object sender, EventArgs e)
        {
            if (IsMouseEntered)
            {
                ButtonBackgroundColor = OriginalButtonColor;
                IsMouseEntered = false;
            }
        }
    }
}
