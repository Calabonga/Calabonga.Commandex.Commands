using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.Welcome.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.Welcome.Core.WizardSteps;

public partial class StepFinalViewModel : WizardStepViewModel<PersonViewModel>
{
    public StepFinalViewModel()
    {
        Title = "Final";
    }

    [ObservableProperty]
    private PersonViewModel _person;

    public override void OnEnter(PersonViewModel? payload) => Person = payload!;
}