using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Calabonga.Commandex.ZoneCommand.Core;
using Calabonga.Commandex.ZoneCommand.Core.ViewModels;
using Calabonga.Commandex.ZoneCommand.Core.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.ZoneCommand;

public sealed class ZoneCommandCommandexCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, ZoneCommandCommandexCommand>();
        services.AddScoped<ZoneCommandView>();
        services.AddScoped<ZoneCommandViewModel>();
    }
}
