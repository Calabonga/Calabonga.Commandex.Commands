﻿using Calabonga.Commandex.Engine.Wizards;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calabonga.Commandex.PersonWizardCommand.Core.WizardSteps;

public partial class Step3WizardViewModel : WizardStepValidationViewModel<PersonViewModel>
{
    public Step3WizardViewModel()
    {
        Title = "Step 3";
    }

    [Required]
    [MinLength(5)]
    [NotifyDataErrorInfo]
    [ObservableProperty]
    private string? _lastName;

    public override void OnEnter(PersonViewModel? payload)
    {
        LastName = payload?.LastName ?? string.Empty;
    }

    public override void OnLeave(PersonViewModel? payload)
    {
        if (payload != null)
        {
            payload.LastName = LastName;
        }
    }
}
