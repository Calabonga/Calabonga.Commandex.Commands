using Calabonga.Commandex.Engine;
using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Welcome;

public class WelcomeCommandexCommand : EmptyCommandexCommand<string>
{
    public WelcomeCommandexCommand(IAppSettings appSettings)
        => AppSettings = new CurrentAppSettings(appSettings.CommandsPath);

    public CurrentAppSettings AppSettings { get; }

    public override bool IsPushToShellEnabled => true;

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        Result = AppSettings.Message;
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Добро пожаловать в модульность";

    public override string Description => "Это демонстрация по реализации команды для Commandex.";

    public override string Version => "1.0.0-beta.5";

    protected override string? Result { get; set; }
}