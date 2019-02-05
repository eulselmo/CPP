using System;
using System.Threading;

//public delegate void ThreadStart();
class ThreadTest
{
    static void Main()
    {
        string start = DateTime.Now.ToString("HH:mm:ss tt");
        string stop;
        Console.WriteLine(start);



        Go(50, "0--> ");

        Thread t = new Thread(() => Go(40, "1--> "));
        t.Start();

        Thread t2 = new Thread(() => Go(40, "2--> "));
        t2.Start();


        Thread t3 = new Thread(() => Go(40, "3--> "));
        t3.Start();
        t3.Join();

        Thread t4 = new Thread(() => Print(DateTime.Now.ToString("HH:mm:ss tt")));
        t4.Start();

        Console.ReadKey();
    }



    static long Fibo(int n)
    {
        int f = 0;
        int a = 1, b = 1;
        if (n == 1 || n == 2)
        {
            f = 1;
            return f;
        }
        for (int i = 3; i <= n; i++)
        {
            f = a + b;
            a = b;
            b = f;
        }
        return f;

    }


    static void Go(int n, string m)
    {
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(m + i + " " + Fibo(i));
        }
    }

    static void Print(string message)

    {
        Console.WriteLine(message);
    }


}
