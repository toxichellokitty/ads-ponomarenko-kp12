using System;
using static System.Console;

namespace lab6_ads
{
    class Queue
    {
        private string[] _array;
        public int Count { get; private set; }

        public Queue(int capacity)
        {
            _array = new string[capacity];
            Count = 0;
        }

        public void Clear()
        {
            Program.CreateQueue();
        }

        public void PrintQueue()
        {
            Console.Write("Current queue values: ");
            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{_array[i]}" + " ");
            }
            Console.WriteLine();
        }

        public bool EnQueue(string element)
        {
            _array[Count] = element;
            Count += 1;
            PrintQueue();
            

            if (Count == _array.Length)
            {
                WriteLine("Queue is full!");
                for (int i = 0; i < _array.Length; i++)
                    DeQueue();
            }

            return true;
        }

        public bool DeQueue()
        {
            if (Count == 0) return false;
            
            Count -= 1;
            Shift();
            PrintQueue();
            return true;
        }

        private void Shift()
        {
            for (int i = 0; i < Count; i++)
                _array[i] = _array[i + 1];
            
        }


        public bool ContainsElement(string elem)
        {
            for (int i = 0; i < Count; i++)
                if (_array[i] == elem) return true;
                
            return false;
        }

    }
    class Program
    {
        static int capacity;
        private static Queue q;
        static void Main(string[] args)
        {
            string key;
            WriteLine("You can fill the queue enterig string in format as X00X00X, where X is a letter and 0 is a number. \nIf you want to delete first element, enter string in format X0X. \nEnter 'exit' or leave the string empty to stop the program. \nEnter 'clear' to create new queue. \nEnter 'find' to check if the queue contains the element.");
            CreateQueue();
            while(true)
            {
                Write("Choose 1 for reference example or 2 for keybord input:");
                key = ReadLine();
                if (key == "1" || key == "2")
                    break;
            }
            if (key == "1") ReferenceExample();
            else StartProgram();
            WriteLine("Goodbye.");
        }

        private static void ReferenceExample()
        {
            string input;
            for (int i = 0; i < capacity; i++)
            {
                if (i < 10) input = $"A0{i}A0{i}A";
                else input = $"A{i}A{i}A";

                bool isEnqueued = q.EnQueue(input);
            }

        }

        private static void StartProgram()
        {
            while (true)
            {
                string input = "";
                Write("Enter string: ");
                input = ReadLine();
                if (input == "" || input == "exit") break;
                else if (input == "clear")
                {
                    q.Clear();
                    continue;
                }
                else if (input == "find")
                {
                    Write("Enter element: ");
                    string elem = ReadLine();
                    if (q.ContainsElement(elem)) WriteLine("Success!");
                    else WriteLine("Is not found.");
                }
                else if (input.Length == 3)
                {
                    if (CheckInput3(input))
                    {
                        bool isDeQueued = q.DeQueue();
                        if (!isDeQueued) WriteLine("Queue is empty!");
                        if (isDeQueued && q.Count == 0) break;
                    }
                    else
                    {
                        WriteLine("Mistake! There are some ways to solve it: \n Input should contain digits and letters only. \n Input should be in format X00X00X, where X is letter and 0 is number.");
                        continue;
                    }
                }
                else if (input.Length == 7)
                {
                    if (!CheckInput(input))
                    {
                        WriteLine("Mistake! There are some ways to solve it: \n Input should contain digits and letters only. \n Input should be in format X00X00X, where X is letter and 0 is number.");
                        continue;
                    }
                    else {bool isEnqueued = q.EnQueue(input);}
                }
                else WriteLine("Input should be in format X00X00X, where X is letter and 0 is number.");
            }
        }

        private static bool CheckInput3(string input)
        {
            char[] inputChars = input.ToCharArray();

            for (int i = 0; i < inputChars.Length; i++)
                if (!char.IsDigit(inputChars[i]) && !char.IsLetter(inputChars[i]))
                    return false;

            if (char.IsLetter(inputChars[0]) && char.IsDigit(inputChars[1]) && char.IsLetter(inputChars[2]))
                return true;
            else return false;
        }

        private static bool CheckInput(string input)
        {
            char[] inputChars = input.ToCharArray();

            for (int i = 0; i < inputChars.Length; i++)
                if (!char.IsDigit(inputChars[i]) && !char.IsLetter(inputChars[i]))
                    return false;

            if (char.IsLetter(inputChars[0]) && char.IsDigit(inputChars[1]) && char.IsDigit(inputChars[2]) &&
                char.IsLetter(inputChars[3]) && char.IsDigit(inputChars[4]) && char.IsDigit(inputChars[5]) &&
                char.IsLetter(inputChars[6])) return true;
            else return false;
        }
        public static void CreateQueue()
        {
            while (true)
            {
                Console.Write("Enter queue capacity: ");
                
                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    if (capacity <= 0)
                    {
                        Console.WriteLine("Incorrect input");
                        continue;
                    }
                    else
                    {
                        q = new Queue(capacity);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }
            }
        }
    }
}