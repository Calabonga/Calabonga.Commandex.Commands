﻿using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calabonga.Commandex.PersonWizardCommand.Core.WizardSteps;

public partial class StepFinalViewModel : WizardStepViewModel<PersonViewModel>
{
    public StepFinalViewModel()
    {
        Title = "Final";
    }

    [ObservableProperty]
    private PersonViewModel? _person;

    public override void OnEnter(PersonViewModel? payload) => Person = payload!;
}
