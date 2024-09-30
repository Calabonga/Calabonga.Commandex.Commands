﻿using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.WelcomeCommand.Core.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Calabonga.Commandex.WelcomeCommand.Core;

/// <summary>
/// // Calabonga: Summary required (WelcomeEmptyCommandexCommand 2024-08-11 11:20)
/// </summary>
public class WelcomeEmptyCommandexCommand : EmptyCommandexCommand
{
    private readonly ILogger<WelcomeEmptyCommandexCommand> _logger;

    public WelcomeEmptyCommandexCommand(
        [FromKeyedServices(nameof(WelcomeCommandDefinition))] CurrentAppSettings appSettings,
        ILogger<WelcomeEmptyCommandexCommand> logger)
    {
        _logger = logger;
        AppSettings = appSettings;
    }

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.0.0";

    public CurrentAppSettings AppSettings { get; }

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