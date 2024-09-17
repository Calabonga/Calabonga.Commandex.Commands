using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.RelatedResultsCommand;

public class RelatedResultsCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICommandexCommand, FirstCommand>();
        services.AddTransient<ICommandexCommand, SecondCommand>();
        services.AddTransient<ICommandexCommand, ThirdCommand>();
    }
}