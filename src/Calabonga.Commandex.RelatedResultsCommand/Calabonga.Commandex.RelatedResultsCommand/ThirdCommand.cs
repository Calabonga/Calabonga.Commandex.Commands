using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Processors.Results;
using Calabonga.Commandex.Engine.Settings;
using Calabonga.OperationResults;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Reflection;

namespace Calabonga.Commandex.RelatedResultsCommand;

public class ThirdCommand : ParameterCommandexCommand<CreatedAtParameter>
{
    private readonly ILogger<ThirdCommand> _logger;

    public ThirdCommand(ILogger<ThirdCommand> logger, IAppSettings appSettings) : base(appSettings) => _logger = logger;

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Third Command in the chain";

    public override string Description => "This is brief description about third command";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var parameter = ReadParameter();

        _logger.LogInformation("Date {Date} with {Data}", parameter?.CreatedAt, parameter?.RandomData);

        ClearParameter();

        _logger.LogInformation("Parameter data removed");

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;

    public override object? GetResult()
    {
        var parameter = ReadParameter();
        var data = JsonSerializer.Serialize(parameter, JsonSerializerOptionsExt.Cyrillic);
        return new ClipboardResult(data);
    }
}
