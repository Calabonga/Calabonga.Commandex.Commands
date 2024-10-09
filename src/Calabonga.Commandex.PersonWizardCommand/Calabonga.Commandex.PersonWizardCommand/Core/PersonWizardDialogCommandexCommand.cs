using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Processors.Results;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using Calabonga.Commandex.PersonWizardCommand.Core.ViewModels;
using Calabonga.Utils.SymbolrCore;
using System.Text.Json;

namespace Calabonga.Commandex.PersonWizardCommand.Core;

public class PersonWizardDialogCommandexCommand : WizardDialogCommandexCommand<PersonWizardDialogViewModel>
{
    public PersonWizardDialogCommandexCommand(IDialogService dialogService) : base(dialogService)
    {
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Person Wizard";

    public override string Description => "Получение данных Ф.И.О от пользователя с разбиением на страницы (шаги wizard) с валидацией ввода.";

    public override bool IsPushToShellEnabled => true;

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => "1.2.0";

    protected override PersonWizardDialogViewModel SetResult(PersonWizardDialogViewModel result) => result;

    public override object? GetResult()
    {
        var payload = Result?.Payload;

        if (payload is null)
        {
            return new TextFileResult("error.txt", "person is null");
        }

        var person = (PersonViewModel)payload;

        var data = JsonSerializer.Serialize(person, JsonSerializerOptionsExt.Cyrillic );
        var fileName = Transliterator.Run(person.LastName, SpaceReplace.Underscore, TransformMode.Url);
        return new TextFileResult(fileName, data);
    }
}
