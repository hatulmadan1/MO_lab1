using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class DichotomyMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data)
        {
            double delta = data.Epsilon * 0.29;
            double start = data.Start, end = data.End;
            double length = end - start;
            Console.WriteLine($"\n{(Math.Log2((data.End - data.Start) / data.Epsilon)):F} Start    End       x1       x2       f1       f2       l2/l1");
            int i = 0;
            int precision = GetPrecision(data.Epsilon);
            while (Math.Round(end - start, precision) > data.Epsilon)
            {
                double x1 = (start + end) / 2 - delta;
                double x2 = (start + end) / 2 + delta;

                double f1 = data.Function.Invoke(x1);
                double f2 = data.Function.Invoke(x2);

                Console.Write($"{i++}) {start:F6} {end:F6} {x1:F6} {x2:F6} {f1:F6} {f2:F6} ");

                if (f1 >= f2)
                {
                    start = x1;
                }
                if (f1 <= f2)
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
