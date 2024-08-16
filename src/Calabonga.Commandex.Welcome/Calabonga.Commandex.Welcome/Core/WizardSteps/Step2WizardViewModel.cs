using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.Welcome.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calabonga.Commandex.Welcome.Core.WizardSteps;

public partial class Step2WizardViewModel : WizardStepValidationViewModel<PersonViewModel>
{
    public Step2WizardViewModel()
    {
        Title = "Step 2";
    }
    [Required]
    [MinLength(5)]
    [ObservableProperty]
    [NotifyDataErrorInfo]
    private string _middleName;

    public override void OnEnter(PersonViewModel? payload)
    {
        MiddleName = payload?.MiddleName ?? string.Empty;
    }

    public override void OnLeave(PersonViewModel? payload)
    {
        if (payload != null)
        {
            payload.MiddleName = MiddleName;
        }
    }
}