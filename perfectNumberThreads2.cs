using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ThreadNaming
{
    static void Main()
    {
        
        //main threads
        GoPerfect(2, 35000, "main thread (1) --> ");
        GoPerfect(35001, 70000, "main thread (2) --> ");

        Console.WriteLine("---------------------");

        
        Task task2 = new Task(() => GoPerfect(2, 35000, "2nd thread ------>"));
        task2.Start();

        Task task3 = new Task(() => GoPerfect(35001, 70000, "3rd thread ------> "));
        task3.Start();

        Task task4 = new Task(() => GoPerfect(50001, 80000, "4rd thread ------> "));
        task4.Start();
        

        //GoPerfect(1, 50000, "Normal Loop");

        Console.WriteLine(" --------------------------- ");


        Console.ReadKey();

    }


    static bool PerfectNumbers(long n)
    {
        long s = 0;
        for (int i = 1; i <= n / 2 + 1; i++)
        {
            if (n % i == 0)
            {
                s += i;
            }
        }
        if (n == s) return true;
        else return false;
    }



    static void GoPerfect(int a, int b, string m)
    {
        Stopwatch sw = Stopwatch.StartNew();
        //string start = DateTime.Now.ToString("HH:mm:ss tt");

        Console.WriteLine(m + " - {0:f2} s", sw.Elapsed.TotalSeconds);

        for (int i = a; i <= b; i++)
        {
            if (PerfectNumbers(i))
            {
                Console.WriteLine(m + " - " + i);
            }
            //if (i % 1000 == 0) { Console.Write("."); }

        }

        //sw = Stopwatch.StartNew();
        //string stop = DateTime.Now.ToString("HH:mm:ss tt");
        Console.WriteLine(m + " - {0:f2} s", sw.Elapsed.TotalSeconds);

    }
}