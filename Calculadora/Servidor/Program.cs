using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;

namespace Servidor
{
    class Program
    {
        // Main Method
        static void Main(string[] args)
        {
            ExecuteServer();
        }

        public static void ExecuteServer()
        {
  
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            Socket listener = new Socket(ipAddr.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

            try
            {

                listener.Bind(localEndPoint);

                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");
                    Socket clientSocket = listener.Accept();

                    byte[] bytes = new Byte[1024];
                    string data = null;
                    string respuesta = "";

                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes, 0, numByte);
                        if (data.IndexOf(".") > -1)
                        {
                            break;
                        }
                    }

                    List<string> list = new List<string>();
                    list = data.Split(' ').ToList();
                    list.Remove(".");
                    ProductService calculadora = new ProductService();
                    if (list.Contains("+"))
                    {
                        respuesta = $"The result is {calculadora.Suma(Convert.ToDouble(list.First()),Convert.ToDouble(list.Last()))}";
                    }
                    else if (list.Contains("-"))
                    {
                        respuesta = $"The result is: {calculadora.Resta(Convert.ToDouble(list.First()), Convert.ToDouble(list.Last()))}";
                    }
                    else if (list.Contains("*"))
                    {
                        respuesta = $"The result is: {calculadora.Multiplicacion(Convert.ToDouble(list.First()), Convert.ToDouble(list.Last()))}";
                    }
                    else if (list.Contains("/"))
                    {
                        if(calculadora.Division(Convert.ToDouble(list.First()), Convert.ToDouble(list.Last()))== -255)
                        {
                            respuesta = "Math ERROR";
                        }
                        else
                        {
                            respuesta = $"The result is: {calculadora.Division(Convert.ToDouble(list.First()), Convert.ToDouble(list.Last()))}";
                        }
                    }
                    else
                    {
                        respuesta = "I did not perform any operation";
                    }


                    Console.WriteLine("Text received -> {0} ", data);
                    Console.WriteLine("Text send -> {0} ", respuesta);
                    byte[] message = Encoding.ASCII.GetBytes(respuesta);

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
