using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Processors.Results;
using Calabonga.Commandex.QuizCommand.Core.ViewModels;
using Calabonga.Commandex.QuizCommand.Core.Views;
using System.Text;
using System.Reflection;

namespace Calabonga.Commandex.QuizCommand.Core;

/// <summary>
/// Demo dialog command that loads a quiz question from a remote service and returns it as a ClipboardResult.
/// </summary>
public sealed class QuestionLoadedCommand : DialogCommandexCommand<QuizDialogView, QuizViewModel>
{
    public QuestionLoadedCommand(IDialogService dialogService) : base(dialogService) { }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Вопросы для викторины";

    public override string Description => "Загрузчик вопросов без возможности ответить со стороннего сервиса, но с возможностью показать загруженные данные.";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

    public override bool IsPushToShellEnabled => true;

    public override object GetResult()
    {
        var question = ((QuizViewModel)Result!).Question
                       ?? throw new InvalidOperationException("Question is not loaded.");

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Вопрос: {question.QuestionText}");
        stringBuilder.AppendLine($"Из категории: {question.CategoryName}");
        stringBuilder.AppendLine($"A: {question.AnswerA}");
        stringBuilder.AppendLine($"B: {question.AnswerB}");
        stringBuilder.AppendLine($"C: {question.AnswerC}");
        stringBuilder.AppendLine($"D: {question.AnswerD}");
        stringBuilder.AppendLine($"правильный вариант: {question.CorrectAnswer}");
        return new ClipboardResult(stringBuilder.ToString());
    }
}
