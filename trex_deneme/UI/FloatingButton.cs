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
    public partial class FloatingButton : UserControl
    {
        private Brush _brush = Brushes.Blue;
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
        private void UpdateBackground()
        {
            _brush = new SolidBrush(ButtonBackgroundColor);
            Refresh();
        }
        public FloatingButton()
        {
            InitializeComponent();
        }
        public void DrawRoundRect(Graphics g, Brush p, float X, float Y, float width, float height, float radius)
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
            g.FillPath(p, gp);
        }
        private void FloatingButton_Paint(object sender, PaintEventArgs e)
        {
             Graphics v = e.Graphics;
             DrawRoundRect(v, _brush, e.ClipRectangle.Left, e.ClipRectangle.Top , e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 25);
            //Without rounded corners
            // e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);

        }
    }
}
