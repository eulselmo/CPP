using System;
using System.Threading;

//public delegate void ThreadStart();
class ThreadTest
{
    static void Main()
    {
        Thread t = new Thread(new ThreadStart(Go));
        t.Start();   // Run Go() on the new thread.
        Go();        // Simultaneously run Go() in the main thread.

        Thread t2 = new Thread(Go);    // No need to explicitly use ThreadStart
        t2.Start();

        Thread t3 = new Thread(() => Console.WriteLine("Lambda has created this thread"));
        t3.Start();

        Thread t4 = new Thread(() => Print("Our parameter"));
        t4.Start();

        //---------------------------------

        for (int i = 0; i < 10; i++)
            new Thread(() => Console.Write(i)).Start();

        Console.WriteLine();

        for (int j = 0; j < 10; j++)
        {
            int temp = j;
            new Thread(() => Console.Write(temp)).Start();
        }



        Console.ReadKey();
    }

    static void Go()
    {
        Console.WriteLine("New Thread!");
    }

    static void Print(string message)
    {
        Console.WriteLine(message);
    }

}