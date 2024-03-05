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
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace trex_deneme.UI
{
    public partial class labelCrcle : UserControl
    {
        
        public labelCrcle()
        {
            InitializeComponent();
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
                _labelCount = value;
                UpdateBackground();
            }
            
        }
        private Color _cirlceBackgroundColor = System.Drawing.Color.FromArgb(232, 252, 207);
        public Color CirlceBackgroundColor
        {
            get
            {
                return _cirlceBackgroundColor;
            }
            set
            {
                _cirlceBackgroundColor = value;
                this.Refresh();
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
            lblCount.Text = LabelCount;
            lblCount.ForeColor = CircleLabelColor;
        }
        public void DrawRoundRect(Graphics g,  float X, float Y, float width, float height, float radius)
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
            SolidBrush solidBrush = new SolidBrush(_cirlceBackgroundColor);
            g.FillPath(solidBrush , gp);

            
        }
        private void LabelCircle_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, e.ClipRectangle.Left , e.ClipRectangle.Top+(this.Height/7), e.ClipRectangle.Width -2, e.ClipRectangle.Height - (this.Height / 3.5f), 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
        //    e.Graphics.DrawEllipse(new Pen(Color.White, 3), 0, 0, this.Width - 2, this.Height - (this.Height / 6));
        }

        private void LabelCircle_Resize(object sender, EventArgs e)
        {
          //  this.Width = this.Height;
         //   base.OnResize(e);
        }

        

       



    }
}
