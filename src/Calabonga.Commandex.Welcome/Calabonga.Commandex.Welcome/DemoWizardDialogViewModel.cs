using Calabonga.Commandex.Engine.Wizards;

namespace Calabonga.Commandex.Welcome;

public class DemoWizardDialogViewModel : WizardDialogViewModel
{
    public DemoWizardDialogViewModel(IWizardStepManager manager) : base(manager)
    {
        Title = "Демонстрация Wizard";
    }
}