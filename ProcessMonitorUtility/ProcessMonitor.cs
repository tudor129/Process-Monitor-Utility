
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
    
    public void MonitorSingleProcess(string name, int lifeTime, int frequency)
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
                    try
                    {
                        _console.WriteLine($"Process {name} has been running for too long. Killing it now.");
                        _processManager.KillProcess(process);
                    }
                    catch (Exception ex)
                    {
                        _console.WriteLine($"Failed to kill process {name}: {ex.Message}");
                    }
                }
            }
            Thread.Sleep(frequency * 1000);
        }
    }

    // This method should monitor multiple processes at the same time.
    // Should be called in the Main method instead of MonitorSingleProcess.
    // The arguments will be provided when calling the method, it does not work yet with user input.
    // Unit tests have not been provided for this method.
    public void MonitorMultipleProcesses(string[] names, int[] lifeTimes, int frequency)
    {
        _console.WriteLine("Press 'q' to quit monitoring.");

        List<Thread> threads = new List<Thread>();
        for (int i = 0; i < names.Length; i++)
        {
            int index = i;
            Thread thread = new Thread(() => MonitorSingleProcess(names[index], lifeTimes[index], frequency));
            threads.Add(thread);
            thread.Start();
        }

        while (true)
        {
            if (_console.KeyAvailable && _console.ReadKey().KeyChar == 'q')
            {
                foreach (var thread in threads)
                {
                    thread.Interrupt();
                }
                break;
            }
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }
}

