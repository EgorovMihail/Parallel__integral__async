using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integral
{
    public class IntegralMath : IMath
    {
    public double Trap(double a, double b, double h, Func<double, double> func)
        {
            if (h < 0.0)
            {
                throw new ArgumentException();
            }

            if (h > 1.0)
            {
                throw new ArgumentException();
            }

            if ((h < 0.000001) && (h != 0.0))
            {
                throw new ArgumentException();
            }

            if (a >= b)
            {
                throw new ArgumentException();
            }

            double sum_x = 0.0;

            if (h != 0.0)
            {
                int n = Convert.ToInt32((b - a) / h);

                for (int i = 1; i < n; i++)
                {
                    sum_x += func(a + i * h);
                }

                sum_x += (func(a) + func(b)) / 2.0;
                sum_x *= h;
            }

            return sum_x;
        }

        public double Sims(double A, double B, double h, Func<double, double> func)
        {
            if (h < 0.0)
            {
                throw new ArgumentException();
            }

            if (h > 1.0)
            {
                throw new ArgumentException();
            }

            if ((h < 0.000001) && (h != 0.0))
            {
                throw new ArgumentException();
            }

            if (A >= B)
            {
                throw new ArgumentException();
            }

            double x = 0.0;
            double sum = 0.0;
            int m = Convert.ToInt32((B - A) / h);

            for (int i = 0; i < m; i++)
            {
                x = A + i * h;

                if (i % 2 == 0) sum += 2.0 * func(x);
                else sum += 4.0 * func(x);
            }

            double res = h / 3.0 * (func(A) + func(B) + sum);

            return res;
        }

        //Параллельный метод трапеций
        public double pTrap(double a, double b, double h, Func<double, double> func)
        {
            if (h < 0.0)
            {
                throw new ArgumentException();
            }

            if (h > 1.0)
            {
                throw new ArgumentException();
            }

            if ((h < 0.000001) && (h != 0.0))
            {
                throw new ArgumentException();
            }

            if (a >= b)
            {
                throw new ArgumentException();
            }

            double sum_x = 0.0;

            if (h != 0.0)
            {
                int n = Convert.ToInt32((b - a) / h);
                double[] buf = new double[n];

                Parallel.For(1, n, i =>
                {
                    buf[i] = func(a + i * h);
                });

                sum_x = h * (buf.AsParallel().Sum(X => X) + (func(a) + func(b)) / 2.0);
            }

            return sum_x;
        }

        //паралельный метод Симпсона 
        public double pSims(double A, double B, double h, Func<double, double> func)
        {
            if (h < 0.0)
            {
                throw new ArgumentException();
            }

            if (h > 1.0)
            {
                throw new ArgumentException();
            }

            if ((h < 0.000001) && (h != 0.0))
            {
                throw new ArgumentException();
            }

            if (A >= B)
            {
                throw new ArgumentException();
            }

            double res = 0.0;

            if (h != 0.0)
            {
                int m = Convert.ToInt32((B - A) / h);

                double[] buf = new double[m];
                double[] x = new double[m];

                Parallel.For(0, m, i =>
                {
                    x[i] = A + i * h;

                    if (i % 2 == 0) { buf[i] = 2.0 * func(x[i]); }
                    else { buf[i] = 4.0 * func(x[i]); }
                });

                res = h / 3.0 * (func(A) + func(B) + buf.AsParallel().Sum(X => X));
            }

            return res;
        }
    }
}
