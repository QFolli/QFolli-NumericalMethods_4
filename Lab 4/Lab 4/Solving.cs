using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Solving
    {
        public delegate double Func(double x);

        //public static double Function(double x) => (Math.Tan(x) / x);
        public static double Function(double x) => (Math.Log(x) + Math.Sqrt(1+x));

        public static  double Newton(double h, double x, double[] MasX, double[] MasY, double[,] MasA)
        {

            double[] Y = new double[MasX.Length];
            Y[0] = MasY[0];
            for (int i = 0; i < MasX.Length - 1; i++)
                Y[i + 1] = MasA[0, i];

            double[] q = new double[MasX.Length - 1];
            q[0] = x - MasX[0];
            for (int i = 1; i < MasX.Length - 1; i++)
                q[i] = q[i - 1] * (x - MasX[i]);

            double res = Y[0];
            for (int i = 1, fact = 1; i < MasX.Length; i++)
            {
                fact *= i;
                res += (Y[i] * q[i - 1]) / (fact * Math.Pow(h, i));
            }



            return res;
        }
    }
}
