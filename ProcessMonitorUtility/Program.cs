using ProcessMonitorUtility;
using System;
using System.Diagnostics;

namespace ProcessMonitorUtility;
public class Program
{
    public static void Main()
    {
        var console = new RealConsole();
        var processManager = new SystemProcessManager();
        var processMonitor = new ProcessMonitor(console, processManager);
        
        processMonitor.MonitorSingleProcess("notepad", 1, 1);
        
        
        string[] processNames = new string[]{ "explorer", "notepad" };
        int[] lifetimes = new int[]{ 1, 2 };
        int frequency = 1;
        
        //processMonitor.MonitorProcesses(processNames, lifetimes, frequency);
    }
}
