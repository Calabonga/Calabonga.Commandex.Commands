﻿using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Engine.NugetDependencies;
using Calabonga.Commandex.PersonWizardCommand.Core;
using Calabonga.Commandex.PersonWizardCommand.Core.Entities;
using Calabonga.Commandex.PersonWizardCommand.Core.ViewModels;
using Calabonga.Commandex.PersonWizardCommand.Core.WizardSteps;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.PersonWizardCommand;

public class WizardCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, PersonWizardDialogCommandexCommand>();
        services.AddTransient<INugetDependency, PersonWizardDialogCommandexCommandNugetDependency>();

        services.AddWizard<PersonWizardDialogViewModel>();

        services.AddWizardStep<Step1, Step1WizardViewModel, PersonViewModel>("Шаг №1");
        services.AddWizardStep<Step2, Step2WizardViewModel, PersonViewModel>("Шаг №2");
        services.AddWizardStep<Step3, Step3WizardViewModel, PersonViewModel>("Шаг №3");
        services.AddWizardStep<StepFinal, StepFinalViewModel, PersonViewModel>("Итог");
    }
}


public class PersonWizardDialogCommandexCommandNugetDependency : INugetDependency
{
    public Type Type => typeof(PersonWizardDialogCommandexCommand);

    public List<NugetDependency> Dependencies => [
        new NugetDependency() { Name = "Calabonga.Utils.SymbolrCore", Version = "3.0.0" }
    ];
}
