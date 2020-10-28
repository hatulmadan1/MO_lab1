using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class DichotomyMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data, Boolean suppressOutput = false)
        {
            var funcCallingCount = 0; 
            double delta = data.Epsilon * 0.29;
            double start = data.Start, end = data.End;
            double length = end - start;
            Console.WriteLine($"\n{(Math.Log2((data.End - data.Start) / data.Epsilon)),-1:N} {"Start",7} {"End",9} {"x1",9} {"x2",9} {"f1",9} {"f2",9} {"l2/l1",9}");
            int i = 0;
            int precision = GetPrecision(data.Epsilon);
            while (Math.Round(end - start, precision) > data.Epsilon)
            {
                double x1 = (start + end) / 2 - delta;
                double x2 = (start + end) / 2 + delta;

                double f1 = data.Function.Invoke(x1);
                double f2 = data.Function.Invoke(x2);
                funcCallingCount += 2;

                Console.Write($"{i++}{")",-1} {start,9:N6} {end,9:N6} {x1,9:N6} {x2,9:N6} {f1,9:N6} {f2,9:N6} ");
                

                if (f1 >= f2)
                {
                    start = x1;
                }
                if (f1 <= f2)
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
