using System.Net.Http;
using System.Text.Json;
using Calabonga.Commandex.Engine;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calabonga.Commandex.QuizCommand;

public partial class QuizDialogResult : DefaultDialogResult
{
    private readonly HttpClient _client = new();

    public QuizDialogResult()
    {
        _client.BaseAddress = new Uri("https://quiz.calabonga.net/");
    }

    public override string DialogTitle => "Quiz Title";

    [ObservableProperty]
    private Question? _question;

    [RelayCommand]
    private async Task LoadQuestionAsync()
    {
        IsBusy = true;
        var cancellationTokenSource = new CancellationTokenSource();
        var response = await _client.GetAsync("/api/v1/questions/random", cancellationTokenSource.Token);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationTokenSource.Token);

        Question = JsonSerializer.Deserialize<Question>(content, JsonSerializerOptionsExt.Cyrillic);
        IsBusy = false;
    }
}