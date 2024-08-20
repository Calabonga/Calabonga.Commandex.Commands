using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;

namespace Calabonga.Commandex.RelatedResultsCommand;

/// <summary>
/// 
/// </summary>
public class SecondCommand : ParameterCommandexCommand<CreatedAtParameter>
{
    private readonly ILogger<SecondCommand> _logger;

    public SecondCommand(ILogger<SecondCommand> logger, IAppSettings appSettings) : base(appSettings)
    {
        _logger = logger;
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Second Command in the chain";

    public override string Description => "This is brief description about second command";

    public override string Version => "1.0.0-alpha.1";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        _logger.LogDebug("Executing command in {Name}", GetType().Name);

        var result = Parameter?.RandomData;
        if (!string.IsNullOrEmpty(result))
        {
            return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
        }

        if (Parameter != null)
        {
            Parameter.RandomData = "RND";
            _logger.LogDebug("Save Parameter in command {Name}", GetType().Name);
            SaveParameter();
        }

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }
}