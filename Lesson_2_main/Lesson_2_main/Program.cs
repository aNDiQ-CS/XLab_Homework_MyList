using aNDiQLib;
using System;

namespace Lesson_2_main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> a = new MyList<int>();
            Console.WriteLine("MyList from aNDiQLib");
            Console.WriteLine("------");
            Console.WriteLine("\nFilling MyList with 10 digits");

            for (int i = 0; i < 10; i++)
            {
                a.Add(i);
                Console.WriteLine(a);   
                Thread.Sleep(400);
            }
            Console.WriteLine("\nMyList after adding 10 digits");
            Console.WriteLine(a);

            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nInserting and removing some elements");
            a.Insert(1337, 0);
            Console.WriteLine("Insert 1337 to index 0: " + a);
            a.Insert(52, 1);
            Console.WriteLine("Insert 52 to index 1: " + a);
            a.Insert(123, 9);
            Console.WriteLine("Insert 123 to index 9: " + a);
            a.Remove(123);
            Console.WriteLine("Remove number 123: " + a);
            a.Remove(1);
            Console.WriteLine("Remove number 1: " + a);
            a.RemoveAt(10);
            Console.WriteLine("Remove number from index 10: " + a);
            a.RemoveAt(1);
            Console.WriteLine("Remove number from index: " + a);
            a.RemoveAt(1);
            Console.WriteLine("Remove number from index 10: " + a);
            a.RemoveAt(1);
            Console.WriteLine("Remove number from index 10: " + a);
            a.Remove(a[2]);
            Console.WriteLine("Remove number from a[2]: " + a);
            a[0] = 228;
            Console.WriteLine("a[0] = 228: " + a);            

            Console.WriteLine("\nLet's check, if MyArray contains your number!");
            Console.Write("Enter your number: ");            
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (a.Contains(number))
                {
                    Console.WriteLine("Yep, we have it!");
                }
                else
                {
                    Console.WriteLine("Nope, there's nothing");
                }
            }
            else
            {
                Console.WriteLine("Sorry, that's not a number");
            }

            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();

            Console.WriteLine("\nClearing MyList");
            a.Clear();
            Console.WriteLine(a);

            Console.WriteLine("Now, we'll fill MyList with 33 digits to test for the last time");
            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();            
            Console.Clear();
            for (int i = 0; i < 33; i++)
            {
                a.Add(i);
                Console.WriteLine(a);
                Thread.Sleep(250);
            }            

            Console.WriteLine("\nNow, we'll delete MyList item by item");
            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();

            for (int i = 0; i < 33; i++)
            {
                a.RemoveAt(0);
                Console.WriteLine(a);
                Thread.Sleep(250);
            }
            Console.WriteLine(a);

            Console.WriteLine("Now, we'll fill MyList with 69 digits just for fun :D");
            Console.WriteLine("\nPRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();
            for (int i = 0; i < 69; i++)
            {
                a.Add(i);
                Console.WriteLine(a);
                Thread.Sleep(200);
            }

            Console.WriteLine("\nSeems like it works just fine!");
        }
    }
}
