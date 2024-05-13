using Moq;
using System.Diagnostics;


namespace ProcessMonitorUtility.Tests;


[TestFixture]
public class Tests
{
    Mock<IConsole> _consoleMock;
    Mock<IProcessManager> _processManagerMock;
    ProcessMonitor _monitor;
   
    [SetUp]
    public void Setup()
    {
        _consoleMock = new Mock<IConsole>();
        _processManagerMock = new Mock<IProcessManager>();
        
        _consoleMock.Setup(m => m.ReadKey()).Returns(new
                ConsoleKeyInfo(
                'q', 
                ConsoleKey.Q, 
                false, 
                false, 
                false
                ));
        _consoleMock.Setup(m => m.KeyAvailable).Returns(true);
        
        _monitor = new ProcessMonitor(_consoleMock.Object, _processManagerMock.Object);
    }

    [Test]
    public void TestProcessMonitor_KillsProcessAfterLifetime()
    {
        var processMock = new Mock<IProcessWrapper>();
        processMock.Setup(p => p.ProcessName).Returns("notepad");
        processMock.Setup(p => p.StartTime).Returns(DateTime.Now.AddMinutes(-1));
        
        _processManagerMock.Setup(m => m.GetProcessesByName("notepad")).Returns(new[]
        {
            processMock.Object
        });
        
        _consoleMock.SetupSequence(m => m.KeyAvailable)
            .Returns(false)
            .Returns(true);
        
        
        //Act
        _monitor.MonitorSingleProcess("notepad", 1, 1);
        //Assert
        _processManagerMock.Verify(m => m.KillProcess(processMock.Object), Times.Once);
    }
}
