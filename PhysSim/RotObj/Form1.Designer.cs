namespace RotObj
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
      this._panel = new MV.ScPanel();
      this.label1 = new System.Windows.Forms.Label();
      this._paramEdit = new System.Windows.Forms.TextBox();
      this._infoLbl = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // _panel
      // 
      this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this._panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this._panel.Location = new System.Drawing.Point(7, 45);
      this._panel.Name = "_panel";
      this._panel.Size = new System.Drawing.Size(458, 406);
      this._panel.TabIndex = 0;
      this._panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(5, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "speed  dPhi:";
      // 
      // _paramEdit
      // 
      this._paramEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._paramEdit.Location = new System.Drawing.Point(101, 11);
      this._paramEdit.Name = "_paramEdit";
      this._paramEdit.Size = new System.Drawing.Size(85, 22);
      this._paramEdit.TabIndex = 2;
      this._paramEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnParamEditKeyDown);
      // 
      // _infoLbl
      // 
      this._infoLbl.AutoSize = true;
      this._infoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._infoLbl.Location = new System.Drawing.Point(205, 14);
      this._infoLbl.Name = "_infoLbl";
      this._infoLbl.Size = new System.Drawing.Size(69, 15);
      this._infoLbl.TabIndex = 3;
      this._infoLbl.Text = "V:  R   phi";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(468, 454);
      this.Controls.Add(this._infoLbl);
      this.Controls.Add(this._paramEdit);
      this.Controls.Add(this.label1);
      this.Controls.Add(this._panel);
      this.Name = "Form1";
      this.Text = "Rotating Graphic-Object";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MV.ScPanel _panel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _paramEdit;
    private System.Windows.Forms.Label _infoLbl;
  }
}

