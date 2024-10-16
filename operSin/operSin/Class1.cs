using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operSin
{
    public class Class_Sin
    {
        public static double oper_Sin(double grados)
        {
            double radianes = grados * (Math.PI / 180);
            return Math.Sin(radianes);
        }
    }
}
