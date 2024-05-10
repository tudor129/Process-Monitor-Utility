using System.Diagnostics;

namespace ProcessMonitorUtility;

public class SystemProcessManager : IProcessManager
{
    public IProcessWrapper[] GetProcessesByName(string name)
    {
        return Process.GetProcessesByName(name).Select(p => new ProcessWrapper(p)).ToArray();
    }
    public void KillProcess(IProcessWrapper process)
    {
        process.Kill();
    }
}
