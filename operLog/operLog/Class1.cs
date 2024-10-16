using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operLog
{
    public class Class_Log
    {
        public static double oper_Log(double numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("El número debe ser mayor que 0");
            }
            return Math.Log10(numero);
        }
    }
}
