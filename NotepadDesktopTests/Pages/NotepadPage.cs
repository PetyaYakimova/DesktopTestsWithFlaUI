using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;

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
}