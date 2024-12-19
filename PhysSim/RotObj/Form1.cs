using System.Windows.Forms;

namespace RotObj
{
    public partial class Form1 : Form
    {
        double _speedMag, _speedAngle;
        RotatingGraphicObject ro = new RotatingGraphicObject();
        // SpeedArrowObject ro = new SpeedArrowObject();

        public Form1()
        {
            InitializeComponent();
            _paramEdit.Text = "10,30";
        }

        void OnParamEditKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13: // CR
                    ParseParameters();
                    ro.V.SetFrom_R_Phi(_speedMag, 0);
                    ro.InitFigure();
                    ro.Pos.SetXY(0, 0);
                    _panel.Invalidate();
                    break;
                case 38: // up
                    ro.CalcNextPos();
                    _panel.Invalidate();
                    break;
                case 40: // down
                    ParseParameters();
                    ro.Rotate(_speedAngle);
                    _panel.Invalidate();
                    break;
                case 37: // <-
                    break;
                case 39: // ->
                    break;
            }
        }

        void OnPanelPaint(object sender, PaintEventArgs e)
        {
            ro.Paint(e.Graphics);
            _infoLbl.Text = "V = " + ro.V.ToString();
        }

        void ParseParameters()
        {
            string[] tokens = _paramEdit.Text.Split(',');
            _speedMag = double.Parse(tokens[0]);
            _speedAngle = double.Parse(tokens[1]);
        }
    }
}