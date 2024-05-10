namespace ProcessMonitorUtility;

public class RealConsole : IConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    public string ReadLine()
    {
       return Console.ReadLine();
    }
    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }
    public bool KeyAvailable
    {
        get
        {
            return Console.KeyAvailable;
        }
    }
}
