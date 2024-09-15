using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Exceptions;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.ExhibitCommand.Core.Entities;
using Calabonga.OperationResults;
using System.Text.Json;

namespace Calabonga.Commandex.ExhibitCommand.Core;

/// <summary>
/// Loader items from www.calabonga.com
/// </summary>
public class LoadExhibitCommandexCommand : ResultCommandexCommand<Exhibit?>
{
    private readonly HttpClient _client = new();

    public LoadExhibitCommandexCommand() => _client.BaseAddress = new Uri("https://api.calabonga.com");

    public override string Version => "v1.0.0-beta.15.0";

    public override async Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        Result = await ExecuteAsync();
        return Operation.Result();
    }

    public override string[] Tags => ["httpclient", "calabonga.com"];

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

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public override void Dispose() => _client.Dispose();
}