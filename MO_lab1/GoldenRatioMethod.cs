using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class GoldenRatioMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data, Boolean suppressOutput = false)
        {
            var funcCallingCount = 0; 
            double Fib = (Math.Sqrt(5) - 1) / 2;
            double start = data.Start, end = data.End;
            double length = end - start;
            double x1 = start + Fib * length, x2;
            double f1 = data.Function.Invoke(x1), f2;
            ++funcCallingCount;
            Console.WriteLine($"\n{Math.Abs(Math.Log((data.End - data.Start) / data.Epsilon) / Math.Log(Fib)),5:N} {"Start",7} {"End",9} {"New x",9} {"New f(x)",9} {"l2/l1",9}");
            int i = 0;
            int precision = GetPrecision(data.Epsilon);
            while (Math.Round(length, precision) >= data.Epsilon)
            {
                x2 = end - (x1 - start);

                f2 = data.Function.Invoke(x2);
                ++funcCallingCount;

                Console.Write($"{i++,2}{")",-1} {start,9:N6} {end,9:N6} {x2,9:N6} {f2,9:N6} ");

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

                Console.WriteLine($"{(length / (end - start)),9:N6}");

                length = end - start;
            }

            Console.WriteLine($"funcCallingCount: {funcCallingCount}");
            return (start, end);
        }
    }
}
