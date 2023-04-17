using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace SWNW_TCPChat
{
    public delegate void StoUI_startSuccess_DELEGATE_t();
    public delegate void StoUI_serverEnd_DELEGATE_t(string message);
    public delegate void CtoUI_connectSuccess_DELEGATE_t();
    public delegate void CtoUI_connectionEnd_DELEGATE_t(string message);
    public delegate void CStoUI_receivedMessage_DELEGATE_t(string from, string message);
    public delegate void CStoUI_clientListUpdate_DELEGATE_t(string[] clients);

    public partial class Form1 : Form
    {
        public static Form1 frm;
        StoUI_startSuccess_DELEGATE_t f_StoUI_startSuccess_DELEGATE;
        StoUI_serverEnd_DELEGATE_t f_StoUI_serverEnd_DELEGATE;
        CtoUI_connectSuccess_DELEGATE_t f_CtoUI_connectSuccess_DELEGATE;
        CtoUI_connectionEnd_DELEGATE_t f_CtoUI_connectionEnd_DELEGATE;
        CStoUI_receivedMessage_DELEGATE_t f_CStoUI_receivedMessage_DELEGATE;
        CStoUI_clientListUpdate_DELEGATE_t f_CStoUI_clientListUpdate_DELEGATE;

        CCClient m_client = null;
        CServer m_server = null;

        public Form1()
        {
            InitializeComponent();
            frm = this;
            f_StoUI_startSuccess_DELEGATE = StoUI_startSuccess_DELEGATE;
            f_StoUI_serverEnd_DELEGATE = StoUI_serverEnd_DELEGATE;
            f_CtoUI_connectSuccess_DELEGATE = CtoUI_connectSuccess_DELEGATE;
            f_CtoUI_connectionEnd_DELEGATE = CtoUI_connectionEnd_DELEGATE;
            f_CStoUI_receivedMessage_DELEGATE = CStoUI_receivedMessage_DELEGATE;
            f_CStoUI_clientListUpdate_DELEGATE = CStoUI_clientListUpdate_DELEGATE;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            u_chatView.Columns.Add("User", u_chatView.Width / 5);
            u_chatView.Columns.Add("Message", (u_chatView.Width / 5) * 4);
            u_chatView.View = View.Details;

            u_userView.Columns.Add("User", u_userView.Width - 5);
            u_userView.View = View.Details;

            u_usernameBox.AppendText(new Random().Next(1, 100).ToString());
        }

        private void startServer()
        {
            IPHostEntry host = Dns.GetHostEntry(u_ipBox.Text);
            int port = Convert.ToInt32(u_portBox.Text);
            m_server = new CServer(host.AddressList[1], (ushort)port);
        }

        private void startClient()
        {
            IPHostEntry host = Dns.GetHostEntry(u_ipBox.Text);
            int port = Convert.ToInt32(u_portBox.Text);
            string username = u_usernameBox.Text;
            m_client = new CCClient(host.AddressList[1], (ushort)port, username);
        }

        private void stopServer()
        {
            m_server.taskQueue.put(new CTask(CWhatToDo.sTerminate));
        }

        private void stopClient()
        {
            m_client.taskQueue.put(new CTask(CWhatToDo.cTerminate));
        }

        private void on_u_connectBtn_click(object sender, EventArgs e)
        {
            if(u_connectBtn.Text == "Connect")
            {
                if(u_servBtn.Checked) startServer();
                else startClient();
            }
            else    // Disconnect
            {
                if(u_servBtn.Checked) stopServer();
                else stopClient();
            }
        }

        private void on_u_inputBox_keyDown(object sender, KeyEventArgs e)
        {
            // so machen, dass ENTER ebenso die Nachricht sendet.
            if(e.KeyCode == Keys.Enter)
            {
                m_client.taskQueue.put(new CTask(CWhatToDo.cSendMessage, u_inputBox.Text));
                u_inputBox.Text = "";
            }
        }

        private void on_u_sendBtn_click(object sender, EventArgs e)
        {
            m_client.taskQueue.put(new CTask(CWhatToDo.cSendMessage, u_inputBox.Text));
            u_inputBox.Text = "";
        }

        private void StoUI_startSuccess_DELEGATE()
        {
            u_chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", "Server started!" }));
            u_chatView.Items[u_chatView.Items.Count - 1].EnsureVisible();

            u_connectBtn.Text = "Disconnect";
            u_ipBox.Enabled = false;
            u_portBox.Enabled = false;
            u_servBtn.Enabled = false;
            u_clientBtn.Enabled = false;
            u_usernameBox.Enabled = false;
            u_inputBox.Enabled = false;
            u_sendBtn.Enabled = false;
        }

        public void StoUI_startSuccess()
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> StoUI_startSuccess_DELEGATE
            BeginInvoke(f_StoUI_startSuccess_DELEGATE);
        }

        private void StoUI_serverEnd_DELEGATE(string message)
        {
            u_chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", message }));
            u_chatView.Items[u_chatView.Items.Count - 1].EnsureVisible();

            u_connectBtn.Text = "Connect";
            u_ipBox.Enabled = true;
            u_portBox.Enabled = true;
            u_servBtn.Enabled = true;
            u_clientBtn.Enabled = true;
            u_usernameBox.Enabled = false;
            u_inputBox.Enabled = false;
            u_sendBtn.Enabled = false;
            u_userView.Items.Clear();

            m_server = null;
        }

        public void StoUI_serverEnd(string message)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> StoUI_serverEnd_DELEGATE
            BeginInvoke(f_StoUI_serverEnd_DELEGATE, new object[] { message });
        }

        private void CtoUI_connectSuccess_DELEGATE()
        {
            u_chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", "Connected!" }));
            u_chatView.Items[u_chatView.Items.Count - 1].EnsureVisible();

            u_connectBtn.Text = "Disconnect";
            u_ipBox.Enabled = false;
            u_portBox.Enabled = false;
            u_servBtn.Enabled = false;
            u_clientBtn.Enabled = false;
            u_usernameBox.Enabled = false;
            u_inputBox.Enabled = true;
            u_sendBtn.Enabled = true;
        }

        public void CtoUI_connectSuccess()
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> CtoUI_connectSuccess_DELEGATE
            BeginInvoke(f_CtoUI_connectSuccess_DELEGATE);
        }

        private void CtoUI_connectionEnd_DELEGATE(string message)
        {
            u_chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", message }));
            u_chatView.Items[u_chatView.Items.Count - 1].EnsureVisible();

            u_connectBtn.Text = "Connect";
            u_ipBox.Enabled = true;
            u_portBox.Enabled = true;
            u_servBtn.Enabled = true;
            u_clientBtn.Enabled = true;
            u_usernameBox.Enabled = true;
            u_inputBox.Enabled = false;
            u_sendBtn.Enabled = false;
            u_userView.Items.Clear();

            m_client = null;
        }

        public void CtoUI_connectionEnd(string message)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> CtoUI_connectionEnd_DELEGATE
            BeginInvoke(f_CtoUI_connectionEnd_DELEGATE, new object[] { message });
        }

        private void CStoUI_receivedMessage_DELEGATE(string from, string message)
        {
            u_chatView.Items.Add(new ListViewItem(new string[] { from + ":", message }));
            u_chatView.Items[u_chatView.Items.Count - 1].EnsureVisible();
        }

        public void CStoUI_receivedMessage(string from, string message)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> StoUI_receivedMessage_DELEGATE
            BeginInvoke(f_CStoUI_receivedMessage_DELEGATE, new object[] { from, message });
        }

        private void CStoUI_clientListUpdate_DELEGATE(string[] clients)
        {
            if (clients.Length > u_userView.Items.Count)
            {
                // neuer User
                u_chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", clients.Last() + " joined!" }));
            }
            else
            {
                // Nutzer hat verlassen, den suchen, der verlassen hat:
                foreach (ListViewItem l in u_userView.Items)
                {
                    if (!clients.Contains(l.Text))
                    {
                        u_chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", l.Text + " left!" }));
                    }
                }

            }

            u_userView.Items.Clear();
            foreach (string c in clients)
            {
                u_userView.Items.Add(new ListViewItem(c));
            }

            u_chatView.Items[u_chatView.Items.Count - 1].EnsureVisible();
        }

        public void CStoUI_clientListUpdate(string[] clients)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> CStoUI_clientListUpdate_DELEGATE
            BeginInvoke(f_CStoUI_clientListUpdate_DELEGATE, new object[] { clients });
        }

        private void on_u_servBtn_checkedChanged(object sender, EventArgs e)
        {
            if (!u_servBtn.Checked) u_usernameBox.Enabled = true;
            else u_usernameBox.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_server != null) stopServer();
            if (m_client != null) stopClient();
        }
    }
}
