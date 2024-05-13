using ProcessMonitorUtility;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;

namespace ProcessMonitorUtility;
public class Program
{
    static string name;
    static int lifeTime;
    static int frequency;
    
    public static void Main()
    {
        Console.WriteLine("Enter the name of the process you want to monitor: ");
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

        var console = new RealConsole();
        var processManager = new SystemProcessManager();
        var processMonitor = new ProcessMonitor(console, processManager);

        processMonitor.MonitorSingleProcess(name, lifeTime, frequency);
        
        // string[] processNames = new string[]{ "explorer", "notepad" };
        // int[] lifetimes = new int[]{ 1, 2 };
        // int frequency = 1;
        
        //processMonitor.MonitorMultipleProcesses(processNames, lifetimes, frequency);
    }

}
