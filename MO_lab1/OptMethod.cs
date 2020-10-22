using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public abstract class OptMethod
    {
        public abstract (double, double) Execute(TestCase data);

        public static int GetPrecision(double eps)
        {
            if (eps >= 1)
            { //we only need the fraction digits
                eps = eps - (long)eps;
            }
            if (eps == 0)
            { //nothing to count
                return 0;
            }
            eps *= 10; //shifts 1 digit to left
            int count = 1;
            while (eps - (long)eps != 0)
            { //keeps shifting until there are no more fractions
                eps *= 10;
                count++;
            }
            return count;
        }
    }
}
