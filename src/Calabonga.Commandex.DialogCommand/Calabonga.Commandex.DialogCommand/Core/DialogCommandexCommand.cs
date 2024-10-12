using Calabonga.Commandex.DialogCommand.Core.ViewModels;
using Calabonga.Commandex.DialogCommand.Core.Views;
using Calabonga.Commandex.Engine.Commands;
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

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.3.0";

    public override bool IsPushToShellEnabled => true;
}
