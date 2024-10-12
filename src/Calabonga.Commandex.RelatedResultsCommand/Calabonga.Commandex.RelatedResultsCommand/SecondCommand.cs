using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;

namespace Calabonga.Commandex.RelatedResultsCommand;

/// <summary>
/// 
/// </summary>
internal class SecondCommand : ParameterCommandexCommand<CreatedAtParameter>
{
    private readonly ILogger<SecondCommand> _logger;

    public SecondCommand(ILogger<SecondCommand> logger, IAppSettings appSettings) : base(appSettings) => _logger = logger;

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Second Command in the chain";

    public override string Description => "This is brief description about second command";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.3.0";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        _logger.LogDebug("Executing command in {Name}", GetType().Name);

        var parameter = ReadParameter();
        var result = parameter?.RandomData;
        if (!string.IsNullOrEmpty(result))
        {
            return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
        }

        if (parameter != null)
        {
            parameter.RandomData = "RND";
            _logger.LogDebug("Save Parameter in command {Name}", GetType().Name);
            WriteParameter(parameter);
        }

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;
}
