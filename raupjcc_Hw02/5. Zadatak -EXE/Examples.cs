using _5.zadatak;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5.Zadatak__EXE
{
    class Examples
    {   /*
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            LongOperationClass.LongOperation("A");
            LongOperationClass.LongOperation("B");
            LongOperationClass.LongOperation("C");
            LongOperationClass.LongOperation("D");
            LongOperationClass.LongOperation("E");
            stopwatch.Stop();
            Console.WriteLine(" Synchronous long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();
        } 

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(() => LongOperationClass.LongOperation("A"),
            () => LongOperationClass.LongOperation("B"),
            () => LongOperationClass.LongOperation("C"),
            () => LongOperationClass.LongOperation("D"),
            () => LongOperationClass.LongOperation("E"));
            stopwatch.Stop();
            Console.WriteLine(" Parallel long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();
        } 

        static void Main(string[] args)
        {
            int counter = 0;
            Parallel.For(0, 100000, (i) =>
           {
               Thread.Sleep(1);
               counter += 1;
           });
            Console.WriteLine(" Counter should be 100000. Counter is {0}", counter);
            Console.ReadLine();
        } 

        static void Main(string[] args)
        {
            int counter = 0;
            object objectUsedForLock = new object();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                lock (objectUsedForLock)
                {
                    counter += 1;
                }
            });
            Console.WriteLine(" Counter should be 100000. Counter is {0}", counter);
            Console.ReadLine();
        } 

        static void Main(string[] args)
        {
            List<int> results = new List<int>();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                results.Add(i * i);
            });
            Console.WriteLine("Bag length should be 100000. Length is {0}", results.Count);
            Console.ReadLine();
        } */

        static void Main(string[] args)
        {
            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                iterations.Add(i);
            });
            Console.WriteLine("Bag length should be 100000. Length is {0}", iterations.Count);
            Console.ReadLine();
        }
    }
}
