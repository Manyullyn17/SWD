
namespace ToDoList
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
            this._toDoList = new System.Windows.Forms.ListBox();
            this._doneList = new System.Windows.Forms.ListBox();
            this._inListButton = new System.Windows.Forms.Button();
            this._doneButton = new System.Windows.Forms.Button();
            this._undoButton = new System.Windows.Forms.Button();
            this._toDoEdit = new System.Windows.Forms.TextBox();
            this._dbgLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toDoList
            // 
            this._toDoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._toDoList.FormattingEnabled = true;
            this._toDoList.ItemHeight = 20;
            this._toDoList.Location = new System.Drawing.Point(12, 81);
            this._toDoList.Name = "_toDoList";
            this._toDoList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._toDoList.Size = new System.Drawing.Size(189, 384);
            this._toDoList.TabIndex = 0;
            this._toDoList.SelectedIndexChanged += new System.EventHandler(this.OnSelIdxChanged);
            // 
            // _doneList
            // 
            this._doneList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._doneList.FormattingEnabled = true;
            this._doneList.ItemHeight = 20;
            this._doneList.Location = new System.Drawing.Point(367, 81);
            this._doneList.Name = "_doneList";
            this._doneList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this._doneList.Size = new System.Drawing.Size(186, 384);
            this._doneList.TabIndex = 1;
            // 
            // _inListButton
            // 
            this._inListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._inListButton.Location = new System.Drawing.Point(219, 39);
            this._inListButton.Name = "_inListButton";
            this._inListButton.Size = new System.Drawing.Size(134, 30);
            this._inListButton.TabIndex = 2;
            this._inListButton.Text = "In die Liste";
            this._inListButton.UseVisualStyleBackColor = true;
            this._inListButton.Click += new System.EventHandler(this.OnInListBtnClick);
            // 
            // _doneButton
            // 
            this._doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._doneButton.Location = new System.Drawing.Point(219, 216);
            this._doneButton.Name = "_doneButton";
            this._doneButton.Size = new System.Drawing.Size(134, 41);
            this._doneButton.TabIndex = 3;
            this._doneButton.Text = "Erledigt ->";
            this._doneButton.UseVisualStyleBackColor = true;
            this._doneButton.Click += new System.EventHandler(this.OnDoneBtnClick);
            // 
            // _undoButton
            // 
            this._undoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._undoButton.Location = new System.Drawing.Point(219, 275);
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(134, 41);
            this._undoButton.TabIndex = 4;
            this._undoButton.Text = "Undo <-";
            this._undoButton.UseVisualStyleBackColor = true;
            this._undoButton.Click += new System.EventHandler(this.OnUndoBtnClick);
            // 
            // _toDoEdit
            // 
            this._toDoEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._toDoEdit.Location = new System.Drawing.Point(12, 41);
            this._toDoEdit.Name = "_toDoEdit";
            this._toDoEdit.Size = new System.Drawing.Size(189, 26);
            this._toDoEdit.TabIndex = 5;
            this._toDoEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnToDoEditKeyDown);
            // 
            // _dbgLbl
            // 
            this._dbgLbl.AutoSize = true;
            this._dbgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dbgLbl.Location = new System.Drawing.Point(12, 466);
            this._dbgLbl.Name = "_dbgLbl";
            this._dbgLbl.Size = new System.Drawing.Size(59, 20);
            this._dbgLbl.TabIndex = 6;
            this._dbgLbl.Text = "debug";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 36);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(80, 32);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.OnLoadFileClick);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.saveFileToolStripMenuItem.Text = "Save File";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.OnSaveFileClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 494);
            this.Controls.Add(this._dbgLbl);
            this.Controls.Add(this._toDoEdit);
            this.Controls.Add(this._undoButton);
            this.Controls.Add(this._doneButton);
            this.Controls.Add(this._inListButton);
            this.Controls.Add(this._doneList);
            this.Controls.Add(this._toDoList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _toDoList;
        private System.Windows.Forms.ListBox _doneList;
        private System.Windows.Forms.Button _inListButton;
        private System.Windows.Forms.Button _doneButton;
        private System.Windows.Forms.Button _undoButton;
        private System.Windows.Forms.TextBox _toDoEdit;
        private System.Windows.Forms.Label _dbgLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
    }
}

