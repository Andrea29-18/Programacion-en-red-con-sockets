using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

// Esta capa sirve para que el cliente y servidor se pueden comunicarse, al igual que el
// cliente puede llamar los metodos que el servidor le ofrece, sirve como intermediario
// Los contratos de código proporcionan una manera de especificar condiciones previas


namespace Contracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        double Suma(double numero1, double numero2);

        [OperationContract]
        double Resta(double numero1, double numero2);

        [OperationContract]
        double Multiplicacion(double numero1, double numero2);

        [OperationContract]
        double Division(double numero1, double numero2);
    }
}
