using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.PersonWizardCommand.Core.ViewModels;

namespace Calabonga.Commandex.PersonWizardCommand.Core;

public class PersonWizardDialogCommandexCommand : WizardDialogCommandexCommand<PersonWizardDialogViewModel>
{
    public PersonWizardDialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Person Wizard";

    public override string Description => "Получение данных Ф.И.О от пользователя с разбиением на страницы (шаги wizard) с валидацией ввода.";

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.0.0";

    protected override PersonWizardDialogViewModel SetResult(PersonWizardDialogViewModel result) => result;
}