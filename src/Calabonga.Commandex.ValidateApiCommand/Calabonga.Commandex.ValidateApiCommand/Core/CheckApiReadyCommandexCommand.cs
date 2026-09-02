using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using System.Reflection;

namespace Calabonga.Commandex.ValidateApiCommand.Core;

public sealed class CheckApiReadyCommandexCommand : ResultCommandexCommand<bool>
{
    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Check API";

    public override string Description => "Это имитация запроса на некий выдуманный API сервис для демонстрации работы команды Commandex Framework.";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

    protected override bool Result { get; set; }

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        Result = Random.Shared.Next(0, 2) == 1;
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;
}
