using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using NotepadTests.Base;
using NotepadTests.Pages;

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
        string text = "Sample Text";

        var window = App.GetMainWindow(Automation);

        var page = new NotepadPage(window, Automation);

        page.EnterText(text);

        Assert.That(page.GetText(), Is.EqualTo(text));
    }

    [Test]
    public void Should_Open_Save_Dialog()
    {
        var window = App.GetMainWindow(Automation);

        var page = new NotepadPage(window, Automation);
        page.PressFileMenu();

        page.PressSaveAs();

        Assert.That(page.SaveWindow, Is.Not.Null);
    }
}