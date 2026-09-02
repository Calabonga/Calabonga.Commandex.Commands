using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.ValidateApiCommand.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.ValidateApiCommand;

public sealed class ValidateApiCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, CheckApiReadyCommandexCommand>();
        services.AddScoped<ICommandexCommand, ValidateDocumentCommandexCommand>();
    }
}
