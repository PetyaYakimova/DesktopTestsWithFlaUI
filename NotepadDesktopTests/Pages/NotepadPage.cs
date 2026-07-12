using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NotepadTests.Pages;

public class NotepadPage
{
    private readonly Window _window;
    private readonly UIA3Automation _automation;

    public NotepadPage(Window window, UIA3Automation automation)
    {
        _window = window;
        _automation = automation;
    }

    public TextBox Editor =>
        _window.FindFirstDescendant(
            cf => cf.ByControlType(ControlType.Document))
        ?.AsTextBox();

    public void EnterText(string text)
    {
        Editor.Enter(text);
    }

    public string GetText()
    {
        return Editor.Text;
    }

    public void PressFileMenu()
    {
        _window.FindFirstDescendant(cf => cf.ByName("File"))?.AsButton()?.Invoke();
    }

    public void PressSaveAs()
    {
        Retry.WhileNull(() => _automation.GetDesktop().FindFirstDescendant(cf => cf.ByName("Save As")), TimeSpan.FromSeconds(5));

        var saveAs = _window.FindFirstDescendant(
            cf => cf.ByText("Save As..."));

        saveAs.Click();
    }

    public AutomationElement? SaveWindow()
    {
        WaitHelper.WaitUntil(() =>
        {
            var saveWindow = _automation
                .GetDesktop()
                .FindFirstDescendant(
                    cf => cf.ByName("Save As"));
            return saveWindow != null;
        });

        var saveWindow = _automation
            .GetDesktop()
            .FindFirstDescendant(
                cf => cf.ByName("Save As"));

        return saveWindow;
    }
}