using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Calabonga.ZoneCommandexCommand.Core;
using Calabonga.ZoneCommandexCommand.Core.ViewModels;
using Calabonga.ZoneCommandexCommand.Core.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.ZoneCommandexCommand;

public class ZoneCommandCommandexCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, ZoneCommandCommandexCommand>();
        services.AddScoped<ZoneCommandView>();
        services.AddScoped<ZoneCommandViewModel>();
    }
}
