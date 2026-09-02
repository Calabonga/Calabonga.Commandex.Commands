using Calabonga.Commandex.Engine.Base;
using Calabonga.Commandex.HelloWorld.Core;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.HelloWorld;

public sealed class HelloWorldDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, HelloWorldCommandexCommand>();
    }
}