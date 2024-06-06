using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemsLab
{
    internal class StemsC
    {
        public static void FindStemsVersionC(Dictionary<string, int> stems)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();

            int n = 30;
            List<Tuple<int, string, int>> popularStems = new List<Tuple<int, string, int>>();

            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            Task<List<Tuple<int, string, int>>> task1 = Task<List<Tuple<int, string, int>>>.Run(() => StemSearch(stems, queue));
            Task<List<Tuple<int, string, int>>> task2 = Task<List<Tuple<int, string, int>>>.Run(() => StemSearch(stems, queue));

            //Task.Run(() => StemSearch(stems, queue));

            for (int stemSize = 2; stemSize < n; stemSize++)
            {
                queue.Enqueue(stemSize);
            }

            //Task.Delay(1000).Wait();
            Task.WhenAll(task1, task2).Wait();

            popularStems.AddRange(task1.Result);
            popularStems.AddRange(task2.Result);
            popularStems.Sort();
            popularStems.ForEach(ps => Console.WriteLine($"Most popular stem of size {ps.Item1} is: {ps.Item2} (occurs {ps.Item3} times)"));

            stopwatch.Stop();

            Console.WriteLine("Process: " + stopwatch.Elapsed);


        }

        static List<Tuple<int, string, int>> StemSearch(Dictionary<string, int> stems, ConcurrentQueue<int> queue)
        {
            List<Tuple<int, string, int>> popularStems = new List<Tuple<int, string, int>>();

            int stemSize = 1;

            while (stemSize > 0 && queue.Count != 0)
            //---------------------------^^^^^----- BELT...
            {
                if (!queue.TryDequeue(out stemSize)) // ...and BRACES
                {
                    Console.WriteLine("Unsuccesful TryDequeue. Assume Queue has been emptied");
                    break;
                }

                string bestStem = "";
                int bestCount = 0;

                foreach (KeyValuePair<string, int> entry in stems)
                {
                    string stem = entry.Key;
                    int count = entry.Value;

                    if (stemSize == stem.Length && count > bestCount)
                    {
                        bestStem = stem;
                        bestCount = count;
                    }
                }

                if (!string.IsNullOrEmpty(bestStem))
                {
                    //Console.WriteLine($"Most popular stem of size {stemSize} is: {bestStem} (occurs {bestCount} times)");
                    popularStems.Add(new Tuple<int, string, int>(stemSize, bestStem, bestCount));

                }

            }
            return popularStems;
        }
    }
}
