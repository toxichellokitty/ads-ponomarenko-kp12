using System;
using static System.Console;

namespace lab2
{
    class Program
    {
        static Random rnd = new Random();
        static int[,] rnd_matrix (int n)
        {
            int[,] arr = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(10, 99);
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }
            return (arr);
        }


        static int[,] gen_matrix(int n)
        {
            int[,] arr = new int[n, n];
            int res = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res++;
                    arr[i, j] = res;
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }
            return (arr);
        }


        static void Main(string[] args)
        {
            
            int n, m, a, k, l, t, y, f, v, b, g, s, choose;
            int max, min, mi, mj;

            Write("Enter n: "); n = Convert.ToInt32(ReadLine());
            Write("Enter m: "); m = Convert.ToInt32(ReadLine());

            a = ((m * m - m) / 2) - 1;
            b = m * m - a - 2;
            int[] arr1 = new int[a + 1];
            int[] arr2 = new int[b + 1];
            int[,] arr = new int[n, m];
            

            if (n > 0 && n == m)
            {
                Write("Enter 1 if you want to generate random matrix, and enter 2 if you want to fill it with numbers from 1 to n*m: "); choose = Convert.ToInt32(ReadLine());

                if (choose == 1)
                    arr = rnd_matrix(n);

                else if (choose == 2)
                    arr = gen_matrix(n);

                else WriteLine("There are some mistakes.");

                WriteLine();

                arr1[a] = -1;
                arr2[b] = -1;


                k = 0;
                y = 0;
                l = 0;
                v = 2;
                f = n - 3;

                mi = n - 1;
                mj = m - 1;
                max = arr[mi, mj];

                
                while (arr1[a] == -1)
                {

                    for (int j = 1 + y; j < n; j++)
                    {
                        arr1[k] = arr[n - 1, j];
                        Write($"{arr1[k]} ");
                        k++;

                        if (arr[n - 1, j] > max)
                        {
                            max = arr[n - 1, j];
                            mi = n - 1;
                            mj = j;
                        }
                    }

                    for (int i = n - 2; i > y; i--)
                    {
                        arr1[k] = arr[i, n - 1];
                        Write($"{arr1[k]} ");
                        k++;

                        if (arr[i, n - 1] > max)
                        {
                            max = arr[i, n - 1];
                            mi = i;
                            mj = n - 1;
                        }
                    }
                    y += 2;

                    
                    t = f;
                    f = 0;
                    
                    while (t > 0)
                    {
                        arr1[k] = arr[l + v, n - l - 2];

                        if (arr[l + v, n - l - 2] > max)
                        {
                            max = arr[l + v, n - l - 2];
                            mi = l + v;
                            mj = n - l - 2;
                        }

                        Write($"{arr1[k]} ");
                        k++;
                        l++;
                        t--;
                        f++;
                    }
                    l = 0;
                    v += 2;
                    f -= 3;

                    n--;
                }

                WriteLine($"Maximum number is arr[{mi},{mj}] = {max}");


                WriteLine();

                k = 0;
                l = 0;
                f = m;
                g = 0;
                v = 0;
                y = 0;
                s = 2;

                mi = 0;
                mj = m - 1;
                min = arr[mi, mj];

                while (arr2[b] == -1)
                {
                    t = f;
                    f = 0;

                    while (t > 0)
                    {
                        arr2[k] = arr[v + y, m - 1 - l - f];

                        if (arr[v + y, m - 1 - l - f] < min)
                        {
                            min = arr[v + y, m - 1 - l - f];
                            mi = v + y;
                            mj = m - 1 - l - f;
                        }

                        Write($"{arr2[k]} ");
                        k++;
                        t--;

                        v++;
                        f++;
                    }
                    l += 2;
                    f -= 3;
                    v = 0;
                    y++;


                    for (int i = m - s; i >= 0 + g; i--)
                    {
                        arr2[k] = arr[i, g];
                        Write($"{arr2[k]} ");
                        k++;

                        if (arr[i, g] < min)
                        {
                            min = arr[i, g];
                            mi = i;
                            mj = g;
                        }
                    }
                    s += 2;


                    for (int j = 1 + g; j < m - y - g; j++)
                    {
                        arr2[k] = arr[g, j];
                        Write($"{arr2[k]} ");
                        k++;

                        if (arr[g, j] < min)
                        {
                            min = arr[g, j];
                            mi = g;
                            mj = j;
                        }
                    }

                    g++;
                }

                WriteLine($"Minimum number is arr[{mi},{mj}] = {min}");

            }
            

            else WriteLine("There are some mistakes.");

        }
    }
}
