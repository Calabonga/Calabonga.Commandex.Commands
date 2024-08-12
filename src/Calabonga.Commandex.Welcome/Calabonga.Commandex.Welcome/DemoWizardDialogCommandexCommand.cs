using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.Welcome;

public class DemoWizardDialogCommandexCommand : WizardDialogCommandexCommand<DemoWizardViewModel>
{
    public DemoWizardDialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Demo Wizard";

    public override string Description => "Simple demo";

    public override string Version => "1.0.0-alpha.4";

}