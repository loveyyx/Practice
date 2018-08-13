using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace WindowsFormsApplication2
{
    class PlaneClass
    {
        int x, y;

        public void iniplane(Form frm, Label lb)
        {
            x= frm.Width / 2;
            y= frm.Height - 100;
            lb.Location = new Point(x, y);
        }

        public void keycontrol(Form frm, KeyEventArgs e, Label lb1)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (y >= 10)
                {
                    y -= 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (y <= frm.Height - 80)
                {
                    y += 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (x >= 10)
                {
                    x -= 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (x <= frm.Width - 80)
                {
                    x += 10;
                    lb1.Location = new Point(x, y);
                }
            }
            if(e.KeyCode==Keys.Space)
            {
                Label lbl=new Label();
                lbl.Location=new Point(x+14,y-15);
                lbl.Text = "*";
                lbl.Font = new Font("宋体", 16, System.Drawing.FontStyle.Bold);
                frm.Controls.Add(lbl);
            }
        }

       public void move(Form frm)
        {
            foreach(Control item in frm.Controls)
            {
                if (item.Name != "label1")
                {
                    int a = item.Location.X, b =(item .Location.Y - 10);
                    item.Location = new Point(a,b);
                    if (b < 0)
                    {
                        frm.Controls.Remove(item);
                    }
                }
            }
        }


    }
}
