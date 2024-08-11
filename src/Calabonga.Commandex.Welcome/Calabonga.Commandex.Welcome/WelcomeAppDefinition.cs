using Calabonga.Commandex.Engine.Commands;
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
        services.AddScoped<DemoWizardDialogResult>();
    }
}