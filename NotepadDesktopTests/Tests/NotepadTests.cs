using FlaUI.Core.AutomationElements;
using NUnit.Framework;
using NotepadTests.Base;

namespace NotepadTests.Tests;

public class NotepadTests : TestBase
{
    [Test]
    public void Notepad_Should_Open()
    {
        var window = App.GetMainWindow(Automation);

        Assert.That(window, Is.Not.Null);
        Assert.That(window.Title, Does.Contain("Notepad"));
    }
}