

namespace V1
{
  partial class LifeForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.m_TimerChk = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this._forceSquare = new System.Windows.Forms.CheckBox();
            this._selectWire = new System.Windows.Forms.RadioButton();
            this._selectSpark = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this._selectTail = new System.Windows.Forms.RadioButton();
            this._clearSparksButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._speedSelect = new System.Windows.Forms.NumericUpDown();
            this.m_panel = new V1.MPanel();
            ((System.ComponentModel.ISupportInitialize)(this._speedSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Step";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnStepButton);
            // 
            // m_TimerChk
            // 
            this.m_TimerChk.AutoSize = true;
            this.m_TimerChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_TimerChk.Location = new System.Drawing.Point(92, 14);
            this.m_TimerChk.Name = "m_TimerChk";
            this.m_TimerChk.Size = new System.Drawing.Size(109, 21);
            this.m_TimerChk.TabIndex = 2;
            this.m_TimerChk.Text = "Timer On/Off";
            this.m_TimerChk.UseVisualStyleBackColor = true;
            this.m_TimerChk.Click += new System.EventHandler(this.OnTimerChk);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.OnTimer);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(202, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnClearButton);
            // 
            // _forceSquare
            // 
            this._forceSquare.AutoSize = true;
            this._forceSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._forceSquare.Location = new System.Drawing.Point(383, 14);
            this._forceSquare.Name = "_forceSquare";
            this._forceSquare.Size = new System.Drawing.Size(113, 21);
            this._forceSquare.TabIndex = 4;
            this._forceSquare.Text = "Force Square";
            this._forceSquare.UseVisualStyleBackColor = true;
            this._forceSquare.Click += new System.EventHandler(this.OnForceSquareClick);
            // 
            // _selectWire
            // 
            this._selectWire.AutoSize = true;
            this._selectWire.Checked = true;
            this._selectWire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectWire.Location = new System.Drawing.Point(96, 41);
            this._selectWire.Name = "_selectWire";
            this._selectWire.Size = new System.Drawing.Size(55, 21);
            this._selectWire.TabIndex = 6;
            this._selectWire.TabStop = true;
            this._selectWire.Text = "Wire";
            this._selectWire.UseVisualStyleBackColor = true;
            this._selectWire.CheckedChanged += new System.EventHandler(this.OnToolSelectChanged);
            // 
            // _selectSpark
            // 
            this._selectSpark.AutoSize = true;
            this._selectSpark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectSpark.Location = new System.Drawing.Point(157, 41);
            this._selectSpark.Name = "_selectSpark";
            this._selectSpark.Size = new System.Drawing.Size(63, 21);
            this._selectSpark.TabIndex = 7;
            this._selectSpark.Text = "Spark";
            this._selectSpark.UseVisualStyleBackColor = true;
            this._selectSpark.CheckedChanged += new System.EventHandler(this.OnToolSelectChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tool select:";
            // 
            // _selectTail
            // 
            this._selectTail.AutoSize = true;
            this._selectTail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectTail.Location = new System.Drawing.Point(226, 41);
            this._selectTail.Name = "_selectTail";
            this._selectTail.Size = new System.Drawing.Size(49, 21);
            this._selectTail.TabIndex = 9;
            this._selectTail.Text = "Tail";
            this._selectTail.UseVisualStyleBackColor = true;
            this._selectTail.CheckedChanged += new System.EventHandler(this.OnToolSelectChanged);
            // 
            // _clearSparksButton
            // 
            this._clearSparksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._clearSparksButton.Location = new System.Drawing.Point(278, 12);
            this._clearSparksButton.Name = "_clearSparksButton";
            this._clearSparksButton.Size = new System.Drawing.Size(99, 23);
            this._clearSparksButton.TabIndex = 10;
            this._clearSparksButton.Text = "Clear Sparks";
            this._clearSparksButton.UseVisualStyleBackColor = true;
            this._clearSparksButton.Click += new System.EventHandler(this.OnClearSparks);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Speed (%):";
            // 
            // _speedSelect
            // 
            this._speedSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._speedSelect.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._speedSelect.Location = new System.Drawing.Point(383, 41);
            this._speedSelect.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this._speedSelect.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._speedSelect.Name = "_speedSelect";
            this._speedSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._speedSelect.Size = new System.Drawing.Size(62, 23);
            this._speedSelect.TabIndex = 12;
            this._speedSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._speedSelect.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._speedSelect.ValueChanged += new System.EventHandler(this.OnSpeedChanged);
            // 
            // m_panel
            // 
            this.m_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_panel.Location = new System.Drawing.Point(4, 67);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(501, 501);
            this.m_panel.TabIndex = 0;
            this.m_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
            this.m_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseDown);
            this.m_panel.Resize += new System.EventHandler(this.OnPanelResize);
            // 
            // LifeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 577);
            this.Controls.Add(this._speedSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._clearSparksButton);
            this.Controls.Add(this._selectTail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._selectSpark);
            this.Controls.Add(this._selectWire);
            this.Controls.Add(this._forceSquare);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.m_TimerChk);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_panel);
            this.Name = "LifeForm";
            this.Text = "WireWorld";
            ((System.ComponentModel.ISupportInitialize)(this._speedSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MPanel m_panel;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox m_TimerChk;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox _forceSquare;
        private System.Windows.Forms.RadioButton _selectWire;
        private System.Windows.Forms.RadioButton _selectSpark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton _selectTail;
        private System.Windows.Forms.Button _clearSparksButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _speedSelect;
    }
}

