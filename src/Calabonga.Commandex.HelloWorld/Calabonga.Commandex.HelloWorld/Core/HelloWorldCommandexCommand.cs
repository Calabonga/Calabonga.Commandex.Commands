using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.HelloWorld.Core;

/// <summary>
/// Empty command with no results for Shell
/// </summary>
public class HelloWorldCommandexCommand : EmptyCommandexCommand
{
    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Hello World";

    public override string Description => "Simplest command type for Commandex";

    public override string Version => "1.0.0-alpha.3";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;
}