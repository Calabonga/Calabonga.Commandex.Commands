using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.QuizCommand.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace Calabonga.Commandex.QuizCommand.Core.ViewModels;

public partial class QuizViewModel : DefaultViewModel
{
    private readonly HttpClient _client = new();

    public QuizViewModel()
    {
        _client.BaseAddress = new Uri("https://quiz.calabonga.net/");
        Title = "Загрузчик вопросов";
    }

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

    public override ResizeMode ResizeMode => ResizeMode.CanMinimize;

    public override SizeToContent SizeToContent => SizeToContent.WidthAndHeight;
}