using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.ValidateApiCommand.Core;

public class CheckApiReadyCommandexCommand : ResultCommandexCommand<bool>
{
    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Check API";

    public override string Description => "Check API ready to accept requests.";

    public override string Version => "1.0.0-beta.15.0";

    protected override bool Result { get; set; }

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        var value = Random.Shared.Next(0, 2);
        var boolValue = value switch
        {
            0 => "False",
            1 => "True",
            _ => throw new ArgumentOutOfRangeException()
        };

        Result = bool.Parse(boolValue);
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;
}
