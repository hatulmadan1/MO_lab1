using System;
using System.Collections.Generic;
using System.Text;

namespace MO_lab1
{
    public class TestCase
    {
        public double Start { get; set; }
        public double End { get; set; }
        public Func<double, double> Function { get; set; }
        public double Epsilon { get; set; }
    }
}
