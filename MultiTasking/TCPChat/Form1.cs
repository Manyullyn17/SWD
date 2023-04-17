using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace TCPChat
{
    public delegate void ServerToUI_startSuccess_DELEGATE_t();
    public delegate void ServerToUI_serverEnd_DELEGATE_t(string message);
    public delegate void ClientToUI_connectSuccess_DELEGATE_t();
    public delegate void ClientToUI_connectionEnd_DELEGATE_t(string message);
    public delegate void CStoUI_receivedMessage_DELEGATE_t(string from, string message);
    public delegate void CStoUI_clientListUpdate_DELEGATE_t(string[] clients);

    public partial class Form1 : Form
    {
        public static Form1 frm;
        ServerToUI_startSuccess_DELEGATE_t f_ServerToUI_startSuccess_DELEGATE;
        ServerToUI_serverEnd_DELEGATE_t f_ServerToUI_serverEnd_DELEGATE;
        ClientToUI_connectSuccess_DELEGATE_t f_ClientToUI_connectSuccess_DELEGATE;
        ClientToUI_connectionEnd_DELEGATE_t f_ClientTUI_connectionEnd_DELEGATE;
        CStoUI_receivedMessage_DELEGATE_t f_CStoUI_receivedMessage_DELEGATE;
        CStoUI_clientListUpdate_DELEGATE_t f_CStoUI_clientListUpdate_DELEGATE;

        CClient m_client = null;
        CServer m_server = null;

        public Form1()
        {
            InitializeComponent();
            frm = this;
            f_ServerToUI_startSuccess_DELEGATE = ServerToUI_startSuccess_DELEGATE;
            f_ServerToUI_serverEnd_DELEGATE = ServerToUI_serverEnd_DELEGATE;
            f_ClientToUI_connectSuccess_DELEGATE = ClientToUI_connectSuccess_DELEGATE;
            f_ClientTUI_connectionEnd_DELEGATE = ClientToUI_connectionEnd_DELEGATE;
            f_CStoUI_receivedMessage_DELEGATE = CStoUI_receivedMessage_DELEGATE;
            f_CStoUI_clientListUpdate_DELEGATE = CStoUI_clientListUpdate_DELEGATE;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chatView.Columns.Add("User", chatView.Width / 5);
            chatView.Columns.Add("Message", (chatView.Width / 5) * 4);
            chatView.View = View.Details;

            userView.Columns.Add("User", userView.Width - 5);
            userView.View = View.Details;

            usernameBox.AppendText(new Random().Next(1, 100).ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_server != null) StopServer();
            if (m_client != null) StopClient();
        }

        private void StartServer()
        {
            if (!IPAddress.TryParse(ipBox.Text, out IPAddress ip))  // check if IPAddress is valid
                ip = IPAddress.Parse("127.0.0.1");                  // set default IPAddress
            ushort port = Convert.ToUInt16(portBox.Text);
            m_server = new CServer(ip, port);
        }

        private void StopServer()
        {
            m_server.taskQueue.Put(new CTask(CWhatToDo.sTerminate));
        }

        private void StartClient()
        {
            if (!IPAddress.TryParse(ipBox.Text, out IPAddress ip))  // check if IPAddress is valid
                ip = IPAddress.Parse("127.0.0.1");                  // set default IPAddress
            ushort port = Convert.ToUInt16(portBox.Text);
            string username = usernameBox.Text;
            m_client = new CClient(ip, port, username);
        }

        private void StopClient()
        {
            m_client.taskQueue.Put(new CTask(CWhatToDo.cTerminate));
        }

        private void On_serverBtn_checkedChanged(object sender, EventArgs e)
        {
            if (!serverBtn.Checked)
                usernameBox.Enabled = true;
            else
                usernameBox.Enabled = false;
        }

        private void On_connectBtn_click(object sender, EventArgs e)
        {
            if (connectBtn.Text == "Connect")
            {
                if (serverBtn.Checked) StartServer();
                else StartClient();
            }
            else    // Disconnect
            {
                if (serverBtn.Checked) StopServer();
                else StopClient();
            }
        }

        private void On_sendBtn_click(object sender, EventArgs e)
        {
            m_client.taskQueue.Put(new CTask(CWhatToDo.cSendMessage, inputBox.Text));
            inputBox.Clear();
        }

        private void On_inputBox_keyDown(object sender, KeyEventArgs e)
        {
            // send text when enter is pressed
            if (e.KeyCode == Keys.Enter)
            {
                On_sendBtn_click(sender, e);

                // suppress "ding" when enter is pressed
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ServerToUI_startSuccess_DELEGATE()
        {
            chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", "Server started!" }));
            chatView.Items[chatView.Items.Count - 1].EnsureVisible();

            connectBtn.Text = "Disconnect";
            ipBox.Enabled = false;
            portBox.Enabled = false;
            serverBtn.Enabled = false;
            clientBtn.Enabled = false;
            usernameBox.Enabled = false;
            inputBox.Enabled = false;
            sendBtn.Enabled = false;
        }

        public void ServerToUI_startSuccess()
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> ServerToUI_startSuccess_DELEGATE
            BeginInvoke(f_ServerToUI_startSuccess_DELEGATE);
        }

        private void ServerToUI_serverEnd_DELEGATE(string message)
        {
            chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", message }));
            chatView.Items[chatView.Items.Count - 1].EnsureVisible();

            connectBtn.Text = "Connect";
            ipBox.Enabled = true;
            portBox.Enabled = true;
            serverBtn.Enabled = true;
            clientBtn.Enabled = true;
            usernameBox.Enabled = false;
            inputBox.Enabled = false;
            sendBtn.Enabled = false;
            userView.Items.Clear();

            m_server = null;
        }

        public void ServerToUI_serverEnd(string message)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> ServerToUI_serverEnd_DELEGATE
            BeginInvoke(f_ServerToUI_serverEnd_DELEGATE, new object[] { message });
        }

        private void ClientToUI_connectSuccess_DELEGATE()
        {
            chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", "Connected!" }));
            chatView.Items[chatView.Items.Count - 1].EnsureVisible();

            connectBtn.Text = "Disconnect";
            ipBox.Enabled = false;
            portBox.Enabled = false;
            serverBtn.Enabled = false;
            clientBtn.Enabled = false;
            usernameBox.Enabled = false;
            inputBox.Enabled = true;
            sendBtn.Enabled = true;
        }

        public void ClientToUI_connectSuccess()
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> ClientToUI_connectSuccess_DELEGATE
            BeginInvoke(f_ClientToUI_connectSuccess_DELEGATE);
        }

        private void ClientToUI_connectionEnd_DELEGATE(string message)
        {
            chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", message }));
            chatView.Items[chatView.Items.Count - 1].EnsureVisible();

            connectBtn.Text = "Connect";
            ipBox.Enabled = true;
            portBox.Enabled = true;
            serverBtn.Enabled = true;
            clientBtn.Enabled = true;
            usernameBox.Enabled = true;
            inputBox.Enabled = false;
            sendBtn.Enabled = false;
            userView.Items.Clear();

            m_client = null;
        }

        public void ClientToUI_connectionEnd(string message)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> lientTUI_connectionEnd_DELEGATE
            BeginInvoke(f_ClientTUI_connectionEnd_DELEGATE, new object[] { message });
        }

        private void CStoUI_receivedMessage_DELEGATE(string from, string message)
        {
            chatView.Items.Add(new ListViewItem(new string[] { from, message }));
            chatView.Items[chatView.Items.Count - 1].EnsureVisible();
        }

        public void CStoUI_receivedMessage(string from, string message)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> CStoUI_receivedMessage_DELEGATE
            BeginInvoke(f_CStoUI_receivedMessage_DELEGATE, new object[] { from, message });
        }

        private void CStoUI_clientListUpdate_DELEGATE(string[] clients)
        {
            if (clients.Length > userView.Items.Count)
            {
                // new User
                chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", clients.Last() + " joined!" }));
            }
            else
            {
                // find User that left
                foreach (ListViewItem l in userView.Items)
                {
                    if (!clients.Contains(l.Text))
                    {
                        chatView.Items.Add(new ListViewItem(new string[] { "<INFO>", l.Text + " left!" }));
                    }
                }

            }

            userView.Items.Clear();
            foreach (string c in clients)
            {
                userView.Items.Add(new ListViewItem(c));
            }

            chatView.Items[chatView.Items.Count - 1].EnsureVisible();
        }

        public void CStoUI_clientListUpdate(string[] clients)
        {
            // WICHTIG: MUSS HIER DELEGATE MACHEN!!! -> CStoUI_clientListUpdate_DELEGATE
            BeginInvoke(f_CStoUI_clientListUpdate_DELEGATE, new object[] { clients });
        }
    }
}
