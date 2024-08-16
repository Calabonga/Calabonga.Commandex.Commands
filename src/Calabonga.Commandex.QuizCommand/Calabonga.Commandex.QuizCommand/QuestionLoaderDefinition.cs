using Calabonga.Commandex.Engine.Commands;
using Calabonga.Commandex.QuizCommand.Core;
using Calabonga.Commandex.QuizCommand.Core.Views;
using Calabonga.Wpf.AppDefinitions;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.Commandex.QuizCommand;

public class QuestionLoaderDefinition : AppDefinition
{
    /// <summary>
    /// Configure services for current application
    /// </summary>
    /// <param name="services">instance of <see cref="IServiceCollection"/></param>
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<QuizDialogView>();
        services.AddScoped<Core.ViewModels.QuizDialogResult>();
        services.AddScoped<ICommandexCommand, QuestionLoadedCommand>();
    }
}