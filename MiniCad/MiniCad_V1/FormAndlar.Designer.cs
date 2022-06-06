

namespace Andlar
{
  partial class FormAndlar
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
            this._panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._sizeEd = new System.Windows.Forms.TextBox();
            this._typeEd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._creDelChk = new System.Windows.Forms.RadioButton();
            this._connectChk = new System.Windows.Forms.RadioButton();
            this._disconnectChk = new System.Windows.Forms.RadioButton();
            this._moveChk = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._panel.Location = new System.Drawing.Point(3, 60);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(577, 383);
            this._panel.TabIndex = 0;
            this._panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this._panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this._panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size:";
            // 
            // _sizeEd
            // 
            this._sizeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sizeEd.Location = new System.Drawing.Point(60, 20);
            this._sizeEd.Name = "_sizeEd";
            this._sizeEd.Size = new System.Drawing.Size(67, 22);
            this._sizeEd.TabIndex = 2;
            // 
            // _typeEd
            // 
            this._typeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._typeEd.Location = new System.Drawing.Point(260, 20);
            this._typeEd.Name = "_typeEd";
            this._typeEd.Size = new System.Drawing.Size(74, 22);
            this._typeEd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ObjType:";
            // 
            // _creDelChk
            // 
            this._creDelChk.AutoSize = true;
            this._creDelChk.Checked = true;
            this._creDelChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._creDelChk.Location = new System.Drawing.Point(351, 12);
            this._creDelChk.Name = "_creDelChk";
            this._creDelChk.Size = new System.Drawing.Size(122, 20);
            this._creDelChk.TabIndex = 8;
            this._creDelChk.TabStop = true;
            this._creDelChk.Text = "Create/Delete";
            this._creDelChk.UseVisualStyleBackColor = true;
            // 
            // _connectChk
            // 
            this._connectChk.AutoSize = true;
            this._connectChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._connectChk.Location = new System.Drawing.Point(479, 12);
            this._connectChk.Name = "_connectChk";
            this._connectChk.Size = new System.Drawing.Size(81, 20);
            this._connectChk.TabIndex = 9;
            this._connectChk.TabStop = true;
            this._connectChk.Text = "Connect";
            this._connectChk.UseVisualStyleBackColor = true;
            // 
            // _disconnectChk
            // 
            this._disconnectChk.AutoSize = true;
            this._disconnectChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._disconnectChk.Location = new System.Drawing.Point(479, 34);
            this._disconnectChk.Name = "_disconnectChk";
            this._disconnectChk.Size = new System.Drawing.Size(102, 20);
            this._disconnectChk.TabIndex = 10;
            this._disconnectChk.TabStop = true;
            this._disconnectChk.Text = "Disconnect";
            this._disconnectChk.UseVisualStyleBackColor = true;
            // 
            // _moveChk
            // 
            this._moveChk.AutoSize = true;
            this._moveChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._moveChk.Location = new System.Drawing.Point(351, 34);
            this._moveChk.Name = "_moveChk";
            this._moveChk.Size = new System.Drawing.Size(63, 20);
            this._moveChk.TabIndex = 11;
            this._moveChk.TabStop = true;
            this._moveChk.Text = "Move";
            this._moveChk.UseVisualStyleBackColor = true;
            // 
            // FormAndlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 455);
            this.Controls.Add(this._connectChk);
            this.Controls.Add(this._disconnectChk);
            this.Controls.Add(this._moveChk);
            this.Controls.Add(this._creDelChk);
            this.Controls.Add(this._typeEd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._sizeEd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._panel);
            this.Name = "FormAndlar";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel _panel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _sizeEd;
    private System.Windows.Forms.TextBox _typeEd;
    private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton _creDelChk;
        private System.Windows.Forms.RadioButton _connectChk;
        private System.Windows.Forms.RadioButton _disconnectChk;
        private System.Windows.Forms.RadioButton _moveChk;
    }
}

