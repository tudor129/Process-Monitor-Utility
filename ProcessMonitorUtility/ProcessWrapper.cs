using System.Diagnostics;

namespace ProcessMonitorUtility;

public class ProcessWrapper : IProcessWrapper
{
    readonly Process _process;

    public ProcessWrapper(Process process)
    {
        _process = process;
    }
    public string ProcessName
    {
        get
        {
            return _process.ProcessName;
        }
    }
    public DateTime StartTime
    {
        get
        {
            return _process.StartTime;
        }
    }

    public void Kill()
    {
        _process.Kill();
    }
}
