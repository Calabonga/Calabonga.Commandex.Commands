using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.RelatedResultsCommand;

public sealed class RelatedResultsCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, FirstCommand>();
        services.AddScoped<ICommandexCommand, SecondCommand>();
        services.AddScoped<ICommandexCommand, ThirdCommand>();
    }
}