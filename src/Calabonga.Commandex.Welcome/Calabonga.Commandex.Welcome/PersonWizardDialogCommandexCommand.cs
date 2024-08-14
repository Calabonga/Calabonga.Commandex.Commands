using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.Welcome;

public class PersonWizardDialogCommandexCommand : WizardDialogCommandexCommand<PersonWizardDialogViewModel>
{
    public PersonWizardDialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Demo Wizard";

    public override string Description => "Simple demo";

    public override string Version => "1.0.0-alpha.5";
}