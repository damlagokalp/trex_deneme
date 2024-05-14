using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace trex_deneme
{
    public static class ColorManager
    {
       public static void AssignColor(ListViewItem item)
        {
            string text = item.SubItems[1].Text;

            switch (text)
            {
                case "Fragmentation":
                    item.BackColor = System.Drawing.Color.FromArgb(255, 252, 131);
                    break;
                case "Unnecessary Object":
                    item.BackColor = System.Drawing.Color.FromArgb(143, 184, 237);
                    break;
                case "Wrong Configuration":
                    item.BackColor = System.Drawing.Color.FromArgb(224, 30, 55);
                    break;
                case "Low Disk Space":
                    item.BackColor = System.Drawing.Color.FromArgb(128, 237, 153);
                    break;
                case "Corruption":
                    item.BackColor = System.Drawing.Color.FromArgb(194, 187, 240);
                    break;
                
                default:
                    item.BackColor = System.Drawing.Color.White;
                    break;
                    
            }
        }
    }




    }

