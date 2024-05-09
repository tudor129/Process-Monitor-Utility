using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessMonitorUtility;

public class ProcessMonitor
{
    public static void MonitorProcess()
    {
        Console.WriteLine("Enter the name of the process you want to monitor: ");
        string processName = Console.ReadLine();

        Console.WriteLine("Enter the maximum life time of the process in minutes: ");
        if (!int.TryParse(Console.ReadLine(), out int maxLifeTime) || maxLifeTime <= 0)
        {
            Console.WriteLine("Invalid input for maximum life time.");
            return;
        }

        Console.WriteLine("Enter the frequency of checks in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out int checkFrequency) || checkFrequency <= 0)
        {
            Console.WriteLine("Invalid input for check frequency.");
            return;
        }

        Console.WriteLine("Press 'q' to quit monitoring.");
        while (true)
        {
            var processes = Process.GetProcessesByName(processName);
            
            if (Console.KeyAvailable && Console.ReadKey().KeyChar == 'q')
                break;

            foreach (var process in processes)
            {
                Console.WriteLine("Checking process..." +
                                  process.ProcessName + " that is running for " +
                                  (DateTime.Now - process.StartTime).TotalMinutes + " minutes, and current time " +
                                  DateTime.Now + " and max life time " +
                                  maxLifeTime + " minutes.");
                if ((DateTime.Now - process.StartTime).TotalMinutes > maxLifeTime)
                {
                    Console.WriteLine($"Process {processName} has been running for too long. Killing it now.");
                    process.Kill();
                }
            }
            Thread.Sleep(checkFrequency * 1000);
        }
    }
}
