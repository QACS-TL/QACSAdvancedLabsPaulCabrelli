using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace StemsLab
{
    public class StemsOrig
    {
        public static void FindStems(Dictionary<string, int> stems)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();

            int n = 30;

            for (int stemSize = 2; stemSize <= n + 1; stemSize++)
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
                    Console.WriteLine("Most popular stem of size " + stemSize + " is: " + bestStem + " (occurs " + bestCount + " times)");
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Process: " + stopwatch.Elapsed);
        }
    }
}
