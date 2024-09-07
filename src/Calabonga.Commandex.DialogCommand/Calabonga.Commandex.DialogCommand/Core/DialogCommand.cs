using Calabonga.Commandex.DialogCommand.Core.ViewModels;
using Calabonga.Commandex.DialogCommand.Core.Views;
using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.DialogCommand.Core;

public class DialogCommand : DialogCommandexCommand<DemoDialogView, DemoDialogResult>
{
    public DialogCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Dialog Demo";

    public override string Description => "Демонстрация диалогового окна в Commandex";

    public override string Version => "1.0.0-beta.2"; //semver.org

    public override bool IsPushToShellEnabled => true;
}