using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace operRaiz2
{
    public class Class_Raiz2
    {
        public static double operRaiz2(double numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("El número no puede ser negativo");
            }
            return Math.Sqrt(numero);
        }
    }
}
