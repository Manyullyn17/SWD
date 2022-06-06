namespace satellite
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.m_Ed1 = new System.Windows.Forms.TextBox();
      this.m_RunChk = new System.Windows.Forms.CheckBox();
      this.m_StepButt = new System.Windows.Forms.Button();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.m_pnl = new satellite.ScPanel();
      this.m_ZoomTrk = new System.Windows.Forms.TrackBar();
      this.m_lbl2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.m_ZoomTrk)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(9, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Speed,Dir";
      // 
      // m_Ed1
      // 
      this.m_Ed1.Location = new System.Drawing.Point(69, 12);
      this.m_Ed1.Name = "m_Ed1";
      this.m_Ed1.Size = new System.Drawing.Size(64, 20);
      this.m_Ed1.TabIndex = 2;
      this.m_Ed1.Text = "5  0";
      // 
      // m_RunChk
      // 
      this.m_RunChk.AutoSize = true;
      this.m_RunChk.Location = new System.Drawing.Point(148, 14);
      this.m_RunChk.Name = "m_RunChk";
      this.m_RunChk.Size = new System.Drawing.Size(88, 17);
      this.m_RunChk.TabIndex = 3;
      this.m_RunChk.Text = "Run (On/Off)";
      this.m_RunChk.UseVisualStyleBackColor = true;
      // 
      // m_StepButt
      // 
      this.m_StepButt.Location = new System.Drawing.Point(242, 11);
      this.m_StepButt.Name = "m_StepButt";
      this.m_StepButt.Size = new System.Drawing.Size(58, 23);
      this.m_StepButt.TabIndex = 4;
      this.m_StepButt.Text = "Step";
      this.m_StepButt.UseVisualStyleBackColor = true;
      this.m_StepButt.Click += new System.EventHandler(this.OnStepButt);
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // m_pnl
      // 
      this.m_pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_pnl.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.m_pnl.Location = new System.Drawing.Point(12, 53);
      this.m_pnl.Name = "m_pnl";
      this.m_pnl.Size = new System.Drawing.Size(453, 321);
      this.m_pnl.TabIndex = 5;
      this.m_pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
      this.m_pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseDown);
      // 
      // m_ZoomTrk
      // 
      this.m_ZoomTrk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_ZoomTrk.Location = new System.Drawing.Point(487, 16);
      this.m_ZoomTrk.Maximum = 300;
      this.m_ZoomTrk.Minimum = 10;
      this.m_ZoomTrk.Name = "m_ZoomTrk";
      this.m_ZoomTrk.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.m_ZoomTrk.Size = new System.Drawing.Size(42, 358);
      this.m_ZoomTrk.TabIndex = 6;
      this.m_ZoomTrk.Value = 10;
      this.m_ZoomTrk.ValueChanged += new System.EventHandler(this.OnZoomChanged);
      // 
      // m_lbl2
      // 
      this.m_lbl2.AutoSize = true;
      this.m_lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.m_lbl2.Location = new System.Drawing.Point(325, 17);
      this.m_lbl2.Name = "m_lbl2";
      this.m_lbl2.Size = new System.Drawing.Size(41, 13);
      this.m_lbl2.TabIndex = 7;
      this.m_lbl2.Text = "label2";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(527, 386);
      this.Controls.Add(this.m_lbl2);
      this.Controls.Add(this.m_ZoomTrk);
      this.Controls.Add(this.m_pnl);
      this.Controls.Add(this.m_StepButt);
      this.Controls.Add(this.m_RunChk);
      this.Controls.Add(this.m_Ed1);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "SatV3 Form1";
      ((System.ComponentModel.ISupportInitialize)(this.m_ZoomTrk)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_Ed1;
    private System.Windows.Forms.CheckBox m_RunChk;
    private System.Windows.Forms.Button m_StepButt;
    private System.Windows.Forms.Timer timer1;
    private ScPanel m_pnl;
    private System.Windows.Forms.TrackBar m_ZoomTrk;
    private System.Windows.Forms.Label m_lbl2;
  }
}

