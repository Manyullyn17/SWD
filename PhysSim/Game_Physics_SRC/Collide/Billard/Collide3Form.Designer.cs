
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
            this.label1 = new System.Windows.Forms.Label();
            this._Ed1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this._runChk = new System.Windows.Forms.CheckBox();
            this._loadBtn = new System.Windows.Forms.Button();
            this._spdLbl = new System.Windows.Forms.Label();
            this._panel = new MV.ScPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Speed Mult:";
            // 
            // _Ed1
            // 
            this._Ed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Ed1.Location = new System.Drawing.Point(107, 4);
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
            this._runChk.Location = new System.Drawing.Point(300, 8);
            this._runChk.Name = "_runChk";
            this._runChk.Size = new System.Drawing.Size(49, 17);
            this._runChk.TabIndex = 6;
            this._runChk.Text = "Run";
            this._runChk.UseVisualStyleBackColor = true;
            this._runChk.CheckedChanged += new System.EventHandler(this.OnRunCheckChanged);
            // 
            // _loadBtn
            // 
            this._loadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._loadBtn.Location = new System.Drawing.Point(355, 4);
            this._loadBtn.Name = "_loadBtn";
            this._loadBtn.Size = new System.Drawing.Size(67, 23);
            this._loadBtn.TabIndex = 8;
            this._loadBtn.Text = "Load";
            this._loadBtn.UseVisualStyleBackColor = true;
            this._loadBtn.Click += new System.EventHandler(this.OnLoadBtnClicked);
            // 
            // _spdLbl
            // 
            this._spdLbl.AutoSize = true;
            this._spdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._spdLbl.Location = new System.Drawing.Point(440, 7);
            this._spdLbl.Name = "_spdLbl";
            this._spdLbl.Size = new System.Drawing.Size(61, 16);
            this._spdLbl.TabIndex = 9;
            this._spdLbl.Text = "Speed: ";
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._panel.Location = new System.Drawing.Point(7, 36);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(974, 576);
            this._panel.TabIndex = 0;
            this._panel.SizeChanged += new System.EventHandler(this.OnResize);
            this._panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
            this._panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseDown);
            this._panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelMouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(570, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // Collide3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 615);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._spdLbl);
            this.Controls.Add(this._loadBtn);
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
        private System.Windows.Forms.Button _loadBtn;
        private System.Windows.Forms.Label _spdLbl;
        private System.Windows.Forms.Label label2;
    }
}

