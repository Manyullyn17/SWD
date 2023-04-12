using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace SWNW_TCPChat
{
    class CCClient
    {
        #region locals
        private TcpClient m_sock = null;
        private IPAddress m_ip = null;
        private UInt16 m_port = 12345;
        private Thread m_TTasks = null;
        private string m_username;
        private NetworkStream m_netStr = null;
        private byte[] m_buff = null;
        private IAsyncResult m_asyncRes = null;

        public CTaskQueue taskQueue = null;
        #endregion locals
        public CCClient(IPAddress ip, UInt16 port, string username)
        {
            m_ip = ip;
            m_port = port;
            m_username = username;
            m_buff = new byte[4096];

            m_sock = new TcpClient();

            taskQueue = new CTaskQueue();
            m_TTasks = new Thread(taskT);
            m_TTasks.Start();
        }

        private void taskT()
        {
            // Verbindungsaufbau
            StreamReader rdr = null;
            StreamWriter wrtr = null;

            try
            {
                m_sock.Connect(m_ip, m_port);
                m_netStr = m_sock.GetStream();
                rdr = new StreamReader(m_netStr);
                wrtr = new StreamWriter(m_netStr);
                wrtr.Write(m_username);
                wrtr.Write('\0');
                wrtr.Flush();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Could not connect to Server; Aborting...");
                System.Console.WriteLine(e.ToString());
                // Irgendwas im UI aufrufen, was dies signalisiert, und abbrechen
                SWNW_TCPChat.Form1.frm.CtoUI_connectionEnd("Could not connect to Server");
                terminate();
            }

            // Irgendwas im UI aufrufen, das signalisiert, dass die Verbindung steht
            SWNW_TCPChat.Form1.frm.CtoUI_connectSuccess();

            m_asyncRes = m_netStr.BeginRead(m_buff, 0, m_buff.Length, onTcpReadCB, m_netStr);

            while (true)
            {
                CTask task = taskQueue.get();
                switch (task.task)
                {
                    case CWhatToDo.cTerminate:
                        {
                            wrtr.Write(CNetPacket.serialize(CNetTopic.Disconnect));
                            wrtr.Flush();
                            SWNW_TCPChat.Form1.frm.CtoUI_connectionEnd("Disconnected!");
                            terminate();
                            break;
                        }
                    case CWhatToDo.cSendMessage:
                        {
                            string[] msg = new string[] { m_username, (string)task.data };
                            wrtr.Write(CNetPacket.serialize(CNetTopic.Message, msg));
                            wrtr.Flush();
                            Form1.frm.CStoUI_receivedMessage(msg[0], msg[1]);
                            break;
                        }
                    default: break;
                }
            }
        }

        private void onTcpReadCB(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = m_netStr.EndRead(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server not available any more; Aborting...");
                Console.WriteLine(e.ToString());
                // Irgendwas im UI aufrufen, was dies signalisiert, und abbrechen
                SWNW_TCPChat.Form1.frm.CtoUI_connectionEnd("Server not available any more!");
                terminate();
                return;
            }

            System.Console.WriteLine("Received Data: len {0}", bytesRead);
            if (bytesRead == 0)
            {
                Console.WriteLine("Client-Connection not available any more; Aborting...");
                SWNW_TCPChat.Form1.frm.CtoUI_connectionEnd("Server not available any more!");
                terminate();
                return;
            }

            CNetPacket received = new CNetPacket();
            received.deserialize(m_buff);

            switch (received.topic)
            {
                case CNetTopic.Disconnect:
                    {
                        SWNW_TCPChat.Form1.frm.CtoUI_connectionEnd("Server closed!");
                        terminate();
                        return;
                        break;
                    }

                case CNetTopic.Message:
                    {
                        string[] msg = (string[])received.data;
                        System.Console.WriteLine("Received Message: {0} - {1}", msg[0], msg[1]);
                        Form1.frm.CStoUI_receivedMessage(msg[0], msg[1]);
                        break;
                    }
                case CNetTopic.UserListUpdate:
                    {
                        Form1.frm.CStoUI_clientListUpdate((string[])received.data);
                        break;
                    }
                default: break;
            }

            Array.Clear(m_buff, 0, m_buff.Length);

            m_asyncRes = m_netStr.BeginRead(m_buff, 0, m_buff.Length, onTcpReadCB, m_netStr);
        }

        private void terminate()
        {
            m_netStr.Close();
            m_netStr.Dispose();

            m_TTasks.Abort();
            m_TTasks.Join();

            m_sock.Close();
        }

        ~CCClient()
        {
            terminate();
        }
    }
}
