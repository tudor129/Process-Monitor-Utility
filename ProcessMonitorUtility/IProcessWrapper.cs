namespace ProcessMonitorUtility;

public interface IProcessWrapper
{
    string ProcessName
    {
        get;
    }

    DateTime StartTime
    {
        get;
    }
    void Kill();
}
