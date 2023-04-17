namespace TCPChat
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
            this.ipBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.chatView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.userView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clientBtn = new System.Windows.Forms.RadioButton();
            this.serverBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP-Address:";
            // 
            // ipBox
            // 
            this.ipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipBox.Location = new System.Drawing.Point(96, 54);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(100, 23);
            this.ipBox.TabIndex = 1;
            this.ipBox.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portBox.Location = new System.Drawing.Point(242, 54);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(44, 23);
            this.portBox.TabIndex = 3;
            this.portBox.Text = "12345";
            // 
            // connectBtn
            // 
            this.connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(292, 52);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(159, 27);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.On_connectBtn_click);
            // 
            // chatView
            // 
            this.chatView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatView.HideSelection = false;
            this.chatView.Location = new System.Drawing.Point(236, 113);
            this.chatView.Name = "chatView";
            this.chatView.Size = new System.Drawing.Size(359, 269);
            this.chatView.TabIndex = 5;
            this.chatView.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chat";
            // 
            // userView
            // 
            this.userView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.userView.HideSelection = false;
            this.userView.Location = new System.Drawing.Point(18, 113);
            this.userView.Name = "userView";
            this.userView.Size = new System.Drawing.Size(212, 298);
            this.userView.TabIndex = 7;
            this.userView.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Connected Users";
            // 
            // inputBox
            // 
            this.inputBox.Enabled = false;
            this.inputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(236, 388);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(291, 23);
            this.inputBox.TabIndex = 9;
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On_inputBox_keyDown);
            // 
            // sendBtn
            // 
            this.sendBtn.Enabled = false;
            this.sendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtn.Location = new System.Drawing.Point(533, 387);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(62, 24);
            this.sendBtn.TabIndex = 10;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.On_sendBtn_click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(225, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Name:";
            // 
            // usernameBox
            // 
            this.usernameBox.Enabled = false;
            this.usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.Location = new System.Drawing.Point(276, 21);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 23);
            this.usernameBox.TabIndex = 12;
            this.usernameBox.Text = "User";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clientBtn);
            this.groupBox1.Controls.Add(this.serverBtn);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 32);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // clientBtn
            // 
            this.clientBtn.AutoSize = true;
            this.clientBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientBtn.Location = new System.Drawing.Point(124, 9);
            this.clientBtn.Name = "clientBtn";
            this.clientBtn.Size = new System.Drawing.Size(56, 19);
            this.clientBtn.TabIndex = 1;
            this.clientBtn.Text = "Client";
            this.clientBtn.UseVisualStyleBackColor = true;
            // 
            // serverBtn
            // 
            this.serverBtn.AutoSize = true;
            this.serverBtn.Checked = true;
            this.serverBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverBtn.Location = new System.Drawing.Point(47, 9);
            this.serverBtn.Name = "serverBtn";
            this.serverBtn.Size = new System.Drawing.Size(60, 19);
            this.serverBtn.TabIndex = 0;
            this.serverBtn.TabStop = true;
            this.serverBtn.Text = "Server";
            this.serverBtn.UseVisualStyleBackColor = true;
            this.serverBtn.CheckedChanged += new System.EventHandler(this.On_serverBtn_checkedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chatView);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ListView chatView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView userView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton clientBtn;
        private System.Windows.Forms.RadioButton serverBtn;
    }
}

