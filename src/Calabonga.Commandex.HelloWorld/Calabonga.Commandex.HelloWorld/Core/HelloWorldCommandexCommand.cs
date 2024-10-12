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

    public override string Description => "Самый простой тип команды, которая есть в Commandex Framework. Команда ничего не возвращает полезного, только ошибку если она случиться.";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.3.0";

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
        => Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());

    public override bool IsPushToShellEnabled => true;
}
