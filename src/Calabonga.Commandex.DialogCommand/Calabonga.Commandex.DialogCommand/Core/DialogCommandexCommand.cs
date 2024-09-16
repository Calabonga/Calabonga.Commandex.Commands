using Calabonga.Commandex.DialogCommand.Core.ViewModels;
using Calabonga.Commandex.DialogCommand.Core.Views;
using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.DialogCommand.Core;

public class DialogCommandexCommand : DialogCommandexCommand<DemoDialogView, DemoDialogResult>
{
    public DialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Команда в диалоговом окне";

    public override string Description => "Демонстрация открытия команды в диалоговом окне Commandex Framework.";

    public override string Version => "1.0.0-beta.16.0"; //semver.org

    public override bool IsPushToShellEnabled => true;
}