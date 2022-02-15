using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


// Verwaltung einzelner LineSegmente (Figuren)
namespace SimplePaint
{
    struct ColorPoint
    {
        public Point pt;
        public Color col;
    }

    public partial class Form1 : Form
    {
        SolidBrush _br = new SolidBrush(Color.Blue);
        List<LineSeg> _segList = new List<LineSeg>();
        LineSeg _currSeg;   // Das Segment an dem wir gerade zeichnen

        public Form1()
        {
            InitializeComponent();
            _fileName.Text = "Bild1.txt";
        }

        void OnPanelMouseMove(object sender, MouseEventArgs e)
        {
            _dbgLbl.Text = e.X.ToString() + "," + e.Y.ToString();
            if ( e.Button==MouseButtons.Left )
            {
                Graphics gr = _panel.CreateGraphics();
                gr.FillEllipse(_br, e.X-2, e.Y-2, 4, 4);
                // _ptAry[_cnt] = e.Location;
                // _cnt++;
                ColorPoint cpt;
                cpt.pt = e.Location;
                cpt.col = _br.Color;
                _currSeg.AddPoint(cpt);
            }
        }

        void OnPanelPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            foreach(LineSeg seg in _segList)
                seg.Draw(gr);
        }

        void OnMenueClear(object sender, EventArgs e)
        {
            // setzt _ptList.count auf 0
            _segList.Clear();
            _panel.Invalidate();
        }

        void OnPanelMouseUp(object sender, MouseEventArgs e)
        {
            _panel.Invalidate();
        }

        void OnMenueFileLoad(object sender, EventArgs e)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(_fileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            _segList.Clear();

            ColorPoint cpt = new ColorPoint();
            string line;
            string[] words;

            while (!sr.EndOfStream)
            {
                _currSeg = new LineSeg();
                while (true)
                {
                    line = sr.ReadLine();
                    if (line == "#")
                        break;
                    words = line.Split(',');
                    cpt.pt.X = Convert.ToInt32(words[0]);
                    cpt.pt.Y = Convert.ToInt32(words[1]);
                    cpt.col = Color.FromArgb(Convert.ToInt32(words[2]));
                    _currSeg.AddPoint(cpt);
                }
                _segList.Add(_currSeg);
            }

            sr.Close();
            _panel.Invalidate();
        }

        void OnMenueFileSave(object sender, EventArgs e)
        {
            StreamWriter wr;
            try
            {
                wr = new StreamWriter(_fileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            foreach (LineSeg seg in _segList)
            {
                seg.Save(wr);
            }

            wr.Close();
            MessageBox.Show("File saved");
        }

        void OnPanelMouseDown(object sender, MouseEventArgs e)
        {
            _currSeg = new LineSeg();
            _segList.Add(_currSeg);
        }

        void OnMenuColor(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            _br.Color = dlg.Color;
            Pen newpen = new Pen(dlg.Color, 2);
            LineSeg.ChangeColor(newpen);
        }
    }

    class LineSeg
    {
        List<ColorPoint> _ptList = new List<ColorPoint>();
        Pen _pen = new Pen(Color.Blue, 2);

        public void AddPoint(ColorPoint aP)
        {
            _ptList.Add(aP);
        }

        public void Draw(Graphics gr)
        {
            Point pt1, pt2;
            for(int i=0; i<_ptList.Count-1; i++)
            {
                pt1 = _ptList[i].pt;
                pt2 = _ptList[i+1].pt;
                _pen.Color = _ptList[i].col;
                gr.DrawLine(_pen, pt1, pt2);
            }
        }

        public void Save(StreamWriter wr)
        {
            foreach (ColorPoint cpt in _ptList)
            {
                wr.WriteLine("{0},{1},{2}", cpt.pt.X, cpt.pt.Y, cpt.col.ToArgb());
            }

            wr.WriteLine("#");
        }

        public static void ChangeColor(Pen newpen)
        {
           Pen _pen = newpen;
        }
    }
}