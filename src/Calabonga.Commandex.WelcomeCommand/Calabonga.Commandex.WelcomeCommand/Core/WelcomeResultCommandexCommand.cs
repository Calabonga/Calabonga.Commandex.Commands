using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.WelcomeCommand.Core.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.WelcomeCommand.Core;

/// <summary>
/// // Calabonga: Summary required (WelcomeCommandexCommand 2024-08-11 10:49)
/// </summary>
public class WelcomeResultCommandexCommand : ResultCommandexCommand<string>
{
    public WelcomeResultCommandexCommand(
        [FromKeyedServices(nameof(WelcomeCommandDefinition))]
        CurrentAppSettings appSettings)
        => AppSettings = appSettings;


    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.3.0";

    public CurrentAppSettings AppSettings { get; }

    public override bool IsPushToShellEnabled => true;

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        Result = AppSettings.Message;
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Добро пожаловать в модульность (Result)";

    public override string Description => "Это демонстрация реализации команды для Commandex с результатом";

    protected override string? Result { get; set; }
}
