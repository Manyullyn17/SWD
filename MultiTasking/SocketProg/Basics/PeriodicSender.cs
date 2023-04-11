using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

// 1) Aufbau einer TCP/IP (Socket) Verbindung
//
// 2) Serverseitige Kommunikation über die Verbindung auf lowest Level
//       ohne Verwendung von Streams und Stream Reader/Writer
//
// 3) Clientseitige Kommunikation über die Verbindung wesentlich
//    einfacher und bequemer über Stream und Stream Reader/Writer
//

namespace PeriodicSender
{
    class PeriodicSender
    {
        static void Main(string[] args)
        {
            string txt;

            Console.Write("Server or Client (s/c): ");
            txt = Console.ReadLine();

            if (txt == "s")
                Server();
            else
                Client();

            Console.Write("\nHit any Key to continue "); Console.ReadKey();
        }

        static IPAddress GetIPAddress()
        {
            return Dns.Resolve("localhost").AddressList[0];
            // IPAddress ipAdr = Dns.Resolve("HollNotebook").AddressList[0];
            // return Dns.GetHostEntry("192.168.83.1").AddressList[0];
        }

        static void Server()
        {
            TcpListener server;
            Socket socke;
            byte[] rcBuff = new byte[256];

            IPAddress ipAdr = GetIPAddress();
            try
            {
                // server öffnet Port mit der Portnummer 12345
                server = new TcpListener(ipAdr, 12345);
                server.Start();

                Console.WriteLine("Server {0} gestartet", server.LocalEndpoint);
                while (true)
                {
                    // Das Programm bleibt hier solange blockiert bis ein client eine
                    // Verbindung zu uns ( Server ) öffnet
                    socke = server.AcceptSocket();

                    // socke ist die Verbindung zum Client
                    Console.WriteLine("Anfrage von {0}", socke.RemoteEndPoint);

                    NetworkStream nws = new NetworkStream(socke);
                    BinaryWriter wr = new BinaryWriter(nws);

                    for (int i = 1; i <= 100; i++)
                    {
                        Console.WriteLine("Send: {0}", i);
                        wr.Write((short)i);
                        Thread.Sleep(100);
                    }

                    Console.WriteLine("Shutdown Server");
                    socke.Shutdown(SocketShutdown.Both); socke.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Client()
        {
            const string serverName = "localhost";
            // const string serverName = "HollNotebook";
            // const string serverName = "192.168.83.1";
            TcpClient client = null; BinaryReader rd = null;
            try
            {
                // Verbindung zum server aufbauen ( connect )
                client = new TcpClient(serverName, 12345);
                rd = new BinaryReader(client.GetStream());

                int val;
                while (true)
                {
                    val = rd.ReadInt16();
                    Console.WriteLine("Recv: {0}", val);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Server disconnected");
                rd.Close(); client.Close();
            }
        }
    }
}
