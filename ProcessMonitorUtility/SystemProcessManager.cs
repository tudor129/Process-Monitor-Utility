using System.Diagnostics;

namespace ProcessMonitorUtility;

public class SystemProcessManager : IProcessManager
{
    public Process[] GetProcessesByName(string name)
    {
        return Process.GetProcessesByName(name);
    }
    public void KillProcess(Process process)
    {
        process.Kill();
    }
}
