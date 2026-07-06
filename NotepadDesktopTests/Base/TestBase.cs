using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

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
        var window = App.GetMainWindow(Automation);

        App.Close();

        var saveDialog = Automation.GetDesktop()
            .FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Window));

        if (saveDialog != null)
        {
            var dontSaveButton = saveDialog.FindFirstDescendant(cf =>
                cf.ByName("Don't Save"));

            dontSaveButton?.AsButton().Invoke();
        }

        Automation.Dispose();
    }
}