using System;
using static System.Console;

namespace lab4
{
    class SLNode
    {
        public Node tail;
        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
            }
            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
        public SLNode(int data)
        {
            tail = new Node(data);
            tail.next = tail;
        }
        public void AddFirst(int data) 
        {
            Node current = new Node(data);
            current.next = tail.next;
            tail.next = current;

        }
        public void AddToPosition(int data, int position) 
        {
            int count = 1;
            Node current = new Node(data);
            Node temp;

            current.next = tail.next;
            temp = tail;

            while (count < position)
            {
                current.next = current.next.next;
                temp = temp.next;


                count++;
            }
            temp.next = current;
        }
        public void AddLast(int data)
        {
            Node current = new Node(data);
            current.next = tail.next;
            tail.next = current;
            tail = current;
        }
        public void DeleteFirst() 
        {
            if (tail.next == tail)
            {
                WriteLine("Unfortunately, you can't delete the last element. :(");
                WriteLine();
            }

            else
            {
                Node current;
                current = tail.next;

                tail.next = current.next;
                current.next = null;
            }
            
        }
        public void DeleteFromPosition(int position) 
        {
            if (tail.next == tail)
            {
                WriteLine("Unfortunately, you can't delete the last element. :(");
                WriteLine();
            }

            else
            {
                Node current, temp;
                temp = tail;
                current = tail.next;
                int count = 1;

                while (count < position)
                {
                    current = current.next;
                    temp = temp.next;

                    count++;
                }

                temp.next = current.next;
                current.next = null;
            }
        }
        public void DeleteLast()
        {
            if (tail.next == tail)
            {
                WriteLine("Unfortunately, you can't delete the last element. :(");
                WriteLine();
            }

            else
            {
                Node current = tail.next;

                while (current.next != tail)
                    current = current.next;

                current.next = tail.next;
                tail.next = null;
                tail = current;
            }
            
        }
        public void Print() 
        {
            Node current, stop_current;
            current = tail.next;
            stop_current = current.next;
            Write("Current list: ");
            do
            {
                Write(current.data + " ");
                current = current.next;
            }
            while (current.next != stop_current);
        }

        public void UserMethod(int data)
        {
            Node current = new Node(data);
            if (data > -21 && data < 34)
            {
                current.next = tail.next.next;
                tail.next.next = current;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int func;
            int data, position;
            SLNode cycle_list;
            Write("Enter the first element of your list: "); n = Convert.ToInt32(ReadLine());
            cycle_list = new SLNode(n);

            

            while (true)
            {
                WriteLine();
                WriteLine("Enter next numbers depending on function you want to perform: 1 - print current list,");
                WriteLine("2 - add new element at the first position, 3 - add new element at the last position,");
                WriteLine("4 - add new element at the determined position, 5 - delete the first element,");
                WriteLine("6 - delete the last element, 7 - delete the element at determined position, 8 - call user method.");
                WriteLine();
                Write("Number of function: "); func = Convert.ToInt32(ReadLine());

                if (func == 1) cycle_list.Print();

                else if (func == 2)
                {
                    Write("Enter the element for this method: "); data = Convert.ToInt32(ReadLine());
                    cycle_list.AddFirst(data);
                    cycle_list.Print();
                    WriteLine();
                }

                else if (func == 3)
                {
                    Write("Enter the element for this method: "); data = Convert.ToInt32(ReadLine());
                    cycle_list.AddLast(data);
                    cycle_list.Print();
                    WriteLine();
                }

                else if (func == 4)
                {
                    Write("Enter the element for this method: "); data = Convert.ToInt32(ReadLine());
                    Write("Enter the position for this method: "); position = Convert.ToInt32(ReadLine());
                    cycle_list.AddToPosition(data, position);
                    cycle_list.Print();
                    WriteLine();
                }

                else if (func == 5)
                {
                    cycle_list.DeleteFirst();
                    cycle_list.Print();
                    WriteLine();
                }

                else if (func == 6)
                {
                    cycle_list.DeleteLast();
                    cycle_list.Print();
                    WriteLine();
                }

                else if (func == 7)
                {
                    Write("Enter the position for this method: "); position = Convert.ToInt32(ReadLine());
                    cycle_list.DeleteFromPosition(position);
                    cycle_list.Print();
                    WriteLine();
                }

                else if (func == 8)
                {
                    Write("Enter the element for this method: "); data = Convert.ToInt32(ReadLine());
                    cycle_list.UserMethod(data);
                    cycle_list.Print();
                    WriteLine();
                }

                else WriteLine("You can't use method that are not declared! Please don't try it again :'(");
            }
        }
    }
}
