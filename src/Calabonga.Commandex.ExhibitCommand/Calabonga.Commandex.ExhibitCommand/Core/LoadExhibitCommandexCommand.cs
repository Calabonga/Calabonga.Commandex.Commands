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
    public override async Task<OperationEmpty<ExecuteCommandexCommandException>> ExecuteCommandAsync()
    {
        Result = await ExecuteAsync();
        return Operation.Result();
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string Version => "1.0.0-rc.17.9.28"; //semver.org

    protected override Exhibit? Result { get; set; }

    public override string DisplayName => "Получение экспоната из Музея Юмора";

    public override string Description => "Запрос (HTTP) на удаленный API с целью получить экспонат одного из видов: анекдот, история, хокку, фразы и изречение, стишок и другие. Загруженные данные не отображаются, а отдаются на Shell.";

    public override bool IsPushToShellEnabled => true;

    private async Task<Exhibit?> ExecuteAsync()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.calabonga.com");
        var response = await client.GetAsync("/api3/v3/random");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Exhibit>(content, JsonSerializerOptionsExt.Cyrillic);
    }
}