using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trex_deneme
{
    public class ControlResizer
    {
        //public void ReSizeControl(Control control, Control targetControl)
        //{
        //    //yeniden boyutlandırılabilir olup olmadığını kontrol eder boyutlar ayarlanır
        //    if (IsControlResizable(control))
        //    {
        //        int referenceWidth = control.Width;
        //        int referenceHeight = 720;
        //        float widthRatio = ((float)targetControl.Width) / (float)referenceWidth;
        //        float heightRatio = ((float)Screen.PrimaryScreen.Bounds.Height / (float)referenceHeight);
        //        SizeF size = new SizeF();
        //        size.Width = widthRatio;
        //        size.Height = heightRatio;
        //        control.Scale(size);
        //        control.Tag = 90;
        //        ResizeFont(control, widthRatio);
        //    }
        //}
        ////yazı tiplerinin boyutlandırılması 
        //private void ResizeFont(Control parentControl, float ratio)
        //{
        //    foreach (Control control in parentControl.Controls)
        //    {
        //        if (control.HasChildren)
        //        {
        //            ResizeFont(control, ratio);
        //        }
        //        if (control.Font != null)
        //        {
        //            control.Font = new Font(control.Font.FontFamily, control.Font.Size * ratio, control.Font.Style);
        //        }
        //    }
        //}
        ////kontrolün yeniden boyutlandırılabilir olup olmadığı belirlenir 
        //public bool IsControlResizable(Control control)
        //{
        //    //etiket null ise boyutlandırılır 
        //    if (control.Tag == null)
        //    {
        //        return true;
        //    }
        //    //etiket 99 ise yeniden boyutlandırılamaz
        //    else
        //    {
        //        if (control.Tag.ToString() == "99")
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }


        public static void ReSizeControl(Control control, Control targetControl)
        {
            // Hedef boyutları belirlemek için oranları ayarlayın
            float widthRatio = (float)targetControl.Width / control.Width;
            float heightRatio = (float)targetControl.Height / control.Height;

            // Kontrolün boyutunu hedef boyutlara göre yeniden boyutlandırın
            ResizeControlRecursively(control, widthRatio, heightRatio);
        }

        private static void ResizeControlRecursively(Control control, float widthRatio, float heightRatio)
        {
            // Kontrolün boyutunu hedef boyutlara göre yeniden boyutlandırın
            control.Width = (int)(control.Width * widthRatio);
            control.Height = (int)(control.Height * heightRatio);

            // Kontrolün alt kontrolerini de yeniden boyutlandırın
            foreach (Control childControl in control.Controls)
            {
                ResizeControlRecursively(childControl, widthRatio, heightRatio);
            }
        }


    }


    }

