using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
//cambiar para que sea parallel for, no threads
class ThreadNaming
{
    static void Main()
    {

        //main threads
        GoPerfect(1, 120000, "Normal --> ");

        Console.WriteLine("---------------------");

        GoPerfectParallel(1, 120000, "Parallel --> ");

        Console.WriteLine("---------------------");

        Console.ReadKey();

    }

    static bool PerfectNumbersParallel(long n)
    {
        long s = 0;
        long m = n / 2 + 1;
        Parallel.For(1, m, i =>
        {
            if (n % i == 0)
            {
                s += i;
            }
        });

        if (n == s) return true;
        else return false;
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
        Console.WriteLine("PerfectNumber: {0:f2} s", sw.Elapsed.TotalSeconds);

        //string start = DateTime.Now.ToString("HH:mm:ss tt");
        //Console.WriteLine(m + " - " + start);
        for (int i = a; i <= b; i++)
        {
            if (PerfectNumbers(i))
            {
                Console.WriteLine(m + " - " + i);
            }
            //if (i % 1000 == 0) { Console.Write("."); }

        }
        Console.WriteLine("PerfectNumber: {0:f2} s", sw.Elapsed.TotalSeconds);
        //string stop = DateTime.Now.ToString("HH:mm:ss tt");
        //Console.WriteLine(m + " - " + stop);

    }

    static void GoPerfectParallel(int a, int b, string m)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Console.WriteLine("PerfectNumber: {0:f2} s", sw.Elapsed.TotalSeconds);

        //string start = DateTime.Now.ToString("HH:mm:ss tt");
        //Console.WriteLine(m + " - " + start);
        for (int i = a; i <= b; i++)
        {
            if (PerfectNumbersParallel(i))
            {
                Console.WriteLine(m + " - " + i);
            }
            //if (i % 1000 == 0) { Console.Write("."); }

        }
        Console.WriteLine("PerfectNumber: {0:f2} s", sw.Elapsed.TotalSeconds);
        //string stop = DateTime.Now.ToString("HH:mm:ss tt");
        //Console.WriteLine(m + " - " + stop);

    }
}
////////////////////////////////////////////////////////////////////////////////////////
///using System;
/*

class Test
{
    static void Main()
    {
        int[] nums = Enumerable.Range(0, 100).ToArray();

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 2 * i - 1;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine(nums[i]);
        }

        long total = 0;

        // Use type parameter to make subtotal a long, not an int
        Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
        {
            subtotal += nums[j];
            //Console.WriteLine(j + " " + nums[j] + " " + subtotal);
            return subtotal;
        },
            (x) => Interlocked.Add(ref total, x)
        );

        Console.WriteLine("The total is {0:N0}", total);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}
*/