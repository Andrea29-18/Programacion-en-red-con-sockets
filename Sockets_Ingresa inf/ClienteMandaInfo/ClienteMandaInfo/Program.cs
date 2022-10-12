using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClienteMandaInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);

            listen.Connect(connect);

            byte[] enviar_info = new byte[100];
            string data;
            Console.WriteLine("Ingrese la info a enviar");

            data = Console.ReadLine();

            enviar_info = Encoding.Default.GetBytes(data);

            listen.Send(enviar_info);

            Console.ReadKey();
        }
    }
}
