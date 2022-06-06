namespace HLSpaceShip
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
      this._scaleEd = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this._infoLbl = new System.Windows.Forms.Label();
      this._SpeedEd = new System.Windows.Forms.TextBox();
      this._panel = new MV.ScPanel();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(4, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(51, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "Zoom:";
      // 
      // _scaleEd
      // 
      this._scaleEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._scaleEd.Location = new System.Drawing.Point(61, 11);
      this._scaleEd.Name = "_scaleEd";
      this._scaleEd.Size = new System.Drawing.Size(37, 22);
      this._scaleEd.TabIndex = 4;
      this._scaleEd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnScaleEditKeyDown);
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.OnTimer);
      // 
      // _infoLbl
      // 
      this._infoLbl.AutoSize = true;
      this._infoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._infoLbl.Location = new System.Drawing.Point(222, 14);
      this._infoLbl.Name = "_infoLbl";
      this._infoLbl.Size = new System.Drawing.Size(74, 16);
      this._infoLbl.TabIndex = 6;
      this._infoLbl.Text = "V omega:";
      // 
      // _SpeedEd
      // 
      this._SpeedEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._SpeedEd.Location = new System.Drawing.Point(302, 13);
      this._SpeedEd.Name = "_SpeedEd";
      this._SpeedEd.Size = new System.Drawing.Size(85, 22);
      this._SpeedEd.TabIndex = 7;
      this._SpeedEd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSpeedEditKeyDown);
      // 
      // _panel
      // 
      this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this._panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._panel.Location = new System.Drawing.Point(7, 45);
      this._panel.Name = "_panel";
      this._panel.Size = new System.Drawing.Size(604, 567);
      this._panel.TabIndex = 0;
      this._panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
      this._panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseMove);
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(122, 10);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(70, 23);
      this.button1.TabIndex = 8;
      this.button1.Text = "Reset";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.OnResetBtn);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(614, 615);
      this.Controls.Add(this.button1);
      this.Controls.Add(this._SpeedEd);
      this.Controls.Add(this._infoLbl);
      this.Controls.Add(this._scaleEd);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._panel);
      this.Name = "Form1";
      this.Text = "HLSpaceShipV2";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MV.ScPanel _panel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _scaleEd;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label _infoLbl;
    private System.Windows.Forms.TextBox _SpeedEd;
    private System.Windows.Forms.Button button1;
  }
}

