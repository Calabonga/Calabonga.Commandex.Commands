using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.Welcome;

public class PersonWizardDialogCommandexCommand : WizardDialogCommandexCommand<PersonWizardDialogViewModel>
{
    public PersonWizardDialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Person Wizard";

    public override string Description => "Wizard with some steps which need to be validated.";

    public override string Version => "1.0.0-beta.7";

    public override bool IsPushToShellEnabled => true;

    protected override PersonWizardDialogViewModel SetResult(PersonWizardDialogViewModel result) => result;
}