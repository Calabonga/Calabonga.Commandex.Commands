using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;

namespace Calabonga.Commandex.RelatedResultsCommand;

public class ThirdCommand : ParameterCommandexCommand<CreatedAtParameter>
{
    private readonly ILogger<ThirdCommand> _logger;

    public ThirdCommand(ILogger<ThirdCommand> logger, IAppSettings appSettings) : base(appSettings)
    {
        _logger = logger;
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Third Command in the chain";

    public override string Description => "This is brief description about third command";

    public override string Version => "1.0.0-alpha.13";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        _logger.LogInformation("Date {Date} with {Data}", Parameter?.CreatedAt, Parameter?.RandomData);

        ClearParameter();

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;
}