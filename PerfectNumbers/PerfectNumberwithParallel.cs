using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ThreadNaming
{
    static void Main()
    {
	//initialize the normal loop versus the parallel loop where the first int is the start and the second int is the limit

        GoPerfect(1, 50000, "Normal Loop");

        Console.WriteLine(" --------------------------- ");

        GoPerfectParallel(1, 75000, "Parallel Loop");

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
    //the difference between both methods is the use of two longs in parallel and other kind of loop where the first two parameters specify the initial and final iteration values. 
    //The third parameter is where the local state is initialized
    static bool PerfectNumbersParallel(long n)
    {
        long s = 0;
        long k = n / 2 + 1;
        Parallel.For(1, k, i =>
        {
            if (n % i == 0)
            {
                s += i;
            }
        });
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

    static void GoPerfectParallel(int a, int b, string m)
    {
        Stopwatch sw = Stopwatch.StartNew();
        //string start = DateTime.Now.ToString("HH:mm:ss tt");

        Console.WriteLine(m + " - {0:f2} s", sw.Elapsed.TotalSeconds);

        for (int i = a; i <= b; i++)
        {
            if (PerfectNumbersParallel(i))
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
