using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab7_new
{
    class Article
    {
        public Article(string title, List<Author> authors, string journalName, int yearOfPublishing, int numberOfCiting)
        {
            this.title = title;
            this.authors = authors;
            this.journalName = journalName;
            this.yearOfPublishing = yearOfPublishing;
            this.numberOfCiting = numberOfCiting;
            this.doi = GenerateDOI(yearOfPublishing);
            this.deleted = false;
        }


        static string GenerateDOI(int year)
        {
            string doi = "";

            Random rnd = new Random(); //65-90
            int temp1 = rnd.Next(65, 90);
            int temp2 = rnd.Next(65, 90);
           
            char ch1 = (char)(temp1);
            char ch2 = (char)(temp2);

            doi = "" + rnd.Next(10) + rnd.Next(10) + "." + rnd.Next(10) + rnd.Next(10) + rnd.Next(10) + rnd.Next(10) + rnd.Next(10) + "/"
                     + ch1 + ch2 + Convert.ToString(year) + "." + rnd.Next(10) + rnd.Next(10) + "." + rnd.Next(10);

            return doi;
        }

        public string title;
        public List<Author> authors;
        public string journalName;
        public int yearOfPublishing;
        public int numberOfCiting;
        public string doi;
        public bool deleted;
    }
    class Key
    {
        public int key;
        public Key(int key)
        {
            this.key = key;
        }
    }
    class Entry
    {
        public Key key;
        public List<Article> value;
        public Entry(Key k, List<Article> v)
        {
            this.key = k;
            this.value = v;
        }

    }
    class Hashtable
    {
        public int size;
        public int loadness;
        public Entry[] table;

        public Hashtable(int size)
        {
            this.size = size;
            this.loadness = 0;
            this.table = new Entry[size];
        }
        public bool containKey(int hash_a)
        {
            bool flag = true;

            if (table[hash_a] is null) flag = false;

            return flag;
        }
        public void Print()
        {

            string authors_str = " Authors: ";
            WriteLine("");

            foreach (Entry item in table)
            {

                if (!(item is null))
                {
                    foreach (Article item_a in item.value)
                    {
                        if (!item_a.deleted)

                        {
                            authors_str = " Authors: ";
                            foreach (Author item_autor in item_a.authors)
                            {
                                authors_str += item_autor.authorName + ". ";
                            }

                            WriteLine(item_a.doi + " Title: " + item_a.title + " Journal: " + item_a.journalName + " Year: " + item_a.yearOfPublishing + " Number of citing: " + item_a.numberOfCiting + authors_str);
                        }
                    }
                }
            }
        }
        public void Find(string doi)
        {
            int hash_a = GenerateHash(doi);
            bool fl_find = true;
            string authors_str = " Authors: ";
            WriteLine("");


            if (!(table[hash_a] is null))
            {
                foreach (Article item_a in table[hash_a].value)
                {
                    if (item_a.doi == doi)
                    {
                        if (!item_a.deleted)

                        {
                            foreach (Author item_autor in item_a.authors)
                            {
                                authors_str += item_autor.authorName + ". ";
                            }
                            fl_find = false;
                            WriteLine(item_a.doi + " Title: " + item_a.title + " Journal: " + item_a.journalName + " Year: " + item_a.yearOfPublishing + " Number of citing: " + item_a.numberOfCiting + authors_str);

                        }
                    }
                }

                if (fl_find) WriteLine(doi + " not found");

            }
            else
            {
                WriteLine(doi + " not found");
            }

        }
        static int GenerateHash(string doi)
        {
            int hash_a = -1;

            hash_a = Convert.ToInt32(doi.Substring(0, 2)) * 10 + Convert.ToInt32(doi.Substring(3, 1));

            return hash_a;
        }
        public void remove(string doi, Hashtable_Authors hsAuthors)
        {

            int hash_a = GenerateHash(doi);
            bool fl_find = true;

            WriteLine("");


            if (!(table[hash_a] is null))
            {
                //foreach (Article item_a in table[hash_a].value)
                for (int i = 0; i < table[hash_a].value.Count; i++)
                {
                    if (table[hash_a].value[i].doi == doi)
                    {
                        if (!table[hash_a].value[i].deleted)

                        {
                            table[hash_a].value[i].deleted = true;
                            fl_find = false;
                            hsAuthors.authorHIndex(table[hash_a].value[i], false);
                            
                            WriteLine(doi + " deleted");
                        }


                    }
                }

                if (fl_find) WriteLine(doi + " not found");

            }
            else
            {
                WriteLine(doi + " not found");
            }



        }
        public void insert(Article a, Hashtable_Authors hsAuthors)
        {


            int hash_a = GenerateHash(a.doi);


            bool flag = containKey(hash_a);

            if (flag)
            {
                table[hash_a].value.Add(a);

            }
            else
            {
                List<Article> articleList = new List<Article>();
                articleList.Add(a);
                Entry new_e = new Entry(new Key(hash_a), articleList);
                table[hash_a] = new_e;
            }

            hsAuthors.authorHIndex(a, true);


        }
    }
    class Author
    {
        public Author(string authorName, int HIndex)
        {
            this.authorName = authorName;
            this.HIndex = HIndex;
        }
        public string authorName;
        public int HIndex;


    }
    class Entry_Authors
    {
        public Key key;
        public List<Author> AuthorList;
        public Entry_Authors(Key k, List<Author> v)
        {
            this.key = k;
            this.AuthorList = v;
        }
    }
    class Hashtable_Authors
    {
        public int size;
        public int loadness;
        public Entry_Authors[] table;

        public Hashtable_Authors(int size)
        {
            this.size = size;
            this.loadness = 0;
            this.table = new Entry_Authors[size];
        }


        public bool containKey(int hash_a)
        {
            bool flag = true;

            if (table[hash_a] is null) flag = false;

            return flag;
        }

        public void Print()
        {
            WriteLine("");

            foreach (Entry_Authors item in table)
                if (!(item is null))
                    foreach (Author item_a in item.AuthorList)
                        if (item_a.HIndex > 0)
                            WriteLine(" Author: " + item_a.authorName + " Index: " + item_a.HIndex);
                        
        }



        static int GenerateHash(string authorName)
        {
            int hash_a = -1;
            int sum = 0;
            int size = authorName.Length - 1;


            for (int k = 0; k < size + 1; k++)
                sum = sum + Convert.ToInt32(authorName[k]);

            hash_a = sum % size;

            return hash_a;
        }
        public void authorHIndex(Article a, bool InsOrRem)
        {
            bool flag;
            int hash_a;
            bool insert_flag;

            if (InsOrRem)
            {
               

                for (int i = 0; i < a.authors.Count; i++)
                {
                    hash_a = GenerateHash(a.authors[i].authorName);
                    flag = containKey(hash_a);


                    if (flag)
                    {
                        insert_flag = true;
                        for (int j = 0; j < table[hash_a].AuthorList.Count; j++)
                        {
                            if (table[hash_a].AuthorList[j].authorName == a.authors[i].authorName)
                            {
                                insert_flag = false;
                                table[hash_a].AuthorList[j].HIndex += a.numberOfCiting;
                            }
                        }
                        if (insert_flag)
                        {
                            a.authors[i].HIndex = a.numberOfCiting;
                            table[hash_a].AuthorList.Add(a.authors[i]);
                        }


                    }
                    else
                    {

                        List<Author> AuthorList = new List<Author>();
                        a.authors[i].HIndex = a.numberOfCiting;
                        AuthorList.Add(a.authors[i]);
                        Entry_Authors new_e = new Entry_Authors(new Key(hash_a), AuthorList);
                        table[hash_a] = new_e;

                    }

                }



            }
            else
            {
                for (int i = 0; i < a.authors.Count; i++)
                {
                    hash_a = GenerateHash(a.authors[i].authorName);
                    flag = containKey(hash_a);


                    if (flag)
                    {

                        for (int j = 0; j < table[hash_a].AuthorList.Count; j++)
                        {
                            if (table[hash_a].AuthorList[j].authorName == a.authors[i].authorName)
                            {

                                table[hash_a].AuthorList[j].HIndex -= a.numberOfCiting;

                                if (table[hash_a].AuthorList[j].HIndex < 0) table[hash_a].AuthorList[i].HIndex = 0;


                            }
                        }



                    }


                }
            }



        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hsArticles = new Hashtable(1000);
            Hashtable_Authors hsAuthors = new Hashtable_Authors(1000);


            Console.WriteLine("Type help! to see list of commands.");
            while (true)
            {
                string input = Console.ReadLine();
                string[] inputarr = input.Split(" ");
                switch (inputarr[0])
                {
                    case "help!":
                        Console.WriteLine("List of commands:\n\radd! - add new article." +
                            "Arguments: title name, authors, journal name, year of publishing, number of citing" +
                            "\nExample: add! Title name;Surname1 Name1,Surname2 Name2;Journal name;2019;11" +
                            "\n\rremove! - remove article by doi-key. Example: remove! 13.41055/HJ2019.30.2" +
                            "\n\rfind! - find an article by doi-key. Example: find! 13.41055/HJ2019.30.2" +
                             "\n\rprint! - print all hashtable." +
                            "\n\rprintind! - print all authors and their h-index." +
                            "\n\rexit! - exit app.");
                        break;
                    case "add!":
                        input = input.Substring(5);
                        string[] arr_input = input.Split(";");
                        Article a = CreateArticle(arr_input);
                        hsArticles.insert(a, hsAuthors);
                        break;
                    case "remove!":
                        hsArticles.remove(inputarr[1], hsAuthors);
                        break;
                    case "find!":
                        hsArticles.Find(inputarr[1]);
                        break;

                    case "print!":
                        hsArticles.Print();
                        break;
                    case "printind!":
                        hsAuthors.Print();
                        break;

                    case "exit!":
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
                if (input == "!exit") break;
            }
            Console.WriteLine("Bye!");
        }

        static Article CreateArticle(string[] arr_input)
        {
            string temp = arr_input[1];
            string[] authors = temp.Split(",");
            List<Author> tempList = new List<Author>();

            for (int i = 0; i < authors.Length; i++)
            {
                Author au = new Author(authors[i], 0);
                tempList.Add(au);
            }

            int year = Convert.ToInt32(arr_input[3]);

            Article a = new Article(arr_input[0], tempList, arr_input[2],
                            year, Convert.ToInt32(arr_input[4]));
            return (a);
        }
    }
}
