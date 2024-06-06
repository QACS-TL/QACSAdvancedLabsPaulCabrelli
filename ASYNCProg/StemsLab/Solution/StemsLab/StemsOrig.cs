using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace StemsLab
{
    public class StemsOrig
    {
        public static void FindStemsOriginalVersion(Dictionary<string, int> stems)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Reset();
            stopwatch.Start();

            int n = 30;

            for (int stem_size = 2; stem_size <= n + 1; stem_size++)
            {
                string best_stem = "";
                int best_count = 0;

                foreach (KeyValuePair<string, int> entry in stems)
                {
                    string stem = entry.Key;
                    int count = entry.Value;

                    if (stem_size == stem.Length && count > best_count)
                    {
                        best_stem = stem;
                        best_count = count;
                    }
                }

                if (!string.IsNullOrEmpty(best_stem))
                {
                    Console.WriteLine("Most popular stem of size " + stem_size + " is: " + best_stem + " (occurs " + best_count + " times)");
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Process: " + stopwatch.Elapsed);
        }
    }
}
