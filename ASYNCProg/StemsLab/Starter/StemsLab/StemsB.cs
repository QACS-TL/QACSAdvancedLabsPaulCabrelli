using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemsLab
{
    public class StemsB
    {
        public static void FindStemsVersionB(Dictionary<string, int> stems)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();
                
            int n = 30;
            List<Tuple<int, string, int>> popularStems = new List<Tuple<int, string, int>>();

            //Task<List<Tuple<int, string, int>>> task1 = Task<List<Tuple<int, string, int>>>.Factory.StartNew(() => StemSearch(stems, 2, n / 2 + 1));
            //Task<List<Tuple<int, string, int>>> task2 = Task<List<Tuple<int, string, int>>>.Factory.StartNew(() => StemSearch(stems, n / 2 + 1, n + 1));
            Task<List<Tuple<int, string, int>>> task1 = Task.Run(() => StemSearch(stems, 2, n / 2 + 1));
            Task<List<Tuple<int, string, int>>> task2 = Task.Run(() => StemSearch(stems, n / 2 + 1, n + 1));

            Task.WhenAll(task1, task2).Wait();
            popularStems.AddRange(task1.Result);
            popularStems.AddRange(task2.Result);

            popularStems.ForEach(ps => Console.WriteLine($"Most popular stem of size {ps.Item1} is: {ps.Item2} (occurs {ps.Item3} times)"));

            stopwatch.Stop();
            Console.WriteLine("Process: " + stopwatch.Elapsed);

        }

        static List<Tuple<int, string, int>> StemSearch(Dictionary<string, int> stems, int start, int end)
        {
            List<Tuple<int, string, int>> popularStems = new List<Tuple<int, string, int>>();
            for (int stemSize = start; stemSize < end; stemSize++)
            {
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
                    // Will be printed out of order because tasks will complete randomly
                    //Console.WriteLine($"Most popular stem of size {stemSize} is: {bestStem} (occurs {bestCount} times)");
                    popularStems.Add(new Tuple<int, string, int>(stemSize, bestStem, bestCount));
                }
            }
            return popularStems;
        }
    }
}
