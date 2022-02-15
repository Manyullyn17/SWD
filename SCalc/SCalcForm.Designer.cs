
namespace SCalc
{
    partial class SCalcForm
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
            this._inputA = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this._inputB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubButton = new System.Windows.Forms.Button();
            this._trcList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _inputA
            // 
            this._inputA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._inputA.Location = new System.Drawing.Point(66, 49);
            this._inputA.Name = "_inputA";
            this._inputA.Size = new System.Drawing.Size(175, 26);
            this._inputA.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(281, 47);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(113, 30);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "A = A + B";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.OnAddButtonClick);
            // 
            // _inputB
            // 
            this._inputB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._inputB.Location = new System.Drawing.Point(66, 106);
            this._inputB.Name = "_inputB";
            this._inputB.Size = new System.Drawing.Size(175, 26);
            this._inputB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "B:";
            // 
            // SubButton
            // 
            this.SubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubButton.Location = new System.Drawing.Point(281, 104);
            this.SubButton.Name = "SubButton";
            this.SubButton.Size = new System.Drawing.Size(113, 30);
            this.SubButton.TabIndex = 5;
            this.SubButton.Text = "A = A - B";
            this.SubButton.UseVisualStyleBackColor = true;
            this.SubButton.Click += new System.EventHandler(this.OnSubButtonClick);
            // 
            // _trcList
            // 
            this._trcList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._trcList.FormattingEnabled = true;
            this._trcList.ItemHeight = 20;
            this._trcList.Location = new System.Drawing.Point(31, 171);
            this._trcList.Name = "_trcList";
            this._trcList.Size = new System.Drawing.Size(382, 244);
            this._trcList.TabIndex = 6;
            // 
            // SCalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 450);
            this.Controls.Add(this._trcList);
            this.Controls.Add(this.SubButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._inputB);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this._inputA);
            this.Name = "SCalcForm";
            this.Text = "SCalc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _inputA;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox _inputB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubButton;
        private System.Windows.Forms.ListBox _trcList;
    }
}

