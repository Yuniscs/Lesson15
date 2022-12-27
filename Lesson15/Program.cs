using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine($"Start Program");
            var task1 = MethodAAsync();
            var task2 = MethodBAsync();
            var task3 = Task.Run(async () => await task1);
            var task4 = Task.Run(async () => await task2);
            Task.WaitAll(task1, task2);
            watch.Stop();
            Console.WriteLine($"Execution Time:{watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
        public static async Task<int> MethodAAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($" A{i}");
                await Task.Delay(500);
            }
            int result = 123;
            Console.WriteLine($" A returns result {result}");
            return result;
        }
        public static async Task<int> MethodBAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($" B{i}");
                await Task.Delay(500);
            }
            int result = 456;
            Console.WriteLine($" B returns result {result}");
            return result;
        }

    }
}
