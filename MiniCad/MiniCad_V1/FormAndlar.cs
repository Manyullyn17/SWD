using System.Collections.Generic;
// using System.ComponentModel;
using System.Drawing;
// using System.Linq;
using System.Windows.Forms;

namespace Andlar
{
    struct Line
    {
        public GraphicObject obj1;
        public GraphicObject obj2;
    }

    public partial class FormAndlar : Form
    {
        List<GraphicObject> _grObjList = new List<GraphicObject>();
        List<Line> _lineList = new List<Line>();
        List<Line> _lineRemoveList = new List<Line>();
        GraphicObject _dragObj; // das Objekt welches gerade bewegt wird
        GraphicObject _lineObj1, _lineObj2;
        Line _Line;
        Pen _linePen = new Pen(Color.Blue, 3);

        public FormAndlar()
        {
            InitializeComponent();
            GraphicObject.SetDefaultColors(_panel.BackColor, Color.Red);
            _sizeEd.Text = "10"; _typeEd.Text = "R";
        }

        void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            foreach (Line line in _lineList)
                gr.DrawLine(_linePen, line.obj1.GetPos(), line.obj2.GetPos());

            foreach (GraphicObject obj in _grObjList)
                obj.PaintVisible(gr);
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (_connectChk.Checked || _disconnectChk.Checked)
            {
                if (_lineObj1 == null)
                    _lineObj1 = FindObjectAt(e.Location);
                else
                    _lineObj2 = FindObjectAt(e.Location);
                if (_lineObj1 != null && _lineObj2 != null)
                {
                    _Line.obj1 = _lineObj1;
                    _Line.obj2 = _lineObj2;

                    if (_connectChk.Checked)
                        _lineList.Add(_Line);
                    else
                        _lineList.Remove(_Line);

                    _panel.Invalidate();

                    _lineObj1 = _lineObj2 = null;
                }
            }
            else if (_creDelChk.Checked) // wir sind im Create/Delete Modus
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
            if (!_creDelChk.Checked && _dragObj != null) // drag Object
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

                    foreach (Line line in _lineList)    // get list of lines connected to object
                        if (line.obj1 == obj || line.obj2 == obj)
                            _lineRemoveList.Add(line);

                    foreach (Line line in _lineRemoveList)  // remove all lines connected to object
                        _lineList.Remove(line);

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
