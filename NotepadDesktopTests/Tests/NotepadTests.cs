using FlaUI.Core.AutomationElements;
using NotepadTests.Base;
using NotepadTests.Pages;
using NUnit.Framework;

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

    [Test]
    public void Should_Type_Text()
    {
        var window = App.GetMainWindow(Automation);

        var page = new NotepadPage(window, Automation);

        page.EnterText("Github Sample");

        Assert.That(page.GetText(),
            Is.EqualTo("Github Sample"));
    }
}