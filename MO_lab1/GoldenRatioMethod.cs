using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class GoldenRatioMethod
    {
        public static (double, double) Execute(TestCase data)
        {
            double Fib = (Math.Sqrt(5) - 1) / 2;
            double start = data.Start, end = data.End;
            double length = end - start;
            double x1 = start + Fib * length, x2;
            double f1 = data.Function.Invoke(x1), f2;

            while (length >= data.Epsilon)
            {
                x2 = end - (x1 - start);

                f2 = data.Function.Invoke(x2);

                if (x1 > x2)
                {
                    double t = x1;
                    x1 = x2;
                    x2 = t;

                    t = f1;
                    f1 = f2;
                    f2 = t;
                }

                if (f1 >= f2)
                {
                    start = x1;
                    x1 = x2;
                    f1 = f2;
                }
                else if (f1 <= f2)
                {
                    end = x2;
                }

                length = end - start;
            }

            return (start, end);
        }
    }
}
