using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operExp
{
    public class Class_Exp
    {
        public static double oper_Exp(double baseValue, double exponent)
        {
            double factor = Math.Pow(10, exponent);
            return baseValue * factor;
        }
    }
}
