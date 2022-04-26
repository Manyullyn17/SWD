using System;
using System.Collections.Generic;
using System.Collections;
// using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Andlar
{
    public partial class FormAndlar : Form
    {
        List<GraphicObject> _grObjList = new List<GraphicObject>();

        GraphicObject _dragObj; // das Objekt welches gerade bewegt wird

        public FormAndlar()
        {
            InitializeComponent();
            GraphicObject.SetDefaultColors(_panel.BackColor, Color.Red);
            _sizeEd.Text = "10"; _typeEd.Text = "R";
        }

        void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            foreach (GraphicObject obj in _grObjList)
                obj.PaintVisible(gr);
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (_creDelChk.Checked) // wir sind im Create/Delete Modus
            {
                GraphicObject obj = null;

                if (DeleteObjectAt(e.Location))  // es gab etwas zu löschen
                {
                    _panel.Invalidate();
                    return;
                }

                if (_typeEd.Text == "R")
                    obj = new GRectangle(e.X, e.Y, Color.Red);
                if (_typeEd.Text == "C")
                    obj = new GCircle(e.X, e.Y, Color.Blue);
                if (_typeEd.Text == "T")
                    obj = new GTriangle(e.X, e.Y, Color.Green);

                if (obj != null)
                    _grObjList.Add(obj);

                _panel.Invalidate();
            }
            else // start dragging
            {
                _dragObj = FindObjectAt(e.Location);
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if(!_creDelChk.Checked && _dragObj != null) // drag Object
            {
                Graphics gr = _panel.CreateGraphics();
                _dragObj.PaintInVisible(gr); // an der alten Position löschen
                _dragObj.SetPos(e.Location);
                _dragObj.PaintVisible(gr);  // an der neuen Position zeichnen
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _dragObj = null;
            _panel.Invalidate();
        }

        bool DeleteObjectAt(Point aPos)
        {
            foreach (GraphicObject obj in _grObjList)
            {
                if (obj.HitInRadius(aPos))
                {
                    _grObjList.Remove(obj); // wir löschen in einem Durchlauf immer nur ein Object
                    return true;
                }
            }

            return false;
        }

        GraphicObject FindObjectAt(Point aPos)
        {
            foreach (GraphicObject obj in _grObjList)
            {
                if (obj.HitInRadius(aPos))
                    return obj;
            }
            return null;
        }
    }
}
