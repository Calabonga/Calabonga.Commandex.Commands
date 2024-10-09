using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.ParameterOne.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.ParameterOne;

public class ParameterOneCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
        => services.AddScoped<ICommandexCommand, ParameterOneCommandexCommand>();
}
