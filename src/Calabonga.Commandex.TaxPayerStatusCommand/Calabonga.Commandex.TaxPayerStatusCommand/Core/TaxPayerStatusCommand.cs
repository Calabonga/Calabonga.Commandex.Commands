using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.ViewModels;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.Views;

namespace Calabonga.Commandex.TaxPayerStatusCommand.Core;

public class TaxPayerStatusCommandexCommand : DialogCommandexCommand<TaxPayerDialogView, TaxPayerDialogResult>
{
    public TaxPayerStatusCommandexCommand(IDialogService dialogService) : base(dialogService) { }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Проверка статуса налогоплательщика";

    public override string Description => "Публичный сервиса ФНС России «Проверка статуса налогоплательщика налога на профессиональный доход (самозанятого)» (запрос на сайте nalog.ru)";

    public override string Version => "1.0.0-rc.17.9.28"; //semver.org

    public override bool IsPushToShellEnabled => true;

    protected override TaxPayerDialogResult SetResult(TaxPayerDialogResult result) => new()
    {
        NalogResponse = result.NalogResponse,
    };
}