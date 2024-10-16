using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operTan
{
    public class Class_Tan
    {
        public static double oper_Tan(double grados)
        {
            double radianes = grados * (Math.PI / 180);
            return Math.Tan(radianes);
        }
    }
}
