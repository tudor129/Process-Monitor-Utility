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
        
        processMonitor.MonitorProcess("notepad", 1, 1);
    }
}
