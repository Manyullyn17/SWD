using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bsp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Pen pen = new Pen(Color.Indigo, 2);

            gr.DrawRectangle(pen, 20, 20, 40, 30);

            // Kreis in der rechten unteren Ecke zeichnen
            int Xe = Width - 80;
            int Ye = Height - 100;
            pen.Color = Color.DarkGoldenrod;
            gr.DrawEllipse(pen, Xe, Ye, 40, 40);
        }

        private void OnResize(object sender, EventArgs e)
        {
            // Über das Betriebssystem ein Neuzeichnen (Paint) auslösen
            this.Invalidate();
        }
    }
}
