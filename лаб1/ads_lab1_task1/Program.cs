using System;
using static System.Console;
using static System.Math;

namespace ads_lab1_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, a, b, c;

            Write("Enter x: "); x = Convert.ToDouble(ReadLine());
            Write("Enter y: "); y = Convert.ToDouble(ReadLine());
            Write("Enter z: "); z = Convert.ToDouble(ReadLine());

            c = Pow(x, z) - Cbrt(Pow(x, 2) - y * Pow(z, 3));

            if (!(c == 0))
            {
                a = (x + y - z) / c;
                if (!(a == 0))
                {
                    b = Cos((x * y + Pow(y, 2)) / Pow(a, 2));
                    WriteLine($"a = {a}");
                    WriteLine($"b = {b}");
                }
                else
                {
                    WriteLine($"a = {a}");
                    WriteLine("Example b can't be counted.");
                }
            }

            else
                WriteLine("There are some mistakes in entered data.");
           

            ReadKey();
        }
    }
}
