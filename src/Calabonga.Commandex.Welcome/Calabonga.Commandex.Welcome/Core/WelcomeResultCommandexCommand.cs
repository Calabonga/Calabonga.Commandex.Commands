using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Welcome.Core.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.Welcome.Core;

/// <summary>
/// // Calabonga: Summary required (WelcomeCommandexCommand 2024-08-11 10:49)
/// </summary>
public class WelcomeResultCommandexCommand : ResultCommandexCommand<string>
{
    public WelcomeResultCommandexCommand(
        [FromKeyedServices(nameof(WelcomeAppDefinition))]
        CurrentAppSettings appSettings)
        => AppSettings = appSettings;


    public CurrentAppSettings AppSettings { get; }

    public override bool IsPushToShellEnabled => true;

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        Result = AppSettings.Message;
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Добро пожаловать в модульность (Result)";

    public override string Description => "Это демонстрация по реализации команды для Commandex с результатом";

    public override string Version => "1.0.0-beta.9";

    protected override string? Result { get; set; }
}