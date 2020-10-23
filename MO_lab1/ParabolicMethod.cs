using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MO_lab1
{
    public class ParabolicMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data)
        {
            double x1 = data.Start, x3 = data.End, x2 = (x1 + x3) / 2;
            double f1 = data.Function.Invoke(x1), f2 = data.Function.Invoke(x2), f3 = data.Function.Invoke(x3);
            int precision = GetPrecision(data.Epsilon);
            Random random = new Random();

            Console.WriteLine($"\n{"x1",13} {"x3",9} {"u",9} {"f(u)",9} {"x2",9} {"f(x2)",9} {"l2/l1",8}");
            double length = x3 - x1;
            int i = 1;
            while (Math.Round((x3 - x1), precision) >= data.Epsilon)
            {
                double u = x2 - (Math.Pow((x2 - x1), 2) * (f2 - f3) - Math.Pow((x2 - x3), 2) * (f2 - f1)) /
                    (2 * ((x2 - x1) * (f2 - f3) - (x2 - x3) * (f2 - f1)));
                u = Double.IsNaN(u) ? 0.0 : u;

                double fu = data.Function.Invoke(u);

                Console.Write($"{i++,2}{")",-1} {x1,9:F6} {x3,9:F6} {u,9:F6} {fu,9:F6} {x2,9:F6} {f2,9:F6}");

                if (u < x2)
                {
                    if (fu >= f2)
                    {
                        x1 = u;
                        f1 = fu;
                    }
                    else
                    {
                        x3 = x2;
                        f3 = f2;
                    }
                }
                else
                {
                    if (fu >= f2)
                    {
                        x3 = u;
                        f3 = fu;
                    }
                    else
                    {
                        x1 = x2;
                        f1 = f2;
                    }
                }

                x2 = random.NextDouble() * (x3 - x1) + x1;
                f2 = data.Function.Invoke(x2);

                Console.WriteLine($"{(length / (x3 - x1)),9:F6}");
                length = x3 - x1;
            }

            return (x1, x3);
        }
    }
}
