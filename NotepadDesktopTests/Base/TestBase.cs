using FlaUI.Core;
using FlaUI.UIA3;
using NUnit.Framework;

namespace NotepadTests.Base;

public class TestBase
{
    protected Application App;
    protected UIA3Automation Automation;

    [SetUp]
    public void Setup()
    {
        App = Application.Launch("notepad.exe");
        Automation = new UIA3Automation();
    }

    [TearDown]
    public void TearDown()
    {
        Automation?.Dispose();

        if (App != null && !App.HasExited)
        {
            App.Close();
        }
    }
}