using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
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

    [Test]
    public void Should_Open_Save_Dialog()
    {
        var window = App.GetMainWindow(Automation);

        window.FindFirstDescendant(cf => cf.ByName("File"))?.AsButton()?.Invoke();

        Retry.WhileNull(() => Automation.GetDesktop().FindFirstDescendant(cf => cf.ByName("Save As")), TimeSpan.FromSeconds(5));

        var saveAs = window.FindFirstDescendant(
            cf => cf.ByText("Save As..."));

        Assert.That(saveAs, Is.Not.Null, "Could not find the 'Save As' menu item.");

        saveAs.Click();

        WaitHelper.WaitUntil(() =>
        {
            var saveWindow = Automation
                .GetDesktop()
                .FindFirstDescendant(
                    cf => cf.ByName("Save As"));
            return saveWindow != null;
        });

        var saveWindow = Automation
            .GetDesktop()
            .FindFirstDescendant(
                cf => cf.ByName("Save As"));

        Assert.That(saveWindow, Is.Not.Null);
    }
}