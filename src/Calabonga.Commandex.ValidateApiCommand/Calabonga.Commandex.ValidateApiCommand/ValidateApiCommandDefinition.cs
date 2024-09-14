using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.ValidateApiCommand.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.ValidateApiCommand;

public class ValidateApiCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICommandexCommand, CheckApiReadyCommandexCommand>();
        services.AddTransient<ICommandexCommand, ValidateDocumentCommandexCommand>();
    }
}
