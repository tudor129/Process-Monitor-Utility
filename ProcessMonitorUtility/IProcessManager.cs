using System.Diagnostics;

namespace ProcessMonitorUtility;

public interface IProcessManager
{
    Process[] GetProcessesByName(string name);
    void KillProcess(Process process);
}
