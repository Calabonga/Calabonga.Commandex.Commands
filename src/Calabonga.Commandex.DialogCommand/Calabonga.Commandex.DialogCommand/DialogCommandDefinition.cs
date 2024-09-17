using Calabonga.Commandex.DialogCommand.Core;
using Calabonga.Commandex.DialogCommand.Core.ViewModels;
using Calabonga.Commandex.DialogCommand.Core.Views;
using Calabonga.Commandex.Engine.Base;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.DialogCommand;

public class DialogCommandDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICommandexCommand, DialogCommandexCommand>();
        services.AddScoped<DemoDialogResult>();
        services.AddScoped<DemoDialogView>();
    }
}