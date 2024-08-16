using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Welcome.Core.ViewModels;

namespace Calabonga.Commandex.Welcome.Core;

public class PersonWizardDialogCommandexCommand : WizardDialogCommandexCommand<PersonWizardDialogViewModel>
{
    public PersonWizardDialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Person Wizard";

    public override string Description => "Wizard with some steps which need to be validated.";

    public override string Version => "1.0.0-beta.9";

    public override bool IsPushToShellEnabled => true;

    protected override PersonWizardDialogViewModel SetResult(PersonWizardDialogViewModel result) => result;
}