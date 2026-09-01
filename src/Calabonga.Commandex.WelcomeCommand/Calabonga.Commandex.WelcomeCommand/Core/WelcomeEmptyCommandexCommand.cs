using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Calabonga.Commandex.WelcomeCommand.Core;

/// <summary>
/// Demo command that completes without returning any data (logs execution only).
/// </summary>
public sealed class WelcomeEmptyCommandexCommand : EmptyCommandexCommand
{
    private readonly ILogger<WelcomeEmptyCommandexCommand> _logger;

    public WelcomeEmptyCommandexCommand(ILogger<WelcomeEmptyCommandexCommand> logger) => _logger = logger;

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

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
