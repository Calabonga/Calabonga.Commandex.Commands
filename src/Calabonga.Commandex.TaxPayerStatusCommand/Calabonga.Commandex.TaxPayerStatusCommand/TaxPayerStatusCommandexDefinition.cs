using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.Engine.NugetDependencies;
using Calabonga.Commandex.TaxPayerStatusCommand.Core;
using Calabonga.Commandex.TaxPayerStatusCommand.Core.Views;
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
        services.AddTransient<TaxPayerDialogView>();
        services.AddTransient<Core.ViewModels.TaxPayerDialogResult>();
        services.AddTransient<ICommandexCommand, TaxPayerStatusCommandexCommand>();
        services.AddTransient<INugetDependency, TaxPayerStatusCommandNugetDependency>();
    }
}

public class TaxPayerStatusCommandNugetDependency : INugetDependency
{
    public Type Type => typeof(TaxPayerStatusCommandexCommand);

    public List<NugetDependency> Dependencies => [
        new NugetDependency { Name = "Calabonga.TokenGeneratorCore", Version = "1.0.0" }
    ];
}