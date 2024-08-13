using Calabonga.Commandex.Engine.Wizards;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Welcome.WizardSteps;

public partial class StepFinalViewModel : WizardStepViewModel<PersonViewModel>
{
    public StepFinalViewModel()
    {
        Title = "Thank you!";
    }

    [ObservableProperty]
    private PersonViewModel _person;

    public override void OnEnter(PersonViewModel payload) => Person = payload;
}