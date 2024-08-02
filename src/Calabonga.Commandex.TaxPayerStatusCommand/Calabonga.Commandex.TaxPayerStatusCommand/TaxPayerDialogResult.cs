using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using Calabonga.Commandex.Engine;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calabonga.Commandex.TaxPayerStatusCommand;

public partial class TaxPayerDialogResult : DefaultDialogResult
{
    private readonly HttpClient _client = new();

    public TaxPayerDialogResult()
    {
        _client.BaseAddress = new Uri("https://statusnpd.nalog.ru");
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ExecuteCheckCommand))]
    private string? _value;

    [ObservableProperty]
    private NalogResponse? _nalogResponse;

    public override string DialogTitle => "Проверка на nalog.ru";

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

}