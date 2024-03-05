using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trex_deneme.UI
{
    public partial class SysButton : UserControl
    {
        private Color OriginalButtonColor;
        private bool IsMouseEntered = false;

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
        private Image _image;
        public Image ButtonImage
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                UpdateIcon();
            }

        }
        private void UpdateIcon()
        {
            IconBox.Image = ButtonImage;
          //  IconBox.Size = new Size(IconBox.Size.Height, IconBox.Size.Height);

        }
        public SysButton()
        {
            InitializeComponent();
        }

        private void UpdateBackground()
        {
            this.BackColor = ButtonBackgroundColor;

        }
        private void SysButton_MouseEnter(object sender, EventArgs e)
        {
            if (!IsMouseEntered)
            {

                OriginalButtonColor = ButtonBackgroundColor;
                Color color = ControlPaint.Light(ButtonBackgroundColor);
                ButtonBackgroundColor = color;
                IsMouseEntered = true;
            }
        }

        private void SysButton_MouseLeave(object sender, EventArgs e)
        {
            if (IsMouseEntered)
            {
                ButtonBackgroundColor = OriginalButtonColor;
                IsMouseEntered = false;
            }
        }
        public event EventHandler Clicked;
        private void IconBox_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }
    }
}
