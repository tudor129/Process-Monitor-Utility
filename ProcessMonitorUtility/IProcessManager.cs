using System.Diagnostics;

namespace ProcessMonitorUtility;

public interface IProcessManager
{
    IProcessWrapper[] GetProcessesByName(string name);
    void KillProcess(IProcessWrapper process);
}
