using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.ValidateApiCommand.Core;

public class CheckApiReadyCommandexCommand : ResultCommandexCommand<bool>
{
    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Check API";

    public override string Description => "Это имитация запроса на некий выдуманный API сервис для демонстрации работы команды Commandex Framework.";

    public override string Version => "1.0.0-beta.16.0";

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
