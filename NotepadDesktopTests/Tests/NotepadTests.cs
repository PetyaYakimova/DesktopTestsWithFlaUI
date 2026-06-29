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

    [Test]
    public void Should_Type_Text()
    {
        var window = App.GetMainWindow(Automation);

        var editor = window.FindFirstDescendant(
            cf => cf.ByControlType(
                FlaUI.Core.Definitions.ControlType.Document))
            .AsTextBox();

        editor.Enter("Hello FlaUI");

        Assert.That(editor.Text,
            Is.EqualTo("Hello FlaUI"));
    }
}