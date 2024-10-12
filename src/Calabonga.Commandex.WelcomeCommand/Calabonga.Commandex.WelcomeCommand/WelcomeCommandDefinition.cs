using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.WelcomeCommand.Core;
using Calabonga.Commandex.WelcomeCommand.Core.Settings;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.WelcomeCommand;

/// <summary>
/// Definition command
/// </summary>
public class WelcomeCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, WelcomeEmptyCommandexCommand>();
        services.AddScoped<ICommandexCommand, WelcomeResultCommandexCommand>();

        services.AddKeyedTransient<CurrentAppSettings>(nameof(WelcomeCommandDefinition));
    }
}
