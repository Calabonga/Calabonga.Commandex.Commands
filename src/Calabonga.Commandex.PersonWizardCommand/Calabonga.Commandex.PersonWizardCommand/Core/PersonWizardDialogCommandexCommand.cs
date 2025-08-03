using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Dialogs;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using Calabonga.Commandex.PersonWizardCommand.Core.ViewModels;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace Calabonga.Commandex.PersonWizardCommand.Core;

public class PersonWizardDialogCommandexCommand : WizardDialogCommandexCommand<PersonWizardDialogViewModel>
{
    private readonly ILogger<PersonWizardDialogCommandexCommand> _logger;

    public PersonWizardDialogCommandexCommand(
        ILogger<PersonWizardDialogCommandexCommand> logger,
        IDialogService dialogService) : base(dialogService)
    {
        _logger = logger;
    }

    public override string CopyrightInfo => "Calabonga SOFT © 2024";

    public override string DisplayName => "Person Wizard";

    public override string Description => "Register user FirstName, MiddleName and LastName";

    public override bool IsPushToShellEnabled => true;

    /// <summary>
    /// semver.org principle used
    /// </summary>
    public override string Version => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A";

    protected override PersonWizardDialogViewModel SetResult(PersonWizardDialogViewModel result) => result;

    public override object? GetResult()
    {
        var payload = Result?.Payload;

        if (payload is not PersonViewModel person)
        {
            return null;
        }

        try
        {
            var data = JsonSerializer.Serialize(person, JsonSerializerOptionsExt.Cyrillic);
            _logger.LogInformation(data);

            return data;
        }
        catch
        {
            return null;
        }
    }
}
