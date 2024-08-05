using Calabonga.Commandex.Engine;
using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.OperationResults;
using System.Text.Json;

namespace Calabonga.Commandex.ExhibitCommand;

public class LoadExhibitCommandexCommand : EmptyCommandexCommand<Exhibit?>
{
    private readonly HttpClient _client = new();

    public LoadExhibitCommandexCommand() => _client.BaseAddress = new Uri("https://api.calabonga.com");

    public override OperationEmpty<OpenDialogException> ExecuteCommand()
    {
        Result = AsyncHelper.RunSync(ExecuteAsync);
        return Operation.Result();
    }

    public override string Version => "v1.0.0-beta.10";

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    protected override Exhibit? Result { get; set; }

    public override string DisplayName => "Получение экспоната из Музея Юмора";

    public override string Description => "Запрос на удаленный API с целью получить экспонат одного из видов: анекдот, история, хокку, фразы и изречение, стишок и другие. Загруженные данные не отображаются.";

    public override bool IsPushToShellEnabled => true;

    private async Task<Exhibit?> ExecuteAsync()
    {
        var response = await _client.GetAsync("/api3/v3/random");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Exhibit>(content, JsonSerializerOptionsExt.Cyrillic);
    }
}