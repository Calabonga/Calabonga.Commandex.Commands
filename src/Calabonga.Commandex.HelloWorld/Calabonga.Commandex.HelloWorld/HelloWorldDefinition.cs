using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.HelloWorld.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.HelloWorld;

public class HelloWorldDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICommandexCommand, HelloWorldCommandexCommand>();
    }
}