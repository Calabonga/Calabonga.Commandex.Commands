using Calabonga.Commandex.Engine.Base.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.QuizCommand.Core.Views;

namespace Calabonga.Commandex.QuizCommand.Core;

/// <summary>
/// // Calabonga: Summary required (QuestionLoadedCommand 2024-08-16 07:20)
/// </summary>
public class QuestionLoadedCommand : DialogCommandexCommand<QuizDialogView, ViewModels.QuizViewModel>
{
    public QuestionLoadedCommand(IDialogService dialogService) : base(dialogService) { }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Вопросы для виктарины";

    public override string Description => "Загрузчик вопросов без возможности ответить со стороннего сервиса, но с возможностью показать загруженные данные.";

    public override string Version => "v1.0.0-beta-16.0";
}