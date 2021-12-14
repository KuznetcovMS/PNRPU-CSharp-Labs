using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.1;
            double b = 0.8;
            int k = 10;
            int n;

            double e = 0.0001;
            double x;
            double y;
            double x4;
            double curx;

            for (x = a; x <= b; x += (b - a) / k)
            {

                double sn = 0;
                n = 0;
                x4 = Math.Pow(x, 4);
                curx = x;

                double se1 = curx / (4 * n + 1);
                double se2 = se1 + curx * x4 / (4 * (n + 1) + 1);

                Console.Write($"X = {x,-10}");
                
                for (n = 0; n < 3; n++)
                {
                    sn += curx / (4 * n + 1);
                    curx *= x4;
                }
                Console.Write($"SN = {sn,-24}");

                curx = x * x4;
                for (n = 1; Math.Abs(se1 - se2) >= e; n++)
                {
                    se1 = se2;
                    curx *= x4;
                    se2 += curx / (4 * (n + 1) + 1);
                }
                Console.Write($"SE = {se2,-24}");
                
                y = (1.0 / 4.0) * Math.Log((1 + x) / (1 - x)) + 0.5 * Math.Atan(x);
                Console.WriteLine($"Y = {x}");
            }

            Console.ReadKey();
        }
    }
}
