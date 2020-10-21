using System;
using System.Collections.Generic;

namespace MO_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double eps = 0.0001;

            List<TestCase> test = new List<TestCase>(){

            new TestCase()
            {
                Start = -0.5,
                End = 0.5,
                Epsilon = eps,
                Function = x => (-5 * Math.Pow(x, 5) + 4 * Math.Pow(x, 4) - 12 * Math.Pow(x, 3) + 11 * Math.Pow(x, 2) -2 * x + 1)
            },

            new TestCase()
            {
                Start = 6.0,
                End = 9.9,
                Epsilon = eps,
                Function = x => (Math.Pow(Math.Log10(x - 2), 2) + Math.Pow(Math.Log10(10 - x), 2) - Math.Pow(x, 0.2))
            },

            new TestCase()
            {
                Start = 0,
                End = 2 * Math.PI,
                Epsilon = eps,
                Function = x => (-3 * x * Math.Sin(0.75 * x) + Math.Exp(-2 * x))
            },

            new TestCase()
            {
                Start = 0,
                End = 1.0,
                Epsilon = eps,
                Function = x => (Math.Exp(3 * x) + 5 * Math.Exp(-2 * x))
            },

            new TestCase()
            {
                Start = 0.5,
                End = 2.5,
                Epsilon = eps,
                Function = x => (0.2 * x * Math.Log10(x) + Math.Pow(x - 2.3, 2))
            }
            };

            Console.WriteLine("Dichotomy");

            foreach (var t in test)
            {
                Console.WriteLine(DichotomyMethod.Execute(t));
            }

            Console.WriteLine("GoldenRatio");

            foreach (var t in test)
            {
                Console.WriteLine(GoldenRatioMethod.Execute(t));
            }

            Console.WriteLine("Fibonacci");

            foreach (var t in test)
            {
                Console.WriteLine(FibonacciMethod.Execute(t));
            }

            Console.WriteLine("Parabolic");

            foreach (var t in test)
            {
                Console.WriteLine(ParabolicMethod.Execute(t));
            }
        }
    }
}
