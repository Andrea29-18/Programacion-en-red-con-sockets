using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{

    class Program
    {
        static void Main(string[] args)
        {
            ExecuteClient();
        }

        static void ExecuteClient()
        {
            try
            {
                Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
                listen.Connect(connect);

                try
                {

                    byte[] messageSent = Encoding.ASCII.GetBytes("Test Client<EOF>");
                    int byteSent = listen.Send(messageSent);
                     
                    byte[] messageReceived = new byte[1024];

                    int byteRecv = listen.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                        Encoding.ASCII.GetString(messageReceived,
                                                    0, byteRecv));

                    listen.Shutdown(SocketShutdown.Both);
                    listen.Close();
                }

                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
