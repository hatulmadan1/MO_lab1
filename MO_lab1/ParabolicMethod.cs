using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class ParabolicMethod
    {
        public static (double, double) Execute(TestCase data)
        {
            double x1 = data.Start, x3 = data.End, x2 = (x1 + x3) / 2;
            double f1 = data.Function.Invoke(x1), f2 = data.Function.Invoke(x2), f3 = data.Function.Invoke(x3);

            while ((x3 - x1) >= data.Epsilon)
            {
                double u = x2 - (Math.Pow((x2 - x1), 2) * (f2 - f3) - Math.Pow((x2 - x3), 2) * (f2 - f1)) /
                    (2 * ((x2 - x1) * (f2 - f3) - (x2 - x3) * (f2 - f1)));

                double fu = data.Function.Invoke(u);

                if (u > x2)
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
                        x2 = u;
                        f2 = fu;
                    }
                }
                else
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
                        x2 = u;
                        f2 = fu;
                    }
                }
            }

            return (x1, x3);
        }
    }
}
