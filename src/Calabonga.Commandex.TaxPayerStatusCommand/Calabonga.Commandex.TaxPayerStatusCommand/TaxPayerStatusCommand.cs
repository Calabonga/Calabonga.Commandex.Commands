using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;

namespace Calabonga.Commandex.TaxPayerStatusCommand;

public class TaxPayerStatusCommand : DialogCommandexCommand<TaxPayerDialogView, TaxPayerDialogResult>
{
    public TaxPayerStatusCommand(IDialogService dialogService) : base(dialogService) { }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Проверка статуса налогоплательщика";

    public override string Description => "Публичный сервиса ФНС России «Проверка статуса налогоплательщика налога на профессиональный доход (самозанятого)»";

    public override string Version => "v1.0.0-beta.7";

    public override bool IsPushToShellEnabled => true;

    protected override TaxPayerDialogResult SetResult(TaxPayerDialogResult result) => new()
    {
        NalogResponse = result.NalogResponse,
    };
}