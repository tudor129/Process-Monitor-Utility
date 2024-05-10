namespace ProcessMonitorUtility;

public interface IConsole
{
    void WriteLine(string message);
    string ReadLine();
    ConsoleKeyInfo ReadKey();
    bool KeyAvailable { get; }
}
