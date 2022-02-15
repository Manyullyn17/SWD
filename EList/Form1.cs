using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void OnInListBtnClick(object sender, EventArgs e)
        {
            if (_toDoEdit.Text.Length > 1)
                _toDoList.Items.Add(_toDoEdit.Text);
            _toDoEdit.Clear();  // Inhalt der Textbox löschen
            _toDoEdit.Focus();  // Eingabefokus wieder auf die Textbox setzen
        }
        
        void OnToDoEditKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)    // Eingabetaste wurde gedrückt
                OnInListBtnClick(null, null);
        }

        void OnDoneBtnClick(object sender, EventArgs e)
        {
            int idx = _toDoList.SelectedIndex;
            if (idx == -1)
                return;
            /*
            string txt = (string)_toDoList.Items[idx];
            _doneList.Items.Add(txt);
            _toDoList.Items.RemoveAt(idx);
            */

            string[] items = new string[_toDoList.SelectedItems.Count];
            _toDoList.SelectedItems.CopyTo(items, 0);
            _doneList.Items.AddRange(items);

            if (_toDoList.SelectedIndex != -1)
            {
                for (int i = _toDoList.SelectedItems.Count - 1; i >= 0; i--)
                    _toDoList.Items.Remove(_toDoList.SelectedItems[i]);
            }
        }

        void OnUndoBtnClick(object sender, EventArgs e)
        {
            string[] items = new string[_doneList.SelectedItems.Count];
            _doneList.SelectedItems.CopyTo(items, 0);
            _toDoList.Items.AddRange(items);

            if (_doneList.SelectedIndex != -1)
            {
                for (int i = _doneList.SelectedItems.Count - 1; i >= 0; i--)
                    _doneList.Items.Remove(_doneList.SelectedItems[i]);
            }
        }

        void OnSelIdxChanged(object sender, EventArgs e)
        {
            int idx = _toDoList.SelectedIndex;
            if (idx == -1)
                return;
            string txt = (string)_toDoList.Items[idx];
            _dbgLbl.Text = txt;
        }

        void OnLoadFileClick(object sender, EventArgs e)
        {
            StreamReader sr;

            try
            {
                sr = new StreamReader("File1.txt");
            } catch (Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            _toDoList.Items.Clear();    // Momentanen Inhalt von _toDoList löschen
            _doneList.Items.Clear();
            
            string txt;

            while (!sr.EndOfStream)
            {
                txt = sr.ReadLine();
                if (txt == "!!done!!")
                    break;
                _toDoList.Items.Add(txt);
            }
            while (!sr.EndOfStream)
            {
                txt = sr.ReadLine();
                _doneList.Items.Add(txt);
            }

            sr.Close();
        }

        void OnSaveFileClick(object sender, EventArgs e)
        {
            StreamWriter wr;
            try
            {
                wr = new StreamWriter("File1.txt");
            } catch(Exception ex)
            {
                MessageBox.Show("File konnte nicht geöffnet werden");
                return;
            }

            for (int i = 0; i < _toDoList.Items.Count; i++)
            {
                wr.WriteLine("{0}", _toDoList.Items[i]);
            }
            wr.WriteLine("!!done!!");
            for (int i = 0; i < _doneList.Items.Count; i++)
            {
                wr.WriteLine("{0}", _doneList.Items[i]);
            }
            wr.Close(); // Verbindung mit dem File trennen
            MessageBox.Show("File saved");
        }
    }
}
