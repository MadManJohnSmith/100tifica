using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operRaizX
{
    public class Class_RaizX
    {
        public static double oper_RaizX(double numero, double raiz)
        {
            if (raiz == 0)
            {
                throw new ArgumentException("El valor de la raíz no puede ser cero");
            }
            if (numero < 0 && raiz % 1 != 0)
            {
                throw new ArgumentException("El número no puede ser negativo para raíces no enteras");
            }
            return Math.Pow(numero, 1.0 / raiz);
        }
    }
}
