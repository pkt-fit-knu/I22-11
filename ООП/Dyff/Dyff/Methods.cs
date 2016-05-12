using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChMO_lab_duferenciyuvanna
{
    abstract class Method
    {
        protected Function f;
        abstract public double FirstDerivative(double x);
        abstract public double SecondDerivative(double x);
    }

    class NyutonMethod : Method
    {
        double[] t;

        public NyutonMethod(Function f)
        {
            this.f = f;

            t = new double[7];
            
            t[0] = Config.x0 - 3*Config.h;
            t[1] = Config.x0 - 2*Config.h;
            t[2] = Config.x0 - Config.h;
            t[3] = Config.x0;
            t[4] = Config.x0 + Config.h;
            t[5] = Config.x0 + 2*Config.h;
            t[6] = Config.x0 + 3*Config.h;
        }

        double qfunc(double x)
        {
            return (x - t[0]) / Config.h;
        }

        public override double FirstDerivative(double x)
        {
            double q = qfunc(x);
            double res = 0;
            res += delta_n(1, 0);
            res += (2*q -1)/2 * delta_n(2, 0);
            res += (3 * q*q - 6*q + 2) / 6 * delta_n(3, 0);
            res += (2 * q * q * q - 9 * q * q + 11 * q - 3) / 12 * delta_n(4, 0);
            return res / Config.h;
        }

        public override double SecondDerivative(double x)
        {
            double q = qfunc(x);
            double res = 0;
            res += delta_n(2, 0);
            res += (q - 1) * delta_n(3, 0);
            res += (6 * q * q - 18 * q + 11) / 12 * delta_n(4, 0);
            return res / (Config.h * Config.h);
        }

        protected double delta(int i)
        {
            return f.Execute(t[i + 1]) - f.Execute(t[i]);
        }

        protected double delta_n(int n, int i)
        {
            if (n == 1) return delta(i);
            return delta_n(n - 1, i + 1) - delta_n(n - 1, i);
        }
    }

    class LahrangMethod : Method
    {
        public LahrangMethod(Function f)
        {
            this.f = f;
        }

        public override double FirstDerivative(double x)
        {
            return (3 * f.Execute(x) - 4 * f.Execute(x - Config.h) + f.Execute(x - 2 * Config.h) ) / (2*Config.h); 
        }

        public override double SecondDerivative(double x)
        {
            return (2*f.Execute(x) - 5*f.Execute(x+ Config.h) + 4*f.Execute(x+2*Config.h) - f.Execute(x+ 3*Config.h)) / (Config.h*Config.h);
        }
    }

    class CetralSubMethod_oh4 : Method
    {
        public CetralSubMethod_oh4(Function f)
        {
            this.f = f;
        }

        public override double FirstDerivative(double x)
        {
            double r = 0.0;
            r += -f.Execute(x+ 2* Config.h);
            r += 8 * f.Execute(x+Config.h);
            r += -8 * f.Execute(x - Config.h);
            r += f.Execute(x-2*Config.h);
            return r/ (12*Config.h);
        }

        public override double SecondDerivative(double x)
        {
            double h = Config.h;
            double r = 0.0;
            r += -f.Execute(x+2*h);
            r += 16 * f.Execute(x + h);
            r += -30 * f.Execute(x);
            r += 16 * f.Execute(x - h);
            r += -f.Execute(x - 2 * h);
            return r / (12 * h * h);
        }
    }

    class CetralSubMethod_oh2 : Method
    {
        public CetralSubMethod_oh2(Function f)
        {
            this.f = f;
        }

        public override double FirstDerivative(double x)
        {
            throw new NotImplementedException();
        }

        public override double SecondDerivative(double x)
        {
            throw new NotImplementedException();
        }
    }

}
