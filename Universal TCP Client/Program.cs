﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            try
            {
                string testtesttest = "messege";


                TcpClient client = new TcpClient("(chage ip)", 6789);
                var clientStream = client.GetStream();

                ConnectionHandler handler = new ConnectionHandler(clientStream);
                Thread Reshivethread = new Thread(handler.Reshive);
                Thread Sendthread = new Thread(handler.Sendmessege);
                Reshivethread.Start();
                Sendthread.Start();

               
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }



    }
}
