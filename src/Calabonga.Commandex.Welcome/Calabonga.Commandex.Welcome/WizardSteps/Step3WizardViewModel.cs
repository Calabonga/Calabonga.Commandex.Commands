using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class Step3WizardViewModel : WizardStepViewModel<PersonViewModel>
{
    public Step3WizardViewModel()
    {
        Title = "Step 3";
    }

    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _middleName;

    [ObservableProperty]
    private string _lastName;

    public override void Initialize(PersonViewModel payload)
    {
        FirstName = payload.FirstName;
        MiddleName = payload.MiddleName;
        LastName = payload.LastName;
    }
}