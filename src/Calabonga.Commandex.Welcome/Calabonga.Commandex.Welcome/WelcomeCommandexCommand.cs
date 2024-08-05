using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;

namespace Calabonga.Commandex.Welcome;

public class WelcomeCommandexCommand : EmptyCommandexCommand<string>
{
    public override bool IsPushToShellEnabled => true;

    public override OperationEmpty<OpenDialogException> ExecuteCommand()
    {
        Result = $"Welcome from {nameof(WelcomeCommandexCommand)}";
        return Operation.Result();
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Добро пожаловать в модульность";

    public override string Description => "Это демонстрация по реализации команды для Commandex.";

    public override string Version => "1.0.0-beta.3";

    protected override string? Result { get; set; }
}