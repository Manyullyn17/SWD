using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimplePaint
{
    
    struct ColorPoint
    {
        public Point pt;
        public Color col;
    }
    
    public partial class Form1 : Form
    {
        // _br merkt sich auch die momentane Zeichenfarbe
        SolidBrush _br = new SolidBrush(Color.Blue);
        Pen _pen = new Pen(Color.Blue, 2);
        // Point[] _ptAry = new Point[200];
        // int _cnt;   // Anzahl der gültigen Punkte in _ptAry
        List<ColorPoint> _ptList = new List<ColorPoint>();

        public Form1()
        {
            InitializeComponent();
            _fileName.Text = "Bild1.txt";
        }

        void OnPanelMouseMove(object sender, MouseEventArgs e)
        {
            _debugLabel.Text = e.X.ToString() + ", " + e.Y.ToString();
            ColorPoint cpt;
            if(e.Button == MouseButtons.Left)
            {
                Graphics gr = _panel.CreateGraphics();
                gr.FillEllipse(_br, e.X-2, e.Y-2, 4, 4);
                cpt.pt = e.Location;
                cpt.col = _br.Color;    // Zeichenfarbe für den Punkt merken
                _ptList.Add(cpt);
            }
        }

        void OnPanelPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Point pt1, pt2;
            for (int i = 0; i < _ptList.Count - 1; i++)
            {
                pt1 = _ptList[i].pt;
                pt2 = _ptList[i + 1].pt;
                _pen.Color = _ptList[i].col;    // Zeichenfarbe für die Linie setzen
                gr.DrawLine(_pen, pt1, pt2);
            }
        }

        void OnMenuClear(object sender, EventArgs e)
        {
            // setzt _ptList.count auf 0
            _ptList.Clear();
            _panel.Invalidate();
        }

        void OnPanelMouseUp(object sender, MouseEventArgs e)
        {
            _panel.Invalidate();
        }

        void OnMenuFileLoad(object sender, EventArgs e)
        {
            /*
            Color col;
            int val = 13567;
            col = Color.FromArgb(val);  // int in Color umwandeln
            */

            StreamReader sr;    // load with color (backwards compatible)
            try
            {
                sr = new StreamReader(_fileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            _ptList.Clear();
            ColorPoint cpt = new ColorPoint();
            string line;
            string[] words;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();       // "89,53,-16776961"
                words = line.Split(',');
                // words[0] = "89"    words[1] = "53"   words[2] = "-16776961"
                cpt.pt.X = Convert.ToInt32(words[0]);
                cpt.pt.Y = Convert.ToInt32(words[1]);
                if (words.Length > 2)
                {
                    cpt.col = Color.FromArgb(Convert.ToInt32(words[2]));
                } 
                else
                {
                    cpt.col = Color.Blue;
                }
                _ptList.Add(cpt);
            }
            sr.Close();
            _panel.Invalidate();

            /*
            StreamReader sr;  // load without color
            try
            {
                sr = new StreamReader(_fileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            // momentane Zeichnung löschen
            _ptList.Clear();
            Point pt = new Point();
            string line;
            string[] words;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();       // "89,53"
                words = line.Split(',');
                // words[0] = "89"    words[1] = "53"
                pt.X = Convert.ToInt32(words[0]);
                pt.Y = Convert.ToInt32(words[1]);
                _ptList.Add(pt);
            }
            sr.Close();
            _panel.Invalidate();
            */
        }

        void OnMenuFileSave(object sender, EventArgs e)
        {
            StreamWriter wr;    // save with color
            try
            {
                wr = new StreamWriter(_fileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            foreach(ColorPoint cpt in _ptList)
            {
                wr.WriteLine("{0},{1},{2}", cpt.pt.X, cpt.pt.Y, cpt.col.ToArgb());
            }

            wr.Close();
            MessageBox.Show("File saved");

            /*
            StreamWriter wr;  // save without color
            try
            {
                wr = new StreamWriter(_fileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            foreach(Point pt in _ptList)
            {
                wr.WriteLine("{0},{1}", pt.X, pt.Y);
            }

            wr.Close(); // Verbindung mit dem File trennen
            MessageBox.Show("File saved");
            */
        }

        void OnMenuColor(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            _br.Color = dlg.Color;
        }
    }
}
