using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ProductService : IProductService
    {
        public double Suma(double numero1, double numero2)
        {
            var resultado = 0.0;
            resultado = numero1 + numero2;
            return resultado;
        }

        public double Resta(double numero1, double numero2)
        {
            var resultado = 0.0;
            resultado = numero1 - numero2;
            return resultado;
        }
        public double Multiplicacion(double numero1, double numero2)
        {
            var resultado = 0.0;
            resultado = numero1 * numero2;
            return resultado;
        }
        public double Division(double numero1, double numero2)
        {
            var resultado = 0.0;
            if(!numero2.Equals(0.0))
            {
                resultado = numero1 / numero2;
            } 
            else
            {
                resultado = -255;
            }
            return resultado;
        }
    }
}
 