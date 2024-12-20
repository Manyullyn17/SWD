﻿using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPChat
{
    class CServer
    {
        #region locals
        private TcpListener m_server = null;
        private IPAddress m_ip = null;
        private UInt16 m_port = 12345;
        private Thread m_TTasks = null;     // arbeitet Tasks ab
        private List<CSClient> m_clients = null;

        public CTaskQueue taskQueue = null;
        #endregion locals
        public CServer(IPAddress ip, UInt16 port)
        {
            m_ip = ip;
            m_port = port;
            m_clients = new List<CSClient>();

            taskQueue = new CTaskQueue();

            m_server = new TcpListener(m_ip, m_port);
            try
            {
                m_server.Start();
                m_server.BeginAcceptTcpClient(new AsyncCallback(OnAcceptTcpClientCB), m_server);
            }
            catch (Exception e)
            {
                Form1.frm.ServerToUI_serverEnd("Could not start Server!");
                return;
            }

            m_TTasks = new Thread(TaskT);
            m_TTasks.Start();
        }

        private void TaskT()
        {
            Form1.frm.ServerToUI_startSuccess();

            while (true)
            {
                CTask task = taskQueue.Get();
                switch (task.task)
                {
                    case CWhatToDo.sTerminate:
                        {
                            foreach (CSClient c in m_clients)
                            {
                                c.taskQueue.Put(new CTask(CWhatToDo.scTerminate));
                            }
                            Form1.frm.ServerToUI_serverEnd("Server Closed!");
                            Terminate();
                            break;
                        }
                    case CWhatToDo.sStoreClient:
                        {
                            Console.WriteLine("Server: sStoreClient!");
                            m_clients.Add((CSClient)task.sender);

                            List<string> clientList = new List<string>();
                            foreach (CSClient c in m_clients)
                            {
                                clientList.Add(c.username);
                            }
                            CTask tsk = new CTask(CWhatToDo.scSendClientList, clientList.ToArray());
                            foreach (CSClient c in m_clients)
                            {
                                c.taskQueue.Put(tsk);
                            }
                            Form1.frm.CStoUI_clientListUpdate(clientList.ToArray());
                            break;
                        }
                    case CWhatToDo.sRemoveClient:
                        {
                            Console.WriteLine("Server: sRemoveClient!");
                            m_clients.Remove((CSClient)task.sender);

                            List<string> clientList = new List<string>();
                            foreach (CSClient c in m_clients)
                            {
                                clientList.Add(c.username);
                            }
                            CTask tsk = new CTask(CWhatToDo.scSendClientList, clientList.ToArray());
                            foreach (CSClient c in m_clients)
                            {
                                c.taskQueue.Put(tsk);
                            }
                            Form1.frm.CStoUI_clientListUpdate(clientList.ToArray());
                            break;
                        }
                    case CWhatToDo.sForwardMessage:
                        {
                            CTask tsk = new CTask(CWhatToDo.scSendMessage, task.data, task.sender);
                            foreach (CSClient c in m_clients)
                            {
                                if (c == (CSClient)task.sender) continue;
                                c.taskQueue.Put(tsk);
                            }
                            Form1.frm.CStoUI_receivedMessage(((CSClient)task.sender).username, (string)task.data);
                            break;
                        }
                    default: break;
                }
            }
        }

        private void OnAcceptTcpClientCB(IAsyncResult ar)
        {
            TcpClient newClient = m_server.EndAcceptTcpClient(ar);
            System.Console.WriteLine("Client connected!");

            new CSClient(this, newClient);

            m_server.BeginAcceptTcpClient(new AsyncCallback(OnAcceptTcpClientCB), m_server);
        }

        private void Terminate()
        {
            m_TTasks.Abort();
            m_TTasks.Join();
            m_server.Server.Shutdown(SocketShutdown.Both);
            m_server.Stop();
        }

        ~CServer()
        {
            Terminate();
        }
    }
}
