using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChMO_lab_duferenciyuvanna
{
    abstract class Function
    {
        abstract public double Execute(double x);
    }

    class Function1 : Function
    {

        public override double Execute(double x)
        {
            return Math.Sin(x);
        }
    }

    class Function2 : Function
    {

        public override double Execute(double x)
        {
            return Math.Cos(x);
        }
    }

    class Function3 : Function
    {

        public override double Execute(double x)
        {
            return Math.Tan(x);
        }
    }

    class Function4 : Function
    {
        public override double Execute(double x)
        {
            return Math.Abs(x);
        }
    }

    class Function5 : Function
    {
        int k1 = 3;
        int k2 = 6;

        public override double Execute(double x)
        {
            return k1*Math.Pow(x,k2);
        }
    }
}
