using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Engine.Extensions;
using Calabonga.Commandex.Welcome.WizardSteps;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.Welcome;

public class WelcomeAppDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, WelcomeEmptyCommandexCommand>();
        services.AddScoped<ICommandexCommand, WelcomeResultCommandexCommand>();
        services.AddScoped<ICommandexCommand, DemoWizardDialogCommandexCommand>();

        services.AddWizard<DemoWizardViewModel>();

        services.AddWizardStep<Step1, Step1WizardViewModel>("Шаг №1");
        services.AddWizardStep<Step2, Step2WizardViewModel>("Шаг №2");
        services.AddWizardStep<Step3, Step3WizardViewModel>("Шаг №3");
    }
}