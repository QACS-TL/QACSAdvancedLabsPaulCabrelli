using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StemsLab
{
    internal class Timer
    {
        private static double startTime = 0;

        public static void StartTimer()
        {
            startTime = GetCpuTime();
        }

        public static void EndTimer(string txt = "End time")
        {
            if (startTime == 0)
            {
                throw new SystemException("EndTimer() called without a StartTimer()");
            }

            double endTime = GetCpuTime();
            Console.WriteLine($"{txt,-12}: {endTime - startTime:0.000} seconds");

            startTime = 0;
        }

        private static double GetCpuTime()
        {
            Process process = Process.GetCurrentProcess();
            TimeSpan cpuTime = process.TotalProcessorTime;
            return cpuTime.TotalSeconds;
        }
    }
}
