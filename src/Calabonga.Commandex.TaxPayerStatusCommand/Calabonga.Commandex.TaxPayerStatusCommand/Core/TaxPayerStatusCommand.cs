using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Processors.Results;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.ViewModels;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.Views;
using System.Text.Json;
using System.Reflection;

namespace Calabonga.Commandex.TaxPayerStatusCommand.Core;

public class TaxPayerStatusCommandexCommand : DialogCommandexCommand<TaxPayerDialogView, TaxPayerDialogResult>
{
    public TaxPayerStatusCommandexCommand(IDialogService dialogService) : base(dialogService) { }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Проверка статуса налогоплательщика";

    public override string Description => "Публичный сервиса ФНС России «Проверка статуса налогоплательщика налога на профессиональный доход (самозанятого)» (запрос на сайте nalog.ru)";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

    public override bool IsPushToShellEnabled => true;

    protected override TaxPayerDialogResult SetResult(TaxPayerDialogResult result) => new()
    {
        NalogResponse = result.NalogResponse
    };

    public override object GetResult()
    {
        var data = JsonSerializer.Serialize(Result, JsonSerializerOptionsExt.Cyrillic);
        return new TextFileResult("TaxPayer.txt", data);
    }
}
