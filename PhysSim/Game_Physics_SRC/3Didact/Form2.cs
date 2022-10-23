using System;
using System.Drawing;
// using System.ComponentModel;
using System.Windows.Forms;
// using System.Data;

namespace Balls6
{
    // Verwaltung der Controls und der Ereignisse der Controls
    // Verwaltung des Benutzerinterfaces jedoch auf keinen Fall das Ball-Management
    // Ereignisse der Oberfläche werden an den BallManager weitergeleitet
    // Paint(), Create(), MouseMove() . . .
    public class Form2 : Form
    {
        #region Member Variablen
        private GridPanel m_Panel;
        private Label label1;
        private Timer timer1;
        private TextBox m_Ed1;
        private CheckBox m_RunChk;
        private Button m_ColButt;
        private Button m_StepButt;
        private Label m_InfoLbl;
        private System.ComponentModel.IContainer components;

        private BallManager m_BallMgr;
        private double m_Speed, m_Direction;
        Point m_MousePos;
        #endregion

        public Form2()
        {
            InitializeComponent();
            // m_BallMgr = new PingPongManager();
            m_BallMgr = new BallManager();
            // m_BallMgr = new BilliardManager();
            GraphicObject.SetDefaultColors(m_Panel.BackColor, Color.Red);
            m_ColButt.BackColor = Color.Blue;
            timer1.Interval = Par.TIMER_INTERVAL; timer1.Start();
            m_Ed1.Text = "10 0";
            Size = new Size(1000, 600);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_Panel = new Balls6.GridPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.m_Ed1 = new System.Windows.Forms.TextBox();
            this.m_RunChk = new System.Windows.Forms.CheckBox();
            this.m_ColButt = new System.Windows.Forms.Button();
            this.m_StepButt = new System.Windows.Forms.Button();
            this.m_InfoLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Panel
            // 
            this.m_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_Panel.Location = new System.Drawing.Point(14, 58);
            this.m_Panel.Name = "m_Panel";
            this.m_Panel.Size = new System.Drawing.Size(589, 320);
            this.m_Panel.TabIndex = 0;
            this.m_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPaint);
            this.m_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelMouseDown);
            this.m_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelMouseMove);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Speed,Dir";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.OnTimer);
            // 
            // m_Ed1
            // 
            this.m_Ed1.Location = new System.Drawing.Point(86, 9);
            this.m_Ed1.Name = "m_Ed1";
            this.m_Ed1.Size = new System.Drawing.Size(87, 22);
            this.m_Ed1.TabIndex = 2;
            this.m_Ed1.Text = "10  60";
            this.m_Ed1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnEd1KeyDown);
            // 
            // m_RunChk
            // 
            this.m_RunChk.Location = new System.Drawing.Point(192, 9);
            this.m_RunChk.Name = "m_RunChk";
            this.m_RunChk.Size = new System.Drawing.Size(106, 28);
            this.m_RunChk.TabIndex = 3;
            this.m_RunChk.Text = "Run (On/Off)";
            // 
            // m_ColButt
            // 
            this.m_ColButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.m_ColButt.Location = new System.Drawing.Point(355, 9);
            this.m_ColButt.Name = "m_ColButt";
            this.m_ColButt.Size = new System.Drawing.Size(77, 28);
            this.m_ColButt.TabIndex = 4;
            this.m_ColButt.Text = "Set Color";
            this.m_ColButt.UseVisualStyleBackColor = false;
            this.m_ColButt.Click += new System.EventHandler(this.ColButt_Click);
            // 
            // m_StepButt
            // 
            this.m_StepButt.Location = new System.Drawing.Point(298, 9);
            this.m_StepButt.Name = "m_StepButt";
            this.m_StepButt.Size = new System.Drawing.Size(48, 28);
            this.m_StepButt.TabIndex = 5;
            this.m_StepButt.Text = "Step";
            this.m_StepButt.Click += new System.EventHandler(this.OnStepButt);
            // 
            // m_InfoLbl
            // 
            this.m_InfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_InfoLbl.Location = new System.Drawing.Point(451, 18);
            this.m_InfoLbl.Name = "m_InfoLbl";
            this.m_InfoLbl.Size = new System.Drawing.Size(259, 19);
            this.m_InfoLbl.TabIndex = 6;
            this.m_InfoLbl.Text = "Info:";
            // 
            // Form2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(608, 383);
            this.Controls.Add(this.m_InfoLbl);
            this.Controls.Add(this.m_StepButt);
            this.Controls.Add(this.m_ColButt);
            this.Controls.Add(this.m_RunChk);
            this.Controls.Add(this.m_Ed1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_Panel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new Form2());
        }

        void PanelPaint(object sender, PaintEventArgs e)
        {
            GraphicObject.WndSize = m_Panel.Size;
            m_BallMgr.Paint(e.Graphics);
        }

        void OnTimer(object sender, System.EventArgs e)
        {
            GraphicObject.WndSize = m_Panel.Size;
            if (m_RunChk.Checked)
            {
                m_BallMgr.CalcNextPositions();
                m_Panel.Invalidate();
                m_BallMgr.Info1(m_InfoLbl);
            }
        }

        void DoSingleStep()
        {
            m_RunChk.Checked = false;
            GraphicObject.WndSize = m_Panel.Size;
            m_BallMgr.CalcNextPositions();
            m_Panel.Invalidate();
            m_BallMgr.Info1(m_InfoLbl);
        }

        void OnStepButt(object sender, System.EventArgs e)
        {
            DoSingleStep();
        }

        void OnEd1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                DoSingleStep();
        }

        void PanelMouseMove(object sender, MouseEventArgs e)
        {
            if (m_RunChk.Checked)
                return;
            GraphicObject.WndSize = m_Panel.Size;
            m_MousePos.X = e.X; m_MousePos.Y = Ball.InvertYCoord(e.Y);
            m_BallMgr.BallInfo(m_InfoLbl, m_MousePos);
            // m_BallMgr.MouseMove(e, m_Panel.CreateGraphics());
        }

        void PanelMouseDown(object sender, MouseEventArgs e)
        {
            GraphicObject.WndSize = m_Panel.Size;
            m_MousePos.X = e.X; m_MousePos.Y = GraphicObject.InvertYCoord(e.Y);

            if (m_BallMgr.DeleteBallAtPos(m_MousePos))
            {
                m_Panel.Refresh();
                return;
            }

            m_MousePos = GridPanel.Snap2Grid(m_MousePos);
            SpeedAndDirFromText();
            // Ball bl = new Ball(m_MousePos, m_ColButt.BackColor, m_Speed, m_Direction);
            // Ball bl = new FrictionBall3(m_MousePos, m_ColButt.BackColor, m_Speed, m_Direction);
            // Ball bl = new ColliderBall(m_MousePos, m_ColButt.BackColor, m_Speed, m_Direction);
            Ball bl = new GravityBall3(m_MousePos, m_ColButt.BackColor, m_Speed, m_Direction);
            m_BallMgr.AddBall(bl);
            m_Panel.Refresh();
        }

        void SpeedAndDirFromText()
        {
            string txt, str1, str2;
            int p1;
            txt = m_Ed1.Text; txt += "  ";
            for (p1 = 0; txt[p1] != ' '; p1++)
            {
                if (p1 >= txt.Length)
                    return;
            }
            str1 = txt.Substring(0, p1);
            str2 = txt.Substring(p1);
            m_Speed = double.Parse(str1); m_Direction = double.Parse(str2);
        }

        void ColButt_Click(object sender, System.EventArgs e)
        {
            ColorDialog colDiag = new ColorDialog();
            if (colDiag.ShowDialog() == DialogResult.OK)
                m_ColButt.BackColor = colDiag.Color;
        }
    }
}
