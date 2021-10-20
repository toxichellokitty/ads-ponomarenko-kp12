using System;
using static System.Console;
using static System.Math;

namespace ads_lab1_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, n1;
            int t, k, l, k1;

            Write("Enter n: "); n = Convert.ToInt32(ReadLine());

            if (n > 0)
            {
                for (int i = 1; i < n; i++)
                {
                    n1 = i;
                    k = 0;
                    l = 0;

                    while (n1 >= 1)
                    {
                        t = n1 % 10;
                        k = 10 * k + t;
                        n1 = n1 / 10;
                    }

                    if (k == i)
                    {
                        
                        k = k1 = k * k;

                        while (k1 >= 1)
                        {
                            t = k1 % 10;
                            l = 10 * l + t;
                            k1 = k1 / 10;
                        }

                        if (l == k)
                        {
                            WriteLine("Number-palindrome, which squared also gives palindrome: " + i);
                        }
                    }
                }
            }

            else WriteLine("Entered number is incorrect.");
            

          ReadKey();
        }
    }
}
