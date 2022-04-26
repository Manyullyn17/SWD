

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
            this._creDelChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _panel
            // 
            this._panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._panel.Location = new System.Drawing.Point(4, 74);
            this._panel.Margin = new System.Windows.Forms.Padding(4);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(769, 471);
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
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size:";
            // 
            // _sizeEd
            // 
            this._sizeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sizeEd.Location = new System.Drawing.Point(80, 25);
            this._sizeEd.Margin = new System.Windows.Forms.Padding(4);
            this._sizeEd.Name = "_sizeEd";
            this._sizeEd.Size = new System.Drawing.Size(88, 26);
            this._sizeEd.TabIndex = 2;
            // 
            // _typeEd
            // 
            this._typeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._typeEd.Location = new System.Drawing.Point(347, 25);
            this._typeEd.Margin = new System.Windows.Forms.Padding(4);
            this._typeEd.Name = "_typeEd";
            this._typeEd.Size = new System.Drawing.Size(97, 26);
            this._typeEd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "ObjType:";
            // 
            // _creDelChk
            // 
            this._creDelChk.AutoSize = true;
            this._creDelChk.Checked = true;
            this._creDelChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this._creDelChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this._creDelChk.Location = new System.Drawing.Point(486, 27);
            this._creDelChk.Name = "_creDelChk";
            this._creDelChk.Size = new System.Drawing.Size(148, 24);
            this._creDelChk.TabIndex = 5;
            this._creDelChk.Text = "Create/Delete";
            this._creDelChk.UseVisualStyleBackColor = true;
            // 
            // FormAndlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 560);
            this.Controls.Add(this._creDelChk);
            this.Controls.Add(this._typeEd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._sizeEd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._panel);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.CheckBox _creDelChk;
    }
}

