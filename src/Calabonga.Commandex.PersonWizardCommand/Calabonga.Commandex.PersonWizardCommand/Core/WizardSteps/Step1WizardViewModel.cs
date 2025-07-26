using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calabonga.Commandex.PersonWizardCommand.Core.WizardSteps;

public partial class Step1WizardViewModel : WizardStepValidationViewModel<PersonViewModel>
{
    public Step1WizardViewModel()
    {
        Title = "Step 1 - HasErrors:" + HasErrors; ;
    }

    [Required]
    [MinLength(5)]
    [ObservableProperty]
    [NotifyDataErrorInfo]
    private string? _firstName;

    public override void OnEnter(PersonViewModel? payload)
    {
        FirstName = payload?.FirstName ?? string.Empty;
    }

    public override void OnLeave(PersonViewModel? payload)
    {
        if (payload != null)
        {
            payload.FirstName = FirstName;
        }
    }
}
