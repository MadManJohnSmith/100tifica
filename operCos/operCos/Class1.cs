using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operCos
{
    public class Class_Cos
    {
        public static double oper_Cos(double grados)
        {
            double radianes = grados * (Math.PI / 180);
            return Math.Cos(radianes);
        }
    }
}
