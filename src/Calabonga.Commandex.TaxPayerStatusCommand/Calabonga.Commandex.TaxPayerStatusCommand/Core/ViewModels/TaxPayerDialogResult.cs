using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.Entities;
using Calabonga.Utils.TokenGeneratorCore;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace Calabonga.Commandex.TaxPayerStatusCommand.Core.ViewModels;

public partial class TaxPayerDialogResult : DefaultDialogResult
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

    /// <summary>
    /// // Calabonga: Summary required (IDialogResult 2024-08-02 10:09)
    /// </summary>
    public override ResizeMode ResizeMode => ResizeMode.NoResize;

    [RelayCommand(CanExecute = nameof(CanExecuteCheck))]
    private async Task ExecuteCheck()
    {
        var response = await _client.PostAsJsonAsync("/api/v1/tracker/taxpayer_status", new
        {
            inn = Value,
            requestDate = DateTime.UtcNow.ToString("yyyy-MM-dd")
        });

        Value = string.Empty;

        NalogResponse = await response.Content.ReadFromJsonAsync<NalogResponse>();
    }

    private bool CanExecuteCheck => !string.IsNullOrEmpty(Value) && Value.Length is >= 10 and <= 12;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public override void Dispose() => _client.Dispose();
}