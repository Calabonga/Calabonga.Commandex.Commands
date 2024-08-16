﻿using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Welcome.Core;
using Calabonga.Commandex.Welcome.Core.Entities;
using Calabonga.Commandex.Welcome.Core.ViewModels;
using Calabonga.Commandex.Welcome.Core.WizardSteps;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;
using Step1WizardViewModel = Calabonga.Commandex.Welcome.Core.WizardSteps.Step1WizardViewModel;
using Step2WizardViewModel = Calabonga.Commandex.Welcome.Core.WizardSteps.Step2WizardViewModel;
using Step3WizardViewModel = Calabonga.Commandex.Welcome.Core.WizardSteps.Step3WizardViewModel;
using StepFinalViewModel = Calabonga.Commandex.Welcome.Core.WizardSteps.StepFinalViewModel;

namespace Calabonga.Commandex.Welcome;

public class WelcomeAppDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, WelcomeEmptyCommandexCommand>();
        services.AddScoped<ICommandexCommand, WelcomeResultCommandexCommand>();
        services.AddScoped<ICommandexCommand, PersonWizardDialogCommandexCommand>();

        services.AddWizard<PersonWizardDialogViewModel>();

        services.AddWizardStep<Step1, Step1WizardViewModel, PersonViewModel>("Шаг №1");
        services.AddWizardStep<Step2, Step2WizardViewModel, PersonViewModel>("Шаг №2");
        services.AddWizardStep<Step3, Step3WizardViewModel, PersonViewModel>("Шаг №3");
        services.AddWizardStep<StepFinal, StepFinalViewModel, PersonViewModel>("Итог");
    }
}