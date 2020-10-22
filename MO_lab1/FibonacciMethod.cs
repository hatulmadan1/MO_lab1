﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class FibonacciMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data)
        {
            List<double> fibNumbers = new List<double>() {1, 1};
            for (int i = 2; !checkCondition(i, data); i++)
            {
                fibNumbers.Add(fibNumbers[^1] + fibNumbers[^2]);
            }
            int n = fibNumbers.Count - 1;
            double start = data.Start, end = data.End;
            double length = end - start;
            double x1 = start + (fibNumbers[n - 2]/fibNumbers[n])* length, 
                x2 = start + (fibNumbers[n - 1] / fibNumbers[n]) * length;
            double f1 = data.Function.Invoke(x1), f2 = data.Function.Invoke(x2);
            int k = 1;

            Console.WriteLine($"\n{n:F} Start   End     New x    New f(x)   l2/l1");
            int i_ = 0;
            int precision = GetPrecision(data.Epsilon);

            while (Math.Round(length, precision) >= data.Epsilon)
            {
                if (f1 >= f2)
                {
                    start = x1;
                    x1 = x2;
                    f1 = f2;

                    Console.Write($"{i_++}) {start:F6} {end:F6} {x2:F6} {f2:F6} ");
                    Console.WriteLine($"{(length / (end - start)):F6}");

                    length = end - start;
                    x2 = start + (fibNumbers[n - k - 1] / fibNumbers[n - k]) * length;
                    if (k != fibNumbers.Count - 2)
                    {
                        f2 = data.Function.Invoke(x2);
                    }
                }
                else if (f1 <= f2)
                {
                    end = x2;
                    x2 = x1;
                    f2 = f1;

                    Console.Write($"{i_++}) {start:F6} {end:F6} {x1:F6} {f1:F6} ");
                    Console.WriteLine($"{(length / (end - start)):F6}");

                    length = end - start;
                    x1 = start + (fibNumbers[n - k - 2] / fibNumbers[n - k]) * length;
                    if (k != fibNumbers.Count - 2)
                    {
                        f1 = data.Function.Invoke(x1);
                    }
                }

                if (k == fibNumbers.Count - 2)
                {
                    x2 = x1 + data.Epsilon;
                    f2 = data.Function.Invoke(x2);
                    if (f1 == f2)
                    {
                        start = x1;
                    }

                    else if (f1 < f2)
                    {
                        end = x2;
                    }
                }
            }

            return (start, end);
        }

        private static bool checkCondition(double n, TestCase data)
        {
            return (Math.Pow(((1 + Math.Sqrt(5)) / 2), n) - Math.Pow(((1 - Math.Sqrt(5)) / 2), n)) / Math.Sqrt(5) >
                   (data.End - data.Start) / data.Epsilon;
        }
    }
}
