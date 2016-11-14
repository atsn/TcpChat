using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Universal_TCP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter name");
            string name = Console.ReadLine();
            Console.WriteLine("press 1 for client and 2 for server");
            ConsoleKey pressedkey = Console.ReadKey(true).Key;


            if (pressedkey.Equals(ConsoleKey.D1) || pressedkey.Equals(ConsoleKey.NumPad1))
            {
                try
                {
                    Console.WriteLine("please enter ip");
                    string ip = Console.ReadLine();
                    string testtesttest = "messege";

                    TcpClient client = new TcpClient(ip, 6789);
                    var clientStream = client.GetStream();
                    ConnectionHandler handler = new ConnectionHandler(clientStream);
                    Thread Reshivethread = new Thread(handler.Reshive);
                    Thread Sendthread = new Thread(handler.Sendmessege);
                    Reshivethread.Start();
                    Sendthread.Start();
                    Console.WriteLine("Du kan nu skrive");

                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }

            else if (pressedkey.Equals(ConsoleKey.D2) || pressedkey.Equals(ConsoleKey.NumPad2))
            {
                IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
                TcpListener server = new TcpListener(ip, 6789);
                server.Start();
                TcpClient serverclient = server.AcceptTcpClient();
                Console.WriteLine("client forbundet");
                ConnectionHandler handler = new ConnectionHandler(serverclient.GetStream());
                Thread Reshivethread = new Thread(handler.Reshive);
                Thread Sendthread = new Thread(handler.Sendmessege);
                Reshivethread.Start();
                Sendthread.Start();
                Console.WriteLine("Du kan nu skrive");
            }
            else
            {
                Console.WriteLine("button not regconiced");
            }
        }



    }
}
