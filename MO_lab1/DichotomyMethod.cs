using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class DichotomyMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data)
        {
            double delta = data.Epsilon * 0.49;
            double start = data.Start, end = data.End;
            double length = end - start;
            Console.WriteLine($"{Math.Log2((data.End - data.Start) / data.Epsilon)} Start End x1 x2 f1 f2 l2/l1");
            int i = 0;
            while (Math.Round(end - start, GetPrecision(data.Epsilon)) > data.Epsilon)
            {
                double x1 = (start + end) / 2 - delta;
                double x2 = (start + end) / 2 + delta;

                double f1 = data.Function.Invoke(x1);
                double f2 = data.Function.Invoke(x2);

                Console.Write($"{i++} {start} {end} {x1} {x2} {f1} {f2} ");

                if (f1 >= f2)
                {
                    start = x1;
                }
                if (f1 <= f2)
                {
                    end = x2;
                }

                Console.WriteLine($"{(end - start) / length}");
                
                length = end - start;
            }

            return (start, end);
        }
    }
}
