using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.ParameterTwo.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.ParameterTwo;

public class ParameterTwoCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, ParameterTwoCommandexCommand>();
    }
}