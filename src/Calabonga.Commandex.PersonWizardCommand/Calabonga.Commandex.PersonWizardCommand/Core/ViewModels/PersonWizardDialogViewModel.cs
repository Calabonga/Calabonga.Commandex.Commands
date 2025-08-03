using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Windows;

namespace Calabonga.Commandex.PersonWizardCommand.Core.ViewModels;

/// <summary>
/// Person ViewModel Wizard Commandex Command
/// </summary>
public sealed class PersonWizardDialogViewModel : WizardDialogViewModel<PersonViewModel>
{
    private readonly ILogger<PersonWizardDialogViewModel> _logger;

    public PersonWizardDialogViewModel(
        ILogger<PersonWizardDialogViewModel> logger,
        IWizardManager<PersonViewModel> manager) : base(manager)
    {
        _logger = logger;
        Title = "Person data wizard";
    }

    protected override PersonViewModel InitializeContext()
    {
        return new PersonViewModel();
    }

    protected override void OnWizardFinishedExecute(PersonViewModel? payload)
    {
        if (payload is null)
        {
            _logger.LogInformation("Payload is null");

            return;
        }

        _logger.LogInformation(JsonSerializer.Serialize(payload, JsonSerializerOptionsExt.Cyrillic));
    }

    public override ResizeMode ResizeMode => ResizeMode.CanResize;

    public override WindowStyle WindowStyle => WindowStyle.SingleBorderWindow;

    public override SizeToContent SizeToContent => SizeToContent.WidthAndHeight;
}
