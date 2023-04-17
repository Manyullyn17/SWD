using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

// Dazu könnte man ein schönes Prozess-Ablaufdiagramm 
// an die Tafel malen

// Unterschied zu MTCliserv1
//   vereinfachtes String ( ReadLine() ) Handling

namespace MTCliserv2
{
    public class MTCliserv2
    {
        List<ConnTalk> connList = new List<ConnTalk>();

        static void Main(string[] args)
        {
            string txt;

            Console.Write("MTCliserv2 Server or Client (s/c): ");
            txt = Console.ReadLine();
            MTCliserv2 mTCliserv2 = new MTCliserv2();

            if (txt == "s")
                mTCliserv2.Server();
            else
                Client();

            Console.Write("\nHit any Key to continue "); Console.ReadKey();
        }

        static IPAddress GetIPAddress()
        {
            IPAddress ipAdr = Dns.Resolve("localhost").AddressList[0];
            // IPAddress ipAdr = Dns.Resolve("HollNotebook").AddressList[0];
            // return Dns.Resolve("192.168.83.1").AddressList[0];
            // return Dns.GetHostEntry("192.168.83.1").AddressList[0];
            return ipAdr;
        }

        void Server()
        {
            TcpListener server;
            Socket socke;
            IPAddress ipAdr = GetIPAddress();
            try
            {
                server = new TcpListener(ipAdr, 13);
                server.Start();
                Console.WriteLine("Server {0} gestartet", server.LocalEndpoint);
                while (true)
                {
                    socke = server.AcceptSocket(); // Aufruf blockiert!!
                                                   // ein Client hat eine Verbindung zu uns aufgebaut
                                                   // socke repräsentiert diese Verbindung
                                                   // ein neuer Thread wird gestartet welcher nun die Kommunikation mit diesem Client abwickelt
                    connList.Add(new ConnTalk(socke));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error {0}", e);
            }
        }

        static void PrintConnectionInfo(Socket aSock)
        {
            Console.WriteLine("Anfrage von {0}", aSock.RemoteEndPoint);
        }

        static void Client()
        {
            const string serverName = "localhost";

            try
            {
                // im new  new TcpClient() passiert das connect
                TcpClient client = new TcpClient(serverName, 13);
                NetworkStream strm = client.GetStream();
                Socket sc = client.Client;
                StreamReader strmRd = new StreamReader(strm);
                StreamWriter strmWr = new StreamWriter(strm);
                string txt, txt2;

                Console.Write("Name= "); txt = Console.ReadLine();
                strmWr.WriteLine(txt); strmWr.Flush();

                Console.WriteLine("Connected to {0}", sc.RemoteEndPoint);
                while (true)
                {
                    Console.Write("Msg= "); txt = Console.ReadLine();
                    if (txt == "end")
                        break;
                    strmWr.WriteLine(txt); strmWr.Flush();
                    txt2 = strmRd.ReadLine();
                    Console.WriteLine("Answer: {0}", txt2);
                }

                // Client samt NetworkStream schließen
                // sc.Shutdown(SocketShutdown.Both); sc.Close();
                client.Close(); strmRd.Close(); strmWr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void BroadcastMsg(string msg)
        {
            foreach (ConnTalk con in connList)
            {
                con.SendMsg(msg);
            }
        }
    }

    // Pro Verbindung wird 1 ConnTalk-objekt erzeugt
    class ConnTalk
    {
        Thread m_Thr;
        Socket m_Sc;
        string m_name;
        StreamWriter strmWr;

        public ConnTalk(Socket aSc)
        {
            m_Sc = aSc;
            m_Thr = new Thread(this.TalkWithClient);
            m_Thr.Start();
        }

        void TalkWithClient()
        {
            NetworkStream strm = new NetworkStream(m_Sc);
            StreamReader strmRd = new StreamReader(strm); // damit Console.Write() auf dieser Verbindung funktioniert
            strmWr = new StreamWriter(strm);
            string txt;
            MTCliserv2 mTCliserv2 = new MTCliserv2();

            Console.WriteLine("Talking with {0}", m_Sc.RemoteEndPoint);
            try
            {
                m_name = strmRd.ReadLine();
                while (true)
                {
                    txt = m_name + " ";
                    txt += strmRd.ReadLine();
                    Console.WriteLine("Msg: {0}", txt);
                    txt += "\r\n";
                    //strmWr.Write(txt); strmWr.Flush();  // stattdessen broadcast
                    //mTCliserv2.BroadcastMsg(txt);
                    //foreach (ConnTalk con in connList)
                    //{
                    //    con.SendMsg(txt);
                    //}
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in TalkWithClient");
            }

            Console.WriteLine("{0} Disconnected", m_Sc.RemoteEndPoint);
            // m_Sc.Shutdown(SocketShutdown.Both); 
            m_Sc.Close(); strm.Close(); strmRd.Close(); strmWr.Close();
            return;
        }

        public void SendMsg(string msg)
        {
            try
            {
                strmWr.Write(msg);
                strmWr.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in TalkWithClient");
            }
        }
    }
}
