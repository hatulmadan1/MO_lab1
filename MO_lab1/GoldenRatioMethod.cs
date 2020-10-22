using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class GoldenRatioMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data)
        {
            double Fib = (Math.Sqrt(5) - 1) / 2;
            double start = data.Start, end = data.End;
            double length = end - start;
            double x1 = start + Fib * length, x2;
            double f1 = data.Function.Invoke(x1), f2;
            Console.WriteLine($"\n{Math.Abs(Math.Log((data.End - data.Start) / data.Epsilon) / Math.Log(Fib)):F} Start   End     New x    New f(x)   l2/l1");
            int i = 0;
            int precision = GetPrecision(data.Epsilon);
            while (Math.Round(length, precision) >= data.Epsilon)
            {
                x2 = end - (x1 - start);

                f2 = data.Function.Invoke(x2);

                Console.Write($"{i++}) {start:F6} {end:F6} {x2:F6} {f2:F6} ");

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

                Console.WriteLine($"{(length / (end - start)):F6}");

                length = end - start;
            }

            return (start, end);
        }
    }
}
