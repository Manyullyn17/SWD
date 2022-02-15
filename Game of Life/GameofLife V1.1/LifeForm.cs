using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace V1
{
    public partial class LifeForm : Form
    {
        #region CONSTANTS
        const int MAX_CELLS = 25;   // number of cells per row/column
        //const int CELL_SIZE = 20;   // size in pixels
        const int C_M = 2;  // CellMargin (space between cell walls and filling)
        #endregion
    
        // 2 Matritzen zur Verwaltung der n'ten und der n+1'ten Generation
        bool[,] m_CA = new bool[MAX_CELLS, MAX_CELLS];
        bool[,] m_CB = new bool[MAX_CELLS, MAX_CELLS];
        bool[,] m_CC;   // current ( active ) CellArray n'te Generation
        int cell_sizex = 20;
        int cell_sizey = 20;

        public LifeForm()
        {
            InitializeComponent();
            timer1.Interval = 100;
            // zum Testen ein paar Zellen setzen
            // m_CA[3, 3] = true; m_CA[3, 4] = true; m_CA[3, 5] = true;
            // m_CA[4, 3] = true; m_CA[4, 4] = true; m_CA[4, 5] = true;
            m_CC = m_CA;
        }

        private void OnPanelPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawCells(e.Graphics);
        }

        private void OnPanelMouseDown(object sender, MouseEventArgs e)
        {
            // der Cell Editor
            if (e.X < MAX_CELLS * cell_sizex && e.Y < MAX_CELLS * cell_sizey)
            {
                TurnCellOnOff(e.X, e.Y);
                m_panel.Invalidate();
            }
        }

        // Cells des aktiven Arrays (m_CC) zeichnen
        void DrawCells(Graphics gr)
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
            Point pt1 = new Point();

            float sizex = cell_sizex - 2 * C_M + C_M / 2;
            float sizey = cell_sizey - 2 * C_M + C_M / 2;


            for (int j = 0; j < MAX_CELLS; j++)
            {
                for (int i = 0; i < MAX_CELLS; i++)
                {
                    if (m_CC[i,j] == true)
                    {
                        pt1.X = i * cell_sizex + C_M;
                        pt1.Y = j * cell_sizey + C_M;
                        gr.FillRectangle(brush, pt1.X, pt1.Y, sizex, sizey);
                    }
                }
            }
        }

        void DrawGrid(Graphics gr)
        {
            // Raster zeichnen
            Pen pen = new Pen(Color.Black);
            Point pt1 = new Point();
            Point pt2 = new Point();

            for (int i = 0; i <= MAX_CELLS; i++)
            {
                pt1.X = i * cell_sizex;
                pt1.Y = 0;
                pt2.X = pt1.X;
                pt2.Y = cell_sizey * MAX_CELLS;
                gr.DrawLine(pen, pt1, pt2);
            }

            for (int i = 0; i <= MAX_CELLS; i++)
            {
                pt1.X = 0;
                pt1.Y = i * cell_sizey;
                pt2.X = cell_sizex * MAX_CELLS;
                pt2.Y = pt1.Y;
                gr.DrawLine(pen, pt1, pt2);
            }
        }

        // Nächste Generation berechnen
        private void OnStepButton(object sender, EventArgs e)
        {
            if (m_CC == m_CA)
            {
                ClearCells(m_CB);
                CalcNextGeneration(m_CA, m_CB);
                m_CC = m_CB;
            }
            else
            {
                ClearCells(m_CA);
                CalcNextGeneration(m_CB, m_CA);
                m_CC = m_CA;
            }
            m_panel.Invalidate();
        }

        private void OnTimerChk(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            timer1.Enabled = false;
            else
            timer1.Enabled = true;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            OnStepButton(null, null);
        }

        private void OnClearButton(object sender, EventArgs e)
        {
            ClearCells(m_CA); ClearCells(m_CB);
            m_panel.Invalidate();
        }

        private void OnPanelResize(object sender, EventArgs e)
        {
            int width = m_panel.Size.Width;
            int height = m_panel.Size.Height;

            //int[] sizes = new[] {width, height};
            //cell_size = (sizes.Min()-1) / MAX_CELLS;
            cell_sizex = (width - 1) / MAX_CELLS;
            cell_sizey = (height - 1) / MAX_CELLS;

            if (_forceSquare.Checked)
            {
                int[] sizes = new[] { width, height };
                cell_sizex = (sizes.Min() - 1) / MAX_CELLS;
                cell_sizey = cell_sizex;
            }

            m_panel.Invalidate();
        }   // added resizing capabilities

        private void OnForceSquareClick(object sender, EventArgs e)
        {
            OnPanelResize(null, null);
        }
    }
}
