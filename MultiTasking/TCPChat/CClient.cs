using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPChat
{
    class CClient
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
        public CClient(IPAddress ip, UInt16 port, string username)
        {
            m_ip = ip;
            m_port = port;
            m_username = username;
            m_buff = new byte[4096];

            m_sock = new TcpClient();

            taskQueue = new CTaskQueue();
            m_TTasks = new Thread(TaskT);
            m_TTasks.Start();
        }

        private void TaskT()
        {
            // Connect
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
                System.Console.WriteLine("Could not connect to Server. Aborting...");
                System.Console.WriteLine(e.ToString());
                // Tell UI that connection failed
                TCPChat.Form1.frm.ClientToUI_connectionEnd("Could not connect to Server");
                Terminate();
            }

            // Tell UI that connection succeeded
            TCPChat.Form1.frm.ClientToUI_connectSuccess();

            m_asyncRes = m_netStr.BeginRead(m_buff, 0, m_buff.Length, OnTcpReadCB, m_netStr);

            while (true)
            {
                CTask task = taskQueue.Get();
                switch (task.task)
                {
                    case CWhatToDo.cTerminate:
                        {
                            wrtr.Write(CNetPacket.serialize(CNetTopic.Disconnect));
                            wrtr.Flush();
                            TCPChat.Form1.frm.ClientToUI_connectionEnd("Disconnected!");
                            Terminate();
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

        private void OnTcpReadCB(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = m_netStr.EndRead(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server not available any more. Aborting...");
                Console.WriteLine(e.ToString());
                // Tell UI that connection lost
                TCPChat.Form1.frm.ClientToUI_connectionEnd("Server not available any more!");
                Terminate();
                return;
            }

            System.Console.WriteLine("Received Data: len {0}", bytesRead);
            if (bytesRead == 0)
            {
                Console.WriteLine("Client-Connection not available any more. Aborting...");
                TCPChat.Form1.frm.ClientToUI_connectionEnd("Server not available any more!");
                Terminate();
                return;
            }

            CNetPacket received = new CNetPacket();
            received.deserialize(m_buff);

            switch (received.topic)
            {
                case CNetTopic.Disconnect:
                    {
                        TCPChat.Form1.frm.ClientToUI_connectionEnd("Server closed!");
                        Terminate();
                        return;
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

            m_asyncRes = m_netStr.BeginRead(m_buff, 0, m_buff.Length, OnTcpReadCB, m_netStr);
        }

        private void Terminate()
        {
            m_netStr.Close();
            m_netStr.Dispose();

            m_TTasks.Abort();
            m_TTasks.Join();

            m_sock.Close();
        }

        ~CClient()
        {
            Terminate();
        }
    }
}
