using System;
using System.Collections.Generic;

namespace KrayovaZadacha
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    abstract class Methd
    {
        public abstract List<Point> Execute();
    }

    class MethodSkinchRizn : Methd
    {
        class Iteration
        {
            public double m;// { get; set; }
            public double k { get; set; }
            public double f { get; set; }
            public double c { get; set; }
            public double d { get; set; }

            public Iteration(double x)
            {
                m = -2 - 0.2 * x;
                k = 0.98 + 0.2 * x;
                f = -4 * x;
            }

            internal void CalculateC(double p)
            {
                c = 1/(m - k*p);
            }

            internal void CalculateD(double cp, double dp, double h)
            {
                d = f*h*h - k*cp*dp;
            }
        }
        class Iterations:List<Iteration>
        {
            private double h;
            private double alfa0, alfa1, beta0, beta1,A,B;
            public Iterations(double x0, double h, double alfa0, double alfa1, double beta0, double beta1, double A, double B)
            {
                this.h = h;
                var iter0 = new Iteration(x0);
                this.alfa0 = alfa0;
                this.alfa1 = alfa1;
                this.beta0 = beta0;
                this.beta1 = beta1;
                this.A = A;
                this.B = B;
                iter0.c = (alfa1 - alfa0*h)/(iter0.m*(alfa1 - alfa0*h)+iter0.k*alfa1);
                iter0.d = (iter0.k * A * h) / (alfa1 - alfa0 * h) + iter0.f * h * h;
                base.Add(iter0);
            }

            public void Add(double x)
            {
                var iter = new Iteration(x);
                iter.CalculateC(this[Count - 1].c);
                iter.CalculateD(this[Count - 1].c, this[Count - 1].d,h);
                base.Add(iter);
            }

        }

        private Iterations iterations;
        private double alfa0=1, alfa1=-1, beta0=1, beta1=0, A=0, B=3.78, h;
        private double a, b; //[a;b]
        public MethodSkinchRizn(double h,double a, double b)
        {
            this.h = h;
            this.a = a;
            this.b = b;
            iterations = new Iterations(a, h, alfa0, alfa1, beta0, beta1, A, B);
        }

        public override List<Point> Execute()
        {
            int n = (int)Math.Floor((b-a)/h);
            double curx = a;
            List<Point> points = new List<Point>();
            points.Add(new Point { X = a });//y0,x0            
            for (int i = 1; i <= n - 2; i++)
            {
                curx += h;
                iterations.Add(curx);
                points.Add(new Point { X = curx });
            }
            points.Add(new Point() { X = b-h });
            var last = iterations[iterations.Count - 1];

            double yn = (beta1*last.c*last.d + B*h)/(beta1*(1 + last.c) + beta0*h);
            points.Add(new Point() {X = b, Y = yn});

            for(int i= n-2;i>=0;i--)
            {
                last = iterations[i];
                var yi = last.c * (last.d - points[i+2].Y);
                points[i + 1].Y = yi;
            }
            points[0].Y = (alfa1*points[1].Y - A*h)/(alfa1 - alfa0*h);
            return points;
        }
    }
}