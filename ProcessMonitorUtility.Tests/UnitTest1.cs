using Moq;
using System.Diagnostics;


namespace ProcessMonitorUtility.Tests;
public class Tests : ProcessMonitor
{
    public Tests(IConsole console, IProcessManager processManager) : base(console, processManager)
    {
        
    }

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void TestProcessMonitor_KillsProcessAfterLifetime()
    {
       var consoleMock = new Mock<IConsole>();
       var processManagerMock = new Mock<IProcessManager>();
       var processMock = new Mock<Process>();
       
       processMock.Setup(p => p.ProcessName).Returns("notepad");
       processMock.Setup(p => p.StartTime).Returns(DateTime.Now.AddMinutes(-1));
       processManagerMock.Setup(m => m.GetProcessesByName("notepad")).Returns(new Process[]
       {
           processMock.Object
       });
       consoleMock.Setup(m => m.ReadKey()).Returns(new ConsoleKeyInfo('q', ConsoleKey.Q, false, false, false));
       consoleMock.Setup(m => m.KeyAvailable).Returns(true);
       
       var monitor = new ProcessMonitor(consoleMock.Object, processManagerMock.Object);
       
       //Act
       monitor.MonitorProcess("notepad", 1, 1);
       //Assert
       processManagerMock.Verify(m => m.KillProcess(processMock.Object), Times.Once);
       
    }
}
