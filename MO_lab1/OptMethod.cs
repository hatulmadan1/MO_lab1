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
            return (eps.ToString().Split(',')[1].Length);
        }
    }
}
