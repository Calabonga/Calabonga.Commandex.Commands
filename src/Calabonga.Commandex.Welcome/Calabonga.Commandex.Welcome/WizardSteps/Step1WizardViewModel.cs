using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.Input;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class Step1WizardViewModel : WizardStepViewModel
{
    public Step1WizardViewModel()
    {
        Title = "Step 1 - HasErrors:" + HasErrors;
        AddError("Error from Constructor");
    }

    [RelayCommand]
    private void AddErrorMessage()
    {
        AddError("Error");

    }

    [RelayCommand]
    private void RemoveErrors()
    {
        ResetErrors();
    }
}