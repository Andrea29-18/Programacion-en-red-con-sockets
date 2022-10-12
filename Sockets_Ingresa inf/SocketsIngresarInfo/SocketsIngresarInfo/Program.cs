using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketsIngresarInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            //El stream para el flujo de unformación
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket conexion;
            IPEndPoint connect = new IPEndPoint(IPAddress.Parse ("127.0.0.1"), 13000);

            listen.Bind(connect);

            //Maximo 10 personas conectadas
            listen.Listen(10);
           

            conexion = listen.Accept();
            Console.WriteLine("Conexion aceptada");

            byte[] recibir_info = new byte[100];
            string data = "";
            int array_size = 0;

            array_size= conexion.Receive(recibir_info, 0, recibir_info.Length, 0);
            Array.Resize(ref recibir_info, array_size);
            data = Encoding.Default.GetString(recibir_info);

            Console.WriteLine("La infor recibida es: {0}", data);
            Console.ReadKey();
        }
    }
}
