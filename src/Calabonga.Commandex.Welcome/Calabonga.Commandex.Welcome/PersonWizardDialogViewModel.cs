using Calabonga.Commandex.Engine.Wizards;

namespace Calabonga.Commandex.Welcome;

/// <summary>
/// // Calabonga: Summary required (PersonWizardDialogViewModel 2024-08-13 11:45)
/// </summary>
public class PersonWizardDialogViewModel : WizardDialogViewModel<PersonViewModel>
{
    public PersonWizardDialogViewModel(IWizardStepManager manager) : base(manager)
    {
        Title = "Демонстрация Wizard";
    }

    protected override PersonViewModel InitializeContext() => new();
}