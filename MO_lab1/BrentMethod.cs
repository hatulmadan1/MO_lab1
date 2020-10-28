using System;
using System.IO.Pipes;

namespace MO_lab1
{
    public class BrentMethod : OptMethod
    {
        public override (double, double) Execute(TestCase data, Boolean suppressOutput = false)
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
            var idx = 1;
            u = 0;
            double prevAB = c - a;

            while (Math.Abs(c - a - 2 * eps) > eps)
            {
                var g = e;
                e = d;

                double tmp;
                if (Math.Abs(x - w) > prec && Math.Abs(x - v) > prec && Math.Abs(w - v) > prec
                    && Math.Abs(fx - fw) > prec && Math.Abs(fx - fv) > prec && Math.Abs(fv - fw) > prec)
                {
                    var (x1, x2, x3) = (x, w, v);
                    var (f1, f2, f3) = (fx, fw, fv);
                    tmp = x2 - ((x2 - x1) * (x2 - x1) * (f2 - f3) - (x2 - x3) * (x2 - x3) * (f2 - f1)) /
                        2 / ((x2 - x1) * (f2 - f3) - (x2 - x3) * (f2 - f1));

                    if (idx > 0 && tmp - a >= eps && c - tmp >= eps && Math.Abs(tmp - x) < g / 2)
                    {
                        u = tmp;
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
                    }
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
                }

                if (Math.Abs(u - x) < eps)
                {
                    u = x + Math.Sign(u - x) * eps;
                }

                var fu = func.Invoke(u);
                if (fu <= fx)
                {
                    if (u >= x)
                        a = x;
                    else
                    {
                        c = x;
                    }

                    (v, w, x) = (w, x, u);
                    (fv, fw, fx) = (fw, fx, fu);
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

                    if (fu <= fw || Math.Abs(v - x) < prec || Math.Abs(v - w) < prec)
                    {
                        v = u;
                        fv = fu;
                    }
                }

        
                Console.WriteLine($"Iter: {idx++} \ta: {a:F6}\tc: {c:F6}\tl/l': {prevAB / (c-a):F6}");
                prevAB = c - a;
            }

            Console.WriteLine();
            return (a, c);
        }
    }
}