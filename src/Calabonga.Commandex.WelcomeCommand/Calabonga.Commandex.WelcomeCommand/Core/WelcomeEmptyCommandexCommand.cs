using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;

namespace Calabonga.Commandex.WelcomeCommand.Core;

/// <summary>
/// // Calabonga: Summary required (WelcomeEmptyCommandexCommand 2024-08-11 11:20)
/// </summary>
public class WelcomeEmptyCommandexCommand : EmptyCommandexCommand
{
    private readonly ILogger<WelcomeEmptyCommandexCommand> _logger;

    public WelcomeEmptyCommandexCommand(ILogger<WelcomeEmptyCommandexCommand> logger) => _logger = logger;

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.3.0";

    public override bool IsPushToShellEnabled => true;

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        _logger.LogInformation("Command executed successfully {CommandName}", nameof(WelcomeEmptyCommandexCommand));
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Добро пожаловать в модульность (Empty)";

    public override string Description => "Это демонстрация реализации команды для Commandex без возврата данных";
}
