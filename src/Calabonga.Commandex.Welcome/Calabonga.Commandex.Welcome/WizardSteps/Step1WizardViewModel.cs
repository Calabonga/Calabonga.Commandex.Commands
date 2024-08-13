using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class Step1WizardViewModel : WizardStepViewModel<PersonViewModel>
{
    public Step1WizardViewModel()
    {
        Title = "Step 1 - HasErrors:" + HasErrors;
        AddError("This is error from constructor");
    }

    [ObservableProperty]
    private string _firstName;

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

    public override void OnEnter(PersonViewModel payload)
    {
        FirstName = payload.FirstName;
    }

    public override void OnLeave(PersonViewModel payload)
    {
        payload.FirstName = FirstName;
    }
}