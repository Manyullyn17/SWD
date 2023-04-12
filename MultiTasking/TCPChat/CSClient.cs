using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace SWNW_TCPChat
{
    class CSClient
    {
        #region locals
        private CServer m_server = null;
        private TcpClient m_sock = null;
        private Thread m_TTasks = null;
        private NetworkStream m_netStr = null;
        private byte[] m_buff = null;

        public string username = null;
        public CTaskQueue taskQueue = null;
        #endregion locals
        public CSClient(CServer server, TcpClient socket)
        {
            m_server = server;
            m_sock = socket;
            m_netStr = m_sock.GetStream();
            m_buff = new byte[4096];

            taskQueue = new CTaskQueue();
            m_TTasks = new Thread(taskT);
            m_TTasks.Start();
        }

        private void taskT()
        {   
            StreamReader rdr = new StreamReader(m_netStr);
            StreamWriter wrtr = new StreamWriter(m_netStr);
            #region onboarding
            // Nutzernamen empfangen
            m_sock.ReceiveTimeout = 1000;   // Client hat eine Sekunde Zeit, seinen Namen bekannzugeben
            StringBuilder name = new StringBuilder();

            try
            {
                int c;
                while ((c = rdr.Read()) >= 0)
                {
                    if ((char)c == '\0') break;
                    if (char.IsLetterOrDigit((char)c)) name.Append((char)c);
                }
            }
            catch (Exception e)
            {
                name.Clear();
                Console.WriteLine(e.ToString());
            }

            if (name.Length == 0 || name.Length > 50)
            {
                // Ungültiger Name oder Timeout, abbrechen und zerstören (bzw server NICHT instruieren, client zu speichern)
                Console.WriteLine("Failed to retrieve username from client/too long; Onboarding failed, aborting...");
                terminate();
            }

            username = name.ToString();
            Console.WriteLine("New User connected Successfully! Username: {0}", username);
            m_server.taskQueue.put(new CTask(CWhatToDo.sStoreClient, null, this));
            #endregion onboarding

            m_netStr.BeginRead(m_buff, 0, m_buff.Length, onTcpReadCB, m_netStr);
            
            while (true)
            {
                CTask task = taskQueue.get();
                switch (task.task)
                {
                    case CWhatToDo.scTerminate:
                        {
                            wrtr.Write(CNetPacket.serialize(CNetTopic.Disconnect));
                            wrtr.Flush();
                            m_server.taskQueue.put(new CTask(CWhatToDo.sRemoveClient, null, this));
                            terminate();
                            break;
                        }
                    case CWhatToDo.scSendMessage:
                        {
                            Console.WriteLine("Client: scSendMessage!");
                            CSClient sender = (CSClient)task.sender;
                            string message = (string)task.data;
                            wrtr.Write(CNetPacket.serialize(CNetTopic.Message, new string[] { sender.username, message }));
                            wrtr.Flush();
                            break;
                        }
                    case CWhatToDo.scSendClientList:
                        {
                            wrtr.Write(CNetPacket.serialize(CNetTopic.UserListUpdate, task.data));
                            wrtr.Flush();
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
            catch(Exception e)
            {
                Console.WriteLine("Client-Connection not available any more; Aborting...");
                Console.WriteLine(e.ToString());
                m_server.taskQueue.put(new CTask(CWhatToDo.sRemoveClient, null, this));
                terminate();
                return;
            }

            System.Console.WriteLine("Received Data: len {0}", bytesRead);
            if (bytesRead == 0)
            {
                Console.WriteLine("Client-Connection not available any more; Aborting...");
                m_server.taskQueue.put(new CTask(CWhatToDo.sRemoveClient, null, this));
                terminate();
                return;
            }

            CNetPacket received = new CNetPacket();
            received.deserialize(m_buff);

            switch (received.topic)
            {
                case CNetTopic.Message:
                    {
                        m_server.taskQueue.put(new CTask(CWhatToDo.sForwardMessage, ((string[])received.data)[1], this));
                        break;
                    }
                case CNetTopic.Disconnect:
                    {
                        m_server.taskQueue.put(new CTask(CWhatToDo.sRemoveClient, null, this));
                        terminate();
                        return;
                        break;
                    }
                default: break;
            }

            Array.Clear(m_buff, 0, m_buff.Length);

            m_netStr.BeginRead(m_buff, 0, m_buff.Length, onTcpReadCB, m_netStr);
        }

        public void terminate()
        {
            m_netStr.Close();
            m_netStr.Dispose();

            m_TTasks.Abort();
            m_TTasks.Join();

            m_sock.Close();
        }

        ~CSClient()
        {
            Console.WriteLine("CSClient: Deconstructor");
            terminate();
        }
    }
}
