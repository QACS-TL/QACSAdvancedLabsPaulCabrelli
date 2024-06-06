

using StemsLab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Dictionary<string, int> stems = GenerateStemsDictionary();
        //StemsOrig.FindStems(stems);
        //StemsA.FindStemsVersionA(stems);
        //StemsB.FindStemsVersionB(stems);
        StemsC.FindStemsVersionC(stems);
    }

    private static Dictionary<string, int> GenerateStemsDictionary()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Dictionary<string, int> stems = new Dictionary<string, int>();
        using (StreamReader sr = new StreamReader("words"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                for (int count = 1; count <= line.Length; count++)
                {
                    string stem = line.Substring(0, count);
                    if (stems.ContainsKey(stem))
                    {
                        stems[stem]++;
                    }
                    else
                    {
                        stems[stem] = 1;
                    }
                    //Console.WriteLine("stem:" + stem + "value:<" + stems[stem] + ">");
                }
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"Load: {stopwatch.Elapsed}: stems contains {stems.Count} entries");
        return stems;
    }
}

