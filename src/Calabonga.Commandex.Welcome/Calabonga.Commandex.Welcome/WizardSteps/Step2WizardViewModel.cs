using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class Step2WizardViewModel : WizardStepViewModel<PersonViewModel>
{
    public Step2WizardViewModel()
    {
        Title = "Step 2";
    }

    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _middleName;

    public override bool CanGoBack => true;

    public override void Initialize(PersonViewModel payload)
    {
        FirstName = payload.FirstName;
        MiddleName = payload.MiddleName;
    }


}