using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        PlaneClass plane = new PlaneClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            plane.iniplane(this, label1);
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            plane.keycontrol(this, e, label1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            plane.move(this);
            
        }

  


    }
}
