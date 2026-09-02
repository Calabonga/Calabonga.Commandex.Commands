using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using System.Reflection;

namespace Calabonga.Commandex.ValidateApiCommand.Core;

public sealed class ValidateDocumentCommandexCommand : ResultCommandexCommand<ValidateResult>
{
    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Validate Document";

    public override string Description => "Это имитация валидации некоторого значения с возвратом более сложного объекта как результат для демонстрации работы команды Commandex Framework.";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

    protected override ValidateResult? Result { get; set; }

    public override Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        // check file name
        // check server
        // return object;

        var isExists = Random.Shared.Next(0, 3) switch
        {
            0 => (bool?)false,
            1 => true,
            _ => null
        };

        if (isExists is null)
        {
            var error = new ExecuteCommandexCommandException("ERROR");
            return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Error(error));
        }

        Result = new ValidateResult
        {
            IsExists = isExists.Value,
            Name = isExists.Value ? "True" : "False"
        };

        return Task.FromResult<OperationEmpty<ExecuteCommandexCommandException>>(Operation.Result());
    }

    public override bool IsPushToShellEnabled => true;
}
