using System;
using System.IO.Pipes;

namespace MO_lab1
{
    public class BrentMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data)
        {
            return BrentMethodDeclaration(data);
        }

        private (double, double) BrentMethodDeclaration(TestCase tc)
        {
            var prec = 1e-5;
            var a = tc.Start;
            var c = tc.End;
            var eps = tc.Epsilon;
            var func = tc.Function;
            double u, d, e, x, w, v, fx, fw, fv, K = (3 - Math.Sqrt(5)) / 2;
            x = w = v = (a + c) / 2;
            fx = fw = fv = func.Invoke(x);
            d = e = c - a;
            var i = 0;

            u = Double.MaxValue;
            while (Math.Abs(c - a) > 3 * eps)
            {
                var g = e;
                e = d;

                if (Math.Abs(x - w) > prec && Math.Abs(x - v) > prec && Math.Abs(w - v) > prec
                    && Math.Abs(fx - fw) > prec && Math.Abs(fx - fv) > prec && Math.Abs(fv - fw) > prec)
                {
                    var (item1, item2) = new ParabolicMethod().Execute(new TestCase
                    {
                        Start = a, End = c, Epsilon = eps, Function = func
                    });
                    u = (item1 + item2) / 2;
                }


                if (Math.Abs(u - x) < g / 2
                    && u - a >= eps
                    && c - u >= eps)
                {
                    d = Math.Abs(u - x);
                }
                else
                {
                    if (x < (a + c) / 2)
                    {
                        u = x + K * (c - x);
                        d = c - x;
                    }
                    else
                    {
                        u = x - K * (x - a);
                        d = x - a;
                    }

                    if (Math.Abs(u - x) < eps)
                    {
                        u = x + Math.Sign(u - x) * eps;
                    }

                    var fu = func.Invoke(u);
                    if (fu < fx)
                    {
                        if (u >= x)
                        {
                            a = x;
                        }
                        else
                        {
                            c = x;
                        }

                        v = w;
                        w = x;
                        x = u;
                        fv = fw;
                        fw = fx;
                        fx = fu;
                    }
                    else
                    {
                        if (u >= x)
                        {
                            c = u;
                        }
                        else
                        {
                            a = u;
                        }

                        if (fu <= fw || Math.Abs(w - x) < prec)
                        {
                            v = w;
                            w = u;
                            fv = fw;
                            fw = fu;
                        }
                        else
                        {
                            if (fu <= fv || Math.Abs(v - x) < prec || Math.Abs(v - w) < prec)
                            {
                                v = u;
                                fv = fu;
                            }
                        }
                    }
                }

                i++;
                Console.WriteLine($"Iter: {i}\t\tA: {a}\t\tB: {c}\t\tB-A: {c - a}");
            }

            Console.WriteLine();
            return (a, c);
        }
    }
}