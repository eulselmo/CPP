using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleForLoop
{
    class Program
    {
        static void Main()
        {

            double[] array = new double[200 * 1000 * 1000];

            for (int i = 0; i < array.Length; i++)
                array[i] = 1;

            for (int i = 0; i < 5; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Serial(array, 2);
                Console.WriteLine("Serial: {0:f2} s", sw.Elapsed.TotalSeconds);

                sw = Stopwatch.StartNew();
                ParallelFor(array, 2);
                Console.WriteLine("Parallel.For: {0:f2} s", sw.Elapsed.TotalSeconds);

            }

            Console.ReadKey();
        }


        static void Serial(double[] array, double factor)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * factor;
            }

        }

        static void ParallelFor(double[] array, double factor)
        {
            Parallel.For(
                0, array.Length, i => { array[i] = array[i] * factor; });
        }

    }
}
