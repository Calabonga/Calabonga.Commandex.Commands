using Calabonga.Commandex.Engine;
using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Welcome;

public class WelcomeCommandexCommand : EmptyCommandexCommand<string>
{
    private readonly IAppSettings _appSettings;

    public WelcomeCommandexCommand(IAppSettings appSettings)
    {
        AppSettings = new CurrentAppSettings(appSettings.CommandsPath);
    }

    public override OperationEmpty<OpenDialogException> ExecuteCommand()
    {
        Result = AppSettings.Message;
        return Operation.Result();
    }

    public CurrentAppSettings AppSettings { get; }

    public override bool IsPushToShellEnabled => true;

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Добро пожаловать в модульность";

    public override string Description => "Это демонстрация по реализации команды для Commandex.";

    public override string Version => "1.0.0-beta.4";

    protected override string? Result { get; set; }
}