using Calabonga.Commandex.Engine;
using Calabonga.Commandex.Engine.Commands;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.TaxPayerStatusCommand;

public class TaxPayerStatusCommandexDefinition : AppDefinition
{
    /// <summary>
    /// Configure services for current application
    /// </summary>
    /// <param name="services">instance of <see cref="IServiceCollection"/></param>
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<TaxPayerDialogView>();
        services.AddScoped<TaxPayerDialogResult>();
        services.AddScoped<ICommandexCommand, TaxPayerStatusCommand>();
        services.AddScoped<INugetDependency, TaxPayerStatusCommandNugetDependency>();
    }
}

public class TaxPayerStatusCommandNugetDependency : INugetDependency
{
    public Type Type => typeof(TaxPayerStatusCommand);

    public List<NugetDependency> Dependencies => [
        new NugetDependency { Name = "Calabonga.TokenGeneratorCore", Version = "1.0.0" }
    ];
}