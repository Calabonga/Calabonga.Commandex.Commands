using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.Entities;
using Calabonga.Utils.TokenGeneratorCore;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace Calabonga.Commandex.TaxPayerStatusCommand.Core.ViewModels;

public sealed partial class TaxPayerDialogResult : DefaultDialogResult
{
    private readonly HttpClient _client = new();

    public TaxPayerDialogResult()
    {
        _client.BaseAddress = new Uri("https://statusnpd.nalog.ru");
        Title = "Проверка на nalog.ru (code:" + TokenGenerator.Generate(6) + ")";
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ExecuteCheckCommand))]
    private string? _value;

    [ObservableProperty]
    private NalogResponse? _nalogResponse;

    public override ResizeMode ResizeMode => ResizeMode.NoResize;

    public override SizeToContent SizeToContent => SizeToContent.WidthAndHeight;


    [RelayCommand(CanExecute = nameof(CanExecuteCheck))]
    private async Task ExecuteCheck()
    {
        try
        {
            var response = await _client.PostAsJsonAsync("/api/v1/tracker/taxpayer_status", new { inn = Value, requestDate = DateTime.UtcNow.ToString("yyyy-MM-dd") });

            NalogResponse = await response.Content.ReadFromJsonAsync<NalogResponse>();
        }
        catch (OperationCanceledException)
        {
            NalogResponse = new NalogResponse() { Message = "Request was canceled." };
        }
        catch (Exception)
        {
            NalogResponse = new NalogResponse() { Message = "An error occurred while processing the request." };
        }
    }

    private bool CanExecuteCheck => !string.IsNullOrEmpty(Value) && Value.Length is >= 10 and <= 12;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public override void Dispose() => _client.Dispose();
}
