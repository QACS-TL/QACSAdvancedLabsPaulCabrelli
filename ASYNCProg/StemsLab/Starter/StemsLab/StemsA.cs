using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StemsLab
{
    public class StemsA
    {
        public static void FindStemsVersionA(Dictionary<string, int> stems)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();

            int n = 30;
            List<Task<Tuple<int, string, int>>> tasks = new List<Task<Tuple<int, string, int>>>();
            List<Tuple<int, string, int>> popularStems = new List<Tuple<int, string, int>>();

            for (int stemSize = 2; stemSize <= n; stemSize++)
            {
                int size = stemSize; // Avoid capturing loop variable
                Task<Tuple<int, string, int>> task = Task.Run(() => StemSearch(stems, size));
                tasks.Add(task);
            }

            Task.WhenAll(tasks).Wait();

            tasks.ForEach(t => popularStems.Add(t.Result));

            //for (int i=0; i< popularStems.Count; i++)
            //{
            //    if (popularStems[i] != null)
            //        Console.WriteLine($"Most popular stem of size {popularStems[i].Item1} is: {popularStems[i].Item2} (occurs {popularStems[i].Item3} times)");
            //}

            foreach (var tuple in popularStems)
            {
                if (tuple != null)
                    Console.WriteLine($"Most popular stem of size {tuple.Item1} is: {tuple.Item2} (occurs {tuple.Item3} times)");
            }
                //Doesn't work because some elements (positions 0 and 1 are null)
                //popularStems.ForEach(ps => Console.WriteLine($"Most popular stem of size {ps.Item1} is: {ps.Item2} (occurs {ps.Item3} times)"));

                stopwatch.Stop();
            Console.WriteLine("Process: " + stopwatch.Elapsed);
        }

        static Tuple<int, string, int> StemSearch(Dictionary<string, int> stems, int stemSize)
        {
            string bestStem = "";
            int bestCount = 0;
            Tuple<int, string, int> val = null;

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
                //popularStems.Add(new Tuple<int, string, int>(stemSize, bestStem, bestCount) );
                val = new Tuple<int, string, int>(stemSize, bestStem, bestCount);
            }
            return val;
        }
    }
}
