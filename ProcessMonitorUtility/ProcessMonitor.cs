using System;
using System.Threading;

namespace ProcessMonitorUtility;

public class ProcessMonitor
{
    readonly IConsole _console;
    readonly IProcessManager _processManager;

    public ProcessMonitor(IConsole console, IProcessManager processManager)
    {
        _console = console;
        _processManager = processManager;
    }

    public void MonitorProcess(string name, int lifeTime, int frequency)
    {
        _console.WriteLine("Press 'q' to quit monitoring.");

        while (true)
        {
            var processes = _processManager.GetProcessesByName(name);
            
            if (_console.KeyAvailable && _console.ReadKey().KeyChar == 'q')
                break;

            foreach (var process in processes)
            {
                double runningTime = (DateTime.Now - process.StartTime).TotalMinutes;
                _console.WriteLine($"Checking process {process.ProcessName} running for {runningTime} minutes.");
                
                if (runningTime > lifeTime)
                {
                    _console.WriteLine($"Process {name} has been running for too long. Killing it now.");
                    _processManager.KillProcess(process);
                }
            }
            Thread.Sleep(frequency * 1000);
        }
        
        /*Console.WriteLine("Enter the name of the process you want to monitor: ");
        name = Console.ReadLine();

        Console.WriteLine("Enter the maximum life time of the process in minutes: ");
        if (!int.TryParse(Console.ReadLine(), out lifeTime) || lifeTime <= 0)
        {
            Console.WriteLine("Invalid input for maximum life time.");
            return;
        }

        Console.WriteLine("Enter the frequency of checks in seconds: ");
        if (!int.TryParse(Console.ReadLine(), out frequency) || frequency <= 0)
        {
            Console.WriteLine("Invalid input for check frequency.");
            return;
        }

        Console.WriteLine("Press 'q' to quit monitoring.");
        while (true)
        {
            var processes = Process.GetProcessesByName(name);
            
            if (Console.KeyAvailable && Console.ReadKey().KeyChar == 'q')
                break;

            foreach (var process in processes)
            {
                Console.WriteLine("Checking process..." +
                                  process.ProcessName + " that is running for " +
                                  (DateTime.Now - process.StartTime).TotalMinutes + " minutes, and current time " +
                                  DateTime.Now + " and max life time " +
                                  lifeTime + " minutes.");
                if ((DateTime.Now - process.StartTime).TotalMinutes > lifeTime)
                {
                    Console.WriteLine($"Process {name} has been running for too long. Killing it now.");
                    process.Kill();
                }
            }
            Thread.Sleep(frequency * 1000);
        }*/
    }
}

