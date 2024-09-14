using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Calabonga.Commandex.PersonWizardCommand.Core.ViewModels;

/// <summary>
/// // Calabonga: Summary required (PersonWizardDialogViewModel 2024-08-13 11:45)
/// </summary>
public class PersonWizardDialogViewModel : WizardDialogViewModel<PersonViewModel>
{
    private readonly ILogger<PersonWizardDialogViewModel> _logger;

    public PersonWizardDialogViewModel(
        ILogger<PersonWizardDialogViewModel> logger,
        IWizardManager<PersonViewModel> manager) : base(manager)
    {
        _logger = logger;
        Title = "Демонстрация Wizard";
    }

    protected override PersonViewModel InitializeContext() => new();

    protected override void OnWizardFinishedExecute(PersonViewModel? payload)
    {
        if (payload is null)
        {
            _logger.LogInformation("Payload is null");
            return;
        }

        _logger.LogInformation(JsonSerializer.Serialize(payload, JsonSerializerOptionsExt.Cyrillic));
    }
}