using System;
using System.Collections.Generic;
using static System.Console;

namespace lab3
{
    class Program
    {
        
        static (List<int>, int) Data (List<int> cringe, int a)
        {
            while(true)
            {
                if (cringe.Contains(a))
                    a = rnd.Next(100, 1000);

                else break;

            }

            return (cringe, a);
        }


        static Random rnd = new Random();
        static int[,] gen_matrix(int n)
        {
            int[,] arr = new int[n, n];
            int a;
            List<int> cringe = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    a = rnd.Next(100, 1000);
                    
                    (cringe, a) = Data(cringe, a);
                    arr[i, j] = a;
                    cringe.Add(a);
                    if (j > i && i + j + 1 != n)
                        BackgroundColor = ConsoleColor.Magenta;
                    else BackgroundColor = ConsoleColor.Black;
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();
            return (arr);
        }
        static void Main(string[] args)
        {
            int n, temp, min, m;
            int k = 0;
            Write("Enter n: "); n = Convert.ToInt32(ReadLine());
            int[,] arr = new int[n, n];
            m = (n * n - n) / 2 - n / 2;
            int[] arr1 = new int[m];

            arr = gen_matrix(n);


            for (int i = 0; i < n - 1; i++)
                for (int j = 1; j < n; j++)
                    if (j > i)
                        if (i + j + 1 != n)
                        {
                            arr1[k] = arr[i, j];
                            k++;
                        }

            for (int i = 0; i < m - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < m; j++)
                {
                    if (arr1[j] < arr1[min])
                        min = j;
                }

                if (i != min)
                {
                    temp = arr1[min];
                    arr1[min] = arr1[i];
                    arr1[i] = temp;
                }
            }

            k = 0;
            for (int i = 0; i < n - 1; i++)
                for (int j = 1; j < n; j++)
                    if (j > i)
                        if (i + j + 1 != n)
                        {
                            arr[i, j] = arr1[k];
                            k++;
                        }

            WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j > i && i + j + 1 != n)
                        BackgroundColor = ConsoleColor.DarkMagenta;
                    else BackgroundColor = ConsoleColor.Black;
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }


        }
    }
}
