using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.Input;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class Step1WizardViewModel : WizardStepViewModel
{
    public Step1WizardViewModel()
    {
        Title = "Step 1 - CanLeave:" + CanLeave;
        AddError("Error from Constructor");
    }

    [RelayCommand]
    private void AddErrorMessage()
    {
        AddError("Error");
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(CanLeave));

    }

    [RelayCommand]
    private void RemoveErrors()
    {
        ResetErrors();
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(CanLeave));
    }
}