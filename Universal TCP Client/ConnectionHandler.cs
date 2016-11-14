using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Universal_TCP_Client
{
    class ConnectionHandler
    {
        private NetworkStream clientStream;
        public string messege { get; set; } = "kør";

        public ConnectionHandler(NetworkStream ClientStream)
        {
            clientStream = ClientStream;
        }



        public void Reshive()
        {
            while (!messege.ToLower().Equals("stop"))
            {
                try
                {
                    StreamReader clientStreamReader = new StreamReader(clientStream);

                    Console.WriteLine(clientStreamReader.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }

            }



        }

        public void Sendmessege()
        {
            while (!messege.ToLower().Equals("stop"))
            {
                {
                    try
                    {
                        StreamWriter clientStreamWriter = new StreamWriter(clientStream);
                        clientStreamWriter.AutoFlush = true;

                       messege = Console.ReadLine();
                        clientStreamWriter.WriteLine(messege);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                }

            }


        }

    }
}
