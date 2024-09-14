using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.Welcome.Core;
using Calabonga.Commandex.Welcome.Core.Settings;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.Welcome;

public class WelcomeCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, WelcomeEmptyCommandexCommand>();
        services.AddScoped<ICommandexCommand, WelcomeResultCommandexCommand>();

        services.AddKeyedTransient<CurrentAppSettings>(nameof(WelcomeCommandDefinition));
    }
}