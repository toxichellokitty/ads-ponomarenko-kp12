using System;
using System.Collections.Generic;
using static System.Console;


namespace lab5
{
    class Program
    {
        static int[,] arr = new int[n, n];
        static int n;
        static int[] arr1 = new int[count];
        static int count;
        static (int[,], int) rnd_matrix(int n)
        {
            Random rnd = new Random();
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(100, 1000);
                    if (i % 2 == 0 && (i != j && i + j + 1 != n))
                    {
                        BackgroundColor = ConsoleColor.Magenta;
                        count++;
                    }
                    else BackgroundColor = ConsoleColor.Black;
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();
            return (arr, count);
        }


        static (int[,], int) gen_matrix(int n)
        {
            int[,] arr = new int[n, n];
            int count = 0;
            int y = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = y;
                    if (i % 2 == 0 && (i != j && i + j + 1 != n))
                    {
                        BackgroundColor = ConsoleColor.Magenta;
                        count++;
                    }
                    else BackgroundColor = ConsoleColor.Black;
                    y++;
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();
            return (arr, count);
        }

        static void Main(string[] args)
        {
            int n, choose;
            count = 0;

            Write("Enter n: "); n = Convert.ToInt32(ReadLine());


            Write("Enter 1 if you want to generate random matrix, and enter 2 if you want to fill it with numbers from 1 to n*m: "); choose = Convert.ToInt32(ReadLine());

            if (choose == 1)
                (arr, count) = rnd_matrix(n);

            else if (choose == 2)
                (arr, count) = gen_matrix(n);

            else WriteLine("There are some mistakes.");

            WriteLine();

            sort_arr();
        }

        static void sort_arr ()
        {
            int c = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i % 2 == 0 && (i != j && i + j + 1 != n))
                    {
                        arr1[c] = arr[i, j];
                        c++;
                    } 
            

            arr1 = sort_Dijkstra(arr1, count);

            c = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i % 2 == 0 && (i != j && i + j + 1 != n))
                    {
                        arr[i,j] = arr1[c];
                        c++;
                    }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0 && (i != j && i + j + 1 != n))
                        BackgroundColor = ConsoleColor.DarkMagenta;
                    else BackgroundColor = ConsoleColor.Black;
                    Write($"{arr[i, j]} ");
                }
                WriteLine();
            }

        }

        static int[] sort_Dijkstra (int[] arr1, int count)
        {
            int i, j;
            int eq = 0;
            i = 0;
            arr1[eq] = arr1[i];
            j = count - 1;


            recursion_fun(i, j, arr1);

            return arr1;
        }

        static void recursion_fun(int i, int j, int[] arr1)
        {
            int temp, pivot, eq, last_el, p, first_el;
            first_el = i;
            last_el = j;
            eq = i;
            p = eq + 1;
            pivot = arr1[i];
            

            if (i == j)
                return;
            else
                while (i <= j)
                {
                    if (arr1[i] > pivot)
                    {
                        temp = arr1[i];
                        arr1[i] = arr1[eq];
                        arr1[eq] = temp;
                        i++;
                        eq++;
                    }

                    else if (arr1[i] < pivot)
                    {
                        temp = arr1[i];
                        arr1[i] = arr1[j];
                        arr1[j] = temp;
                        j--;
                    }

                    else i++;

                }



            
            recursion_fun(first_el, eq, arr1);
            recursion_fun(p, last_el, arr1);


        }


    }
}
