using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Processors.Results;
using Calabonga.Commandex.QuizCommand.Core.ViewModels;
using Calabonga.Commandex.QuizCommand.Core.Views;
using System.Text;

namespace Calabonga.Commandex.QuizCommand.Core;

/// <summary>
/// // Calabonga: Summary required (QuestionLoadedCommand 2024-08-16 07:20)
/// </summary>
public class QuestionLoadedCommand : DialogCommandexCommand<QuizDialogView, QuizViewModel>
{
    public QuestionLoadedCommand(IDialogService dialogService) : base(dialogService) { }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Вопросы для викторины";

    public override string Description => "Загрузчик вопросов без возможности ответить со стороннего сервиса, но с возможностью показать загруженные данные.";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.2.0";

    public override bool IsPushToShellEnabled => true;

    public override object GetResult()
    {
        var result = (QuizViewModel)Result!;
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Вопрос: {result.Question!.QuestionText}");
        stringBuilder.AppendLine($"Из категории: {result.Question!.CategoryName}");
        stringBuilder.AppendLine($"A: {result.Question!.AnswerA}");
        stringBuilder.AppendLine($"B: {result.Question!.AnswerB}");
        stringBuilder.AppendLine($"C: {result.Question!.AnswerC}");
        stringBuilder.AppendLine($"D: {result.Question!.AnswerD}");
        stringBuilder.AppendLine($"правильный вариант: {result.Question!.CorrectAnswer.ToString()}");
        return new ClipboardResult(stringBuilder.ToString());
    }
}
