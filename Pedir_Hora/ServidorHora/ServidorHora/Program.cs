using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{

    class Program
    {

        static void Main(string[] args)
        {
            ExecuteServer();
        }

        public static void ExecuteServer()
        {
       

            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);

            try
            {
                listen.Bind(connect);
                listen.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    Socket clientSocket = listen.Accept();
                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes,
                                                0, numByte);

                        if (data.IndexOf("<EOF>") > -1)
                            break;
                    }
                    string hoyEs = DateTime.Now.ToString();

                    Console.WriteLine("Text received -> {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes(hoyEs);

                    clientSocket.Send(message);

                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}