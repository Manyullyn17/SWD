
namespace Collide
{
  partial class Collide3Form
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
      this._panel = new MV.ScPanel();
      this.label1 = new System.Windows.Forms.Label();
      this._Ed1 = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this._runChk = new System.Windows.Forms.CheckBox();
      this.button2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // _panel
      // 
      this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this._panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._panel.Location = new System.Drawing.Point(7, 36);
      this._panel.Name = "_panel";
      this._panel.Size = new System.Drawing.Size(611, 576);
      this._panel.TabIndex = 0;
      this._panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
      this._panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseMove);
      this._panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseDown);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "M1:V1: M2:V2";
      // 
      // _Ed1
      // 
      this._Ed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._Ed1.Location = new System.Drawing.Point(118, 4);
      this._Ed1.Name = "_Ed1";
      this._Ed1.Size = new System.Drawing.Size(77, 22);
      this._Ed1.TabIndex = 4;
      this._Ed1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnEditKeyDown);
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.OnTimer);
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(215, 4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(67, 23);
      this.button1.TabIndex = 5;
      this.button1.Text = "Reset";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.OnResetBtn);
      // 
      // _runChk
      // 
      this._runChk.AutoSize = true;
      this._runChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._runChk.Location = new System.Drawing.Point(299, 6);
      this._runChk.Name = "_runChk";
      this._runChk.Size = new System.Drawing.Size(49, 17);
      this._runChk.TabIndex = 6;
      this._runChk.Text = "Run";
      this._runChk.UseVisualStyleBackColor = true;
      this._runChk.CheckedChanged += new System.EventHandler(this.OnRunCheckChanged);
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(354, 4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(67, 23);
      this.button2.TabIndex = 7;
      this.button2.Text = "Reverse";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.OnReverseBtn);
      // 
      // Collide3Form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(621, 615);
      this.Controls.Add(this.button2);
      this.Controls.Add(this._runChk);
      this.Controls.Add(this.button1);
      this.Controls.Add(this._Ed1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._panel);
      this.Name = "Collide3Form";
      this.Text = "HLSpaceShip";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MV.ScPanel _panel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _Ed1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox _runChk;
    private System.Windows.Forms.Button button2;
  }
}

