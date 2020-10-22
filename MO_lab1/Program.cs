using System;
using System.Collections.Generic;

namespace MO_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double eps = 0.025;

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
            },

            /*new TestCase()
            {
                Start = -101,
                End = 20,
                Epsilon = 0.0025,
                Function = Math.Abs
            }*/
            };

            Console.WriteLine("Dichotomy");

            foreach (var t in test)
            {
                Console.WriteLine(new DichotomyMethod().Execute(t));
            }

            Console.WriteLine("\nGoldenRatio");

            foreach (var t in test)
            {
                Console.WriteLine(new GoldenRatioMethod().Execute(t));
            }

            Console.WriteLine("\nFibonacci");

            foreach (var t in test)
            {
                Console.WriteLine(new FibonacciMethod().Execute(t));
            }

            Console.WriteLine("\nParabolic");

            foreach (var t in test)
            {
                Console.WriteLine(new ParabolicMethod().Execute(t));
            }
        }
    }
}
