namespace SWNW_TCPChat
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.u_ipBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.u_portBox = new System.Windows.Forms.TextBox();
            this.u_connectBtn = new System.Windows.Forms.Button();
            this.u_chatView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.u_userView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.u_inputBox = new System.Windows.Forms.TextBox();
            this.u_sendBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.u_usernameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.u_clientBtn = new System.Windows.Forms.RadioButton();
            this.u_servBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP/Host";
            // 
            // u_ipBox
            // 
            this.u_ipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_ipBox.Location = new System.Drawing.Point(72, 53);
            this.u_ipBox.Name = "u_ipBox";
            this.u_ipBox.Size = new System.Drawing.Size(100, 23);
            this.u_ipBox.TabIndex = 1;
            this.u_ipBox.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // u_portBox
            // 
            this.u_portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_portBox.Location = new System.Drawing.Point(218, 53);
            this.u_portBox.Name = "u_portBox";
            this.u_portBox.Size = new System.Drawing.Size(44, 23);
            this.u_portBox.TabIndex = 3;
            this.u_portBox.Text = "12345";
            // 
            // u_connectBtn
            // 
            this.u_connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_connectBtn.Location = new System.Drawing.Point(425, 51);
            this.u_connectBtn.Name = "u_connectBtn";
            this.u_connectBtn.Size = new System.Drawing.Size(168, 27);
            this.u_connectBtn.TabIndex = 4;
            this.u_connectBtn.Text = "Connect";
            this.u_connectBtn.UseVisualStyleBackColor = true;
            this.u_connectBtn.Click += new System.EventHandler(this.on_u_connectBtn_click);
            // 
            // u_chatView
            // 
            this.u_chatView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_chatView.HideSelection = false;
            this.u_chatView.Location = new System.Drawing.Point(234, 109);
            this.u_chatView.Name = "u_chatView";
            this.u_chatView.Size = new System.Drawing.Size(359, 269);
            this.u_chatView.TabIndex = 5;
            this.u_chatView.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(231, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chat";
            // 
            // u_userView
            // 
            this.u_userView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_userView.HideSelection = false;
            this.u_userView.Location = new System.Drawing.Point(16, 109);
            this.u_userView.Name = "u_userView";
            this.u_userView.Size = new System.Drawing.Size(212, 298);
            this.u_userView.TabIndex = 7;
            this.u_userView.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Users Online";
            // 
            // u_inputBox
            // 
            this.u_inputBox.Enabled = false;
            this.u_inputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_inputBox.Location = new System.Drawing.Point(234, 384);
            this.u_inputBox.Name = "u_inputBox";
            this.u_inputBox.Size = new System.Drawing.Size(291, 23);
            this.u_inputBox.TabIndex = 9;
            this.u_inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.on_u_inputBox_keyDown);
            // 
            // u_sendBtn
            // 
            this.u_sendBtn.Enabled = false;
            this.u_sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_sendBtn.Location = new System.Drawing.Point(531, 383);
            this.u_sendBtn.Name = "u_sendBtn";
            this.u_sendBtn.Size = new System.Drawing.Size(62, 24);
            this.u_sendBtn.TabIndex = 10;
            this.u_sendBtn.Text = ">>>";
            this.u_sendBtn.UseVisualStyleBackColor = true;
            this.u_sendBtn.Click += new System.EventHandler(this.on_u_sendBtn_click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name";
            // 
            // u_usernameBox
            // 
            this.u_usernameBox.Enabled = false;
            this.u_usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.u_usernameBox.Location = new System.Drawing.Point(319, 53);
            this.u_usernameBox.Name = "u_usernameBox";
            this.u_usernameBox.Size = new System.Drawing.Size(100, 23);
            this.u_usernameBox.TabIndex = 12;
            this.u_usernameBox.Text = "User";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.u_clientBtn);
            this.groupBox1.Controls.Add(this.u_servBtn);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 32);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modus";
            // 
            // u_clientBtn
            // 
            this.u_clientBtn.AutoSize = true;
            this.u_clientBtn.Location = new System.Drawing.Point(148, 11);
            this.u_clientBtn.Name = "u_clientBtn";
            this.u_clientBtn.Size = new System.Drawing.Size(51, 17);
            this.u_clientBtn.TabIndex = 1;
            this.u_clientBtn.Text = "Client";
            this.u_clientBtn.UseVisualStyleBackColor = true;
            // 
            // u_servBtn
            // 
            this.u_servBtn.AutoSize = true;
            this.u_servBtn.Checked = true;
            this.u_servBtn.Location = new System.Drawing.Point(56, 11);
            this.u_servBtn.Name = "u_servBtn";
            this.u_servBtn.Size = new System.Drawing.Size(56, 17);
            this.u_servBtn.TabIndex = 0;
            this.u_servBtn.TabStop = true;
            this.u_servBtn.Text = "Server";
            this.u_servBtn.UseVisualStyleBackColor = true;
            this.u_servBtn.CheckedChanged += new System.EventHandler(this.on_u_servBtn_checkedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.u_usernameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.u_sendBtn);
            this.Controls.Add(this.u_inputBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.u_userView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.u_chatView);
            this.Controls.Add(this.u_connectBtn);
            this.Controls.Add(this.u_portBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.u_ipBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox u_ipBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox u_portBox;
        private System.Windows.Forms.Button u_connectBtn;
        private System.Windows.Forms.ListView u_chatView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView u_userView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox u_inputBox;
        private System.Windows.Forms.Button u_sendBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox u_usernameBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton u_clientBtn;
        private System.Windows.Forms.RadioButton u_servBtn;
    }
}

