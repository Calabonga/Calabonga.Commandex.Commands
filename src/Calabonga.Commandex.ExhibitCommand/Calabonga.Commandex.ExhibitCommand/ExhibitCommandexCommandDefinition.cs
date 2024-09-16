using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.ExhibitCommand.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.ExhibitCommand;

public class ExhibitCommandexCommandDefinition : AppDefinition
{
    /// <summary>
    /// Configure services for current application
    /// </summary>
    /// <param name="services">instance of <see cref="IServiceCollection"/></param>
    public override void ConfigureServices(IServiceCollection services)
        => services.AddScoped<ICommandexCommand, LoadExhibitCommandexCommand>();
}