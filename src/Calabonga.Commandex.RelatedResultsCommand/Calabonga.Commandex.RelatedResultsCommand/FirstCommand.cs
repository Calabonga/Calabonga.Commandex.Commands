using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;

namespace Calabonga.Commandex.RelatedResultsCommand;

public class FirstCommand : ParameterCommandexCommand<CreatedAtParameter>
{
    private readonly ILogger<FirstCommand> _logger;

    public FirstCommand(
        ILogger<FirstCommand> logger,
        IAppSettings appSettings) : base(appSettings)
    {
        _logger = logger;
    }

    /// <summary>
    /// Author or copyright information
    /// </summary>
    public override string CopyrightInfo => "Calabonga SOFT � 2024";

    /// <summary>
    /// Display command name in command list 
    /// </summary>
    public override string DisplayName => "First Command in the chain";

    /// <summary>
    /// Brief information about what command created for
    /// </summary>
    public override string Description => "This is brief description about first command";

    /// <summary>
    /// Current command version info for identification
    /// </summary>
    public override string Version => "1.0.0-alpha.2";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        _logger.LogDebug("Executing command in {Name}", GetType().Name);

        Parameter = new CreatedAtParameter() { CreatedAt = DateTime.Now };

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }
}