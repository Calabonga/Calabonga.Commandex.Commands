using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.Input;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class Step1WizardViewModel : WizardStepViewModel
{
    public Step1WizardViewModel()
    {
        Title = "Step 1 - HasErrors:" + HasErrors;
        AddError("This is error from constructor");
    }

    [RelayCommand]
    private void AddErrorMessage()
    {
        AddError("Error" + DateTime.Now.ToString("G"));
    }

    [RelayCommand]
    private void RemoveErrors()
    {
        ResetErrors();
    }
}